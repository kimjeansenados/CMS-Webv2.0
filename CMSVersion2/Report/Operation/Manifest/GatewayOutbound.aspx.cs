using CMSVersion2.Models;
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
    public partial class GatewayOutbound : System.Web.UI.Page
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

                Batch.DataSource = getBatch();
                Batch.DataTextField = "BatchName";
                Batch.DataValueField = "BatchName";
                Batch.DataBind();

                Gateway.DataSource = getGatewayList();
                Gateway.DataTextField = "Gateway";
                Gateway.DataValueField = "Gateway";
                Gateway.SelectedIndex = 0;
                Gateway.DataBind();

                Date.SelectedDate = DateTime.Now;

            }

        }

        public DataTable getGatewayList()
        {
            string DateStr = "";
            try
            {
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGatewayOutBoundList(getConstr.ConStrCMS, DateStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewayoutbound");
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

        public DataTable getGatewayTranmittal()
        {
            string DateStr = "";
            string GatewayStr = "";
            string BCOStr = "All";
            string BatchStr = "All";

            try
            {
                GatewayStr = Gateway.SelectedItem.Text.ToString();
                BCOStr = BCO.SelectedItem.Text.ToString();
                BatchStr = Batch.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGWOutbound(getConstr.ConStrCMS, DateStr, GatewayStr, BCOStr, BatchStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "GWOutbound";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.Gateway = GatewayStr;
            //ReportGlobalModel.Branch = BCOStr;
            //ReportGlobalModel.Batch = BatchStr;

            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //gridPickupCargo.DataSource = getGatewayTranmittal();
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
            Gateway.Items.Clear();
            Gateway.DataSource = getGatewayList();
            Gateway.DataTextField = "Gateway";
            Gateway.DataValueField = "Gateway";
            Gateway.SelectedIndex = 0;
            Gateway.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
            gridPickupCargo.Rebind();
        }

        protected void Print_Click1(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            gridPickupCargo.Rebind();
        }

        protected void gridPickupCargo_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
        }
    }
}