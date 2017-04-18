using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.CargoMonitoring
{
    public partial class RUD : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable getHold()
        {
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
            DataSet data = BLL.Report.CargoMonitoring.GetCargoMonitoringRUD(getConstr.ConStrCMS, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_Hold_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Hold.DataSource = getHold();
        }

        protected void grid_Hold_PreRender(object sender, EventArgs e)
        {
            grid_Hold.DataSource = getHold();
            grid_Hold.Rebind();
        }
    }
}