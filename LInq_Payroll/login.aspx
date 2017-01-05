<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LInq_Payroll.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css'>
    <link href="assets/plugins/iCheck/skins/minimal/blue.css" type="text/css" rel="stylesheet">
    <link href="assets/fonts/font-awesome/css/font-awesome.min.css" type="text/css" rel="stylesheet">
    <link href="assets/css/styles.css" type="text/css" rel="stylesheet">
</head>
<body class="focused-form">
    <form id="form1" runat="server">
        <div class="container" id="login-form">
            <a href="index.html" class="login-logo">
                <img src="assets/img/login-logo.png"></a>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2>Login Form</h2>
                        </div>
                        <div class="panel-body">

                            <div role="form" class="form-horizontal" id="validate-form">
                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-user"></i>
                                            </span>
                                            <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="Username" data-parsley-minlength="6" required />
                                            <%--<input type="text" class="form-control" placeholder="Email Username" data-parsley-minlength="6" placeholder="At least 6 characters" required>--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-key"></i>
                                            </span>
                                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" class="form-control" placeholder="Password" data-parsley-minlength="6" required />
                                            <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                                        </div>
                                    </div>
                                </div>


                                <div class="panel-footer">
                                    <div class="clearfix">
                                        <%--<a href="extras-registration.html" class="btn btn-default pull-left">Register</a>--%>
                                        <%--<a href="extras-login.html" class="btn btn-primary pull-right">Login</a>--%>
                                        <asp:Label Text="" style="color:red;" ID="lblMessage" class="pull-left" runat="server" />
                                        <%--<asp:LinkButton ID="btnLogin" class="btn btn-primary pull-right" OnClick="btnLogin_Click" runat="server">Login</asp:LinkButton>--%>
                                        <asp:Button ID="btnLogin" class="btn btn-primary pull-right" OnClick="btnLogin_Click" runat="server" Text="Login" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <%--  <div class="text-center">
                        <a href="#" class="btn btn-label btn-social btn-facebook mb20"><i class="fa fa-fw fa-facebook"></i>Connect with Facebook</a>
                        <a href="#" class="btn btn-label btn-social btn-twitter mb20"><i class="fa fa-fw fa-twitter"></i>Connect with Twitter</a>
                    </div>--%>
                </div>
            </div>
        </div>
    </form>

    <script src="assets/js/jquery-1.10.2.min.js"></script>
    <!-- Load jQuery -->
    <script src="assets/js/jqueryui-1.9.2.min.js"></script>
    <!-- Load jQueryUI -->

    <script src="assets/js/bootstrap.min.js"></script>
    <!-- Load Bootstrap -->


    <script src="assets/plugins/easypiechart/jquery.easypiechart.js"></script>
    <!-- EasyPieChart-->
    <script src="assets/plugins/sparklines/jquery.sparklines.min.js"></script>
    <!-- Sparkline -->
    <script src="assets/plugins/jstree/dist/jstree.min.js"></script>
    <!-- jsTree -->

    <script src="assets/plugins/codeprettifier/prettify.js"></script>
    <!-- Code Prettifier  -->
    <script src="assets/plugins/bootstrap-switch/bootstrap-switch.js"></script>
    <!-- Swith/Toggle Button -->

    <script src="assets/plugins/bootstrap-tabdrop/js/bootstrap-tabdrop.js"></script>
    <!-- Bootstrap Tabdrop -->

    <script src="assets/plugins/iCheck/icheck.min.js"></script>
    <!-- iCheck -->

    <script src="assets/js/enquire.min.js"></script>
    <!-- Enquire for Responsiveness -->

    <script src="assets/plugins/bootbox/bootbox.js"></script>
    <!-- Bootbox -->

    <script src="assets/plugins/simpleWeather/jquery.simpleWeather.min.js"></script>
    <!-- Weather plugin-->

    <script src="assets/plugins/nanoScroller/js/jquery.nanoscroller.min.js"></script>
    <!-- nano scroller -->

    <script src="assets/plugins/jquery-mousewheel/jquery.mousewheel.min.js"></script>
    <!-- Mousewheel support needed for jScrollPane -->

    <script src="assets/js/application.js"></script>
    <script src="assets/demo/demo.js"></script>
    <script src="assets/demo/demo-switcher.js"></script>

</body>
</html>
