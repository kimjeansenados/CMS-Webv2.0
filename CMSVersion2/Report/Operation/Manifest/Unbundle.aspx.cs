using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Unbundle : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Date.SelectedDate = DateTime.Now;

                SackNumber.DataSource = getBundleNumber();
                SackNumber.DataTextField = "SackNo";
                SackNumber.DataValueField = "SackNo";
                SackNumber.DataBind();
                SackNumber.SelectedIndex = 0;

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                //Origin.DataSource = getCity();
                //Origin.DataTextField = "CityName";
                //Origin.DataValueField = "CityName";
                //Origin.DataBind();

            }
        }

        public DataTable getBundleNumber()
        {
            DataSet data = BLL.Report.BundleReport.GetBundleNumber(getConstr.ConStrCMS, Date.SelectedDate.Value.ToString("dd MMM yyyy"));
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getCity()
        {
            string bco = "All";
            try
            {
                bco = BCO.SelectedValue;
            }
            catch (Exception) { }
            DataSet data = BLL.City.GetCityByBCO(getConstr.ConStrCMS, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getUnbundle()
        {
            string DateStr = "";
            string SackNoStr = "";
            string BCOStr = "All";
            try
            {
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
                BCOStr = BCO.SelectedValue;
                SackNoStr = SackNumber.SelectedItem.Text.ToString();
               
                //OriginStr = Origin.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {
                //DateStr = "";
            }
            DataSet data = BLL.Report.UnbundleReport.GetBundle(getConstr.ConStrCMS, DateStr, SackNoStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();

            DateStr = (DateStr == null) ? "All" : DateStr;
            SackNoStr = (SackNoStr == null) ? "All" : SackNoStr;
            //OriginStr = (OriginStr == null) ? "All" : OriginStr;

            ReportGlobalModel.Report = "Unbundle";
            ReportGlobalModel.table1 = dt;

            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.SackNo = SackNoStr;
            ReportGlobalModel.Origin = BCOStr;
            
            return dt;
        }

        protected void grid_Unbundle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Unbundle.DataSource = getUnbundle();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Unbundle.DataSource = getUnbundle();
            grid_Unbundle.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //Origin.Text = "";
            //Origin.Items.Clear();
            //Origin.AppendDataBoundItems = true;
            //Origin.Items.Add("All");
            //Origin.SelectedIndex = 0;
            //Origin.DataSource = getCity();
            //Origin.DataTextField = "CityName";
            //Origin.DataValueField = "CityName";
            //Origin.DataBind();
        }

        protected void grid_Unbundle_PreRender(object sender, EventArgs e)
        {
            grid_Unbundle.Rebind();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            SackNumber.Text = "";
            SackNumber.Items.Clear();
            SackNumber.DataSource = getBundleNumber();
            SackNumber.DataTextField = "SackNo";
            SackNumber.DataValueField = "SackNo";
            SackNumber.DataBind();
            SackNumber.SelectedIndex = 0;
        }
    }
}