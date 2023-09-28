<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="LR_Station.History" %>

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
            <a href="#" class="headerButton" data-bs-toggle="offcanvas" data-bs-target="#sidebarPanel">
                <ion-icon name="menu-outline"></ion-icon>
            </a>
        </div>
        <div class="pageTitle">History</div>
        <div class="right">
            <a href="Index.aspx" class="headerButton">
                <ion-icon name="bed-outline"></ion-icon>
            </a>
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <form runat="server" method="post">
            <div class="section inset mt-2">
                <div class="row">
                    <div class="col">
                        <div class="section-title">Delivered</div>
                        <asp:Repeater ID="rptBed" runat="server" OnItemDataBound="rptBed_ItemDataBound">
                            <ItemTemplate>
                                <div class="accordion" id='<%# string.Format("accordionExample{0}",Container.ItemIndex + 1) %>'>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                                data-bs-target='<%# string.Format("#accordion00{0}",Container.ItemIndex + 1) %>'>
                                                <ion-icon name="bed-outline"></ion-icon>
                                                <div class="in">
                                                    <asp:HiddenField ID="hidhn" runat="server" Value='<%# string.Format("{0}" ,Eval("hn")) %>' />
                                                    <div><b><%# string.Format("{0}" ,Eval("end_date")) %></b></div>
                                                    <div><%# string.Format("{0}" ,Eval("name")) %></div>
                                                    <div><%# string.Format("{0}" ,Eval("hn")) %></div>
                                                </div>
                                            </button>
                                        </h2>
                                        <div id='<%# string.Format("accordion00{0}",Container.ItemIndex + 1) %>' class="accordion-collapse collapse" data-bs-parent='<%# string.Format("accordionExample{0}",Container.ItemIndex + 1) %>'>
                                            <div class="accordion-body">
                                                <div class="row">
                                                    <div class="wide-block pt-2 pb-1">
                                                        <h3>Patient Detail</h3>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End With:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_with")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End Date:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_date")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End EFW:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_efw")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End AGPAR:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_agpar")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Follow Mom? :</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_follow")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div>-----------------------------</div>
        
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Status:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("status")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Age:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("age")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>GPAL:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("gpal")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>GA:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("ga")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div>-----------------------------</div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>EFW:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("efw")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>EFW TWIN:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("efw_twin")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Dilate:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_dilate")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Effac:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_effacement")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Memb:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_membrane")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Stat:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_station")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Pres:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_present")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>FHS:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("fhs")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>UC:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("utene")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
        
                                                <div class="row">
        
                                                    <asp:Repeater ID="rptevent1" runat="server">
                                                        <ItemTemplate>
                                                            <div class="wide-block pt-2 pb-1">
                                                                <h3><%# string.Format("Event {0}",Container.ItemIndex + 1) %></h3>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Type:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("eventtype")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Date:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("datetime")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Dilate:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_dilate")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Effac:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_effacement")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Memb:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_membrane")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Memb Note:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_membrane_note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Stat:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_station")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Pres:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_present")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Pres Twin:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_present_twin")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS NOTE:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs_note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS TWIN:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs_twin")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>UC:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("utene")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Status:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("status")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Plan:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("plan")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Note:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <%--                                                        <div class="row">
                                                                    <div class="col">
                                                                        <p>
                                                                            <a href="<%# string.Format("EditEvent.aspx?se_id={0}&eventtype={1}&datetime={2}&pv_dilate={3}&pv_effacement={4}&pv_membrane={5}&pv_station={6}&pv_present={7}&fhs={8}&utene={9}&status={10}&plan={11}&note={12}&hn={13}", Eval("se_id"), Eval("eventtype"), Eval("datetime"), Eval("pv_dilate"), Eval("pv_effacement"), Eval("pv_membrane"), Eval("pv_station"), Eval("pv_present"), Eval("pv_present"), Eval("fhs"), Eval("utene"), Eval("status"), Eval("plan"), Eval("note"), Eval("hn")) %>" class="headerButton">
                                                                                <span class="btn btn-primary rounded shadowed">
                                                                                    <ion-icon name="caret-forward-outline"></ion-icon>
                                                                                    Edit Event</span>
                                                                            </a>
                                                                        </p>
                                                                    </div>
                                                                    <div class="col">
                                                                        <p>
                                                                            <a href="#" class="headerButton">
                                                                                <span class="btn btn-primary rounded shadowed">
                                                                                    <ion-icon name="caret-forward-outline"></ion-icon>
                                                                                    Remove Event</span>
                                                                            </a>
                                                                        </p>
                                                                    </div>
                                                                </div>--%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
        
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col">
                        <div class="section-title">Not Delivery</div>
                        <asp:Repeater ID="rptBed2" runat="server" OnItemDataBound="rptBed2_ItemDataBound">
                            <ItemTemplate>
                                <div class="accordion" id='<%# string.Format("accordionExample0{0}",Container.ItemIndex + 1) %>'>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                                data-bs-target='<%# string.Format("#accordion000{0}",Container.ItemIndex + 1) %>'>
                                                <ion-icon name="bed-outline"></ion-icon>
                                                <div class="in">
                                                    <asp:HiddenField ID="hidhn" runat="server" Value='<%# string.Format("{0}" ,Eval("hn")) %>' />
                                                    <div><b><%# string.Format("{0}" ,Eval("end_without_date")) %></b></div>
                                                    <div><%# string.Format("{0}" ,Eval("name")) %></div>
                                                    <div><%# string.Format("{0}" ,Eval("hn")) %></div>
                                                </div>
                                            </button>
                                        </h2>
                                        <div id='<%# string.Format("accordion000{0}",Container.ItemIndex + 1) %>' class="accordion-collapse collapse" data-bs-parent='<%# string.Format("accordionExample0{0}",Container.ItemIndex + 1) %>'>
                                            <div class="accordion-body">
                                                <div class="row">
                                                    <div class="wide-block pt-2 pb-1">
                                                        <h3>Patient Detail</h3>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End With:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_with")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End Date:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_without_date")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>End EFW:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("end_deliver_status")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div>-----------------------------</div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Status:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("status")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Age:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("age")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>GPAL:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("gpal")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>GA:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("ga")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div>-----------------------------</div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>EFW:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("efw")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>EFW TWIN:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("efw_twin")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Dilate:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_dilate")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Effac:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_effacement")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Memb:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_membrane")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Stat:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_station")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>Pres:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("pv_present")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>FHS:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("fhs")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <div>UC:</div>
                                                            </div>
                                                            <div class="col">
                                                                <div><b><%# string.Format("{0}" ,Eval("utene")) %></b></div>
                                                            </div>
                                                            <div class="col">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
        
                                                <div class="row">
        
                                                    <asp:Repeater ID="rptevent2" runat="server">
                                                        <ItemTemplate>
                                                            <div class="wide-block pt-2 pb-1">
                                                                <h3><%# string.Format("Event {0}",Container.ItemIndex + 1) %></h3>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Type:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("eventtype")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Date:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("datetime")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Dilate:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_dilate")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Effac:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_effacement")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Memb:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_membrane")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Memb Note:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_membrane_note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Stat:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_station")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Pres:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_present")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Pres Twin:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("pv_present_twin")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS NOTE:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs_note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>FHS TWIN:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("fhs_twin")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>UC:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("utene")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Status:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("status")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Plan:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("plan")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div>Note:</div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div><b><%# string.Format("{0}" ,Eval("note")) %></b></div>
                                                                    </div>
                                                                    <div class="col">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
        
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                

                

            </div>
        </form>
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

    <!-- bottom right -->
    <div class="fab-button animate bottom-right dropdown goTop">
        <a href="#" class="fab" data-bs-toggle="tooltip" data-bs-placement="top" title="Go to Top">
            <ion-icon name="chevron-up-outline"></ion-icon>
        </a>
    </div>
    <!-- * bottom right -->

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
