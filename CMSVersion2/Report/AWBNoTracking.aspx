﻿<%@ Page Title="AWB Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AWBNoTracking.aspx.cs" Inherits="CMSVersion2.Report.AWBNoTracking" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h3>AWB Tracking</h3>
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
                     </div><!--col-md-4(1)-->
                 </div><!--col-md-12-->
            </div><!--row3-->
            <br />
            <div class="row">
                      <telerik:RadGrid ID="radGridAwbNoTracking" runat="server" Skin="Glow"
                        AllowPaging="True"
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
                                   <telerik:GridBoundColumn HeaderText="Date" DataField="Date" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Time" DataField="Time" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Status" DataField="Status" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Location" DataField="Location" ></telerik:GridBoundColumn>
                                  
                               </Columns>

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
            <br />
                 <div class="row">
                        <telerik:RadLabel ID="lblReceivedBy" runat="server" Text="Received By:" Font-Bold="true" Visible="false"></telerik:RadLabel>
                       <a href="#" runat="server" onClick="handleHyperLinkClick();" visible="false" id="signLink"> View POD </a>
                           
                  </div><!--row4-->

            <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                            <Windows>
                               <telerik:RadWindow RenderMode="Mobile" ID="ViewSignature" runat="server" Title="POD" Height="300px"
                                    Width="400px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>
                          </Windows>
                   </telerik:RadWindowManager>

            <telerik:RadCodeBlock runat="server">
            <script type="text/javascript">
                function handleHyperLinkClick() {
                var text, newValue;

                text = document.getElementById('<%= txtAwbNo.ClientID %>')
                newValue = text.value;
                
                window.radopen("Operation/AWBNoModal/AWBTrackingModal.aspx?Id=" + newValue, "ViewSignature");
                return false;
                }
            </script>
            </telerik:RadCodeBlock>
        </div><!--container-->
    </div><!--"page-wrapper-->
</div><!--wrapper-->
</asp:Content>
