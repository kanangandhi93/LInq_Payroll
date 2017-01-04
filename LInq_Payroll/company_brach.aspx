<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="company_brach.aspx.cs" Inherits="LInq_Payroll.company_brach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function isNumeric(keyCode) {
            return ((keyCode >= 48 && keyCode <= 57) || keyCode == 8)
        }

        function isAlpha(keyCode) {
            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8)
        }

        function isAlphaNumeric(keyCode) {
            return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8)
        }

        function IsMobileNumber(txtMobId) {
            var mob = /^[7|8|9]{1}[0-9]{9}$/;
            var txtMobile = document.getElementById(txtMobId);
            if (mob.test(txtMobile.value) == false) {
                alert("Please enter valid mobile number.");
                txtMobile.focus();
                //return false;
                return document.getElementById(txtMobId).value = '';
            }
            return true;
        }

        function IsPincode(txtPincode) {
            var mob = /^[0-9]{6}$/;
            var txtPincode1 = document.getElementById(txtPincode);
            if (mob.test(txtPincode1.value) == false) {
                alert("Please enter valid Pincode.");
                txtPincode1.focus();
                //return false;
                return document.getElementById(txtPincode).value = '';
            }
            return true;
        }

        function IsDecimal(txtDecimal) {
            var mob = /^[1-9]\d*(\.\d+)?$/;
            var txtDec = document.getElementById(txtDecimal);
            if (mob.test(txtDec.value) == false) {
                alert("Please enter valid number.");
                txtDec.focus();
                //return false;
                return document.getElementById(txtDecimal).value = '';
            }
            return true;
        }

        function IsEmail(txtEmailId) {
            var mob = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,3})+$/;
            var txtEmail = document.getElementById(txtEmailId);
            if (mob.test(txtEmail.value) == false) {
                alert("Please enter valid Email.");
                txtEmail.focus();
                //return false;
                return document.getElementById(txtEmailId).value = '';
            }
            return true;
        }


    </script>



    <div class="container-fluid">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <!-- /.row -->
        <div class="row">
            <div class="col-md-8">
                <div class="white-box">
                    <h3 class="box-title m-b-0">Sample Basic Forms</h3>
                    <p class="text-muted m-b-30 font-13">Bootstrap Elements </p>
                    <div class="row">
                        <div class="col-sm-12 col-xs-12">
                            <div role="form">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Company Name</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtCompanyBranchName" placeholder="Enter Branch Name" required />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Address Line 1</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtAdd1" placeholder="Enter Address Line 1" required />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Address Line 2</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtAdd2" placeholder="Enter Address Line 2" required />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Address Line 3</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtAdd3" placeholder="Enter Address Line 3" />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Select Country</label>
                                    <asp:DropDownList ID="ddlCountry" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                     <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCountry" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Select State</label>
                                            <asp:DropDownList ID="ddlState" class="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlState" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Selec City</label>
                                            <asp:DropDownList ID="ddlcity" class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Postal Code</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtPostalCode" onkeydown="return IsPincode(event.keyCode);" placeholder="Enter Pincode" required />
                                </div>

                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Contact No1.</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtContactNo1" onkeydown="return IsMobileNumber(event.keyCode);" placeholder="Enter Mobile No 1" required />
                                </div>

                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Contact No2.</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtContactNo2" onkeydown="return IsMobileNumber(event.keyCode);" placeholder="Enter Contact No 2" required />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Fax No.</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtFax" onkeydown="return isNumeric(event.keyCode);" placeholder="Enter Fax No" />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Email</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtEmail" onkeydown="return IsEmail(event.keyCode);" placeholder="Enter Email" required />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Founded Year</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtFYear" MaxLength="4" onkeydown="return isNumeric(event.keyCode);" placeholder="Enter Founded Year" required />
                                </div>
                                <asp:Button Text="Submit" OnClick="btnSubmit_Click" ID="btnSubmit" class="btn btn-success m-r-10" OnClientClick="return Validate" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
