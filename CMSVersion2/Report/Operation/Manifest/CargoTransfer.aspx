<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargoTransfer.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.CargoTransfer" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("Are you sure you want to submit the page?"));
        }

        function RefreshParentPage()//function in parent page
        {
            document.location.reload();
        }
    </script>

    <style>
        div.RadUpload .ruBrowse {
            background-position: 0 -23px;
            width: 180px;
            height: 30px;
        }

        div.RadUpload_Default .ruFileWrap .ruButtonHover {
            background-position: 100% -23px !important;
        }
    </style>

<div class="wrapper">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>CARGO TRANSFER</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Cargo Transfer</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>


            <div class="row">

                <telerik:RadLabel runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                </telerik:RadDatePicker>                
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Origin:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Origin" runat="server" Skin="Glow" AutoPostBack="true"
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="Branch Corp Office" />
                        <telerik:RadComboBoxItem Text="Branch Satellite Office" />
                    </Items>
                </telerik:RadComboBox>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="BCO/City:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="250px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Destination:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Destination" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
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
                    Height="400px">

                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>


                    </MasterTableView>
                </telerik:RadGrid>
                <br />              
            </div>
        </div>
    </div>
</div>
</asp:Content>
