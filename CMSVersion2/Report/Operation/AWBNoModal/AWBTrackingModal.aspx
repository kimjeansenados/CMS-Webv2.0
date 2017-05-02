<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AWBTrackingModal.aspx.cs" Inherits="CMSVersion2.Report.Operation.AWBNoModal.AWBTrackingModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .center {
    margin: auto;
    width: 80%;
    
    padding: 10px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" />
    <div>
        <asp:HiddenField ID="lblAwbNumber" runat="server" Visible="true"></asp:HiddenField>
       <%-- <telerik:RadTextBox ID="txtAwbNo" runat="server" Width="230px"></telerik:RadTextBox>--%>

      <%--  <telerik:RadGrid ID="radGridSignature" 
                                runat="server" AllowPaging="True" 
                                ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="10" 
                                AllowSorting="true"
                                RenderMode="Mobile"
                                CommandItemDisplay="Top"
                                OnNeedDataSource="radGridSignature_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                
                                <MasterTableView CommandItemDisplay="Top">
                                   
                                    <CommandItemSettings ShowExportToWordButton="false" ShowExportToExcelButton="false" 
                                    ShowExportToCsvButton="false" ShowExportToPdfButton="false">

                                    </CommandItemSettings>
                                    <Columns>
                                        
                                        <telerik:GridBinaryImageColumn DataField="Signature" HeaderText="Signature" UniqueName="Signature" 
                                        ImageAlign="Middle" ImageHeight="100px" ImageWidth="150px" ResizeMode="Fit"
                                        DataAlternateTextFormatString="Image of {0}"> 
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </telerik:GridBinaryImageColumn>
                                    </Columns>
                                </MasterTableView>
                               
        </telerik:RadGrid>--%>

        <div class="center">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle"/>
            <hr />
            <telerik:RadLabel ID="lblName" runat="server"></telerik:RadLabel>
        </div>

    </div>
    </form>
</body>
</html>
