<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFirstEvent.aspx.cs" Inherits="LR_Station.AddFirstEvent" %>

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
    <link href="assets/css/datepicker.css" rel="stylesheet" />
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
            <a href="AddPatientInfo.aspx" class="headerButton">
                <ion-icon name="chevron-back-outline"></ion-icon>
            </a>
        </div>
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
                <a class="button-item active">
                    <strong>2</strong>
                    <p>Fist Event</p>
                </a>
                <a class="button-item">
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
        <div class="section full mt-2 mb-2">
            <div class="section-title">Register New Patient</div>
            <div class="wide-block pt-2 pb-2">

                <form runat="server" class="needs-validation">

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
                            <label class="label" for="txtComplaint">Chief Complaint</label>
                            <input runat="server" type="text" class="form-control" id="txtComplaint">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Chief Complaint.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtVS">V/S</label>
                            <input runat="server" type="text" class="form-control" id="txtVS">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter V/S.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtBabyWeight">Baby Weight</label>
                            <input runat="server" type="text" class="form-control" id="txtBabyWeight" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" />
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Baby Weight.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtBabyWeight_twin">Baby Weight Twin</label>
                            <input runat="server" type="text" class="form-control" id="txtBabyWeight_twin" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" />
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Baby Weight twin.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxBabyFHS">Baby FHS</label>
                            <select runat="server" class="form-control custom-select" id="cbxBabyFHS">
                                <option selected value="">Choose...</option>
                                <option value="CAT1">CAT1</option>
                                <option value="CAT2">CAT2</option>
                                <option value="CAT3">CAT3</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Admit At.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtBabyFHS_note">Baby FHS Note</label>
                            <input runat="server" type="text" class="form-control" id="txtBabyFHS_note">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Baby Weight twin.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxBabyFHS_twin">Baby FHS Twin</label>
                            <select runat="server" class="form-control custom-select" id="cbxBabyFHS_twin">
                                <option selected value="">Choose...</option>
                                <option value="CAT1">CAT1</option>
                                <option value="CAT2">CAT2</option>
                                <option value="CAT3">CAT3</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Admit At.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtBabyFHS_twin_note">Baby FHS Twin Note</label>
                            <input runat="server" type="text" class="form-control" id="txtBabyFHS_twin_note">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Baby Weight twin.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtUtenc">Utenc</label>
                            <input runat="server" type="text" class="form-control" id="txtUtenc" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');"/>
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Utenc.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtPVDilate">PV Dilate</label>
                            <input runat="server" type="text" class="form-control" id="txtPVDilate" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');"/>
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter PV Dilate.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtPVEfacement">PV Effacement</label>
                            <input runat="server" type="text" class="form-control" id="txtPVEfacement" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');"/>
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter PV Effecement.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxPVMembrane">PV Membrane</label>
                            <select runat="server" class="form-control custom-select" id="cbxPVMembrane">
                                <option selected value="">Choose...</option>
                                <option value="MI">MI</option>
                                <option value="ML">ML</option>
                                <option value="MR">MR</option>
                                <option value="ARM">ARM</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Station.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtPVMembrane">PV Membrane Note</label>
                            <input runat="server" type="text" class="form-control" id="txtPVMembrane">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Baby Weight twin.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxPVPresent">Baby Presentation</label>
                            <select runat="server" class="form-control custom-select" id="cbxPVPresent">
                                <option selected value="">Choose...</option>
                                <option value="Vx">Vx</option>
                                <option value="Br">Br</option>
                                <option value="Tx">Tx</option>
                                <option value="Obliqu">Obliqu</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Station.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxPVPresent_twin">Baby Presentation Twin</label>
                            <select runat="server" class="form-control custom-select" id="cbxPVPresent_twin">
                                <option selected value="">Choose...</option>
                                <option value="Vx">Vx</option>
                                <option value="Br">Br</option>
                                <option value="Tx">Tx</option>
                                <option value="Obliqu">Obliqu</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Station.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxPVStation">PV Station</label>
                            <select runat="server" class="form-control custom-select" id="cbxPVStation">
                                <option selected value="">Choose...</option>
                                <option value="3">3</option>
                                <option value="2">2</option>
                                <option value="1">1</option>
                                <option value="0">0</option>
                                <option value="-1">-1</option>
                                <option value="-2">-2</option>
                                <option value="-3">-3</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Station.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtPlan">Plan</label>
                            <input runat="server" type="text" class="form-control" id="txtPlan">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Plan.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxStatus">Status</label>
                            <select runat="server" class="form-control custom-select" id="cbxStatus">
                                <option selected value="">Choose...</option>
                                <option value="Waiting">Waiting</option>
                                <option value="Delivering">Delivering</option>
                                <option value="Delivered">Delivered</option>
                                <option value="Not Have any Risk">Not Have any Risk</option>
                                <option value="Back Home">Back Home</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Status.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtNote">Note</label>
                            <input runat="server" type="text" class="form-control" id="txtNote">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Note.</div>
                        </div>
                    </div>

                    <div class="mt-2">
                        <div class="wide-block pt-2 pb-1"></div>
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-block me-1 mb-1" Text="SUBMIT" onclick="btnSubmit_Click"></asp:Button>
                        <asp:Button ID="btnBack" runat="server" class="btn btn-secondary btn-block me-1 mb-1" Text="BACK" onclick="btnBack_Click"></asp:Button>
                    </div>
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
        <!-- DateTimePicker TH -->
    <script src="assets/js/bootstrap-datepicker.js"></script>
    <script src="assets/js/bootstrap-datepicker-thai.js"></script>
    <script src="assets/js/locales/bootstrap-datepicker.th.js"></script>
    <script>
        $('.datepicker').datepicker()
    </script>
</body>
</html>
