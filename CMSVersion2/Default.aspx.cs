using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;
using System.Data;

namespace CMSVersion2
{
    public partial class _Default : Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //bool check = HttpContext.Current.User.Identity.IsAuthenticated;
            //if (check == false)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            if (!IsPostBack)
            {
                Date.SelectedDate = DateTime.Now.AddDays(-30);
                DateTo.SelectedDate = DateTime.Now;

                WtDateFrom.SelectedDate = DateTime.Now.AddDays(-30);
                WtDateTo.SelectedDate = DateTime.Now;

                LoadBranchCorpOffice();
            }

            //CHECK IF ALL  > QTY
            if (BCO.SelectedItem.Text == "All")
            {
                QtybyCommodityTypeChart.PlotArea.XAxis.TitleAppearance.Text = "BCO";
            }
            else { QtybyCommodityTypeChart.PlotArea.XAxis.TitleAppearance.Text = "City"; }

            //CHECK IF ALL > WT
            if (WtBCO.SelectedItem.Text == "All")
            {
                WtbyCommodityTypeChart.PlotArea.XAxis.TitleAppearance.Text = "BCO";
            }
            else { WtbyCommodityTypeChart.PlotArea.XAxis.TitleAppearance.Text = "City"; }

            //LOAD TOP DASHBOARD
            setTopDashboard();

        }

        private void LoadBranchCorpOffice()
        {
            BCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            BCO.DataValueField = "BranchCorpOfficeId";
            BCO.DataTextField = "BranchCorpOfficeName";
            BCO.DataBind();

            WtBCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            WtBCO.DataValueField = "BranchCorpOfficeId";
            WtBCO.DataTextField = "BranchCorpOfficeName";
            WtBCO.DataBind();
        }

        private void setTopDashboard()
        {
            ///AWB PENDING
            DataSet dt1 = BLL.Dashboard.GetAWBPendingCount(getConstr.ConStrCMS);
            txtAwbPending.Text = dt1.Tables[0].Rows[0]["cnt"].ToString();
           
            //DISTRIBUTED
            DataSet dt2 = BLL.Dashboard.GetDistributed(getConstr.ConStrCMS);
            txtDistributed.Text = dt2.Tables[0].Rows[0]["cnt"].ToString();
            //DELIVERED
            DataSet dt3 = BLL.Dashboard.GetDelivered(getConstr.ConStrCMS);
            txtDelivered.Text = dt3.Tables[0].Rows[0]["cnt"].ToString();
            //PAID
            DataSet dt4 = BLL.Dashboard.GetPaid(getConstr.ConStrCMS);
            txtPaid.Text = dt4.Tables[0].Rows[0]["cnt"].ToString();

            //UNPAID
            DataSet dt5 = BLL.Dashboard.GetUnpaid(getConstr.ConStrCMS);
            txtUnpaid.Text = dt5.Tables[0].Rows[0]["cnt"].ToString();

            //PICKED UP
            DataSet dt6 = BLL.Dashboard.GetAWBPickedUp(getConstr.ConStrCMS);
            txtPickup.Text = dt5.Tables[0].Rows[0]["cnt"].ToString();


        }

        public DataSet getQtybyCommodity()
        {
            string bcoid = "";
            DateTime DateFromStr = new DateTime();
            DateTime DateToStr = new DateTime();
            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                //BCO
                if (BCO.SelectedItem.Text == "All")
                {
                    string bco = "";
                    DataSet data1 = BLL.Report.FLM_Qtyby_Commodity.GetQtybyCommodityAll(getConstr.ConStrCMS, DateFromStr, DateToStr, bco);
                    return data1;
                }
                else
                {
                    bcoid = BCO.SelectedItem.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DataSet data = BLL.Report.FLM_Qtyby_Commodity.GetQtybyCommodity(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid);
            return data;
        }

        public DataSet getWtbyCommodity()
        {
            string bcoid = "";
            DateTime DateFromStr = new DateTime();
            DateTime DateToStr = new DateTime();
            try
            {

                DateFromStr = WtDateFrom.SelectedDate.Value;
                DateToStr = WtDateTo.SelectedDate.Value;

                //BCO
                if (WtBCO.SelectedItem.Text == "All")
                {
                    string bco = "";
                    DataSet data1 = BLL.Report.FLM_Qtyby_Commodity.GetWtbyCommodityAll(getConstr.ConStrCMS, DateFromStr, DateToStr, bco);
                    return data1;
                }
                else
                {
                    bcoid = WtBCO.SelectedItem.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.FLM_Qtyby_Commodity.GetWtbyCommodity(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid);
            return data;
        }

        protected void WtbyCommodityTypeChart_Load(object sender, EventArgs e)
        {
            DataSet myDS = getWtbyCommodity();
            WtbyCommodityTypeChart.DataSource = myDS;
            WtbyCommodityTypeChart.DataBind();
            WtbyCommodityTypeChart.PlotArea.XAxis.DataLabelsField = "CityName";
        }

        protected void QtybyCommodityTypeChart_Load(object sender, EventArgs e)
        {
            DataSet myDS = getQtybyCommodity();
            QtybyCommodityTypeChart.DataSource = myDS;
            QtybyCommodityTypeChart.DataBind();
            QtybyCommodityTypeChart.PlotArea.XAxis.DataLabelsField = "CityName";
        }

        protected void QtybyCommodityTypeChart_PreRender(object sender, EventArgs e)
        {
            DataSet myDS = getQtybyCommodity();
            QtybyCommodityTypeChart.DataSource = myDS;
            QtybyCommodityTypeChart.DataBind();
            QtybyCommodityTypeChart.PlotArea.XAxis.DataLabelsField = "CityName";
        }
    }
}