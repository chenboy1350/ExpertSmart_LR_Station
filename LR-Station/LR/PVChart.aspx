<%@ Page Language="C#" Async="true" AutoEventWireup="true" EnableViewState="true" CodeBehind="PVChart.aspx.cs" Inherits="LR_Station.PVChart" %>

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
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
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
        <div class="pageTitle">PV Chart</div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">

        <div runat="server" class="header-large-title">
            <h1 class="title">PV Chart</h1>
        </div>
        <div class="section full mt-3 mb-3">
            <canvas id="DILChart"></canvas>
        </div>
    </div>
    <!-- * App Capsule -->

    <!-- DialogIconedInfo -->
    <div class="modal fade dialogbox" id="DialogIconedInfo" data-bs-backdrop="static" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-icon" style="color: #fe9500">
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
                <span>Friends</span>
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
                    <a href="#" class="item" data-bs-toggle="modal" data-bs-target="#DialogIconedInfo">
                        <div class="icon-box bg-primary">
                            <ion-icon name="analytics-outline"></ion-icon>
                        </div>
                        <div class="in">
                            Chart
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" class="item" data-bs-toggle="modal" data-bs-target="#DialogIconedInfo">
                        <div class="icon-box bg-primary">
                            <ion-icon name="desktop-outline"></ion-icon>
                        </div>
                        <div class="in">
                            EFM
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
            <a href="#" class="button">
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

    <script>
        $(window).on('load', function GenChart() {
            var DILchartData;
            var STRchartData;

            <asp:Literal ID="ltChartData" runat="server"></asp:Literal>

            const DILctx = document.getElementById('DILChart').getContext('2d');
            const DILChart = new Chart(DILctx, {
                type: 'line',
                data: {
                    labels: ['0', '', '1', '', '2', '', '3', '', '4', '', '5', '', '6', '', '7', '', '8', '', '9', '', '10', '', '11', '', '12', '', '13', '', '14', '', '15', '', '16', '', '17', '', '18', '', '19', '', '20', '', '21', '', '22', '', '23', '', '24'],
                    datasets: [{
                        label: 'Dilate',
                        data: DILchartData,
                        fill: false,
                        borderColor: 'rgb(75, 192, 192)',
                        tension: 0.2
                    }, {
                        label: 'Stasion',
                        data: STRchartData,
                        fill: false,
                        borderColor: 'rgb(220, 20, 60)',
                        tension: 0.2,
                        yAxisID: 'station'
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        title: {
                            display: true,
                            text: 'Mix PV Chart'
                        }
                    },
                    scales: {
                        x: {
                            title:{
                                display: true,
                                text: 'Time(Hours)',
                            }
                        },
                        y: {
                            min: 0,
                            max: 10,
                            title:{
                                display: true,
                                text: 'Dilate',
                            },
                            ticks: {
                                stepSize: 0.5
                            }
                        },
                        station: {
                            position: 'right',
                            min: -3,
                            max: 3,
                            title:{
                                display: true,
                                text: 'Station',
                            },
                            ticks: {
                                stepSize: 0.5
                            }
                        }
                    }
                },
            });
        });
    </script>
</body>
</html>