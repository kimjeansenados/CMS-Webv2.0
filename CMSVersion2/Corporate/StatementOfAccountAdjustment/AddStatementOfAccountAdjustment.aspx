<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStatementOfAccountAdjustment.aspx.cs" Inherits="CMSVersion2.Corporate.StatementOfAccountAdjustment.AddStatementOfAccountAdjustment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form class="form-horizontal" method="post" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator2" runat="server" Skin="Default" DecoratedControls="All" />

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
                 MasterTableView-CommandItemDisplay="Top"
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
                 MasterTableView-CommandItemDisplay="Top"
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
</body>
</html>
