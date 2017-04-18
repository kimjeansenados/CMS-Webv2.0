using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Unbundle : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SackNumber.DataSource = getUnbundle();
                SackNumber.DataTextField = "SACKNO";
                SackNumber.DataValueField = "SACKNO";
                SackNumber.DataBind();

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Origin.DataSource = getCity();
                Origin.DataTextField = "CityName";
                Origin.DataValueField = "CityName";
                Origin.DataBind();


            }
        }


        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getCity()
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

        public DataTable getUnbundle()
        {
            string DateStr = "";
            string SackNoStr = "All";
            string OriginStr = "All";
            string BCOStr = "All";
            try
            {

                SackNoStr = SackNumber.SelectedItem.Text.ToString();
                BCOStr = BCO.SelectedValue;
                OriginStr = Origin.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }
            DataSet data = BLL.Report.UnbundleReport.GetBundle(getConstr.ConStrCMS, DateStr, SackNoStr, OriginStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_Unbundle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Unbundle.DataSource = getUnbundle();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Unbundle.DataSource = getUnbundle();
            grid_Unbundle.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            Origin.Text = "";
            Origin.Items.Clear();
            Origin.AppendDataBoundItems = true;
            Origin.Items.Add("All");
            Origin.SelectedIndex = 0;
            Origin.DataSource = getCity();
            Origin.DataTextField = "CityName";
            Origin.DataValueField = "CityName";
            Origin.DataBind();
        }

        protected void grid_Unbundle_PreRender(object sender, EventArgs e)
        {
            grid_Unbundle.Rebind();
        }
    }
}