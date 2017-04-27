<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AWBNoTracking.aspx.cs" Inherits="CMSVersion2.Report.AWBNoTracking" %>

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
        </div><!--container-->
    </div><!--"page-wrapper-->
</div><!--wrapper-->
</asp:Content>
