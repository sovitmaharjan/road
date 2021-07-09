<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivationErrorPage.aspx.cs" Inherits="attendance.ActivationError" %>

<!DOCTYPE html>
<html class="account-pages-bg">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Avighna Technologies Pvt.Ltd">

    <!-- App favicon -->
    <link rel="shortcut icon" href="<%=this.baseUrl%>/assets/images/favicon.ico">
    <!-- App title -->
    <title><%=this.projectName%> || Avighna Technology  </title>

    <!-- App css -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

    <script src="assets/js/modernizr.min.js"></script>

</head>


<body class="bg-transparent">

    <!-- Loader -->
    <div id="preloader">
        <div id="status">
            <div class="spinner">
                <div class="spinner-wrapper">
                    <div class="rotator">
                        <div class="inner-spin"></div>
                        <div class="inner-spin"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- HOME -->
    <section>
        <div class="container-alt">
            <div class="row">
                <div class="col-sm-12 text-center">

                    <div class="wrapper-page">
                        <img src="assets/images/animat-search-color.gif" alt="" height="120">
                        <h2 class="text-uppercase text-danger">!!!  <asp:Label ID="Label1" runat="server"></asp:Label> !!!</h2>
                        <p class="text-muted">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </p>
                        <p class="text-muted">
                            Please Contact 
                            <a href="https://avighnatechnology.com" target="_blank">
                                <asp:Label ID="lblfullName" runat="server" Text=""></asp:Label></a>
                        </p>
                        <p class="text-muted">
                            For Further Assistance.
                        </p>
                        <a class="btn btn-success waves-effect waves-light m-t-20" href="<%=this.baseUrl%>/Login">Return To Login</a>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <!-- END HOME -->

    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

</body>
</html>
