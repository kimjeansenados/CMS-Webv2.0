using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Administration.EmployeeModal
{
    public partial class Edit : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadDepartment();
                LoadPosition();
                LoadBranchCorporateOffice();
                LoadRevenueUnitType();
                PopulateRevenueUnitName();
                if (Request.QueryString["EmployeeId"] == null)
                {

                }
                else
                {
                    string EmployeeId = Request.QueryString["EmployeeId"].ToString();


                    DataTable Data = GetEmployeeInfo(new Guid(EmployeeId));
                    int counter = 0;
                    foreach (DataRow row in Data.Rows)
                    {
                        if (counter == 0)
                        {
                            try
                            {
                                RadComboBoxItem item = rcbDepartment.FindItemByValue(row["DepartmentId"].ToString());
                                item.Selected = true;
                                RadComboBoxItem item1 = rcbPosition.FindItemByValue(row["PositionId"].ToString());
                                item1.Selected = true;
                                RadComboBoxItem bcoId = rcbBranchCorpOffice.FindItemByValue(row["BranchCorpOfficeId"].ToString());
                                bcoId.Selected = true;
                                RadComboBoxItem revenueUnitTypeId = rcbRevenueUnitType.FindItemByValue(row["RevenueUnitTypeId"].ToString());
                                revenueUnitTypeId.Selected = true;
                                RadComboBoxItem RevenueUnitId = rcbRevenueUnitName.FindItemByValue(row["RevenueUnitId"].ToString());
                                RevenueUnitId.Selected = true;

                                string bdate = row["Birthdate"].ToString();
                                string licenseExp = row["DriversLicenseExpiration"].ToString();

                                txtBirthdate.SelectedDate = Convert.ToDateTime(bdate);
                                txtLicenseExpiration.SelectedDate = Convert.ToDateTime(licenseExp);


                                txtFirstname.Text = row["FirstName"].ToString();
                                txtLastname.Text = row["Lastname"].ToString();
                                txtMiddlename.Text = row["Middlename"].ToString();
                                //txtBirthdate.Text = row["Birthdate"].ToString();
                                txtTel.Text = row["ContactNo"].ToString();
                                txtMobile.Text = row["Mobile"].ToString();
                                txtEmail.Text = row["Email"].ToString();
                                txtLicense.Text = row["DriversLicenseNo"].ToString();
                                //txtLicenseExpiration.Text = row["DriversLicenseExpiration"].ToString();
                                //txtLicenseExpiration.Text = row["DriversLicenseExpiration"].ToString();

                                lblEmployeeID.Text = row["EmployeeId"].ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }



                            counter++;
                        }
                    }

                }
            }
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Employee";
        }

        public DataTable GetEmployeeInfo(Guid ID)
        {
            DataSet data = BLL.Employee_Info.GetEmployeeById(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public void LoadDepartment()
        {
            DataTable data = BLL.Department.GetDepartment(getConstr.ConStrCMS).Tables[0];
            rcbDepartment.DataSource = data;
            rcbDepartment.DataTextField = "DepartmentName";
            rcbDepartment.DataValueField = "DepartmentId";
            rcbDepartment.DataBind();
        }

        public void LoadPosition()
        {
            DataTable data = BLL.Position.GetPosition(getConstr.ConStrCMS).Tables[0];
            rcbPosition.DataSource = data;
            rcbPosition.DataTextField = "PositionName";
            rcbPosition.DataValueField = "PositionId";
            rcbPosition.DataBind();
        }

        private void LoadBranchCorporateOffice()
        {
            DataTable bcoList = BLL.Revenue_Info.getBranchCorp(getConstr.ConStrCMS).Tables[0];
            rcbBranchCorpOffice.DataSource = bcoList;
            rcbBranchCorpOffice.DataTextField = "BranchCorpOfficeName";
            rcbBranchCorpOffice.DataValueField = "BranchCorpOfficeId";
            rcbBranchCorpOffice.DataBind();

        }

        private void LoadRevenueUnitType()
        {
            DataTable revenueUnitTypeList = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitType.DataSource = revenueUnitTypeList;
            rcbRevenueUnitType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueUnitType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueUnitType.DataBind();
        }

        private void PopulateRevenueUnitName()
        {
            DataTable revenueUnitName = BLL.Revenue_Info.getRevenueUnit(new Guid(rcbRevenueUnitType.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitName.DataSource = revenueUnitName;
            rcbRevenueUnitName.DataTextField = "RevenueUnitName";
            rcbRevenueUnitName.DataValueField = "RevenueUnitId";
            rcbRevenueUnitName.DataBind();
        }

        private void populateRevenueUnitNameByBCO()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(rcbRevenueUnitType.SelectedValue.ToString()), new Guid(rcbBranchCorpOffice.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitName.DataSource = LocationList;
            rcbRevenueUnitName.DataTextField = "RevenueUnitName";
            rcbRevenueUnitName.DataValueField = "RevenueUnitId";
            rcbRevenueUnitName.DataBind();
        }

        protected void rcbBranchCorpOffice_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueUnitType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //PopulateRevenueUnitName();
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueUnitType_TextChanged(object sender, EventArgs e)
        {
            rcbRevenueUnitName.Items.Clear();
            //PopulateRevenueUnitName();
            populateRevenueUnitNameByBCO();
        }


        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            }
            else if (e.CommandName == "Insert")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //logic to truncate long string to prevent SQL error
            for (int i = 1; i < 4; i++)
            {
                string val = e.NewValues[i - 1].ToString();
                int maxLength = i * 10;
                if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
            }
        }

        protected void DetailsView1_ItemCommand1(object sender, DetailsViewCommandEventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating1(object sender, DetailsViewUpdateEventArgs e)
        {

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            BLL.Employee_Info.UpdateEmployee(new Guid(lblEmployeeID.Text), Guid.Parse(rcbDepartment.SelectedValue.ToString()), Guid.Parse(rcbPosition.SelectedValue.ToString()),
                txtFirstname.Text, txtLastname.Text, txtMiddlename.Text,
               txtBirthdate.SelectedDate.Value, txtTel.Text, txtMobile.Text, txtEmail.Text, txtLicense.Text, txtLicenseExpiration.SelectedDate.Value, ID,
                Guid.Parse(rcbRevenueUnitName.SelectedValue.ToString()), getConstr.ConStrCMS);
            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);



        }
    }
}