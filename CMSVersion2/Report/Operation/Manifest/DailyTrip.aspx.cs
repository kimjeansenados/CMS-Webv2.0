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
    public partial class DailyTrip : System.Web.UI.Page
    {
        public static int checker = 0;
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

            }
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

        //public DataTable getCityBCO()
        //{
        //    string bco = "All";
        //    try
        //    {
        //        bco = BCO.SelectedValue;
        //    }
        //    catch (Exception) { }
        //    DataSet data = BLL.City.GetCityByBCO(getConstr.ConStrCMS, bco);
        //    DataTable dt = new DataTable();
        //    dt = data.Tables[0];
        //    return dt;
        //}

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DateStr = "";
            }
            DataSet data = BLL.Report.DailyTripReport.GetDailyTrip(getConstr.ConStrCMS, DateStr, AreaStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            
            //PRINT
            DataView view = new DataView(dt);

            view.RowFilter = String.Format("PaymentModeName = '{0}'", "PP-PrePaid");
            ReportGlobalModel.table1 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "CAS-Coporate Account Shipper");
            ReportGlobalModel.table3 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "FC-Freight Collect");
            ReportGlobalModel.table2 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "CAC-Corporate Account Consignee");
            ReportGlobalModel.table4 = view.ToTable();

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            DateStr = (DateStr == null) ? "All" : DateStr;
            AreaStr = (AreaStr == null) ? "All" : AreaStr;

            ReportGlobalModel.Report = "DailyTrip";
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.Area = AreaStr;
            ReportGlobalModel.Driver = getColumn.get_Column_DataView(dt, "Driver");
            ReportGlobalModel.Checker = getColumn.get_Column_DataView(dt, "Checker");
            ReportGlobalModel.PlateNo = getColumn.get_Column_DataView(dt, "PlateNo");
            ReportGlobalModel.ScannedBy = getColumn.get_Column_DataView(dt, "SCANNEDBY");

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

            Area.DataSource = getArea();
            Area.DataTextField = "RevenueUnitName";
            Area.DataValueField = "RevenueUnitName";
            Area.DataBind();
        }

        protected void grid_DailyTripReport_PreRender(object sender, EventArgs e)
        {
            grid_DailyTripReport.Rebind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}