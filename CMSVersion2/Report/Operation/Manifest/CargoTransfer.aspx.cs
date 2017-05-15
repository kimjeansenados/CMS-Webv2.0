using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class CargoTransfer : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable getGatewayTranmittal()
        {
            DataSet data = BLL.Report.GatewayTransmittal.GetHoldCargo(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
        }
    }
}