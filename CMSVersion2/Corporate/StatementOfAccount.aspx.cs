using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate
{
    public partial class StatementOfAccount : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        private DataTable DataSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            //DataSource = GetStatementOfAccounts();
            //radSearchUser.DataSource = DataSource;
            //radSearchUser.DataTextField = "StatementOfAccountNo";
            //radSearchUser.DataValueField = "StatementOfAccountId";

            //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //{
            //    string usersession = Session["UsernameSession"].ToString();
            //}
        }

        public DataTable GetStatementOfAccounts()
        {
            DataSet data = BLL.StatementOfAccount.GetAll(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetStatementOfAccountsByID()
        {
            DataSet data = BLL.StatementOfAccount.GetAll(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    HyperLink adjustLink = (HyperLink)e.Item.FindControl("AdjustmentLink");
            //    adjustLink.Attributes["href"] = "javascript:void(0);";
            //    adjustLink.Attributes["onclick"] = String.Format("return ShowAdjustmentForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StatementOfAccountId"], e.Item.ItemIndex);

            //}

            //if (e.Item is GridNestedViewItem)
            //{
            //    e.Item.FindControl("InnerContainer").Visible = true;
            //}
        }
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.MasterTableView.CurrentPageIndex = RadGrid2.MasterTableView.PageCount - 1;
                RadGrid2.Rebind();
            }
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = DataSource;
        }
        protected void radSearchUser_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string SOAnumber = string.Empty;

            if (e.DataItem != null)
            {
                SOAnumber = e.Text;

                RadGrid2.DataSource = DataSource.AsEnumerable().Where(x => x.Field<String>("StatementOfAccountNo").Contains(SOAnumber));
                RadGrid2.DataBind();

            }
            else
            {
                RadGrid2.DataSource = DataSource;
                RadGrid2.DataBind();
            }
        }
        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit" && e.Item.OwnerTableView.Name == "Shipments")
            {
                (e.Item.OwnerTableView.Columns[0] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[1] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[2] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[3] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[4] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[5] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[6] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[7] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[8] as GridBoundColumn).ReadOnly = false;

                e.Item.OwnerTableView.RetainExpandStateOnRebind = true;
                e.Item.OwnerTableView.Rebind();

            }
            else if (e.CommandName == "Edit" && e.Item.OwnerTableView.Name == "StatementOfAccounts")
            {
                (e.Item.OwnerTableView.Columns[0] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[1] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[2] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[3] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[4] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[5] as GridBoundColumn).ReadOnly = true;

                e.Item.OwnerTableView.RetainExpandStateOnRebind = true;
                e.Item.OwnerTableView.Rebind();
            }
        }
        protected void RadGrid2_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = DataSource;
            RadGrid2.Rebind();
        }
        #endregion        
        protected void RadGrid2_InsertCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.Item.OwnerTableView.Name)
            {
                case "StatementOfAccounts":
                    GridDataItem company = (GridDataItem)e.Item.OwnerTableView.ParentItem;
                    StatementOfAccountDataSource.SelectParameters["CompanyId"].DefaultValue = company.OwnerTableView.DataKeyValues[company.ItemIndex]["CompanyId"].ToString();
                    break;
                case "Shipments":
                    GridDataItem statementOfAccount = (GridDataItem)e.Item.OwnerTableView.ParentItem;
                    ShipmentDataSource.SelectParameters["StatementOfAccountId"].DefaultValue = statementOfAccount.OwnerTableView.DataKeyValues[statementOfAccount.ItemIndex]["StatementOfAccountId"].ToString();
                    break;
                default:
                    break;
            }
        }
    }
}