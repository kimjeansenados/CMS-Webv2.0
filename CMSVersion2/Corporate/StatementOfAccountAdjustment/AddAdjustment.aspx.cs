using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


public partial class _AddAdjustment : System.Web.UI.Page
{
    Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
    DataTable ShipmentDataSource = new DataTable();
    DataTable PaymentDataSource = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Guid soaid = Guid.Parse(Request.QueryString["StatementOfAccountId"].ToString());
            if (soaid != null)
            {
                DataSet data = BLL.Shipment.GetShipmentsAndPaymentsBySOAID(soaid, getConstr.ConStrCMS);
                DataTable SOA = data.Tables[0];
                foreach (DataRow item in SOA.Rows)
                {
                    txtAccountNo.Text = item["AccountNo"].ToString();
                    txtCompany.Text = item["Companyname"].ToString();
                    txtSoaNo.Text = item["StatementOfAccountNo"].ToString();
                    txtBillingPeriod.Text = item["BillingPeriod"].ToString();
                }

                ShipmentDataSource = data.Tables[1];
                PaymentDataSource = data.Tables[2];
                ShipmentGrid.DataSource = ShipmentDataSource;
                AdjustmentGrid.DataSource = PaymentDataSource;
            }
        }
    }





    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void AdjustmentGrid_ItemCreated(object sender, GridItemEventArgs e)
    {

    }
    protected void AdjustmentGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void AdjustmentGrid_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void AdjustmentGrid_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void ShipmentGrid_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void ShipmentGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
}