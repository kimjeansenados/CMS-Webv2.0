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
    public partial class GatewayInbound : System.Web.UI.Page
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

                Gateway.DataSource = getGatewayList();
                Gateway.DataTextField = "Gateway";
                Gateway.DataValueField = "Gateway";
                Gateway.SelectedIndex = 0;
                Gateway.DataBind();

                ComType.DataSource = getComType();
                ComType.DataTextField = "CommodityTypeName";
                ComType.DataValueField = "CommodityTypeName";
                ComType.DataBind();

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

            DataSet data = BLL.Report.GatewayTransmittal.GetGatewayInBoundList(getConstr.ConStrCMS, DateStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getComType()
        {
            DataSet data = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
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
            string ComTypeStr = "All";

            try
            {
                GatewayStr = Gateway.SelectedItem.Text.ToString();
                BCOStr = BCO.SelectedItem.Text.ToString();
                ComTypeStr = ComType.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGWInbound(getConstr.ConStrCMS, DateStr, GatewayStr, BCOStr, ComTypeStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "GWInbound";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.Gateway = GatewayStr;
            ReportGlobalModel.CommodityType = ComTypeStr;

            return dt;
        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
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

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            gridPickupCargo.Rebind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
            gridPickupCargo.Rebind();
        }
    }
}