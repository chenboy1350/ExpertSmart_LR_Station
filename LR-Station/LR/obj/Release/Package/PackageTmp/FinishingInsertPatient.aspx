<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="FinishingInsertPatient.aspx.cs" Inherits="LR_Station.FinishingInsertPatient" %>

<!doctype html>
<html lang="en">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
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
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
</head>

<body runat="server">
    <!-- loader -->
    <div id="loader">
        <div class="spinner-border text-primary" role="status"></div>
    </div>
    <!-- * loader -->

    <!-- App Header -->
    <div class="appHeader">
        <div class="pageTitle">Register New Patient</div>
    </div>
    <!-- * App Header -->

        <!-- Extra Header -->
        <div class="extraHeader p-0">
            <div class="form-wizard-section">
                <a class="button-item">
                    <strong>1</strong>
                    <p>Patient Info</p>
                </a>
                <a class="button-item">
                    <strong>2</strong>
                    <p>Fist Event</p>
                </a>
                <a class="button-item active">
                    <strong>
                        <ion-icon name="checkmark-outline"></ion-icon>
                    </strong>
                    <p>Final Step</p>
                </a>
            </div>
        </div>
        <!-- * Extra Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <form runat="server">
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
                                <asp:Button ID="btnFinish" class="btn" runat="server" Text="FINISH" OnClick="btnFinish_Click" />
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
                            <h5 class="modal-title">Unsuccess</h5>
                        </div>
                        <div class="modal-body">
                            Keep calm. Everything will be Alright.
                        </div>
                        <div class="modal-footer">
                            <div class="btn-list">
                                <asp:Button ID="btnTryAgain" class="btn btn-text-primary btn-block" runat="server" Text="TRY AGAIN" OnClick="btnTryAgain_Click" />
                                <asp:Button ID="btnDiscard" class="btn btn-text-secondary btn-block" runat="server" Text="DISDARD" OnClick="btnDiscard_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- * DialogIconedDanger -->
        </form>
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
