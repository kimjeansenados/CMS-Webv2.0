using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Segregation : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataView view = new DataView(getSegregationData());
                DataTable distinctValuesDriver = view.ToTable(true, "Driver");
                Driver.DataSource = distinctValuesDriver;
                Driver.DataTextField = "Driver";
                Driver.DataValueField = "Driver";
                Driver.DataBind();
                DataTable distinctValuesChecker = view.ToTable(true, "Checker");
                Checker.DataSource = distinctValuesChecker;
                Checker.DataTextField = "Checker";
                Checker.DataValueField = "Checker";
                Checker.DataBind();

                PlateNo.DataSource = getSegregationData();
                PlateNo.DataTextField = "PlateNo";
                PlateNo.DataValueField = "PlateNo";
                PlateNo.DataBind();

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Destination.DataSource = getCityBCO();
                Destination.DataTextField = "CityName";
                Destination.DataValueField = "CityName";
                Destination.DataBind();

                Date.SelectedDate = DateTime.Now;
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

        public DataTable getBranchCorpOffice()
        {

            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getSegregationData()
        {
            string DateStr = "";
            string DriverStr = "All";
            string CheckerStr = "All";
            string PlateNoStr = "All";
            string BCOStr = "All";
            string CityStr = "All";
            try
            {
                DriverStr = Driver.SelectedItem.Text.ToString();
                CheckerStr = Checker.SelectedItem.Text.ToString();
                PlateNoStr = PlateNo.SelectedItem.Text.ToString();
                BCOStr = BCO.SelectedItem.Text.ToString();
                CityStr = Destination.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }
            DataSet data = BLL.Report.SegregationReport.GetSegregation(getConstr.ConStrCMS, DateStr, DriverStr, CheckerStr, PlateNoStr, BCOStr, CityStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];


            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();

            DateStr = (DateStr == null) ? "All" : DateStr;
            DriverStr = (DriverStr == null) ? "All" : DriverStr;
            CheckerStr = (CheckerStr == null) ? "All" : CheckerStr;
            PlateNoStr = (PlateNoStr == null) ? "All" : PlateNoStr;

            ReportGlobalModel.Report = "Segregation";
            ReportGlobalModel.table1 = dt;

            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.Driver = DriverStr;
            ReportGlobalModel.Checker = CheckerStr;
            ReportGlobalModel.PlateNo = PlateNoStr;


            return dt;
        }

        protected void grid_Segregation_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Segregation.DataSource = getSegregationData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Segregation.DataSource = getSegregationData();
            grid_Segregation.Rebind();
        }

        protected void grid_Segregation_PreRender(object sender, EventArgs e)
        {
            grid_Segregation.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Destination.Text = "";
            Destination.Items.Clear();
            Destination.AppendDataBoundItems = true;
            Destination.Items.Add("All");
            Destination.SelectedIndex = 0;
            Destination.DataSource = getCityBCO();
            Destination.DataTextField = "CityName";
            Destination.DataValueField = "CityName";
            Destination.DataBind();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}