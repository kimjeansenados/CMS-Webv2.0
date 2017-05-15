using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.AWBNoModal
{
    public partial class AWBTrackingModal : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            //radGridSignature.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {

                }
                else
                {
                    string awbNo = Request.QueryString["Id"].ToString();
                    lblAwbNumber.Value = awbNo;
                    LoadSignature(lblAwbNumber.Value);

                }
            }
        }

       
        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.SignaturePOD(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public void LoadSignature(string awbNo)
        {
            int count = 0;
            DataTable Data = GetDetailsAwbNoInformation(awbNo);
            count = Data.Rows.Count;
            if(count > 0)
            {
                int counter = 0;
                foreach (DataRow row in Data.Rows)
                {
                    if (counter == 0)
                    {
                        try
                        {
                            string sign = row["Signature"].ToString();
                            if(!String.IsNullOrEmpty(sign))
                            {
                                byte[] signature = (byte[])row["Signature"];
                                if (signature != null && signature.Length > 0)
                                {
                                    //byte[] bytes = (byte[])GetDetailsAwbNoInformation(awbNo).Rows[0]["Signature"];
                                    string base64String = Convert.ToBase64String(signature, 0, signature.Length);
                                    Image1.ImageUrl = "data:image/png;base64," + base64String;
                                }
                            }

                           
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
               

                //string empName = (string)GetDetailsAwbNoInformation(awbNo).Rows[0]["EmployeeName"];
                //lblName.Text = empName;
            }
        }


        //protected void radGridSignature_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    string awbNo;
        //    awbNo = lblAwbNumber.Value;
        //    if (awbNo != null)
        //    {
        //        try
        //        {
        //            radGridSignature.DataSource = GetDetailsAwbNoInformation(awbNo);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //        }
        //    }
        //}
    }
}