<%@ Page Title="AWB Series Monitoring" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Monitoring.aspx.cs" Inherits="CMSVersion2.Maintenance.AWBSeries.Monitoring" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="wrapper">
       <div id="page-wrapper">
           <div class="container">
               <div class="row">
                <h3><i class="glyphicon glyphicon-search"></i> AWB SERIES MONITORING</h3>
                <ol class="breadcrumb">
                    <li>Maintenance</li>
                    <li>AWB Series</li>
                    <li>Monitoring</li>
                </ol>
            </div>
               <div class="row">
                   <div class="col-md-12">
                       <telerik:RadLabel ID="lblBco" runat="server" Text="BCO:"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rdcBCO" runat="server"  Width="230px" AutoPostBack="true" Skin="Glow" OnSelectedIndexChanged="rdcBCO_SelectedIndexChanged"></telerik:RadComboBox>
                      
                       <telerik:RadLabel ID="lblArea" runat="server" Text="Area:"></telerik:RadLabel>
                       <telerik:RadComboBox ID="rcbRevenueType" runat="server" Skin="Glow" AutoPostBack="true" OnTextChanged="rcbRevenueType_TextChanged" OnSelectedIndexChanged="rcbRevenueType_SelectedIndexChanged"></telerik:RadComboBox>

                       <telerik:RadComboBox ID="rdcArea" runat="server" Width="200px" Skin="Glow" AutoPostBack="true" OnSelectedIndexChanged="rdcArea_SelectedIndexChanged"></telerik:RadComboBox>
                       <telerik:RadComboBox ID="rcbName" Skin="Glow" Height="200px" runat="server" AutoPostBack="true"></telerik:RadComboBox>

                       <telerik:RadComboBox ID="rcbAwbSeries" Skin="Glow" Width="150px" Height="200px" runat="server" AutoPostBack="true"></telerik:RadComboBox>
                      <telerik:RadButton ID="btnSearchEmployee" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                </div>
               </div>
               <br />
               


               <div class="row">

                   <telerik:RadGrid runat="server" Skin="Glow" 
                    ID="radGridAwbSeriesMonitoring"
                    AllowPaging="True" 
                    PageSize="10"  
                    AllowFilteringByColumn="false" 
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                    OnNeedDataSource="radGridAwbSeriesMonitoring_NeedDataSource">
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                       <ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true" UseItemStyles="false" FileName="AWBSeriesMonitoring" Pdf-PageLeftMargin="20px" Pdf-PageRightMargin="20px"> 
                        <Pdf ForceTextWrap="true" PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="100px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                        <Excel  Format="Xlsx"/>
                    </ExportSettings>      

                        <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                            <CommandItemSettings ShowExportToExcelButton="false" ShowExportToPdfButton="true" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                            
                            <Columns>
                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="AirwayBillNo" HeaderText="AWB"></telerik:GridBoundColumn>

                                <telerik:GridDateTimeColumn
                                 DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" UniqueName="CreatedDate" FilterControlWidth="100px">
                             </telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="BranchCorpOfficeName" HeaderText="BCO"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="Area" HeaderText="Area"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="Shipper" HeaderText="Shipper"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="DestinationCity" HeaderText="Destination"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="PaymentModeName" HeaderText="Payment Mode"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="TotalAmount" HeaderText="Amount"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="EncodedBy" HeaderText="Encoded By"></telerik:GridBoundColumn>


                            </Columns>
                           
                        </MasterTableView>
                    </telerik:RadGrid><!--RadGrid - radGridAwbIssuance-->
                   <br />
               </div><!--row-->
           </div><!--container-->
       </div><!--page-wrapper-->
   </div><!--wrapper-->   

</asp:Content>
