using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class DailyTrip : System.Web.UI.Page
    {
        public static int checker = 0;
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Area.DataSource = getCityBCO();
                Area.DataTextField = "CityName";
                Area.DataValueField = "CityName";
                Area.DataBind();
            }
        }

        public DataTable getCityBCO()
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

        public DataTable getDailyTripData()
        {
            string DateStr = "";
            string BCOStr = "All";
            string AreaStr = "All";
            try
            {
                BCOStr = BCO.SelectedItem.Text;
                AreaStr = Area.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }
            DataSet data = BLL.Report.DailyTripReport.GetDailyTrip(getConstr.ConStrCMS, DateStr, AreaStr, BCOStr);
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

        protected void grid_DailyTripReport_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_DailyTripReport.DataSource = getDailyTripData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_DailyTripReport.DataSource = getDailyTripData();
            grid_DailyTripReport.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Area.Text = "";
            Area.Items.Clear();
            Area.AppendDataBoundItems = true;
            Area.Items.Add("All");
            Area.SelectedIndex = 0;
            Area.DataSource = getCityBCO();
            Area.DataTextField = "CityName";
            Area.DataValueField = "CityName";
            Area.DataBind();
        }

        protected void grid_DailyTripReport_PreRender(object sender, EventArgs e)
        {
            grid_DailyTripReport.Rebind();
        }
    }
}