using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Finance.Sales
{
    public partial class MasterSales : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BCOShipper.DataSource = getBCO();
                BCOShipper.DataTextField = "BranchCorpOfficeName";
                BCOShipper.DataValueField = "BranchCorpOfficeName";
                BCOShipper.DataBind();

                BCOConsignee.DataSource = getBCO();
                BCOConsignee.DataTextField = "BranchCorpOfficeName";
                BCOConsignee.DataValueField = "BranchCorpOfficeName";
                BCOConsignee.DataBind();

                Shipmode.DataSource = getShipMode();
                Shipmode.DataTextField = "ShipModeName";
                Shipmode.DataValueField = "ShipModeName";
                Shipmode.DataBind();

                CommodityType.DataSource = getComtype();
                CommodityType.DataTextField = "CommodityTypeName";
                CommodityType.DataValueField = "CommodityTypeName";
                CommodityType.DataBind();

                ServiceMode.DataSource = getServiceMode();
                ServiceMode.DataTextField = "ServiceModeName";
                ServiceMode.DataValueField = "ServiceModeName";
                ServiceMode.DataBind();

                Paymode.DataSource = getPaymode();
                Paymode.DataTextField = "PaymentModeName";
                Paymode.DataValueField = "PaymentModeName";
                Paymode.DataBind();

                User.DataSource = getUser();
                User.DataTextField = "FullName";
                User.DataValueField = "FullName";
                User.DataBind();

            }
        }

        public DataTable getBCO()
        {

            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getShipMode()
        {

            DataSet data = BLL.ShipMode.GetShipMode(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getComtype()
        {

            DataSet data = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getServiceMode()
        {

            DataSet data = BLL.ServiceMode.GetServiceMode(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getPaymode()
        {

            DataSet data = BLL.PaymentMode.GetPaymentMode(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getUser()
        {

            DataSet data = BLL.Users_Info.GetUserInfo(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getMasterSales()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            string BCOShipperStr = "All";
            string BCOConsigneeStr = "All";
            string ShipModeStr = "All";
            string ComTypeStr = "All";
            string ServiceModeStr = "All";
            string PayModeStr = "All";
            string UserStr = "All";
            try
            {
                BCOShipperStr = BCOShipper.SelectedItem.Text;
                BCOConsigneeStr = BCOConsignee.SelectedItem.Text;
                ShipModeStr = Shipmode.SelectedItem.Text;
                ComTypeStr = CommodityType.SelectedItem.Text;
                ServiceModeStr = ServiceMode.SelectedItem.Text;
                PayModeStr = Paymode.SelectedItem.Text;
                UserStr = User.SelectedItem.Text;
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;
            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }

            DataSet data = BLL.Report.MasterSalesReport.GetMasterSales(getConstr.ConStrCMS, date1, date2, BCOShipperStr, BCOConsigneeStr, ShipModeStr, ComTypeStr, ServiceModeStr, PayModeStr, UserStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_MasterSales_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_MasterSales.DataSource = getMasterSales();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_MasterSales.DataSource = getMasterSales();
            grid_MasterSales.Rebind();
        }

        protected void grid_MasterSales_PreRender(object sender, EventArgs e)
        {
            grid_MasterSales.Rebind();
        }
    }
}