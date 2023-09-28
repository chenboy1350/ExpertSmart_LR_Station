<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="EditPatient.aspx.cs" Inherits="LR_Station.EditPatient" %>

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
        <div class="pageTitle">Edit Patient Info</div>
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
                            <asp:TextBox ID="txtNAME" runat="server" class="section-title" />
                        </div>
                    </div>

                </div>
                <div class="wide-block pt-2 pb-2">

                    <div class="mb-05">Admit Times</div>
                    <div class="stepper stepper-secondary">
                        <a href="#" class="stepper-button stepper-down">-</a>
                        <input runat="server" type="text" class="form-control" value="1" disabled id="txtAdmitTimes" />
                        <a href="#" class="stepper-button stepper-up">+</a>
                    </div>

                                        <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtAge">Age</label>
                            <select runat="server" class="form-control custom-select" id="txtAge">
                                <option selected value="">Choose...</option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                                <option value="11">11</option>
                                <option value="12">12</option>
                                <option value="13">13</option>
                                <option value="14">14</option>
                                <option value="15">15</option>
                                <option value="16">16</option>
                                <option value="17">17</option>
                                <option value="18">18</option>
                                <option value="19">19</option>
                                <option value="20">20</option>
                                <option value="21">21</option>
                                <option value="22">22</option>
                                <option value="23">23</option>
                                <option value="24">24</option>
                                <option value="25">25</option>
                                <option value="26">26</option>
                                <option value="27">27</option>
                                <option value="28">28</option>
                                <option value="29">29</option>
                                <option value="30">30</option>
                                <option value="31">31</option>
                                <option value="32">32</option>
                                <option value="33">33</option>
                                <option value="34">34</option>
                                <option value="35">35</option>
                                <option value="36">36</option>
                                <option value="37">37</option>
                                <option value="38">38</option>
                                <option value="39">39</option>
                                <option value="40">40</option>
                                <option value="41">41</option>
                                <option value="42">42</option>
                                <option value="43">43</option>
                                <option value="44">44</option>
                                <option value="45">45</option>
                                <option value="46">46</option>
                                <option value="47">47</option>
                                <option value="48">48</option>
                                <option value="49">49</option>
                                <option value="50">50</option>
                                <option value="51">51</option>
                                <option value="52">52</option>
                                <option value="53">53</option>
                                <option value="54">54</option>
                                <option value="55">55</option>
                                <option value="56">56</option>
                                <option value="57">57</option>
                                <option value="58">58</option>
                                <option value="59">59</option>
                                <option value="60">60</option>
                                <option value="61">61</option>
                                <option value="62">62</option>
                                <option value="63">63</option>
                                <option value="64">64</option>
                                <option value="65">65</option>
                                <option value="66">66</option>
                                <option value="67">67</option>
                                <option value="68">68</option>
                                <option value="69">69</option>
                                <option value="70">70</option>
                                <option value="71">71</option>
                                <option value="72">72</option>
                                <option value="73">73</option>
                                <option value="74">74</option>
                                <option value="75">75</option>
                                <option value="76">76</option>
                                <option value="77">77</option>
                                <option value="78">78</option>
                                <option value="79">79</option>
                                <option value="80">80</option>
                                <option value="81">81</option>
                                <option value="82">82</option>
                                <option value="83">83</option>
                                <option value="84">84</option>
                                <option value="85">85</option>
                                <option value="86">86</option>
                                <option value="87">87</option>
                                <option value="88">88</option>
                                <option value="89">89</option>
                                <option value="90">90</option>
                                <option value="91">91</option>
                                <option value="92">92</option>
                                <option value="93">93</option>
                                <option value="94">94</option>
                                <option value="95">95</option>
                                <option value="96">96</option>
                                <option value="97">97</option>
                                <option value="98">98</option>
                                <option value="99">99</option>
                                <option value="100">100</option>

                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Age</div>
                        </div>
                    </div>

<%--                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtAge">Age</label>
                            <input runat="server" type="text" class="form-control" id="txtAge" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" />
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Patient Age.</div>
                        </div>
                    </div>--%>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtGPAL">GPAL</label>
                            <input runat="server" type="text" class="form-control" id="txtGPAL">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter GPAL.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtEDC">EDC</label>
                            <input runat="server" type="date" id="txtEDC">
                            <asp:Button ID="btnCalGA" runat="server" class="btn btn-primary btn-sm me-1" Text="Calulate GA" OnClick="btnCalGA_Click"/>
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtGA">GA</label>
                            <asp:TextBox ID="txtGA" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter GA.</div>
                        </div>
                    </div>

