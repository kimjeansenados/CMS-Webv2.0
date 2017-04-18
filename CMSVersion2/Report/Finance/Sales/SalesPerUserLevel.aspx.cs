using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Finance.Sales
{
    public partial class SalesPerUserLevel : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BCO.DataSource = getBCO();
                BCO.DataTextField = "BranchCorpOfficeCode";
                BCO.DataValueField = "BranchCorpOfficeId";
                BCO.DataBind();
            }
        }
        public DataTable getBCO()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getSalesPerClient()
        {
            string bcostr = "All";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            try
            {
                bcostr = BCO.SelectedItem.Text.ToString();
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            DataSet data = BLL.Report.SalesPerUserLevelReport.GetSalesPerUserLevel(getConstr.ConStrCMS, bcostr, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_SalesPerUserLevel_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_SalesPerUserLevel.DataSource = getSalesPerClient();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_SalesPerUserLevel.DataSource = getSalesPerClient();
            grid_SalesPerUserLevel.Rebind();
        }

        protected void grid_SalesPerUserLevel_PreRender(object sender, EventArgs e)
        {
            grid_SalesPerUserLevel.Rebind();
        }
    }
}