using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.ExportInfrastructure;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class BranchAcceptance : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Batch.DataSource = getBatch();
                Batch.DataTextField = "BatchName";
                Batch.DataValueField = "BatchName";
                Batch.DataBind();

                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Area.DataSource = getArea();
                Area.DataTextField = "RevenueUnitName";
                Area.DataValueField = "RevenueUnitName";
                Area.DataBind();
            }
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
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

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "branchacceptance");
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBranchAcceptance()
        {
            string DateStr = "";
            string AreaStr = "All";
            string BatchStr = "All";
            string BCOStr = "All";
            try
            {
                BCOStr = BCO.SelectedItem.Text.ToString();
                AreaStr = Area.SelectedItem.Text.ToString();
                BatchStr = Batch.SelectedItem.Text.ToString();
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }

            DataSet data = BLL.Report.BranchAcceptanceReport.GetBranchAcceptance(getConstr.ConStrCMS, DateStr, AreaStr, BatchStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_BranchAcceptance_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
            grid_BranchAcceptance.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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

        protected void grid_BranchAcceptance_PreRender(object sender, EventArgs e)
        {
            grid_BranchAcceptance.Rebind();
        }

        protected void grid_BranchAcceptance_InfrastructureExporting(object sender, Telerik.Web.UI.GridInfrastructureExportingEventArgs e)
        {
            //Telerik.Web.UI.ExportInfrastructure.ExportStructure structure2 = new Telerik.Web.UI.ExportInfrastructure.ExportStructure();
            //Telerik.Web.UI.ExportInfrastructure.Table table2 = new Telerik.Web.UI.ExportInfrastructure.Table("S1");
            //table2.Cells["A1"].Value = "Wine";
            //Telerik.Web.UI.ExportInfrastructure.Cell b2Cell = table2.Cells["B2"];
            //b2Cell.Value = "White";
            //b2Cell.Style.BackColor = System.Drawing.Color.Blue;
            //structure2.Tables.Add(table2);
        }
    }
}