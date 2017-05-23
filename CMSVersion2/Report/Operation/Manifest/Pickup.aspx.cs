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
    public partial class Pickup : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Area.DataSource = getArea();
                Area.DataTextField = "RevenueUnitName";
                Area.DataValueField = "RevenueUnitName";
                Area.DataBind();

                Checker.DataSource = getEmployee();
                Checker.DataTextField = "EmployeeName";
                Checker.DataValueField = "EmployeeName";
                Checker.DataBind();
                Checker.SelectedIndex = 0;
                setAWB();

                Date.SelectedDate = DateTime.Now;
            }
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getEmployee()
        {
            DataSet data = BLL.Employee_Info.GetEmployeeNames(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public void setAWB()
        {
            AWB.DataSource = getPickUpCargoData();
            AWB.DataTextField = "AWBNO";
            AWB.DataValueField = "AWBNO";
            AWB.DataBind();
        }

        public DataTable getArea()
        {
            string bco = "All";
            try
            {
                bco = BCO.SelectedValue;
            }
            catch (Exception) { }
            DataSet data = BLL.Revenue_Info.GetRevenueByBCOCode(getConstr.ConStrCMS, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getPickUpCargoData()
        {
            string AreaStr = "All";
            string AWBStr = "";
            string DateStr = "";
            string BCOStr = "All";
            string CheckerStr = "";
            try
            {

                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
                BCOStr = BCO.SelectedItem.Text;
                AreaStr = Area.SelectedItem.Text.ToString();
                AWBStr = AWB.Text.ToString();
                CheckerStr = Checker.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {
                //DateStr = "";
            }
            DataSet data = BLL.Report.PickupCargoManifestReport.GetPickupCargoManifest(getConstr.ConStrCMS, AreaStr, AWBStr, DateStr, BCOStr , CheckerStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            
            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "PickUpCargo";
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = BCOStr;
            ReportGlobalModel.Area = AreaStr;
            //ReportGlobalModel.Driver = "All"; //getColumn.get_Column_DataView(dt, "DRIVER");
            ReportGlobalModel.Checker = CheckerStr;

            return dt;
        }


        protected void gridPickupCargo_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getPickUpCargoData();

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("DATE === > " + Date.SelectedDate);
            gridPickupCargo.DataSource = getPickUpCargoData();
            gridPickupCargo.Rebind();
            setAWB();
        }

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            //gridPickupCargo.MasterTableView.GetColumn("CREATEDDATE").Visible = false;
            gridPickupCargo.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Area.Text = "";
            Area.Items.Clear();
            Area.AppendDataBoundItems = true;
            Area.Items.Add("All");
            Area.SelectedIndex = 0;
            Area.DataSource = getArea();
            Area.DataTextField = "RevenueUnitName";
            Area.DataValueField = "RevenueUnitName";
            Area.DataBind();
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