<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CMSVersion2.Corporate.CompanyModal.Edit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
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
   <form id="form1" runat="server">



        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <%--<asp:Button runat="server" Text="Close" ID="CloseButton"     OnClick="CloseButton_Click1"/>--%>
        <div>
        <div>
            <asp:Label ID="lblCompanyID" runat="server" Text="" Visible="false"></asp:Label>
      
        <div class="demo-container no-bg">
            <div>
                <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk" AutoPostBack="true">
            <Tabs>
                <telerik:RadTab Text="Company Information"></telerik:RadTab>
                <telerik:RadTab Text="Contact Information"></telerik:RadTab>
                <telerik:RadTab Text="Account Information 1"></telerik:RadTab>
                <telerik:RadTab Text="Account Information 2"></telerik:RadTab>
                <telerik:RadTab Text="Billing Information"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1"  SelectedIndex="0" CssClass="outerMultiPage">
            <%--CompanyInformation--%>
            <telerik:RadPageView runat="server" ID="RadPageView1" >
                <div>
           

                <div>
                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label1" runat="server" Text="Account No"></asp:Label>
                            <br />
                            <br />
                             <asp:Label ID="Label3" runat="server" Text="Company Name"></asp:Label>

                            <br />
                            <br />
                              <asp:Label ID="Label4" runat="server" Text="Address 1"></asp:Label>
                              <br />
                            <br />
                            <br />
                             <br />
                             <asp:Label ID="Label5" runat="server" Text="Address 2"></asp:Label>
                              <br />
                            <br />
                             <br />
                             <br />
                            <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                            <br />
                             <br />
                             <asp:Label ID="Label46" runat="server" Text="Zip Code"></asp:Label>
                            
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAccountNo" Enabled="false" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoCompanyName" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAddress1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAdress2" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadComboBox ID="rcbCompInfoCity" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                          <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfozipCode" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                           
                         
                         </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label7" runat="server" Text="Industry Type"></asp:Label>
                          

                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Contact Info"></asp:Label>
                          

                            <br />
                            <br />
                              <asp:Label ID="Label9" runat="server" Text="TIN"></asp:Label>

                            <br />
                            <br />
                             <asp:Label ID="Label10" runat="server" Text="Website"></asp:Label>

                            <br />
                             <br />
                             <br />
                            <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                            <br />
                              <br />
                            <br />
                             <asp:Label ID="Label12" runat="server" Text="President"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                             <telerik:RadComboBox ID="rcbCompInfoIndustry" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                          <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox RenderMode="Mobile" ID="txtCompInfoTin" Enabled="True" Width="230px" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoWebsite" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                           <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                               <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoPresident" Enabled="True" runat="server"></telerik:RadTextBox>


                         </div>

                </div>
                    </div>
          


        </div>
              
            </telerik:RadPageView>

            <%--Contact Information--%>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                 <div>
           

                <div>
                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label8" runat="server" Text="Contact Person"></asp:Label>
                            <br />
                            <br />
                             <asp:Label ID="Label13" runat="server" Text="Position"></asp:Label>
                            <br />
                            <br />
                            <br />
                              <asp:Label ID="Label14" runat="server" Text="Department"></asp:Label>

                           
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInContacPerson" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoPostion" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoDept" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                         </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label15" runat="server" Text="Mobile No"></asp:Label>
                            <br />
                            <br />
                              <br />
                            <asp:Label ID="Label45" runat="server" Text="Tel No"></asp:Label>
                            <br />
                            <br />
                             <asp:Label ID="Label16" runat="server" Text="Email"></asp:Label>
                              <br />
                            <br />
                            <br />
                              <asp:Label ID="Label17" runat="server" Text="Fax"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoMobile" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoTelNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoEmail" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoFax" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                           
                         </div>

                </div>
                    </div>
          


        </div>

            </telerik:RadPageView>

            <%--Account Information 1--%>
            <telerik:RadPageView runat="server" ID="RadPageView3">
                  <div>
          

                <div class="col-xs-12">
                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label18" runat="server" Text="Account Type"></asp:Label>
                            <br />
                            <br />
                             <asp:Label ID="Label19" runat="server" Text="Account Status"></asp:Label>

                            <br />
                            <br />
                              <asp:Label ID="Label20" runat="server" Text="Organization Type"></asp:Label>
                             <br />
                            <br />
                             <asp:Label ID="Label21" runat="server" Text="Mother Company"></asp:Label>

                            <br />
                            <br />
                             <asp:Label ID="Label22" runat="server" Text="Business Type"></asp:Label>

                         
                             <br />
                             <br />
                            <asp:Label ID="Label23" runat="server" Text="Billing Period"></asp:Label>
                       
                              <br />
                            <br />
                             <asp:Label ID="Label24" runat="server" Text="Payment Term"></asp:Label>
                            

                            
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadComboBox ID="rcbAccountType" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />
                              <telerik:RadComboBox ID="rcbAccountStatus" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />
                             <br />
                            <telerik:RadComboBox ID="rcbAcctInfoOrganizationType" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbOrganizationType_OnSelectedIndexChanged"></telerik:RadComboBox>                            
                            <br />
                             <br />
                            <telerik:RadComboBox ID="rcbAcctInfoMotherCompany" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>                            
                             <br />
                            <br />
                            <telerik:RadComboBox ID="rcbBusinessType" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>     
                            <br />
                            <br />
                            <telerik:RadComboBox ID="rcbBillingPeriod" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />
                           <telerik:RadComboBox ID="rcbPaymentTerm" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                           
                            <%-- <telerik:RadDateTimePicker RenderMode="Lightweight" ID="RadDateTimePicker1" Width="100%" runat="server" DateInput-CssClass="radPreventDecorate"></telerik:RadDateTimePicker>--%>
                             
                         </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="col-xs-3">
                           
                             <asp:Label ID="Label25" runat="server" Text="Payment Mode"></asp:Label>
                              <br />
                            <br /> 
                            <asp:Label ID="Label26" runat="server" Text="Date Approve"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label27" runat="server" Text="Approved By"></asp:Label>
                            <br />
                            <br />
                             <asp:Label ID="Label28" runat="server" Text="BCO"></asp:Label>
                             <br />
                            <br />
                            <br />
                              <asp:Label ID="Label29" runat="server" Text="Area"></asp:Label>
                            <br />
                              <br />
                             <asp:Label ID="Label30" runat="server" Text="Discount"></asp:Label>

                            <br />
                             <br />
                             <br />
                            <asp:Label ID="Label31" runat="server" Text="Tax"></asp:Label>
                         
                              <br />
                            <br />
                             <asp:Label ID="Label32" runat="server" Text="Credit Limit"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                            
                           <telerik:RadComboBox ID="rcbPaymentMode" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />
                             <telerik:RadDatePicker ID="dateApproved" Width="230px" MinDate="1950/1/1" ZIndex="11000"  runat="server"></telerik:RadDatePicker>
                            <%-- <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="RadTextBox1" Enabled="True" runat="server"></telerik:RadTextBox>
                          --%>  
                             <%--<telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="dateApproved" Enabled="True" runat="server"></telerik:RadTextBox>--%>

                            <br />
                            <br />
                            <telerik:RadComboBox ID="rcbApprovedBy" Width="230px" Height="200px" runat="server"></telerik:RadComboBox><br />
                            <br />
                            <telerik:RadComboBox ID="rcbBCO" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbBCO_OnSelectedIndexChanged"></telerik:RadComboBox><br />
                            <br />
                            <telerik:RadComboBox ID="rcbArea" Width="230px" Height="200px" runat="server"></telerik:RadComboBox><br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctDiscount" Enabled="True" runat="server"></telerik:RadTextBox>
                           
                            <br />
                             <br />
                           <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctTax" Enabled="True" runat="server"></telerik:RadTextBox>
                         
                            <br />
                                <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctCreditLimit" Enabled="True" runat="server"></telerik:RadTextBox>
                        </div>

                </div>
                    </div>
           


        </div>


            </telerik:RadPageView>
             
            <%--Account Information 2--%>
            <telerik:RadPageView runat="server" ID="RadPageView4">
                <div>
          

                <div class="col-xs-12">
                    <div class="col-xs-6">
                        
                            <telerik:RadCheckBox runat="server" ID="chkEVM" Text="Applied EVM"></telerik:RadCheckBox>
                            <br />
                            <telerik:RadCheckBox runat="server" ID="chkAWBFee" Text="Has AirwayBill Fee"></telerik:RadCheckBox>
                            <br />
                         <br />
                            <asp:Label ID="Label33" runat="server" Text="Has Freight Collect Fee"></asp:Label>
                            <br />
                        <div style="float: left; position: relative; left: 20%">
                            <telerik:RadCheckBox runat="server" ID="chkFC" Text="FC"></telerik:RadCheckBox>
                           <telerik:RadCheckBox runat="server" ID="chkCC" Text="CC"></telerik:RadCheckBox>
                        </div>
                            <br />
                            <br />
                            <telerik:RadCheckBox runat="server" ID="chkHasInsurance" Text="Has Insurance"></telerik:RadCheckBox>
                        <br />
                             <telerik:RadCheckBox runat="server" ID="chkHasFuelCharge" Text="Has Fuel Charge"></telerik:RadCheckBox>
                        <br />
                             <telerik:RadCheckBox runat="server" ID="chkhasVat" Text="Has Vatable"></telerik:RadCheckBox>
                        </div>

                    <div class="col-xs-6">
                        <telerik:RadCheckBox runat="server" ID="chkHasValuationCharge" Text="Has Valuation Charge"></telerik:RadCheckBox>
                        <br />
                            <telerik:RadCheckBox runat="server" ID="chkHasDevFee" Text="Has Delivery Fee"></telerik:RadCheckBox>
                            
                            <br />
                            <telerik:RadCheckBox runat="server" ID="chkHasPerishableFee" Text="Has Perishable Fee"></telerik:RadCheckBox>
                        <br />
                           <telerik:RadCheckBox runat="server" ID="chkHasDangerousFee" Text="Has Dangerous Fee"></telerik:RadCheckBox>
                        <br />
                            <telerik:RadCheckBox runat="server" ID="chkHasweightCharge" Text="Has Weight Charge"></telerik:RadCheckBox>
                        <br />
                             <telerik:RadCheckBox runat="server" ID="chkHasChargeInvoice" Text="Has Charge Invoice"></telerik:RadCheckBox>
                    </div>
                    </div>
         


        </div>

            </telerik:RadPageView>

            <%--Billing Information --%>
            <telerik:RadPageView runat="server" ID="RadPageView5">
           <div>
           
                
                <div>
                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label34" runat="server" Text="Address 1"></asp:Label>
                            <br />
                            <br />
                                 <br />
                             <br />
                             <asp:Label ID="Label35" runat="server" Text="Address 2"></asp:Label>

                            <br />
                            <br />
                            <br />
                            <br />
                              <asp:Label ID="Label36" runat="server" Text="City"></asp:Label>

                            <br />
                            <br />
                              <br />
                             <asp:Label ID="Label37" runat="server" Text="Zip Code"></asp:Label>

                           
                             <br />
                             <br />
                            <asp:Label ID="Label38" runat="server" Text="Contact Person"></asp:Label>
                         
                              <br />
                            <br />
                             <asp:Label ID="Label39" runat="server" Text="Position"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoAdd1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoAdd2" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadComboBox ID="rcbBillingInfoCity" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                           <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoZipCode" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoContactPerson" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                               <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoPosition" Enabled="True" runat="server"></telerik:RadTextBox>


                         </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label40" runat="server" Text="Department"></asp:Label>
                            <br />
                            <br />
                             <br />
                             <asp:Label ID="Label41" runat="server" Text="Contact No"></asp:Label>

                            <br />
                            <br />
                              <asp:Label ID="Label42" runat="server" Text="Mobile No"></asp:Label>

                            <br />
                            <br />

                             <asp:Label ID="Label43" runat="server" Text="Email"></asp:Label>

                            <br />
                             <br />
                             <br />
                            <asp:Label ID="Label44" runat="server" Text="Fax"></asp:Label>
                           
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoDept" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoContactNo" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoMobileNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                           <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoFax" Enabled="True" runat="server"></telerik:RadTextBox>
                         </div>

                </div>
                    </div>

        </div>

            </telerik:RadPageView>
        </telerik:RadMultiPage>
                        
            </div>
        </div>
        </div>
       <div id="footer">
            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                <telerik:RadButton ID="btmCancel" runat="server" Text="Cancel"></telerik:RadButton>
       </div>


         </div>
        
        <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
