using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report
{
    public partial class AWBNoTracking : System.Web.UI.Page
    {
        #region Properties
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchAwbNo_Click(object sender, EventArgs e)
        {
            string awbNo = "";
            int numberOfRecords = 0;
            if (!String.IsNullOrEmpty(txtAwbNo.Text))
            {
                awbNo = txtAwbNo.Text;
                DataTable Data = GetAwbNoInformation(awbNo);
                numberOfRecords = Data.Rows.Count;

                if (numberOfRecords > 0)
                {
                    #region Fill Value
                    FillValue(Data);
                    radGridAwbNoTracking.DataSource = GetDetailsAwbNoInformation(awbNo);
                    radGridAwbNoTracking.Rebind();
                    radGridAwbNoTracking.DataBind();
                    lblReceivedBy.Visible = true;
                    //podLink.Visible = true;
                    //podLink.Attributes.Add("onclick", "return handleHyperLinkClick(awbNo)");
                    signLink.Visible = true;
                    #endregion
                }
                else
                {
                    txtAwb.Text = "";
                    radGridAwbNoTracking.DataSource = null;
                    radGridAwbNoTracking.Rebind();
                    radGridAwbNoTracking.DataBind();
                    lblReceivedBy.Visible = false;
                    signLink.Visible = false;
                }


            }
        }
        #endregion

        #region Methods
        public DataTable GetAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetAwbInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetDetailsAwbNo(awbNo,2,getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public void FillValue(DataTable Data)
        {
            int counter = 0;
            foreach (DataRow row in Data.Rows)
            {
                if (counter == 0)
                {
                    try
                    {
                        txtAwb.Text = row["AirwayBillNo"].ToString();
                        txtShipper.Text = row["Shipper"].ToString();
                        txtConsignee.Text = row["Consignee"].ToString();
                        txtPayMode.Text = row["PaymentModeName"].ToString();
                        txtCommodity.Text = row["CommodityName"].ToString();

                        txtOrigin.Text = row["Origin"].ToString();
                        txtDestination.Text = row["Destination"].ToString();
                        txtQuantity.Text = row["Quantity"].ToString();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    counter++;
                }
            }
        }
        #endregion
    }
}