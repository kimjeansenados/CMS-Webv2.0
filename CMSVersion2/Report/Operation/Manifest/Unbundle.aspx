<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Unbundle.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Unbundle" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>UNBUNDLE</h3>
                <ol class="breadcrumb">
                    <li>Manifest</li>
                    <li>Operation</li>
                    <li>Unbundle</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
            <div class="row">

                <telerik:RadLabel runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;
                 
                <telerik:RadLabel runat="server" Text="Sack #:"></telerik:RadLabel>
                 <telerik:RadComboBox ID="SackNumber" runat="server" Skin="Glow" MarkFirstMatch="true" AllowCustomText="true" 
                     AppendDataBoundItems="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="250px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" 
                    AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;


                <telerik:RadLabel runat="server" Text="Origin(City):"></telerik:RadLabel>
                 <telerik:RadComboBox ID="Origin" runat="server" Skin="Glow" MarkFirstMatch="true" AllowCustomText="true"
                     AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>
            </div>
            <br />
            <div class="row">
                <telerik:RadGrid ID="grid_Unbundle" runat="server"  Skin="Glow"
                    AllowPaging="True" ShowFooter="true" 
                    PageSize="10"  
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false"
                    AllowSorting="true" OnPreRender="grid_Unbundle_PreRender"
                    OnNeedDataSource="grid_Unbundle_NeedDataSource">    
                <ExportSettings  HideStructureColumns="true" FileName="Unbundle"
                     ExportOnlyData="true" IgnorePaging="true" UseItemStyles="true">
                    <Pdf Title="Unbundle Report" PageHeaderMargin="10px" PageTopMargin="130px"  
                        BorderType="AllBorders" BorderStyle="Thin" DefaultFontFamily="Calibri" 
                        PageTitle="Unbundle Report">
                            <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>"/>
                          </PageHeader>
                        </Pdf>
                </ExportSettings>          
                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                        <Columns>
                             <telerik:GridBoundColumn DataField="NO" HeaderText="NO"  HeaderStyle-Width="20px"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="AWB #" HeaderText="AWB #" FooterText="TOTAL:"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SACKNO" HeaderText="SACK #" Exportable="false"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SCANNED QTY" HeaderText="SCANNED QTY" ></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="DISCREPENCY QTY" HeaderText="DISCREPENCY QTY"></telerik:GridBoundColumn>                   
                             <telerik:GridBoundColumn DataField="SUBTOTAL QTY" HeaderText="TOTAL QTY" FooterText=" " Aggregate="Sum"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNED BY"></telerik:GridBoundColumn>
                        </Columns>
                        <HeaderStyle Font-Size="Smaller" Font-Bold="true" />
                        <FooterStyle Font-Bold="true" />
                        
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
        </div>
    </div>
</div>    
</asp:Content>
