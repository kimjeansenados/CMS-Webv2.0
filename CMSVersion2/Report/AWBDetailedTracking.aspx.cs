using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report
{
    public partial class AWBDetailedTracking : System.Web.UI.Page
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

                if(numberOfRecords > 0)
                {
                    FillValue(Data);
                    radGridAwbNo.DataSource = GetDetailsAwbNoInformation(awbNo);
                    radGridAwbNo.Rebind();
                    radGridAwbNo.DataBind();
                    //LoadSignature(awbNo);
                    lblReceivedBy.Visible = true;
                    signLink.Visible = true;
                }
                else
                {
                    txtAwb.Text = "";
                    txtAwb.Text = "";
                    txtShipper.Text = "";
                    txtConsignee.Text = "";
                    txtPayMode.Text = "";
                    txtCommodity.Text = "";

                    txtOrigin.Text = "";
                    txtDestination.Text = "";
                    txtQuantity.Text = "";
                    radGridAwbNo.DataSource = null;
                    radGridAwbNo.Rebind();
                    radGridAwbNo.DataBind();
                    lblReceivedBy.Visible = false;
                    signLink.Visible = false;
                    //Image1.Visible = false;
                }



            }
        }
        #endregion

        #region Methods

        //public void LoadSignature(string awbNo)
        //{
        //    int count = 0;
        //    DataTable Data = GetSignatureforPOD(awbNo);
        //    count = Data.Rows.Count;
        //    if (count > 0)
        //    {
        //        lblReceivedBy.Visible = true;
        //        Image1.Visible = true;
        //        byte[] bytes = (byte[])GetSignatureforPOD(awbNo).Rows[0]["Signature"];
        //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //        Image1.ImageUrl = "data:image/png;base64," + base64String;
                
        //    }
        //}

        public DataTable GetAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetAwbInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetDetailsAwbNo(awbNo,1, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetSignatureforPOD(string awbNo)
        {
            DataSet data = BLL.AirwayBill.SignaturePOD(awbNo, getConstr.ConStrCMS);
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