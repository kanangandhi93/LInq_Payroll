<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="company_details.aspx.cs" Inherits="LInq_Payroll.company_details" %>
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
                                    <label for="exampleInputEmail1">Select Country</label>
                                    <asp:DropDownList ID="DropDownList1" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Select Country</label>
                                    <asp:DropDownList ID="ddlCountry" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Select State</label>
                                    <asp:DropDownList ID="ddlState" class="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Selec City</label>
                                   <asp:DropDownList ID="ddlcity" class="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <asp:Button Text="Submit" OnClick="btnSubmit_Click" ID="btnSubmit" class="btn btn-success m-r-10" OnClientClick="return Validate" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- /row -->
        <div class="row">
            <div class="col-sm-12">
                <div class="white-box">
                    <h3 class="box-title m-b-0">All Countries </h3>
                    <p class="text-muted m-b-30"></p>
                    <div class="table-responsive">
                        <table id="myTable" class="table table-striped">
                            <thead>
                                <tr>
                                    <th>City Name</th>
                                    <th>State Name</th>
                                    <th>Country Name</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="repData" OnItemCommand="repData_ItemCommand" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("City") %></td>
                                            <td><%# Eval("State") %></td>
                                            <td><%# Eval("CountryName") %></td>
                                            <td>
                                                <asp:LinkButton Text="Edit" CommandArgument='<%# Eval("Id") %>' class="btn btn-primary m-r-10" CommandName="Edit" runat="server" />
                                            </td>
                                            <td>
                                                <asp:LinkButton Text="Delete" CommandArgument='<%# Eval("Id") %>' class="btn btn-danger m-r-10" CommandName="Delete" runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
