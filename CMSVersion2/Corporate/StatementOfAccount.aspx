<%@ Page Title="Statement Of Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatementOfAccount.aspx.cs" Inherits="CMSVersion2.Corporate.StatementOfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">

                        <h3>STATEMENT OF ACCOUNT</h3>

                        <ol class="breadcrumb">
                            <li>Statement of Account
                            </li>
                            <li>List
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchUser" EmptyMessage="Search SOA Number"
                        OnSearch="radSearchUser_Search" Width="300"
                        DataKeyNames="StatementOfAccountId"
                        DataTextField="StatementOfAccountNo"
                        DataValueField="StatementOfAccountId"
                        EnableAutoComplete="true"
                        ShowSearchButton="false" Skin="Office2010Black"
                        DataSourceID="StatementOfAccountDataSource">

                        <DropDownSettings Width="300" />
                    </telerik:RadSearchBox>

                </div>
                <br />
                <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">

                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
                    <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="Grid" DecoratedControls="All" EnableRoundedCorners="false" />
                    <div id="Grid">
                        <telerik:RadGrid ID="RadGrid2"
                            runat="server" AllowPaging="True" Skin="Office2010Black" AllowSorting="True"
                            AllowFilteringByColumn="True"
                            DataKeyNames="CompanyId" CommandItemDisplay="Top"
                            DataSourceID="CompanyDataSource" ShowStatusBar="True"
                            OnInsertCommand="RadGrid2_InsertCommand"
                            OnItemCreated="RadGrid2_ItemCreated"
                            OnItemCommand="RadGrid2_ItemCommand">
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>

                            <MasterTableView AutoGenerateColumns="False" AllowFilteringByColumn="false"
                                CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage"
                                DataSourceID="CompanyDataSource" DataKeyNames="CompanyId" AllowPaging="true"
                                PageSize="5" CommandItemSettings-ShowAddNewRecordButton="false" EditMode="InPlace"
                                RetainExpandStateOnRebind="true">
                                <CommandItemTemplate>
                                    <div class="center" style="align-content: center; text-align: left">
                                        <asp:Label runat="server">
                                            <img src="../Images/emblem.png" alt="" width="20" />
                                            Company Accounts
                                        </asp:Label>
                                    </div>
                                </CommandItemTemplate>
                                <DetailTables>
                                    <telerik:GridTableView Name="StatementOfAccounts" AutoGenerateColumns="false"
                                        DataKeyNames="StatementOfAccountId" DataSourceID="StatementOfAccountDataSource"
                                        Width="100%" runat="server" CommandItemDisplay="Top" AllowFilteringByColumn="false"
                                        CommandItemSettings-ShowAddNewRecordButton="false" RetainExpandStateOnRebind="true"
                                        EditMode="InPlace">
                                        <CommandItemTemplate>
                                            <div class="center" style="align-content: center; text-align: left">
                                                <asp:Label runat="server">
                                                            <img src="../Images/emblem.png" alt="" width="20" />
                                                            Statement Of Accounts
                                                </asp:Label>
                                            </div>
                                        </CommandItemTemplate>
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="CompanyId" MasterKeyField="CompanyId" />
                                        </ParentTableRelation>

                                        <DetailTables>
                                            <telerik:GridTableView Name="Shipments" DataKeyNames="ShipmentId"
                                                DataSourceID="ShipmentDataSource" Width="100%" runat="server"
                                                CommandItemDisplay="Top" AllowPaging="true" PageSize="5"
                                                AllowFilteringByColumn="false" AutoGenerateColumns="false"
                                                CommandItemSettings-ShowAddNewRecordButton="false" EditMode="InPlace"
                                                EditFormSettings-EditColumn-UpdateText="Adjust" EditFormSettings-EditColumn-CancelText="Cancel"
                                                RetainExpandStateOnRebind="true">
                                                <CommandItemTemplate>
                                                    <div class="center" style="align-content: center; text-align: left">
                                                        <asp:Label runat="server">
                                                            <img src="../Images/emblem.png" alt="" width="20" />
                                                            Shipments
                                                        </asp:Label>
                                                    </div>
                                                </CommandItemTemplate>
                                                <ParentTableRelation>
                                                    <telerik:GridRelationFields DetailKeyField="StatementOfAccountId" MasterKeyField="StatementOfAccountId" />
                                                </ParentTableRelation>

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="ShipmentId" UniqueName="ShipmentId" Visible="false"></telerik:GridBoundColumn>
                                                    <telerik:GridDateTimeColumn DataField="DateAccepted" UniqueName="DateAccepted" HeaderText="Date Accepted"></telerik:GridDateTimeColumn>
                                                    <telerik:GridBoundColumn DataField="AirwayBillNo" UniqueName="AirwayBillNo" HeaderText="AirwayBill"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Origin" UniqueName="Origin" HeaderText="Origin"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Destination" UniqueName="Destination" HeaderText="Destination"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FreightCharge" DataType="System.Decimal" UniqueName="FreightCharge" HeaderText="Freight Charge"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VatAmount" DataType="System.Decimal" UniqueName="VatAmount" HeaderText="Vat"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TotalAmount" DataType="System.Decimal" UniqueName="TotalAmount" HeaderText="Amount"></telerik:GridBoundColumn>
                                                    <telerik:GridNumericColumn DataField="Adjustment" UniqueName="Adjustment" HeaderText="Adjsustment" DataType="System.Decimal" ReadOnly="true"></telerik:GridNumericColumn>
                                                    <telerik:GridEditCommandColumn EditText="Make Adjustment" ButtonType="ImageButton"></telerik:GridEditCommandColumn>

                                                </Columns>


                                            </telerik:GridTableView>
                                        </DetailTables>

                                        <Columns>
                                            <telerik:GridBoundColumn DataField="StatementOfAccountId" UniqueName="StatementOfAccountId" Visible="false"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="StatementOfAccountDate" UniqueName="StatementOfAccountDate" HeaderText="SOA Date"></telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="StatementOfAccountNo" HeaderText="SOA No" UniqueName="SOANo" HeaderStyle-Font-Bold="true"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="BillingPeriodName" HeaderText="Billing Period" SortExpression="BillingPeriodName" UniqueName="BillingPeriod"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="SOADueDate" UniqueName="SOADueDate" HeaderText="Due Date"></telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="AmountDue" UniqueName="AmountDue" HeaderText="Amount Due"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Adjustment" DataType="System.Decimal" HeaderText="Adjustment"></telerik:GridBoundColumn>
                                            <telerik:GridEditCommandColumn EditText="Make Adjustment" ButtonType="ImageButton"></telerik:GridEditCommandColumn>
                                            <telerik:GridTemplateColumn UniqueName="Details" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# Eval("StatementOfAccountId", "~/Corporate/StatementOfAccountPrint/StatementOfAccountPrint.aspx?StatementOfAccountId={0}") %>' Text="Print"></asp:HyperLink>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                        </Columns>

                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>
                                   
                                    <telerik:GridBoundColumn DataField="CompanyId" UniqueName="CompanyId" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AccountNo" UniqueName="AccountNo" HeaderText="Account No"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CompanyName" UniqueName="CompanyName" HeaderText="Company Name"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ContactNo" UniqueName="ContactNo" HeaderText="Telephone No"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Email" UniqueName="Email" HeaderText="Email"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Address" UniqueName="Address" HeaderText="Address"></telerik:GridBoundColumn>
                                </Columns>

                            </MasterTableView>
                            <ClientSettings>
                                <Selecting AllowRowSelect="true"></Selecting>
                                <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                <ClientEvents OnRowClick="test" />
                            </ClientSettings>
                        </telerik:RadGrid>
                    </div>

                    <asp:SqlDataSource ID="CompanyDataSource" runat="server"
                        SelectCommand="sp_view_company" SelectCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="StatementOfAccountDataSource" runat="server"
                        SelectCommand="sp_view_StatementOfAccountByCompanyId" SelectCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>">
                        <SelectParameters>
                            <asp:Parameter Name="CompanyId" DbType="Guid" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="ShipmentDataSource" runat="server"
                        SelectCommand="sp_view_ShipmentBySoaId" SelectCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>">
                        <SelectParameters>
                            <asp:Parameter Name="StatementOfAccountId" DbType="Guid" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                </telerik:RadAjaxPanel>

                <telerik:RadCodeBlock runat="server">
                    <script type="text/javascript">

                        function onRequestStart(sender, args) {
                            if (args.get_eventTarget().indexOf("Button") >= 0) {
                                args.set_enableAjax(false);
                            }
                        }

                        function test(sender, args) {


                            var item = args.get_item();
                            var name = item.get_owner().get_name();
                            alert("dfhdj " + name + " is in edit mode = " + item.get_isInEditMode());
                            if (name == "Shipments") {

                                alert("Record " + item.get_itemIndex() + " is in edit mode. and name is " + name);

                            }
                        }
                        function Rebind(sender, args, tableViewId) {
                            var tableView = $find(tableViewId);
                            var columns = tableview.get_colums();

                            for (var i = 0; i < columns.length; i++) {

                                var uniqueName = colums[i].get_uniqueName();
                                if (uniqueName == "Adjustment") {
                                    columns[i].ReadOnly = false;
                                } else {
                                    columns[i].ReadOnly = true;
                                }
                            }
                            tableView.Rebind();
                        };

                        function ShowAdjustmentForm(id, rowIndex) {
                            window.radopen("StatementOfAccountAdjustment/AddStatementOfAccountAdjustment.aspx?StatementOfAccountId=" + id, "AdjustmentListDialog");
                            return false;
                        }

                        function refreshGrid(arg) {
                            if (!arg) {
                                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                            }
                            else {
                                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                            }
                        }
                        function RowDblClick(sender, eventArgs) {
                            window.radopen("UserModal/EditForm_csharp.aspx?StatementOfAccountId=" + eventArgs.getDataKeyValue("StatementOfAccountId"), "UserListDialog");
                        }

                    </script>
                </telerik:RadCodeBlock>

            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
</asp:Content>
