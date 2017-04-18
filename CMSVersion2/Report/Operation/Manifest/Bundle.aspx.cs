using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Bundle : System.Web.UI.Page
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

                BundleNumber.DataSource = getBundle();
                BundleNumber.DataTextField = "SackNo";
                BundleNumber.DataValueField = "SackNo";
                BundleNumber.DataBind();

                Destination.DataSource = getCityBCO();
                Destination.DataTextField = "CityName";
                Destination.DataValueField = "CityName";
                Destination.DataBind();
            }
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getCityBCO()
        {
            string bco = "All";
            try
            {
                bco = BCO.SelectedValue;
            }
            catch (Exception) { }
            DataSet data = BLL.City.GetCityByBCO(getConstr.ConStrCMS, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBundle()
        {
            //DateTime date =
            string bundlenumber = "All";
            string destination = "All";
            string bco = "All";
            string date = "";

            try
            {
                bco = BCO.SelectedValue;
                bundlenumber = BundleNumber.SelectedItem.Text.ToString();
                destination = Destination.SelectedItem.Text.ToString();
                date = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                date = "";
            }

            DataSet data = BLL.Report.BundleReport.GetBundle(getConstr.ConStrCMS, date, bundlenumber, destination, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_Bundle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Bundle.DataSource = getBundle();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Bundle.DataSource = getBundle();
            grid_Bundle.Rebind();
        }

        protected void grid_Bundle_PreRender(object sender, EventArgs e)
        {
            grid_Bundle.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Destination.Text = "";
            Destination.Items.Clear();
            Destination.AppendDataBoundItems = true;
            Destination.Items.Add("All");
            Destination.SelectedIndex = 0;
            Destination.DataSource = getCityBCO();
            Destination.DataTextField = "CityName";
            Destination.DataValueField = "CityName";
            Destination.DataBind();
        }
    }
}