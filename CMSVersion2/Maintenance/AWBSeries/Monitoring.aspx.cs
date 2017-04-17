﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;
namespace CMSVersion2.Maintenance.AWBSeries
{
    public partial class Monitoring : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //{
            //    string usersession = Session["UsernameSession"].ToString();
            //}

            //if (!IsPostBack)
            //{
            //    InitLoad();

            //}
        }

        #region InitLoad
        public void InitLoad()
        {
            LoadBranchCorporateOffice();
            LoadRevenueUnitType();
            LoadEmployee();
            LoadArea();
            LoadAwbSeries();

            //
            //populateRevenueUnitNameByBCO();
            //populateEmployeeByArea();
        }
        #endregion


        #region DataSources
        public DataTable GetAllAwbSeriesMonitoring()
        {
            DataSet data = BLL.AwbSeries.GetAllSeriesMonitoring(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        private void LoadBranchCorporateOffice()
        {
            DataTable bcoList = BLL.Revenue_Info.getBranchCorp(getConstr.ConStrCMS).Tables[0];
            rdcBCO.DataSource = bcoList;
            rdcBCO.DataTextField = "BranchCorpOfficeName";
            rdcBCO.DataValueField = "BranchCorpOfficeId";
            rdcBCO.DataBind();

        }

        private void LoadRevenueUnitType()
        {
            DataTable revenueUnitTypeList = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS).Tables[0];
            rcbRevenueType.DataSource = revenueUnitTypeList;
            rcbRevenueType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueType.DataBind();
        }

        public DataTable GetAWBSeriesbySearch(Guid bcoId, Guid revenueUnitTypeId, Guid revenueUnitId, Guid empId, Guid awbSeriesId, string constr)
        {
            DataSet data = BLL.AwbSeries.GetAwbSeriesbySearch(bcoId, revenueUnitTypeId, revenueUnitId, empId, awbSeriesId, constr);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        private void LoadEmployee()
        {
            DataTable employee = BLL.Employee_Info.GetEmployee(getConstr.ConStrCMS).Tables[0];
            rcbName.DataSource = employee;
            rcbName.DataValueField = "EmployeeId";
            rcbName.DataTextField = "FullName";
            rcbName.DataBind();

        }

        private void populateRevenueUnitNameByBCO()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(rcbRevenueType.SelectedValue.ToString()), new Guid(rdcBCO.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rdcArea.DataSource = LocationList;
            rdcArea.DataTextField = "RevenueUnitName";
            rdcArea.DataValueField = "RevenueUnitId";
            rdcArea.DataBind();

        }

        private void LoadArea()
        {
            DataTable area = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS).Tables[0];
            rdcArea.DataSource = area;
            rdcArea.DataValueField = "RevenueUnitId";
            rdcArea.DataTextField = "RevenueUnitName";
            rdcArea.DataBind();

        }

        private void populateEmployeeByArea()
        {
            DataTable LocationList = BLL.Employee_Info.GetEmployeeBySearch(new Guid(rdcBCO.SelectedValue.ToString()), new Guid(rcbRevenueType.SelectedValue.ToString()), new Guid(rdcArea.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbName.DataSource = LocationList;
            rcbName.DataTextField = "FullName";
            rcbName.DataValueField = "EmployeeId";
            rcbName.DataBind();

        }

        private void LoadAwbSeries()
        {
            DataTable awbSeries = BLL.AwbSeries.GetAwbSeries(getConstr.ConStrCMS).Tables[0];
            rcbAwbSeries.DataSource = awbSeries;
            rcbAwbSeries.DataTextField = "AWBSeries";
            rcbAwbSeries.DataValueField = "AwbIssuanceId";
            rcbAwbSeries.DataBind();

        }
        #endregion


        #region Events
        #region RadGrid Events
        protected void radGridAwbSeriesMonitoring_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridAwbSeriesMonitoring.DataSource = GetAllAwbSeriesMonitoring();
        }
        #endregion

        #region Search

        protected void rdcBCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueType_TextChanged(object sender, EventArgs e)
        {
            rdcArea.Items.Clear();
            populateRevenueUnitNameByBCO();
        }

        protected void rdcArea_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateEmployeeByArea();
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Guid bcoId = new Guid();
            Guid revenueUnitTypeId = new Guid();
            Guid revenueUnitid = new Guid();
            Guid empId = new Guid();
            Guid awbSeriesId = new Guid();

            try
            {
                bcoId = Guid.Parse(rdcBCO.SelectedValue.ToString());
                revenueUnitTypeId = Guid.Parse(rcbRevenueType.SelectedValue.ToString());
                revenueUnitid = Guid.Parse(rdcArea.SelectedValue.ToString());
                empId = Guid.Parse(rcbName.SelectedValue.ToString());
                awbSeriesId = Guid.Parse(rcbAwbSeries.SelectedValue.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (bcoId != null)
            {
                radGridAwbSeriesMonitoring.DataSource = GetAWBSeriesbySearch(bcoId, revenueUnitTypeId, revenueUnitid, empId, awbSeriesId, getConstr.ConStrCMS);
                radGridAwbSeriesMonitoring.Rebind();
                radGridAwbSeriesMonitoring.DataBind();
            }



        }
        #endregion
        #endregion
    }
}