<%--                    <div class="form-group boxed">
                        <div class="listview-title mt-1"><H3>ANC List</H3></div>
                        <asp:Repeater ID="rptANC" runat="server">
                            <ItemTemplate>
                                <ul class="listview simple-listview">
                                    <li>
                                        <div class="in">
                                            <div>
                                                <%# string.Format("{0}" ,Eval("anc_at")) %>
                                                <footer><%# string.Format("{0}" ,Eval("anc_times")) %> Times</footer>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="form-group boxed">
                        <button type="button" class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#DialogForm">ADD ANC</button>
                    </div>--%>

                    <div>LAB1</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxLAB1" onchange="ToggleHideDIV1();">
                        <label class="form-check-label" for="chxLAB1"></label>
                    </div>

                    <div  id="onchangeToggle1" class="form-group boxed" style="display:none";>
                        <div class="input-wrapper">
                            <label class="label" for="txtLAB1Note">LAB1 Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtLAB1Note">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter LAB1 Specify.</div>
                        </div>
                    </div>

                    <div>LAB2</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxLAB2" onchange="ToggleHideDIV2();">
                        <label class="form-check-label" for="chxLAB2"></label>
                    </div>

                    <div id="onchangeToggle2" class="form-group boxed" style="display:none;">
                        <div class="input-wrapper">
                            <label class="label" for="txtLAB2Note">LAB2 Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtLAB2Note">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter LAB2 Specify.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtHCT1">HCT1(%)</label>
                            <input runat="server" type="text" class="form-control" id="txtHCT1" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" />
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter HCT1.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="txtHCT2">HCT2(%)</label>
                            <input runat="server" type="text" class="form-control" id="txtHCT2" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" />
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter HCT2.</div>
                        </div>
                    </div>

                    <div>Food/Drug Allergy</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxAllergy" onchange="ToggleHideDIV3();">
                        <label class="form-check-label" for="chxAllergy"></label>
                    </div>

                    <div id="onchangeToggle3" class="form-group boxed" style="display:none;">
                        <div class="input-wrapper">
                            <label class="label" for="txtAllergyNote">Food/Drug Allergy Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtAllergyNote">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Food/Drug Allergy Specify.</div>
                        </div>
                    </div>

                    <div>Hx Surgery</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxSurgery" onchange="ToggleHideDIV4();">
                        <label class="form-check-label" for="chxSurgery"></label>
                    </div>

                    <div id="onchangeToggle4" class="form-group boxed" style="display:none;">
                        <div class="input-wrapper">
                            <label class="label" for="txtSurgeryNote">Hx Surgery Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtSurgeryNote">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Hx Surgery Specify.</div>
                        </div>
                    </div>

                    <div>U/D</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxUnD" onchange="ToggleHideDIV5();">
                        <label class="form-check-label" for="chxUnD"></label>
                    </div>

                    <div id="onchangeToggle5" class="form-group boxed" style="display:none;">
                        <div class="input-wrapper">
                            <label class="label" for="txtUndNote">U/D Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtUndNote">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter U/D Specify.</div>
                        </div>
                    </div>

                    <div>Risk</div>
                    <div class="form-check form-switch">
                        <input runat="server" class="form-check-input" type="checkbox" id="chxRick" onchange="ToggleHideDIV6();">
                        <label class="form-check-label" for="chxRick"></label>
                    </div>

                    <div id="onchangeToggle6" class="form-group boxed" style="display:none;">
                        <div class="input-wrapper">
                            <label class="label" for="txtRickNote">Risk Specify</label>
                            <input runat="server" type="text" class="form-control" id="txtRickNote">
                            <i class="clear-input">
                                <ion-icon name="close-circle"></ion-icon>
                            </i>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter Rick Specify.</div>
                        </div>
                    </div>

                    <div class="form-group boxed">
                        <div class="input-wrapper">
                            <label class="label" for="cbxCovidState">Covid Status</label>
                            <select runat="server" class="form-control custom-select" id="cbxCovidState" >
                                <option selected value="">Choose...</option>
                                <option value="Not Detect">Not Detect</option>
                                <option value="12">12</option>
                                <option value="17">17</option>
                                <option value="21">21</option>
                                <option value="PUI">PUI</option>
                                <option value="Covid resove <3">Covid resove <3</option>
                            </select>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please choose a Covid Status.</div>
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

                    <!-- Dialog Form -->
                    <div class="modal fade dialogbox" id="DialogForm" data-bs-backdrop="static" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Add ANC</h5>
                                </div>
                                <div class="modal-body text-start mb-2">
                                    <div class="form-group basic">
                                        <div class="input-wrapper">
                                            <label class="form-label" for="txtANCat">ANC at</label>
                                            <input runat="server" type="text" class="form-control" id="txtANCat">
                                            <i class="clear-input">
                                                <ion-icon name="close-circle"></ion-icon>
                                            </i>
                                        </div>
                                    </div>

                                    <div class="form-group basic">
                                        <div class="input-wrapper">
                                            <label class="form-label" for="txtANCTimes">ANC Times</label>
                                            <input runat="server" type="text" class="form-control" id="txtANCTimes">
                                            <i class="clear-input">
                                                <ion-icon name="close-circle"></ion-icon>
                                            </i>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-inline">
                                        <button type="button" class="btn btn-text-secondary" data-bs-dismiss="modal">CLOSE</button>
<%--                                        <asp:Button ID="btnAddANC" runat="server" class="btn btn-text-primary" Text="ADD" ></asp:Button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- * Dialog Form -->

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

        <script>
        $('.datepicker').datepicker()

        function ToggleHideDIV1() {
            var x = document.getElementById("onchangeToggle1");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else
            {
                x.style.display = "none";
            }
        }

        function ToggleHideDIV2() {
            var x = document.getElementById("onchangeToggle2");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else {
                x.style.display = "none";
            }
        }

        function ToggleHideDIV3() {
            var x = document.getElementById("onchangeToggle3");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else {
                x.style.display = "none";
            }
        }

        function ToggleHideDIV4() {
            var x = document.getElementById("onchangeToggle4");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else {
                x.style.display = "none";
            }
        }

        function ToggleHideDIV5() {
            var x = document.getElementById("onchangeToggle5");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else {
                x.style.display = "none";
            }
        }

        function ToggleHideDIV6() {
            var x = document.getElementById("onchangeToggle6");
            if (x.style.display === "none") {
                x.style.display = "block";
            }
            else {
                x.style.display = "none";
            }
        }
        </script>
</body>
</html>
