<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="EndWithDelivery.aspx.cs" Inherits="LR_Station.EndWithDelivery" %>

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
        <div class="left">
            <a href="Event.aspx" class="headerButton">
                <ion-icon name="chevron-back-outline"></ion-icon>
            </a>
        </div>
        <div class="pageTitle">End Case with Delivery</div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <form runat="server" class="needs-validation">
            <div class="section full mt-2 mb-2">
                <div class="wide-block pt-2 pb-1">
                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtHN">HN:</label>
                            <asp:TextBox ID="txtHN" runat="server" class="section-title" readonly="true" />
                        </div>
                    </div>
                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtNAME">NAME:</label>
                            <asp:TextBox ID="txtNAME" runat="server" class="section-title" readonly="true" />
                        </div>
                    </div>

                </div>
                <div class="wide-block pt-2 pb-2">

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtDateTime">DateTime</label>
                            <input runat="server" type="date" id="txtDateTime">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter DateTime.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtEFW">EFW</label>
                            <input runat="server" type="text" class="form-control" id="txtEFW">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtAPGAR">APGAR</label>
                            <input runat="server" type="text" class="form-control" id="txtAPGAR">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxFallow">Move Follow Mom</label>
                            <select runat="server" class="form-control custom-select" id="cbxFallow">
                                <option selected disabled value="">Choose...</option>
                                <option value="CAT1">YES</option>
                                <option value="CAT2">NO</option>
                            </select>
                        </div>
                    </div>

                    <div class="mt-2">
                        <div class="wide-block pt-2 pb-1"></div>
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-block me-1 mb-1" Text="SUBMIT" OnClick="btnSubmit_Click"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-block me-1 mb-1" Text="DISCARD" OnClick="btnCancel_Click"></asp:Button>
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
                                        <asp:Button ID="btnFinish" class="btn" runat="server" Text="FINISH" OnClick="btnFinish_Click"/>
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
                                        <asp:Button ID="btnTryAgain" class="btn btn-text-primary btn-block" runat="server" Text="TRY AGAIN" />
                                        <asp:Button ID="btnDiscard" class="btn btn-text-secondary btn-block" runat="server" Text="DISDARD" OnClick="btnDiscard_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- * DialogIconedDanger -->


                </div>
            </div>
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