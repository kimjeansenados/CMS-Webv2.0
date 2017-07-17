<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="CMSVersion2.Customer.Customer" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container">

                <div class="row">
                    <h3><i class="glyphicon glyphicon-user"></i>CUSTOMER</h3>
                    <ol class="breadcrumb">
                        <li>Customer</li>
                    </ol>
                </div>
                <div class="buttons">
                    <telerik:RadAsyncUpload RenderMode="Lightweight" ID="RadAsyncUpload1" runat="server"
                        OnFileUploaded="RadAsyncUpload1_FileUploaded" AllowedFileExtensions=".xls,.xlsx"
                        Skin="Glow" InputSize="150" Localization-Select="Select">
                    </telerik:RadAsyncUpload>
                    <telerik:RadLabel ID="CountUploaded" runat="server"></telerik:RadLabel>
                    <br />
                    <telerik:RadButton ID="RadButton1" runat="server" Skin="Glow" OnClick="BtnSubmit_Click" Text="Upload"></telerik:RadButton>
                    <br />
                    <br />
                </div>
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

                        <!--OnItemCreated="RadGrid2_ItemCreated"-->
                        <telerik:RadGrid ID="RadGrid2"
                            runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                            PageSize="10" Skin="Glow" AllowSorting="true"
                            OnItemCommand="RadGrid2_ItemCommand1"
                            DataKeyNames="ClientId" CommandItemDisplay="Top"
                            OnNeedDataSource="RadGrid2_NeedDataSource">
                            <ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                            <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ClientId"
                                AllowFilteringByColumn="false"
                                DataKeyNames="ClientId" CommandItemDisplay="Top"
                                InsertItemPageIndexAction="ShowItemOnFirstPage">
                                <CommandItemSettings ShowExportToWordButton="false" ShowExportToExcelButton="true" ShowExportToCsvButton="false" ShowExportToPdfButton="true"></CommandItemSettings>
                                <Columns>

                                    <telerik:GridNumericColumn DataField="Name" HeaderText="Client Name" SortExpression="Name" Exportable="true"
                                        UniqueName="Name">
                                        <HeaderStyle />
                                    </telerik:GridNumericColumn>


                                    <telerik:GridNumericColumn DataField="AccountNo" HeaderText="AccountNo" SortExpression="AccountNo" Exportable="true"
                                        UniqueName="AccountNo">
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
                                    Width="380px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
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
                            function ShowEditForm(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                grid.get_masterTableView().selectItem(rowControl, true);

                                window.radopen("CustomerModal/EditCustomer.aspx?UserId=" + id, "UserListDialog");
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
                            function fileUploaded(sender, args) {
                                document.getElementById("<%= RadButton1.ClientID %>").click();
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

                            window.radopen("EditForm_csharp.aspx?UserID=" + eventArgs.getDataKeyValue("UserId"), "UserListDialog");
                        }

                        (function () {
                            var $;
                            var demo = window.demo = window.demo || {};

                            demo.initialize = function () {
                                $ = $telerik.$;
                            };

                            window.validationFailed = function (radAsyncUpload, args) {
                                var $row = $(args.get_row());
                                var erorMessage = getErrorMessage(radAsyncUpload, args);
                                var span = createError(erorMessage);
                                $row.addClass("ruError");
                                $row.append(span);
                            }

                            function getErrorMessage(sender, args) {
                                var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
                                if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                                    if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                                        return ("This file type is not supported.");
                                    }
                                    else {
                                        return ("This file exceeds the maximum allowed size of 500 KB.");
                                    }
                                }
                                else {
                                    return ("not correct extension.");
                                }
                            }

                            function createError(erorMessage) {
                                var input = '<span class="ruErrorMessage">' + erorMessage + ' </span>';
                                return input;
                            }
                        })
                        </script>


                    </telerik:RadCodeBlock>

                </telerik:LayoutColumn>
            </div>
        </div>


    </div>
</asp:Content>
