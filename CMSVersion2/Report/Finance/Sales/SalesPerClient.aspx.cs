using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Finance.Sales
{
    public partial class SalesPerClient : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Client.DataSource = getClient();
                Client.DataTextField = "Name";
                Client.DataValueField = "Name";
                Client.DataBind();
            }
        }
        public DataTable getClient()
        {
            DataSet data = BLL.Clients.GetClients(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getSalesPerClient()
        {
            string client = "";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;
            try
            {

                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;
            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            try
            {
                client = Client.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {
                client = "";
            }
            DataSet data = BLL.Report.SalesPerClientReport.GetSalesPerClient(getConstr.ConStrCMS, client, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        protected void grid_SalesPerClient_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_SalesPerClient.DataSource = getSalesPerClient();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_SalesPerClient.DataSource = getSalesPerClient();
            grid_SalesPerClient.Rebind();
        }

        protected void grid_SalesPerClient_PreRender(object sender, EventArgs e)
        {
            grid_SalesPerClient.Rebind();
        }
    }
}