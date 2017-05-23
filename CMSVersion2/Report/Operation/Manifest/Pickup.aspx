<%@ Page Title="Pickup Cargo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pickup.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Pickup" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>PICK UP CARGO</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Pickup Cargo</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>


            <div class="row">

                <telerik:RadLabel runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                </telerik:RadDatePicker>                
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="AWB #:"></telerik:RadLabel>
                <telerik:RadComboBox ID="AWB" runat="server" Skin="Glow" AutoPostBack="true"
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true"
                    AppendDataBoundItems="true">
                </telerik:RadComboBox>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="BCO Consignee:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="250px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;
            </div>
            <br />
            <div class="row">
                <telerik:RadLabel runat="server" Text="Area:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Area" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Checker:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Checker" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" OnClick="Search_Click" AutoPostBack="true"> </telerik:RadButton>
                <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click"> </telerik:RadButton>

            </div>

            <br />
            <div class="row">
                <telerik:RadGrid ID="gridPickupCargo" runat="server"  Skin="Glow"
                    AllowPaging="True"
                    PageSize="10"  
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="true"
                    AllowSorting="true" 
                    ExportSettings-Pdf-ForceTextWrap="false"                     
                    ClientSettings-Scrolling-AllowScroll="true"                    
                    ItemStyle-Wrap="false" 
                    Height="400px"
                    OnNeedDataSource="gridPickupCargo_NeedDataSource" 
                    OnPreRender="gridPickupCargo_PreRender">

                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                       <%-- <Columns>                           
                             <telerik:GridDateTimeColumn
                                 DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" UniqueName="CreatedDate" FilterControlWidth="80px">
                             </telerik:GridDateTimeColumn>

                             <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" FilterControlWidth="60px"
                                  DataField="AirwayBillNo" HeaderText="Airway Bill No"></telerik:GridBoundColumn>--%>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />              
            </div>
        </div>
    </div>
</div>
</asp:Content>
