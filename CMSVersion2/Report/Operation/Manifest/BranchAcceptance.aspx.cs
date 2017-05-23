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
using Telerik.Web.UI.ExportInfrastructure;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class BranchAcceptance : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date.SelectedDate = DateTime.Now;
                Batch.DataSource = getBatch();
                Batch.DataTextField = "BatchName";
                Batch.DataValueField = "BatchName";
                Batch.DataBind();

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                //Area.DataSource = getArea();
                //Area.DataTextField = "RevenueUnitName";
                //Area.DataValueField = "RevenueUnitName";
                //Area.DataBind();

               
            }
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
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

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "branchacceptance");
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBranchAcceptance()
        {
            string DateStr = "";
            string BatchStr = "All";
            string BCOStr = "All";
            try
            {

                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
                BCOStr = BCO.SelectedItem.Text.ToString();
               // AreaStr = Area.SelectedItem.Text.ToString();
                BatchStr = Batch.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {
                //DateStr = "";
            }

            DataSet data = BLL.Report.BranchAcceptanceReport.GetBranchAcceptance(getConstr.ConStrCMS, DateStr, BatchStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            
            //FOR PRINTING     
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
           // DateStr = (DateStr == null) ? "All" : DateStr;
           // AreaStr = (AreaStr == null) ? "All" : AreaStr;

            ReportGlobalModel.Report = "BranchAcceptance";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.Area = BCOStr;
            ReportGlobalModel.Batch = BatchStr;
            ReportGlobalModel.Driver = getColumn.get_Column_DataView(dt, "DRIVER");
            ReportGlobalModel.Checker = getColumn.get_Column_DataView(dt, "CHECKER");
            ReportGlobalModel.PlateNo = "All";
            ReportGlobalModel.ScannedBy = getColumn.get_Column_DataView(dt, "SCANNEDBY");
            
            return dt;
        }

        protected void grid_BranchAcceptance_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
            grid_BranchAcceptance.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //Area.Text = "";
            //Area.Items.Clear();
            //Area.AppendDataBoundItems = true;
            //Area.Items.Add("All");
            //Area.SelectedIndex = 0;
            //Area.DataSource = getArea();
            //Area.DataTextField = "RevenueUnitName";
            //Area.DataValueField = "RevenueUnitName";
            //Area.DataBind();
        }

        protected void grid_BranchAcceptance_PreRender(object sender, EventArgs e)
        {
            grid_BranchAcceptance.Rebind();
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