<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AWBDetailedTracking.aspx.cs" Inherits="CMSVersion2.Report.AWBDetailedTracking" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h3>AWB Detailed Tracking</h3>
                    <hr />
                </div><!--col-lg-12-->
            </div><!--row1-->
             <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
            <div class="row">
                <div class="col-md-12">
                    <telerik:RadLabel ID="a" runat="server" Text="Airway Bill:" Font-Bold="true"></telerik:RadLabel>
                    <telerik:RadTextBox ID="txtAwbNo" runat="server" Width="230px"></telerik:RadTextBox>
                    <telerik:RadButton ID="btnSearchAwbNo" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearchAwbNo_Click"></telerik:RadButton>
                </div>
            </div><!--row2-->
            <br />
             <div class="row">
                 <div class="col-md-12">
                     <div class="col-md-4">
                         <telerik:RadLabel ID="lblAwb" runat="server" Text="Airway Bill:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtAwb" runat="server" Width="50%"></telerik:RadLabel>

                         <telerik:RadLabel ID="lblShipper" runat="server" Text="Shipper:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtShipper" runat="server" Width="50%"></telerik:RadLabel>   
                        
                         <telerik:RadLabel ID="lblConsignee" runat="server" Text="Consignee:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtConsignee" runat="server" Width="50%"></telerik:RadLabel>  
                         
                         <telerik:RadLabel ID="lblPayMode" runat="server" Text="PayMode:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtPayMode" runat="server" Width="50%"></telerik:RadLabel>  
                         
                         <telerik:RadLabel ID="Commodity" runat="server" Text="Commodity:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtCommodity" runat="server" Width="50%"></telerik:RadLabel>    
                        
                     </div><!--col-md-4(1)-->
                     <div class="col-md-4">
                         <telerik:RadLabel ID="RadLabel1" runat="server" Width="30%"></telerik:RadLabel>
                         <telerik:RadLabel ID="RadLabel2" runat="server" Width="50%"></telerik:RadLabel>

                         <telerik:RadLabel ID="lblOrigin" runat="server" Text="Origin:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtOrigin" runat="server" Width="50%"></telerik:RadLabel>

                         <telerik:RadLabel ID="lblDestination" runat="server" Text="Destination:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtDestination" runat="server" Width="50%"></telerik:RadLabel>

                         <telerik:RadLabel ID="lblQuantity" runat="server" Text="Quantity:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                         <telerik:RadLabel ID="txtQuantity" runat="server" Width="50%"></telerik:RadLabel>
                     </div><!--col-md-4(2)-->
                 </div><!--col-md-12-->
            </div><!--row3-->
            <br />
            <div class="row">
                      <telerik:RadGrid ID="radGridAwbNo" runat="server" Skin="Glow"
                        AllowPaging="True" ShowFooter="true"
                        PageSize="20"
                        AllowFilteringByColumn="false" 
                        AutoGenerateColumns="false">

                           <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                               <CommandItemSettings ShowExportToExcelButton="false" 
                                    ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                                    ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                                    ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                               <FilterItemStyle VerticalAlign="Top" />

                               <Columns>
                                   <telerik:GridBoundColumn HeaderText="Time" DataField="Time" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Status" DataField="Status" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Location" DataField="Location" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="User" DataField="User" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="Ref1" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="Ref2" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="Ref3" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="Ref4" ></telerik:GridBoundColumn>
                                   
                                
                                  

                               </Columns>
                               <FooterStyle Font-Bold="true" VerticalAlign="Middle" HorizontalAlign="Center"  />

                               <GroupByExpressions>
                                 <telerik:GridGroupByExpression>
                                     <GroupByFields>
                                         <telerik:GridGroupByField FieldName="Date" HeaderText="Date" />
                                     </GroupByFields>
                                     <SelectFields>
                                         <telerik:GridGroupByField FieldName="Date" HeaderText="Date" FormatString="{0:D}" />
                                     </SelectFields>
                                 </telerik:GridGroupByExpression>
                                </GroupByExpressions>
                           </MasterTableView>


                       </telerik:RadGrid>
                 </div><!--row4-->
        </div><!--container-->
    </div><!--"page-wrapper-->
</div><!--wrapper-->
</asp:Content>
