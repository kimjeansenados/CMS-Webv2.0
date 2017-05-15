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
    public partial class GatewayTransmittal : System.Web.UI.Page
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
            }
        }

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewaytransmittal");
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
            string GateWay = "";
            string BCO = "";
            string Batch = "";
            

            DataSet data = BLL.Report.GatewayTransmittal.GetGWTransmittal(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            
            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
            gridPickupCargo.Rebind();
        }

        protected void Print_Click(object sender, EventArgs e)
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
    }
}