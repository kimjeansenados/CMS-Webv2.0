<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="CMSVersion2.Customer.Customer" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
   <div id="page-wrapper"  >

            <div class="container-fluid" ">

               <div class="row">
                <h3><i class="glyphicon glyphicon-user"></i> CUSTOMER</h3>
                <ol class="breadcrumb">
                    <li>Customer</li>
                </ol>
            </div>
                <!-- /.row -->
                          <telerik:LayoutColumn HiddenMd="true" HiddenSm="true" HiddenXs="true">

                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">


                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                    <telerik:AjaxSetting AjaxControlID="radgrid2">
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
                                
                                DataKeyNames="ClientId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                <ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ClientId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="ClientId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   <CommandItemSettings  ShowExportToWordButton="true" ShowExportToExcelButton="true" 
            ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridNumericColumn DataField="Name" HeaderText="Client Name" SortExpression="Name" Exportable="true"
                                            UniqueName="Name">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        
                                        <telerik:GridNumericColumn DataField="AccountNo" HeaderText="AccountNo" SortExpression="AccountNo" Exportable="true"
                                            UniqueName="AccountNo">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" Exportable="true"
                                            UniqueName="CompanyName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="CityName" HeaderText="City Name" SortExpression="CityName" Exportable="true"
                                            UniqueName="CityName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                        
                                        <telerik:GridNumericColumn DataField="BranchCorpOfficeName" HeaderText="BranchCorpOffice" SortExpression="BranchCorpOfficeName" Exportable="true"
                                            UniqueName="BranchCorpOfficeName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                       <telerik:GridDateTimeColumn DataField="ModifiedDate" HeaderText="Date Modified" SortExpression="ModifiedDate" Exportable="true"
                                            UniqueName="ModifiedDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                            <HeaderStyle />

                                        </telerik:GridDateTimeColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false" Exportable="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="EditLink" runat="server" Text="Edit"></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    <%--    <telerik:GridButtonColumn  CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>--%>
                                         <telerik:GridButtonColumn ConfirmText="Are you sure you want to deactivate this user?" ButtonType="LinkButton" Exportable="false"
                                            ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate User" 
                                             CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>
                                    </Columns>

                                   
                              
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
                                    <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="520px"
                                        Width="380px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="600px"
                                        Width="380px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move"  >
                                    </telerik:RadWindow>

                                    
                                     <telerik:RadWindow RenderMode="Mobile" ID="ShowExport" runat="server" Title="Export Report Preview" Height="590px"
                                        Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move"  >
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
                                function ShowEditForm(id, rowIndex) {
                                    var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);
                                        
                                    window.radopen("UserModal/EditForm_csharp.aspx?UserId=" + id, "UserListDialog");
                                    return false;
                                }
                                function ShowInsertForm() {
                                    //window.radopen("AddNewUser.aspx", "AddUser");
                                    return false;
                                }

                                function ShowExportForm() {
                                    window.radopen("Reports/ClientExportReport.aspx", "ShowExport");
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
                                    window.radopen("EditForm_csharp.aspx?UserID=" + eventArgs.getDataKeyValue("UserId"), "UserListDialog");
                                }
                            </script>


                        </telerik:RadCodeBlock>

                    </telerik:LayoutColumn>
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

                 
           </div>
</asp:Content>
