<%@ Page Title="Wt by Commodity" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FLM_Wtby_Commodity.aspx.cs" Inherits="CMSVersion2.Report.FLM.FLM_Wtby_Commodity" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>Quantity by Commodity</h3>
                <ol class="breadcrumb">
                    <li>FLM</li>
                    <li>Weight by Commodity</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

            <div class="row">
                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;


                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true" 
                    AppendDataBoundItems="true" Width="260px" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" OnClick="Search_Click" 
                    Skin="Glow" AutoPostBack="true"> </telerik:RadButton>

                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
                
            </div>            
            <br />

            <div class="row">
                
                <telerik:RadGrid ID="grid_QtyByCommodity" runat="server" Skin="Glow"
                    AllowPaging="True" ShowFooter="true"
                    PageSize="10" OnNeedDataSource="grid_QtyByCommodity_NeedDataSource"
                    AllowFilteringByColumn="false" OnPreRender="grid_QtyByCommodity_PreRender"
                    AutoGenerateColumns="false"                    
                    AllowSorting="true">

                    <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" 
                            ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                       
                        <Columns>
                            <telerik:GridBoundColumn DataField="CityName" HeaderText="Destination" FooterText="Total: "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_0" HeaderText="A. General Cargo" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_1" HeaderText="C. Valuable Cargo" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_2" HeaderText="D. Dangerous Cargo"  Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_3" HeaderText="E. Perishable Cargo" Aggregate="Sum"   FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_4" HeaderText="F. Courier - SAP" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_5" HeaderText="G. Courier - MAP"  Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_6" HeaderText="H. Courier - LAP" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_7" HeaderText="I. Courier - NSAP" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_8" HeaderText="J. Courier - NMAP" Aggregate="Sum"  FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Col_9" HeaderText="K. Courier - NLAP" Aggregate="Sum"   FooterText=" "></telerik:GridBoundColumn>
                            
                            <telerik:GridCalculatedColumn HeaderText="TOTAL" DataType="System.Double" DataFields="Col_0,Col_1,Col_2,Col_3,Col_4,Col_5,Col_6,Col_7,Col_8,Col_9" Expression="{0}+{1}+{2}+{3}+{4}+{5}+{6}+{7}+{8}+{9}" FooterText=" " Aggregate="Sum">
                            </telerik:GridCalculatedColumn>
                            
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
