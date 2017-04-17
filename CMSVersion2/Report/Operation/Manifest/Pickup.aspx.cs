using System;
using System.Data;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Pickup : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
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

                setAWB();

                //Date.SelectedDate = DateTime.Now;
            }
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public void setAWB()
        {
            AWB.DataSource = getPickUpCargoData();
            AWB.DataTextField = "AWB #";
            AWB.DataValueField = "AWB #";
            AWB.DataBind();
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


        public DataTable getPickUpCargoData()
        {
            string AreaStr = "All";
            string AWBStr = "";
            string DateStr = "";
            string BCOStr = "All";
            try
            {
                BCOStr = BCO.SelectedItem.Text;
                AreaStr = Area.SelectedItem.Text.ToString();
                AWBStr = AWB.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }
            DataSet data = BLL.Report.PickupCargoManifestReport.GetPickupCargoManifest(getConstr.ConStrCMS, AreaStr, AWBStr, DateStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        protected void gridPickupCargo_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getPickUpCargoData();

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("DATE === > " + Date.SelectedDate);
            gridPickupCargo.DataSource = getPickUpCargoData();
            gridPickupCargo.Rebind();
            setAWB();
        }

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            gridPickupCargo.MasterTableView.GetColumn("CREATEDDATE").Visible = false;
            gridPickupCargo.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
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
    }
}