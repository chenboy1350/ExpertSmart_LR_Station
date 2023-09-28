<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LR_Station.Index" %>
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
            <a href="#" class="headerButton" data-bs-toggle="offcanvas" data-bs-target="#sidebarPanel">
                <ion-icon name="menu-outline"></ion-icon>
            </a>
        </div>
        <div class="pageTitle">LR-Station</div>
        <div class="right">
            <a href="Event.aspx" class="headerButton">
                <ion-icon name="document-text-outline"></ion-icon>
            </a>
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <div class="header-large-title">
            <h1 class="title">Waiting Covid Result</h1>
        </div>
        <div class="section full mt-3 mb-3">
            <!-- carousel multiple -->
            <div class="carousel-multiple splide">
                <div class="splide__track">
                    <ul class="splide__list">

                        <asp:Repeater ID="rptBedWaiting" runat="server">
                            <ItemTemplate>
                                <%# GenData(Eval("hn"), Eval("name"), Eval("bed"), "Waiting Covide Result Zone") %>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
            <!-- * carousel multiple -->
        </div>

        <div class="header-large-title">
            <h1 class="title">No Covid</h1>
        </div>
        <div class="section full mt-3 mb-3">
            <!-- carousel multiple -->
            <div class="carousel-multiple splide">
                <div class="splide__track">
                    <ul class="splide__list">

                        <asp:Repeater ID="rptBedNoCovid" runat="server">
                            <ItemTemplate>
                                <%# GenData(Eval("hn"), Eval("name"), Eval("bed"), "No Covid Zone") %>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </ul>
                </div>
            </div>
            <!-- * carousel multiple -->
        </div>

        <!-- DialogIconedInfo -->
        <div class="modal fade dialogbox" id="DialogIconedInfo" data-bs-backdrop="static" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-icon" style="color:#fe9500">
                        <ion-icon name="warning-outline"></ion-icon>
                    </div>
                    <div class="modal-header">
                        <h5 class="modal-title">Content is Not Available</h5>
                    </div>
                    <div class="modal-body">
                        Sip a cup of Coffee while waiting a new Content.
                    </div>
                    <div class="modal-footer">
                        <div class="btn-inline">
                            <a href="#" class="btn" data-bs-dismiss="modal">CLOSE</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * DialogIconedInfo -->

        <!-- bottom right -->
<%--        <div class="fab-button animate bottom-right dropdown">
            <a href="#" class="fab" data-bs-toggle="dropdown">
                <ion-icon name="add-outline"></ion-icon>
            </a>
            <div class="dropdown-menu">
                <a class="dropdown-item" href="AddPatientInfo.aspx">
                    <ion-icon name="person-add-outline"></ion-icon>
                    <p>ADD NEW PATIENT</p>
                </a>
            </div>
        </div>--%>
        <!-- * bottom right -->

    </div>
    <!-- * App Capsule -->

    <!-- App Sidebar -->
    <div class="offcanvas offcanvas-start" tabindex="-1" id="sidebarPanel">
        <div class="offcanvas-body">
            <!-- profile box -->
            <div class="profileBox">
                <div class="image-wrapper">
                    <img src="assets/img/sample/avatar/avatar1.jpg" alt="image" class="imaged rounded">
                </div>
                <div class="in">
                    <strong>Admin</strong>
                    <div class="text-muted">
                        <ion-icon name="location"></ion-icon>
                        SUTH
                    </div>
                </div>
                <a href="#" class="close-sidebar-button" data-bs-dismiss="offcanvas">
                    <ion-icon name="close"></ion-icon>
                </a>
            </div>
            <!-- * profile box -->

            <div class="listview-title mt-2 mb-1">
                <span>Menu</span>
            </div>
            <ul class="listview flush transparent no-line image-listview mt-2">
                <li>
                    <a href="Index.aspx" class="item">
                        <div class="icon-box bg-primary">
                            <ion-icon name="bed-outline"></ion-icon>
                        </div>
                        <div class="in">
                            Register
                        </div>
                    </a>
                </li>
                <li>
                    <a href="Event.aspx" class="item">
                        <div class="icon-box bg-primary">
                            <ion-icon name="document-text-outline"></ion-icon>
                        </div>
                        <div class="in">
                            Event
                        </div>
                    </a>
                </li>
                <li>
                    <a href="History.aspx" class="item">
                        <div class="icon-box bg-primary">
                            <ion-icon name="time-outline"></ion-icon>
                        </div>
                        <div class="in">
                            History
                        </div>
                    </a>
                </li>
            </ul>

            <div class="listview-title mt-2 mb-1">
                <span>Option</span>
            </div>
            <ul class="listview flush transparent no-line image-listview mt-2">
                <li>
                    <div class="item">
                        <div class="icon-box bg-primary">
                            <ion-icon name="moon-outline"></ion-icon>
                        </div>
                        <div class="in">
                            <div>Dark Mode</div>
                            <div class="form-check form-switch">
                                <input class="form-check-input dark-mode-switch" type="checkbox" id="darkmodesidebar">
                                <label class="form-check-label" for="darkmodesidebar"></label>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <!-- sidebar buttons -->
        <div class="sidebar-buttons">
            <a href="Login.aspx" class="button">
                <ion-icon name="log-out-outline"></ion-icon>
            </a>
        </div>
        <!-- * sidebar buttons -->
    </div>
    <!-- * App Sidebar -->

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