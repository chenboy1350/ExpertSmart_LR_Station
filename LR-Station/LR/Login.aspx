<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LR_Station.Login" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>LR-Station</title>
    <meta name="description" content="Mobilekit HTML Mobile UI Kit">
    <meta name="keywords" content="bootstrap 5, mobile template, cordova, phonegap, mobile, html" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body class="bg-white">

    <!-- loader -->
    <div id="loader">
        <div class="spinner-border text-primary" role="status"></div>
    </div>
    <!-- * loader -->

    <!-- App Capsule -->
    <div id="appCapsule" class="pt-0">

        <div class="login-form mt-1">
            <div class="section">
                <%--<img src="assets/img/sample/photo/vector4.png" alt="image" class="form-image">--%>
            </div>
            <div class="section mt-1">
                <h1>LR-Station</h1>
                <h4>Incredible of Labour Lab</h4>
            </div>
            <div class="section mt-1 mb-5">
                <form runat="server">
                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <input runat="server" type="text" class="form-control" id="txtUsername" placeholder="Username">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <input runat="server" type="password" class="form-control" id="txtPassword" placeholder="Password" autocomplete="off">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                        </div>
                    </div>

                    <div class="form-links mt-2">
                        <div>
                            <a href="page-register.html">Register Now</a>
                        </div>
                        <div><a href="page-forgot-password.html" class="text-muted">Forgot Password?</a></div>
                    </div>

                    <div class="form-button-group">
                        <asp:Button ID="btnSignin" runat="server" class="btn btn-primary btn-block btn-lg" Text="Sign in" OnClick="btnSignin_Click"/>
                    </div>

                    <!-- DialogIconedSuccess -->
                    <div class="modal fade dialogbox" id="DialogIconedSuccess" data-bs-backdrop="static" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-icon text-success">
                                    <ion-icon name="checkmark-circle"></ion-icon>
                                </div>
                                <div class="modal-header">
                                    <h5 class="modal-title">Success</h5>
                                </div>
                                <div class="modal-body">
                                    Feel free and Enjoin.
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-inline">
                                        <asp:Button ID="btnFinish" class="btn" runat="server" Text="FINISH"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- * DialogIconedSuccess -->

                    <!-- DialogIconedDanger -->
                    <div class="modal fade dialogbox" id="DialogIconedDanger" data-bs-backdrop="static" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-icon text-danger">
                                    <ion-icon name="close-circle"></ion-icon>
                                </div>
                                <div class="modal-header">
                                    <h5 class="modal-title">Incorrect Username or Password</h5>
                                </div>
                                <div class="modal-body">
                                    Please try again.
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-list">
                                        <asp:Button ID="btnTryAgain" class="btn btn-text-primary btn-block" runat="server" Text="TRY AGAIN"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- * DialogIconedDanger -->

                </form>
            </div>
        </div>
    </div>
    <!-- * App Capsule -->



    <!-- ============== Js Files ==============  -->
    <!-- Bootstrap -->
    <script src="assets/js/lib/bootstrap.min.js"></script>
    <!-- Ionicons -->
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
    <!-- Splide -->
    <script src="assets/js/plugins/splide/splide.min.js"></script>
    <!-- ProgressBar js -->
    <script src="assets/js/plugins/progressbar-js/progressbar.min.js"></script>
    <!-- Base Js File -->
    <script src="assets/js/base.js"></script>

</body>

</html>