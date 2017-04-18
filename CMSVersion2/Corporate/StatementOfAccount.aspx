<%@ Page Title="Statement Of Account" Language="C#" MasterPageFile="~/cmsversion.master" AutoEventWireup="true" CodeFile="StatementOfAccount.aspx.cs" Inherits="portal_StatementOfAccount" %>

<%@ MasterType VirtualPath="~/cmsversion.master" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../styles/default.css" rel="stylesheet" />
      <style type="text/css">
        .alink{
            text-decoration:none !important;
            color:#c1c7ca !important;
        }

        .alink:hover{
            text-decoration:none !important;
            color:#c1c7ca !important;
        }
        .center {
            text-align: center;
        }
          </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">


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
                <!-- /.row -->

                <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchUser" EmptyMessage="Search "
                        OnSearch="radSearchUser_Search" Width="300"
                        DataKeyNames="StatementOfAccountId"
                        DataTextField="StatementOfAccountNo"
                        DataValueField="StatementOfAccountId"
                        EnableAutoComplete="true"
                        ShowSearchButton="false" Skin="Glow">
                        <DropDownSettings Width="300" />
                    </telerik:RadSearchBox>

                </div>
                <br />
                <telerik:LayoutColumn HiddenMd="true" HiddenSm="true" HiddenXs="true">
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

                        <telerik:RadGrid ID="RadGrid2" OnItemCreated="RadGrid2_ItemCreated"
                            runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                            PageSize="10" Skin="Glow" AllowSorting="true" OnItemCommand="RadGrid2_ItemCommand1"
                            AllowFilteringByColumn="true"
                            DataKeyNames="StatementOfAccountId" CommandItemDisplay="Top"
                            OnNeedDataSource="RadGrid2_NeedDataSource">
                            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>

                            <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="StatementOfAccountId"
                                AllowFilteringByColumn="false"
                                DataKeyNames="StatementOfAccountId" CommandItemDisplay="Top"
                                InsertItemPageIndexAction="ShowItemOnFirstPage">

                                <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                    ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                <Columns>

                                    <telerik:GridBoundColumn DataField="AccountNo" HeaderText="Account #" SortExpression="AccountnNo"
                                        UniqueName="AccountNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        <HeaderStyle />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName"
                                        UniqueName="CompanyName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        <HeaderStyle />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="BillingPeriodName" HeaderText="Billing Period" SortExpression="BillingPeriodName"
                                        UniqueName="BillingPeriod" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        <HeaderStyle />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="StatementOfAccountNo" HeaderText="SOA #" SortExpression="StatementOfAccountNor"
                                        UniqueName="SOANo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        <HeaderStyle />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridDateTimeColumn DataField="StatementOfAccountDate" HeaderText="SOA Date" SortExpression="StatementOfAccountDate"
                                        UniqueName="StatementOfAccountDate" FilterControlWidth="120px"
                                        PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                    </telerik:GridDateTimeColumn>

                                    <telerik:GridTemplateColumn UniqueName="Details" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# Eval("StatementOfAccountId", "~/portal/UserModal/StatementOfAccount/StatementOfAccountDetails.aspx?StatementOfAccountId={0}") %>' Text="Details"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn UniqueName="Adjustment" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="AdjustmentLink" runat="server" Text="Make Adjustment"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                </Columns>

                                <CommandItemTemplate>
                                    <div class="center" style="align-content: center; text-align: center">
                                        |

                                         <a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../images/emblem.png" alt="Add New User" width="20">
                                             Generate New SOA
                                         </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|    
                                        
                                        <a href="#" onclick="return ShowExportForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Print Preview" width="20">
                                            Print Preview
                                        </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|
                   
                                 
                                        <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                        </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnSubmit" runat="server" text="Submit" xmlns:asp="#unknown"
                                            onclick="btnSubmit_Click" style="display: none" />

                                        |
                                    </div>
                                </CommandItemTemplate>

                            </MasterTableView>
                            <ClientSettings>
                                <Selecting AllowRowSelect="true"></Selecting>
                                <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                        <br />
                        <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                            <Windows>
                                <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="450px"
                                    Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="400px"
                                    Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>


                                <telerik:RadWindow RenderMode="Mobile" ID="ShowExport" runat="server" Title="Export Report Preview" Height="590px"
                                    Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>
                            </Windows>
                        </telerik:RadWindowManager>
                    </telerik:RadAjaxPanel>
                    <telerik:RadCodeBlock runat="server">
                        <script type="text/javascript">
                            function onRequestStart(sender, args) {
                                if (args.get_eventTarget().indexOf("Button") >= 0) {
                                    args.set_enableAjax(false);
                                }
                            }
                        </script>


                        <script type="text/javascript">
                            function ShowAdjustmentForm(id, rowIndex) {
                                <%--var grid = $find("<%= RadGrid2.ClientID %>");
                                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                grid.get_masterTableView().selectItem(rowControl, true);--%>
                                window.radopen("UserModal/StatementOfAccount/AddApprovingAuthority.aspx?StatementOfAccountId=" + id, "AdjustmentForm");
                                //window.radopen("UserModal/ApprovingAuthority/AddApprovingAuthority.aspx", "AddUser");
                                return false;
                            }
                            function ShowInsertForm() {
                                window.radopen("UserModal/ApprovingAuthority/AddApprovingAuthority.aspx", "AddUser");
                                return false;
                            }

                            function ShowExportForm() {
                                window.radopen("/StatementOfAccount.aspx/#", "ShowExport");
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

                                    <%--<%--    //changed code here 
                                    var grid = $find("<%= RadGrid2.ClientID %>");
                                    var MasterTable = grid.get_masterTableView();
                                    var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                                    var key = MasterTable.getCellByColumnUniqueName(row, "UserId");  // get the value by uniquecolumnname
                                    var ID = key.innerHTML;        
                                    MasterTable.fireCommand("MyClick2",ID);        
                                --%>
                                //ShowEditForm();
                                window.radopen("UserModal/EditForm_csharp.aspx?StatementOfAccountId=" + eventArgs.getDataKeyValue("StatementOfAccountId"), "UserListDialog");
                            }

                            function LoadRadGrid() {
                                document.getElementById("btnSubmit").click();
                            }
                        </script>
                    </telerik:RadCodeBlock>
                </telerik:LayoutColumn>
            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
</asp:Content>

