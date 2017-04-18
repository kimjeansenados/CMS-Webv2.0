<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdjustment.aspx.cs" EnableEventValidation="false" Inherits="_AddAdjustment" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Adjustment Form</title>
    <meta name="viewport" content="width=device-width, initial-scale=20" />


    <!-- Website CSS style -->
    <%--<link rel="stylesheet" type="text/css" href="assets/css/main.css" />--%>
    <link href="../../../font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Website Font style -->

    <link href="../../../css/bootstrap.css" rel="stylesheet" />
    <!-- Google Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Passion+One' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Oxygen' rel='stylesheet' type='text/css' />

    <style type="text/css">
        /*
/* Created by Filipe Pina
 * Specific styles of signin, register, component
 */
        http://localhost:54977/font-awesome/css/font-awesome.min.css
        /*
 * General styles
 */
        body, html {
            height: 100%;
            background-repeat: no-repeat;
            background-color: #fff;
            font-family: 'Oxygen', sans-serif;
            overflow: hidden;
        }

        .main {
            margin-top: 70px;
        }

        h1.title {
            font-size: 50px;
            font-family: 'Passion One', cursive;
            font-weight: 400;
        }

        /*hr {
            width: 10%;
            color: #fff;
        }*/

        /*.form-group {
            margin-bottom: 15px;
        }*/

        /*label {
            margin-bottom: 15px;
        }*/

        input,
        input::-webkit-input-placeholder {
            font-size: 11px;
            padding-top: 3px;
        }

        .main-login {
            background-color: #fff;
            /* shadows and rounded borders */
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
        }

        .main-center {
            margin-top: 30px;
            margin: 0 auto;
            max-width: 330px;
            padding: 40px 40px;
        }

        .login-button {
            margin-top: 5px;
        }

        .login-register {
            font-size: 11px;
            text-align: center;
        }

        input:required:hover {
            opacity: 1;
        }

        #footer {
            position: fixed;
            right: 0;
            bottom: 0;
        }

        .page {
            margin-top: 30px;
            margin-right: 15px;
            margin-left: 15px;
        }
    </style>
    <script type="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;//IE (and Moz az well)
            return oWindow;
        }

        function CloseOnReload() {
            //GetRadWindow().Close();
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;
        }

        function RefreshParentPage() {
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;

        }
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator2" runat="server" Skin="Default" DecoratedControls="All" />

        <div class="">
            <form class="form-horizontal" method="post" action="#">
                <div class="page">
                    <br />
                    <br />
                    <div class="col-xs-6">
                        <div class="">
                            <telerik:RadLabel ID="lbl_AccNo" runat="server" Text="Account #" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAccountNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />

                            <telerik:RadLabel ID="lbl_Company" runat="server" Text="Company" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompany" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />

                        </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="">
                            <telerik:RadLabel ID="lbl_SoaNo" runat="server" Text="SOA #" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtSoaNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />

                            <telerik:RadLabel ID="lbl_BillingPeriod" runat="server" Text="Billing Period Covered" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingPeriod" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                        </div>
                    </div>

                </div>
                <div class="">
                    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
                    <%--SHIPMENT--%>
                    <br />
                    <h5>SHIPMENTS</h5>
                    <telerik:RadGrid ID="ShipmentGrid"
                        runat="server"
                        AllowPaging="True"
                        AllowFilteringByColumn="true"
                        PageSize="10" Skin="Glow" AllowSorting="true"
                        GroupingEnabled="true"
                        CommandItemDisplay="Top"
                        OnItemCommand="ShipmentGrid_ItemCommand"
                        OnNeedDataSource="ShipmentGrid_NeedDataSource">

                        <MasterTableView NoMasterRecordsText="No Shipment Records" AutoGenerateColumns="False"
                            AllowFilteringByColumn="false">

                            <Columns>

                                <telerik:GridDateTimeColumn DataField="DateAccepted" HeaderText="Date Accepted" SortExpression="DateAccepted"
                                    UniqueName="DateAccepted" FilterControlWidth="120px"
                                    PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                </telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                                    UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn DataField="Origin" HeaderText="Origin" SortExpression="Origin"
                                    UniqueName="Origin" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="Destination" HeaderText="Destination" SortExpression="Destination"
                                    UniqueName="Destination" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="FreightCharge" HeaderText="Freight Charge" SortExpression="FreightCharge"
                                    UniqueName="FreightCharge" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="VatAmount" HeaderText="Vat Amount" SortExpression="VatAmount"
                                    UniqueName="VatAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="TotalAmount" HeaderText="Total" SortExpression="TotalAmount"
                                    UniqueName="TotalAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                            </Columns>

                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="true"></Selecting>
                            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                        </ClientSettings>
                    </telerik:RadGrid>
                    <%--PAYMENT--%>
                    <br />
                    <h5>PAYMENT</h5>
                    <telerik:RadGrid ID="AdjustmentGrid"
                        runat="server"
                        AllowFilteringByColumn="true"
                        PageSize="10" Skin="Glow" AllowSorting="true"
                        CommandItemDisplay="Top"
                        OnItemCommand="AdjustmentGrid_ItemCommand"
                        OnNeedDataSource="AdjustmentGrid_NeedDataSource">

                        <MasterTableView NoMasterRecordsText="No Records Found" AutoGenerateColumns="False"
                            AllowFilteringByColumn="false">

                            <Columns>

                                <telerik:GridDateTimeColumn DataField="PaymentDate" HeaderText="Date" SortExpression="PaymentDate"
                                    UniqueName="PaymentDate" FilterControlWidth="120px"
                                    PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                </telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                                    UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" SortExpression="Amount"
                                    UniqueName="Amount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="OrNoPrNo" HeaderText="Or#/Pr#" SortExpression="OrNoPrNo"
                                    UniqueName="OrNoPrNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="PaymentTypeName" HeaderText="Payment Type" SortExpression="PaymentTypeName"
                                    UniqueName="PaymentTypeName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="RecievedBy" HeaderText="Recieved By" SortExpression="RecievedBy"
                                    UniqueName="RecievedBy" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                            </Columns>

                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="true"></Selecting>
                            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
                <div>
                    <div id="footer">
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btmCancel" runat="server" Text="Cancel"></telerik:RadButton>
                    </div>
                </div>
            </form>
        </div>
        <%--<script type="text/javascript" src="../../../js/bootstrap.js"></script>--%>

        <br />
    </form>
</body>
</html>
