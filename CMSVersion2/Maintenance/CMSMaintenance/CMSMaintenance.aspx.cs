using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance
{
    public partial class CMSMaintenance : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //{
            //    string usersession = Session["UsernameSession"].ToString();
            //}
            if (!IsPostBack)
            {

                //host = getConstr.IISWebName;

                InitLoad();
            }
        }

        private DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        private void InitLoad()
        {

            LoadGroupIslands();
            //LoadRegion();
            //LoadProvince();
            //LoadBranchCorpOffice();
            //LoadCluster();
            //LoadCity();
            //LoadArea();
            //GetGateway();
            //GetBranch();
            //LoadRevenueType();
            //LoadApplicableRate();
            //LoadCommodity();
            //LoadCommodityType();
            //LoadGoodsDescription();
            //LoadShipmentBasicFee();
            //LoadCrating();
            //TransShipmentRoutes();
            //ServiceType();
            //ServiceMode();
            //PaymentMode();
            //PaymentTerm();
            //BookingRemark();
            //BookingStatus();
            //ShipMode();
            //DeliveryStatus();
            //DeliveryRemarks();
            //LoadPackaging();
            //BookingStatus();
            //BookingRemark();
            //DeliveryStatus();
            //DeliveryRemarks();
            //LoadAccountType();
            //LoadAccountStatus();
            //LoadBusinessType();
            //LoadOrganizationType();
            //LoadIndustry();
            //LoadBillingPeriod();
        }

        #region "Load datasources"

        private void LoadGroupIslands()
        {
            rcbIslandGroup.DataSource = BLL.IslandGroup.GetIslandGroup(getConstr.ConStrCMS);
            rcbIslandGroup.DataValueField = "GroupId";
            rcbIslandGroup.DataTextField = "GroupName";
            rcbIslandGroup.DataBind();
        }
        private void LoadRegion()
        {
            rcbRegion.DataSource = BLL.Region.GetRegion(getConstr.ConStrCMS);
            rcbRegion.DataValueField = "RegionId";
            rcbRegion.DataTextField = "RegionName";
            rcbRegion.DataBind();
        }

        private void LoadProvince()
        {
            rcbProvince.DataSource = BLL.Province.GetProvince(getConstr.ConStrCMS);
            rcbProvince.DataValueField = "ProvinceId";
            rcbProvince.DataTextField = "ProvinceName";
            rcbProvince.DataBind();
        }

        private void LoadBranchCorpOffice()
        {
            rcbBranchCorpOffice.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBranchCorpOffice.DataValueField = "BranchCorpOfficeId";
            rcbBranchCorpOffice.DataTextField = "BranchCorpOfficeName";
            rcbBranchCorpOffice.DataBind();
        }

        private void LoadCluster()
        {
            rcbCluster.DataSource = BLL.Cluster.GetCluster(getConstr.ConStrCMS);
            rcbCluster.DataValueField = "ClusterId";
            rcbCluster.DataTextField = "ClusterName";
            rcbCluster.DataBind();
        }

        private void LoadCity()
        {
            rcbCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbCity.DataValueField = "CityId";
            rcbCity.DataTextField = "CityName";
            rcbCity.DataBind();
        }

        private void LoadArea()
        {
            rcbArea.DataSource = BLL.Area.GetArea(getConstr.ConStrCMS);
            rcbArea.DataValueField = "RevenueUnitId";
            rcbArea.DataTextField = "RevenueUnitName";
            rcbArea.DataBind();
        }

        private void GetGateway()
        {

            rcbGatewayOffice.DataSource = BLL.Gateway.GetGateway(getConstr.ConStrCMS);
            rcbGatewayOffice.DataValueField = "RevenueUnitId";
            rcbGatewayOffice.DataTextField = "RevenueUnitName";
            rcbGatewayOffice.DataBind();
        }

        private void GetBranch()
        {
            rcbBranchSatOffice.DataSource = BLL.Branch.GetBranch(getConstr.ConStrCMS);
            rcbBranchSatOffice.DataValueField = "RevenueUnitId";
            rcbBranchSatOffice.DataTextField = "RevenueUnitName";
            rcbBranchSatOffice.DataBind();
        }

        private void LoadRevenueType()
        {
            rcbRevenue.DataSource = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS);
            rcbRevenue.DataValueField = "RevenueUnitTypeId";
            rcbRevenue.DataTextField = "RevenueUnitTypeName";
            rcbRevenue.DataBind();
        }


        private void LoadApplicableRate()
        {


            rcbApplicableRate.DataSource = BLL.ApplicableRate.GetApplicableRate(getConstr.ConStrCMS);
            rcbApplicableRate.DataValueField = "ApplicableRateId";
            rcbApplicableRate.DataTextField = "ApplicableRateName";
            rcbApplicableRate.DataBind();
        }
        private void LoadCommodity()
        {
            rcbCommodity.DataSource = BLL.Commodity.GetCommodity(getConstr.ConStrCMS);
            rcbCommodity.DataValueField = "CommodityId";
            rcbCommodity.DataTextField = "CommodityName";
            rcbCommodity.DataBind();
        }

        private void LoadCommodityType()
        {
            rcbCommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbCommodityType.DataValueField = "CommodityTypeId";
            rcbCommodityType.DataTextField = "CommodityTypeName";
            rcbCommodityType.DataBind();
        }


        private void LoadGoodsDescription()
        {

            rcbGoodsDescription.DataSource = BLL.GoodsDescription.GetGoodsDescription(getConstr.ConStrCMS);
            rcbGoodsDescription.DataValueField = "GoodsDescriptionId";
            rcbGoodsDescription.DataTextField = "GoodsDescriptionName";
            rcbGoodsDescription.DataBind();
        }

        private void LoadShipmentBasicFee()
        {
            rcbShipmentBasicFee.DataSource = BLL.ShipmentBasicFee.GetShipmentBasicFee(getConstr.ConStrCMS);
            rcbShipmentBasicFee.DataValueField = "ShipmentBasicFeeId";
            rcbShipmentBasicFee.DataTextField = "ShipmentFeeName";
            rcbShipmentBasicFee.DataBind();
        }


        private void LoadCrating()
        {
            rcbCrating.DataSource = BLL.Crating.GetCrating(getConstr.ConStrCMS);
            rcbCrating.DataValueField = "CratingId";
            rcbCrating.DataTextField = "CratingName";
            rcbCrating.DataBind();
        }

        private void LoadPackaging()
        {
            rcbPackaging.DataSource = BLL.Packaging.GetPackaging(getConstr.ConStrCMS);
            rcbPackaging.DataValueField = "PackagingId";
            rcbPackaging.DataTextField = "PackagingName";
            rcbPackaging.DataBind();
        }

        private void TransShipmentRoutes()
        {
            rcbTransShipmentRoutes.DataSource = BLL.TransShipmentRoutes.GetTransShipmentRoutes(getConstr.ConStrCMS);
            rcbTransShipmentRoutes.DataValueField = "TransShipmentRouteId";
            rcbTransShipmentRoutes.DataTextField = "TransShipmentRouteName";
            rcbTransShipmentRoutes.DataBind();
        }

        private void ServiceType()
        {
            rcbServiceType.DataSource = BLL.ServiceType.GetServiceType(getConstr.ConStrCMS);
            rcbServiceType.DataValueField = "ServiceTypeId";
            rcbServiceType.DataTextField = "ServiceTypeName";
            rcbServiceType.DataBind();
        }

        private void ServiceMode()
        {
            rcbServiceMode.DataSource = BLL.ServiceMode.GetServiceMode(getConstr.ConStrCMS);
            rcbServiceMode.DataValueField = "ServiceModeId";
            rcbServiceMode.DataTextField = "ServiceModeName";
            rcbServiceMode.DataBind();
        }

        private void PaymentMode()
        {
            rcbPaymentMode.DataSource = BLL.PaymentMode.GetPaymentMode(getConstr.ConStrCMS);
            rcbPaymentMode.DataValueField = "PaymentModeId";
            rcbPaymentMode.DataTextField = "PaymentModeName";
            rcbPaymentMode.DataBind();
        }

        private void PaymentTerm()
        {
            rcbPaymentTerm.DataSource = BLL.PaymentTerm.GetPaymentTerm(getConstr.ConStrCMS);
            rcbPaymentTerm.DataValueField = "PaymentTermId";
            rcbPaymentTerm.DataTextField = "PaymentTermName";
            rcbPaymentTerm.DataBind();
        }

        private void ShipMode()
        {

            rcbShipMode.DataSource = BLL.ShipMode.GetShipMode(getConstr.ConStrCMS);
            rcbShipMode.DataValueField = "ShipModeId";
            rcbShipMode.DataTextField = "ShipModeName";
            rcbShipMode.DataBind();

        }

        private void BookingStatus()
        {

            rcbBookingStatus.DataSource = BLL.BookingStatus.GetBookingStatus(getConstr.ConStrCMS);
            rcbBookingStatus.DataValueField = "BookingStatusId";
            rcbBookingStatus.DataTextField = "BookingStatusName";
            rcbBookingStatus.DataBind();
        }

        private void BookingRemark()
        {

            rcbBookingRemarks.DataSource = BLL.BookingRemark.GetBookingRemark(getConstr.ConStrCMS);
            rcbBookingRemarks.DataValueField = "BookingRemarkId";
            rcbBookingRemarks.DataTextField = "BookingRemarkName";
            rcbBookingRemarks.DataBind();
        }

        private void DeliveryStatus()
        {

            rcbDeliveryStatus.DataSource = BLL.DeliveryStatus.GetDeliveryStatus(getConstr.ConStrCMS);
            rcbDeliveryStatus.DataValueField = "DeliveryStatusId";
            rcbDeliveryStatus.DataTextField = "DeliveryStatusName";
            rcbDeliveryStatus.DataBind();
        }

        private void DeliveryRemarks()
        {

            rcbDeliverRemark.DataSource = BLL.DeliveryRemarks.GetDeliveryRemarks(getConstr.ConStrCMS);
            rcbDeliverRemark.DataValueField = "DeliveryRemarkId";
            rcbDeliverRemark.DataTextField = "DeliveryRemarkName";
            rcbDeliverRemark.DataBind();
        }

        private void LoadAccountType()
        {

            rcbAccountType.DataSource = BLL.AccountType.GetAccountType(getConstr.ConStrCMS);
            rcbAccountType.DataValueField = "AccountTypeId";
            rcbAccountType.DataTextField = "AccountTypeName";
            rcbAccountType.DataBind();
        }

        private void LoadAccountStatus()
        {

            rcbAccountStatus.DataSource = BLL.AccountStatus.GetAccountStatus(getConstr.ConStrCMS);
            rcbAccountStatus.DataValueField = "AccountStatusId";
            rcbAccountStatus.DataTextField = "AccountStatusName";
            rcbAccountStatus.DataBind();
        }

        private void LoadBusinessType()
        {

            rcbBusinessType.DataSource = BLL.BusinessType.GetBusinessType(getConstr.ConStrCMS);
            rcbBusinessType.DataValueField = "BusinessTypeId";
            rcbBusinessType.DataTextField = "BusinessTypeName";
            rcbBusinessType.DataBind();
        }


        private void LoadOrganizationType()
        {

            rcbOrganizationType.DataSource = BLL.OrganizationType.GetOrganizationType(getConstr.ConStrCMS);
            rcbOrganizationType.DataValueField = "OrganizationTypeId";
            rcbOrganizationType.DataTextField = "OrganizationTypeName";
            rcbOrganizationType.DataBind();
        }

        private void LoadIndustry()
        {


            rcbIndustry.DataSource = BLL.Industry.GetIndustry(getConstr.ConStrCMS);
            rcbIndustry.DataValueField = "IndustryId";
            rcbIndustry.DataTextField = "IndustryName";
            rcbIndustry.DataBind();
        }

        private void LoadBillingPeriod()
        {
            rcbBillingPeriod.DataSource = BLL.BillingPeriod.GetBillingPeriod(getConstr.ConStrCMS);
            rcbBillingPeriod.DataValueField = "BillingPeriodId";
            rcbBillingPeriod.DataTextField = "BillingPeriodName";
            rcbBillingPeriod.DataBind();
        }

        #endregion



        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }



        #region "ISLAND EVENTS"

        protected void btnIslandAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string groupdid = "";

            rwAddGroupIsland.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/GroupIslandMaintenance/AddGroupIsland.aspx?ID=" + groupdid;
            string script = "function f(){$find(\"" + rwAddGroupIsland.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);


        }

        protected void btnIslandEdit_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{ 
            string host = HttpContext.Current.Request.Url.Authority;
            string groupdid = this.rcbIslandGroup.SelectedItem.Value.ToString();

            if (groupdid != "")
            {

                // RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/GroupIslandMaintenance/EditGroupIsland.aspx?ID=" + groupdid;
                RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/GroupIslandMaintenance/EditGroupIsland.aspx?ID=" + groupdid;
                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                //}
            }
        }

        protected void btnIslandDelete_Click(object sender, EventArgs e)
        {
            string groupdid = this.rcbIslandGroup.SelectedItem.Value.ToString();

            if (groupdid != "")
            {
                BLL.IslandGroup.DeleteIslandGroup(new Guid(groupdid), 3, getConstr.ConStrCMS);
                rcbIslandGroup.Items.Clear();
                LoadGroupIslands();
            }
        }

        #endregion

        #region "REGION EVENTS"

        protected void btnRegionEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string regionid = this.rcbRegion.SelectedItem.Value.ToString();

            if (regionid != "")
            {
                //JHay
                //Remove the another host
                RadWindowRegion.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RegionMaintenance/EditRegion.aspx?ID=" + regionid;
                //RadWindowRegion.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RegionMaintenance/EditRegion.aspx?ID=" + regionid;
                string script = "function f(){$find(\"" + RadWindowRegion.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

                //}
            }
        }

        protected void btnRegionDelete_Click(object sender, EventArgs e)
        {
            string regionId = this.rcbRegion.SelectedItem.Value.ToString();

            if (regionId != "")
            {
                BLL.Region.DeleteRegion(new Guid(regionId), 3, getConstr.ConStrCMS);
                rcbRegion.Items.Clear();
                LoadRegion();
            }
        }

        protected void btnRegionAdd_Click(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{ 
            string host = HttpContext.Current.Request.Url.Authority;
            string groupdid = "";


            rwAddregion.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RegionMaintenance/AddRegion.aspx?ID=" + groupdid;
            //rwAddregion.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RegionMaintenance/AddRegion.aspx?ID=" + groupdid;
            string script = "function f(){$find(\"" + rwAddregion.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        #endregion

        #region PROVINCE EVENTS
        protected void btnProvinceAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string groupdid = "";


            //rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ProvinceMaintenance/AddProvince.aspx?ID=" + groupdid;
            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ProvinceMaintenance/AddProvince.aspx?ID=" + groupdid;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);


        }

        protected void btnProvinceEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ProvinceId = this.rcbProvince.SelectedItem.Value.ToString();

            if (ProvinceId != "")
            {

                //rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ProvinceMaintenance/EditProvince.aspx?ID=" + ProvinceId;
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ProvinceMaintenance/EditProvince.aspx?ID=" + ProvinceId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnProvinceDelete_Click(object sender, EventArgs e)
        {
            string ProvinceId = this.rcbProvince.SelectedItem.Value.ToString();

            if (ProvinceId != "")
            {
                BLL.Province.DeleteProvince(new Guid(ProvinceId), 3, getConstr.ConStrCMS);
                rcbProvince.Items.Clear();
                LoadProvince();
            }
        }

        #endregion

        #region BRANCH CORPORATE OFFICE EVENTS

        protected void btnBranchCorpEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string BranchCorpId = this.rcbBranchCorpOffice.SelectedItem.Value.ToString();

            if (BranchCorpId != "")
            {
                //rwAddGroupIsland.NavigateUrl = "http://" + host + "/portal/UserModal/GroupIslandMaintenance/AddGroupIsland.aspx?ID=" + groupdid;
                //rwBranchCodeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchCorpOffice/EditBranchCorp.aspx?ID=" + BranchCorpId;
                rwBranchCodeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchCorpOffice/EditBranchCorp.aspx?ID=" + BranchCorpId;
                string script = "function f(){$find(\"" + rwBranchCodeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnBranchCorpDelete_Click(object sender, EventArgs e)
        {
            string BranchCorpId = this.rcbBranchCorpOffice.SelectedItem.Value.ToString();

            if (BranchCorpId != "")
            {
                BLL.BranchCorpOffice.DeleteBranchCorpOffice(new Guid(BranchCorpId), 3, getConstr.ConStrCMS);
                rcbBranchCorpOffice.Items.Clear();
                LoadBranchCorpOffice();
            }
        }

        protected void btnBranchCorpAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string BranchCorpId = "";

            //rwBranchCodeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchCorpOffice/AddBranchCorp.aspx?ID=" + BranchCorpId;
            rwBranchCodeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchCorpOffice/AddBranchCorp.aspx?ID=" + BranchCorpId;
            string script = "function f(){$find(\"" + rwBranchCodeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            //}
        }
        #endregion

        #region CLUSTER EVENTS
        protected void btnClusterAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string BranchCorpId = "";

            //rwClusterAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Cluster/AddCluster.aspx?ID=" + BranchCorpId;
            rwClusterAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Cluster/AddCluster.aspx?ID=" + BranchCorpId;
            string script = "function f(){$find(\"" + rwClusterAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            //}
        }
        protected void btnClusterEdit_Click(object sender, EventArgs e)
        {

            string host = HttpContext.Current.Request.Url.Authority;
            string clusterID = this.rcbCluster.SelectedItem.Value.ToString();

            if (clusterID != "")
            {

                //rwClusterEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Cluster/EditCluster.aspx?ID=" + clusterID;
                rwClusterEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Cluster/EditCluster.aspx?ID=" + clusterID;
                string script = "function f(){$find(\"" + rwClusterEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void btnClusterDelete_Click(object sender, EventArgs e)
        {
            string clusterid = this.rcbCluster.SelectedItem.Value.ToString();

            if (clusterid != "")
            {
                BLL.Cluster.DeleteCluster(new Guid(clusterid), 3, getConstr.ConStrCMS);
                rcbCluster.Items.Clear();
                LoadCluster();
            }
        }
        #endregion

        #region CITY EVENTS
        protected void btnCityDelete_Click(object sender, EventArgs e)
        {
            string CityId = this.rcbCity.SelectedItem.Value.ToString();

            if (CityId != "")
            {
                BLL.City.DeleteCity(new Guid(CityId), 3, getConstr.ConStrCMS);
                rcbCity.Items.Clear();
                LoadCity();
            }
        }

        protected void btnCityEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string CityId = this.rcbCity.SelectedItem.Value.ToString();

            if (CityId != "")
            {

                rwCityEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/City/EditCity.aspx?ID=" + CityId;
                //rwCityEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/City/EditCity.aspx?ID=" + CityId;
                string script = "function f(){$find(\"" + rwCityEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnCityAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string CityId = "";

            //rwCityAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/City/AddCity.aspx?ID=" + CityId;
            rwCityAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/City/AddCity.aspx?ID=" + CityId;
            string script = "function f(){$find(\"" + rwCityAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            //}
        }
        #endregion

        #region AREA EVENTS
        protected void btnAreaAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            //if (CityId != "")
            //{

            //rwAreaAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Area/AddArea.aspx?ID=" + AreaId;
            rwAreaAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Area/AddArea.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwAreaAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);


        }

        protected void btnAreaEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaID = this.rcbArea.SelectedItem.Value.ToString();

            if (AreaID != "")
            {

                //rwAreaEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Area/EditArea.aspx?ID=" + AreaID;
                rwAreaEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Area/EditArea.aspx?ID=" + AreaID;
                string script = "function f(){$find(\"" + rwAreaEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnAreaDelete_Click(object sender, EventArgs e)
        {
            string AreaId = this.rcbArea.SelectedItem.Value.ToString();

            if (AreaId != "")
            {
                BLL.Area.DeleteArea(new Guid(AreaId), 3, getConstr.ConStrCMS);
                rcbArea.Items.Clear();
                LoadArea();
            }
        }
        #endregion

        #region BRANCH SATELLITE OFFICE EVENTS
        protected void btnBranchSatOfficeADD_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";

            rwBranchSatOfficeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchSatelliteOfficeMaintenance/AddBSO.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwBranchSatOfficeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);


        }

        protected void btnBranchSatOfficeEDIT_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string BSOid = this.rcbBranchSatOffice.SelectedItem.Value.ToString();

            if (BSOid != "")
            {

                rwBranchSatOfficeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchSatelliteOfficeMaintenance/EditBSO.aspx?ID=" + BSOid;
                string script = "function f(){$find(\"" + rwBranchSatOfficeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnBranchSatOfficeDelete_Click(object sender, EventArgs e)
        {
            string BSOid = this.rcbBranchSatOffice.SelectedItem.Value.ToString();

            if (BSOid != "")
            {
                BLL.Area.DeleteArea(new Guid(BSOid), 3, getConstr.ConStrCMS);
                rcbBranchSatOffice.Items.Clear();
                GetBranch();

            }
        }
        #endregion

        #region GATEWAY SATELLITE OFFICE EVENTS
        protected void btnGatewayOfficeADD_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwGatewaySayOfficeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchGateway/AddGateway.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwGatewaySayOfficeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGatewayOfficeEDIT_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string BSOid = this.rcbGatewayOffice.SelectedItem.Value.ToString();
            if (BSOid != "")
            {
                rwGatewaySayOfficeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BranchGateway/EditGateway.aspx?ID=" + BSOid;
                string script = "function f(){$find(\"" + rwGatewaySayOfficeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnGatewayOfficeDELETE_Click(object sender, EventArgs e)
        {
            string BSOid = this.rcbGatewayOffice.SelectedItem.Value.ToString();
            if (BSOid != "")
            {
                BLL.Area.DeleteArea(new Guid(BSOid), 3, getConstr.ConStrCMS);
                rcbGatewayOffice.Items.Clear();
                GetGateway();
            }
        }
        #endregion

        #region REVENUE UNIT EVENTS

        protected void btnRevenueAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwRUTAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RevenueTypeMaintenance/AddRUT.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwRUTAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnRevenueEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbRevenue.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwRUTEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/RevenueTypeMaintenance/EditRUT.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwRUTEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnRevenueDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbRevenue.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.Area.DeleteRUT(new Guid(RUTid), 3, getConstr.ConStrCMS);
                rcbRevenue.Items.Clear();
                LoadRevenueType();
            }
        }
        #endregion

        #region APPLICABLE RATE EVENTS
        protected void btnApplicableRateADD_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwApplicablerateAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ApplicableRate/AddApplicableRate.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwApplicablerateAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void btnApplicableRateEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbApplicableRate.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwApplicablerateEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ApplicableRate/EditApplicableRate.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwApplicablerateEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnApplicableRateDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbApplicableRate.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.ApplicableRate.DeleteApplicableRate(new Guid(RUTid), 3, getConstr.ConStrCMS);
                rcbApplicableRate.Items.Clear();
                LoadApplicableRate();
            }
        }
        #endregion

        #region COMMODITY TYPE EVENTS

        protected void btnCommodityTypeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            //rwCommodityTypeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/CommodityType/AddCommodityType.aspx?ID=" + AreaId;
            rwCommodityTypeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/CommodityType/AddCommodityType.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwCommodityTypeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }


        protected void btnCommodityTypeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbCommodityType.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwCommodityTypeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/CommodityType/EditCommodityType.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwCommodityTypeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnCommodityTypeDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbCommodityType.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.CommodityType.DeleteCommodityType(new Guid(RUTid), 3, getConstr.ConStrCMS);
                rcbCommodityType.Items.Clear();
                LoadCommodityType();
            }
        }
        #endregion

        #region COMMODITY EVENTS

        protected void btnCommodityAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwCommodityAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Commodity/AddCommodity.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwCommodityAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCommodityEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbCommodity.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwCommodityEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Commodity/EditCommodity.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwCommodityEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnCommodityDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbCommodity.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.Commodity.DeleteCommodity(new Guid(RUTid), 3, getConstr.ConStrCMS);
                rcbCommodity.Items.Clear();
                LoadCommodity();
            }
        }
        #endregion

        #region GOODS DESCRIPTION EVENTS

        protected void btnGoodsDescEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbGoodsDescription.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwGoodsDescEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/GoodsDescription/EditGoodsDesc.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwGoodsDescEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnGoodsDescDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbGoodsDescription.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.GoodsDescription.DeleteGoodsDesc(new Guid(RUTid), 3, getConstr.ConStrCMS);
                rcbGoodsDescription.Items.Clear();
                LoadGoodsDescription();
            }
        }

        protected void btnGoodsDescAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwGoodsDescAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/GoodsDescription/AddGoodsDesc.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwGoodsDescAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        #endregion

        #region SBF EVENTS

        protected void btnSBFAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwSBFAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/SBF/AddSBF.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwSBFAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnSBFEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbShipmentBasicFee.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwSBFEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/SBF/EditSBF.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwSBFEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnSBFDelete_Click(object sender, EventArgs e)
        {
            string RUTid = this.rcbShipmentBasicFee.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.ShipmentBasicFee.DeleteShipmentBasicFee(getConstr.ConStrCMS, new Guid(RUTid));
                rcbShipmentBasicFee.Items.Clear();
                LoadShipmentBasicFee();
            }
        }
        #endregion

        #region CRATING EVENTS

        protected void btnCratingAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwCratingAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Crating/AddCrating.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwCratingAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCratingEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbCrating.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwCratingEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Crating/EditCrating.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwCratingEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnCratingDelete_Click(object sender, EventArgs e)
        {
            String RUTid = this.rcbCrating.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.Crating.DeleteCrating(new Guid(RUTid), getConstr.ConStrCMS);
                rcbCrating.Items.Clear();
                LoadCrating();
            }
        }
        #endregion

        #region PACKAGING EVENTS

        protected void btnPackagingAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";

            rwPackagingAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Packaging/AddPackaging.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwPackagingAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnPackagingEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbPackaging.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwPackagingEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Packaging/EditPackaging.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwPackagingEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnPackagingDelete_Click(object sender, EventArgs e)
        {
            String RUTid = this.rcbPackaging.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.Packaging.DeletePacking(new Guid(RUTid), getConstr.ConStrCMS);
                rcbPackaging.Items.Clear();
                LoadPackaging();
            }
        }
        #endregion

        #region SERVICE TYPE EVENTS


        protected void btnServiceTypeDelete_Click(object sender, EventArgs e)
        {
            String RUTid = this.rcbServiceType.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.ServiceType.DeleteServiceType(new Guid(RUTid), getConstr.ConStrCMS);
                rcbServiceType.Items.Clear();
                ServiceType();

            }
        }

        protected void btnServiceTypeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbServiceType.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwServiceTypeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ServiceType/EditServicesType.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwServiceTypeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnServiceTypeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwServiceTypeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ServiceType/AddServiceType.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwServiceTypeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        #endregion

        #region SERVICE MODE EVENTS

        protected void btnServiceModeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaId = "";
            rwServiceModeAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ServiceMode/AddServiceMode.aspx?ID=" + AreaId;
            string script = "function f(){$find(\"" + rwServiceModeAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnServiceModeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string RUTid = this.rcbServiceMode.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                rwServiceModeEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ServiceMode/EditServiceMode.aspx?ID=" + RUTid;
                string script = "function f(){$find(\"" + rwServiceModeEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
        }

        protected void btnServiceModeDelete_Click(object sender, EventArgs e)
        {
            String RUTid = this.rcbServiceMode.SelectedItem.Value.ToString();
            if (RUTid != "")
            {
                BLL.ServiceMode.DeleteServiceMode(new Guid(RUTid), getConstr.ConStrCMS);
                rcbServiceMode.Items.Clear();
                //ServiceType();
                ServiceMode();
            }
        }
        #endregion

        #region BOOKING STATUS EVENTS
        protected void bookingStatusAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string bookingStatusID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BookingStatus/AddBookingStatus.aspx?ID=" + bookingStatusID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void bookingStatusEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string bookingStatusId = this.rcbBookingStatus.SelectedItem.Value.ToString();

            if (bookingStatusId != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BookingStatus/EditBookingStatus.aspx?ID=" + bookingStatusId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void bookingStatusDelete_Click(object sender, EventArgs e)
        {
            string bookingStatus = this.rcbBookingStatus.SelectedItem.Value.ToString();

            if (bookingStatus != "")
            {
                BLL.BookingStatus.DeleteBookingStatus(new Guid(bookingStatus), getConstr.ConStrCMS);
                rcbBookingStatus.Items.Clear();
                BookingStatus();
            }
        }
        #endregion

        #region BOOKING REMARKS EVENTS

        protected void bookingRemarkAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string bookingremarkId = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BookingRemark/AddBookingRemark.aspx?ID=" + bookingremarkId;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void bookingRemarkEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string bookingremarkId = this.rcbBookingRemarks.SelectedItem.Value.ToString();

            if (bookingremarkId != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BookingRemark/EditBookingRemark.aspx?ID=" + bookingremarkId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void bookingRemarkDelete_Click(object sender, EventArgs e)
        {
            string bookingremarks = this.rcbBookingRemarks.SelectedItem.Value.ToString();

            if (bookingremarks != "")
            {
                BLL.BookingRemark.DeleteBookingRemark(new Guid(bookingremarks), getConstr.ConStrCMS);
                rcbBookingRemarks.Items.Clear();
                BookingRemark();
            }
        }
        #endregion

        #region SHIPMODE EVENTS
        protected void ShipModeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string shipmodeId = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ShipMode/AddShipMode.aspx?ID=" + shipmodeId;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void ShipModeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string shipmodeId = this.rcbShipMode.SelectedItem.Value.ToString();

            if (shipmodeId != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/ShipMode/EditShipMode.aspx?ID=" + shipmodeId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void ShipModeDelete_Click(object sender, EventArgs e)
        {
            string shipmodeid = this.rcbShipMode.SelectedItem.Value.ToString();

            if (shipmodeid != "")
            {
                BLL.ShipMode.DeleteShipMode(new Guid(shipmodeid), getConstr.ConStrCMS);
                rcbShipMode.Items.Clear();
                ShipMode();
            }
        }
        #endregion

        #region PAYMENT TERM EVENTS
        protected void PaymentTermAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string PaymentTermId = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/PaymentTerm/AddPaymentTerm.aspx?ID=" + PaymentTermId;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void PaymentTermEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string PaymentTermId = this.rcbPaymentTerm.SelectedItem.Value.ToString();

            if (PaymentTermId != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/PaymentTerm/EditPaymentTerm.aspx?ID=" + PaymentTermId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void PaymentTermDelete_Click(object sender, EventArgs e)
        {
            string paymentTermId = this.rcbPaymentTerm.SelectedItem.Value.ToString();

            if (paymentTermId != "")
            {
                BLL.PaymentTerm.DeletePaymentTerms(new Guid(paymentTermId), getConstr.ConStrCMS);
                rcbPaymentTerm.Items.Clear();
                PaymentTerm();
            }
        }
        #endregion

        #region PAYMENT MODE EVENTS
        protected void PaymentModeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string PaymentModeId = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/PaymentMode/AddPaymentMode.aspx?ID=" + PaymentModeId;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void PaymentModeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string PaymentModeId = this.rcbPaymentMode.SelectedItem.Value.ToString();

            if (PaymentModeId != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/PaymentMode/EditPaymentMode.aspx?ID=" + PaymentModeId;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void PaymentModeDelete_Click(object sender, EventArgs e)
        {
            string paymentModeId = this.rcbPaymentMode.SelectedItem.Value.ToString();

            if (paymentModeId != "")
            {
                BLL.PaymentMode.DeletePaymentModeByID(new Guid(paymentModeId), getConstr.ConStrCMS);
                rcbPaymentMode.Items.Clear();
                PaymentMode();
            }
        }

        #endregion

        #region DELIVERY STATUS EVENTS
        protected void DeliveryStatusAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/DeliveryStatus/AddDeliveryStatus.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void DeliveryStatusEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbDeliveryStatus.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/DeliveryStatus/EditDeliveryStatus.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void DeliveryStatusDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbDeliveryStatus.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.DeliveryStatus.DeleteDeliveryStatus(new Guid(ID), getConstr.ConStrCMS);
                rcbDeliveryStatus.Items.Clear();
                DeliveryStatus();
            }
        }

        #endregion

        #region DELIVERY REMARKS EVENTS
        protected void DeliveryRemarksAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/DeliveryRemark/AddDeliveryRemark.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void DeliveryRemarksEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbDeliverRemark.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/DeliveryRemark/EditDeliveryRemark.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void DeliveryRemarksDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbDeliverRemark.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.DeliveryRemarks.DeleteDeliveryRemarks(new Guid(ID), getConstr.ConStrCMS);
                rcbDeliverRemark.Items.Clear();
                DeliveryRemarks();
            }
        }

        #endregion

        #region ACCOUNT TYPE EVENTS
        protected void AccountTypeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/AccountType/AddAccountType.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void AccountTypeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbAccountType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/AccountType/EditAccountType.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void AccountTypeDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbAccountType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.AccountType.DeleteAccountType(new Guid(ID), getConstr.ConStrCMS);
                rcbAccountType.Items.Clear();
                LoadAccountType();
            }
        }

        #endregion

        #region ACCOUNT STATUS EVENTS
        protected void AccountStatusAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/AccountStatus/AddAccountStatus.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void AccountStatusEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbAccountStatus.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/AccountStatus/EditAccountStatus.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void AccountStatusDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbAccountStatus.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.AccountStatus.DeleteAccountStatus(new Guid(ID), getConstr.ConStrCMS);
                rcbAccountStatus.Items.Clear();
                LoadAccountStatus();
            }
        }

        #endregion

        #region BUSINESS TYPE EVENTS
        protected void BusinessTypeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BusinessType/AddBusinessType.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void BusinessTypeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbBusinessType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/BusinessType/AddBusinessType.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void BusinessTypeDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbBusinessType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.BusinessType.DeleteBusinessType(new Guid(ID), getConstr.ConStrCMS);
                rcbBusinessType.Items.Clear();
                LoadBusinessType();
            }
        }

        #endregion

        #region ORGANIZATION TYPE EVENTS
        protected void OrganizationTypeAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/OrganizationType/AddOrganizationType.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void OrganizationTypeEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbOrganizationType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/OrganizationType/EditOrganizationType.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void OrganizationTypeDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbOrganizationType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.OrganizationType.DeleteOrganizationType(new Guid(ID), getConstr.ConStrCMS);
                rcbOrganizationType.Items.Clear();
                LoadOrganizationType();
            }
        }

        #endregion

        #region INDUSTRY EVENTS
        protected void IndustryAdd_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = "";

            rwProvinceAdd.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Industry/AddIndustry.aspx?ID=" + ID;
            string script = "function f(){$find(\"" + rwProvinceAdd.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void IndustryEdit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string ID = this.rcbOrganizationType.SelectedItem.Value.ToString();

            if (ID != "")
            {
                rwProvinceEdit.NavigateUrl = "http://" + host + "/" + WebPathName + "/portal/UserModal/Industry/EditIndustry.aspx?ID=" + ID;
                string script = "function f(){$find(\"" + rwProvinceEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void IndustryDelete_Click(object sender, EventArgs e)
        {
            string ID = this.rcbIndustry.SelectedItem.Value.ToString();

            if (ID != "")
            {
                BLL.Industry.DeleteIndsutry(new Guid(ID), getConstr.ConStrCMS);
                rcbIndustry.Items.Clear();
                LoadIndustry();
            }
        }

        #endregion
    }
}