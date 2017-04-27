﻿using System;
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
            if (!String.IsNullOrEmpty(txtAwbNo.Text))
            {
                awbNo = txtAwbNo.Text;
                DataTable Data = GetAwbNoInformation(awbNo);
                #region Fill Value
                FillValue(Data);
                radGridAwbNoTracking.DataSource = GetDetailsAwbNoInformation(awbNo);
                radGridAwbNoTracking.Rebind();
                radGridAwbNoTracking.DataBind();

                #endregion

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
            DataSet data = BLL.AirwayBill.GetDetailsAwbNo(awbNo, getConstr.ConStrCMS);
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