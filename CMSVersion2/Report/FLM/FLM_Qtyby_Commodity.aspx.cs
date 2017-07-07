﻿using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.FLM
{

    public partial class FLM_Qtyby_Commodity : System.Web.UI.Page
    {

        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInit();

                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now.AddDays(30);
            }
        }
        private void LoadInit()
        {
            LoadBranchCorpOffice();
        }

        private void LoadBranchCorpOffice()
        {
            BCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            BCO.DataValueField = "BranchCorpOfficeId";
            BCO.DataTextField = "BranchCorpOfficeName";
            BCO.DataBind();
        }

        public DataTable getQtybyCommodity()
        {
            string bcoid = "";           
            DateTime DateFromStr = new DateTime();
            DateTime DateToStr = new DateTime();

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                
                //BCO
                if (BCO.SelectedItem.Text == "All")
                {
                    bcoid = "";
                }
                else
                {
                    bcoid = BCO.SelectedItem.Text;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.FLM_Qtyby_Commodity.GetQtybyCommodity(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            
            //FOR PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "QtybyCommodity";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = DateFromStr.ToShortDateString() + "" + "-" + "" + DateToStr.ToShortDateString();
            ReportGlobalModel.Branch = BCO.SelectedItem.Text;
            return dt;
        }

        protected void grid_QtyByCommodity_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_QtyByCommodity.DataSource = getQtybyCommodity();
        }

        protected void grid_QtyByCommodity_PreRender(object sender, EventArgs e)
        {
            grid_QtyByCommodity.Rebind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_QtyByCommodity.DataSource = getQtybyCommodity();
            grid_QtyByCommodity.Rebind();
        }
    }
}