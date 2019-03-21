<!DOCTYPE html>
<html>
<head>
 <meta charset="utf-8">
 <meta http-equiv="X-UA-Compatible" content="IE=edge">
 <title>WATER MOo| Dashboard</title>
 <!-- Tell the browser to be responsive to screen width -->
 <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
 <!-- Bootstrap 3.3.7 -->
 <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
 <!-- Font Awesome -->
 <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
 <!-- Ionicons -->
 <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
 <!-- jvectormap -->
 <link rel="stylesheet" href="bower_components/jvectormap/jquery-jvectormap.css">
 <!-- Theme style -->
 <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
 <!-- AdminLTE Skins. Choose a skin from the css/skins
      folder instead of downloading all of them to reduce the load. -->
 <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">

 <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
 <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
 <!--[if lt IE 9]>
 <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
 <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
 <![endif]-->

 <!-- Google Font -->
 <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
 
<link href="css/examples.css" rel="stylesheet" type="text/css">
	

</head>
<body class="hold-transition skin-blue sidebar-mini">
<div class="wrapper">

 <header class="main-header">

   <!-- Logo -->
   <a href="index2.html" class="logo">
     <!-- mini logo for sidebar mini 50x50 pixels -->
     <span class="logo-mini"><b>A</b>LT</span>
     <!-- logo for regular state and mobile devices -->
     <span class="logo-lg"><b>WATER</b>MOo</span>
   </a>

   <!-- Header Navbar: style can be found in header.less -->
   <nav class="navbar navbar-static-top">
     <!-- Sidebar toggle button-->
     <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
       <span class="sr-only">Toggle navigation</span>
     </a>
     <!-- Navbar Right Menu -->
     <div class="navbar-custom-menu">
       <ul class="nav navbar-nav">
         <li class="dropdown user user-menu">
           <a href="#" class="dropdown-toggle" data-toggle="dropdown">
             <img src="dist/img/nama.jpg" class="user-image" alt="User Image">
             <span class="hidden-xs">Choirun Nisa</span>
           </a>
           <ul class="dropdown-menu">
             <!-- User image -->
             <li class="user-header">
               <img src="dist/img/nama.jpg" class="img-circle" alt="User Image">
               <p>
               Choirun Nisa - App Developer
               </p>
             </li>
             <!-- Menu Body -->

             <!-- Menu Footer-->

           </ul>
         </li>
         <!-- Control Sidebar Toggle Button -->
         <li>
           <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
         </li>
       </ul>
     </div>

   </nav>
 </header>
 <!-- Left side column. contains the logo and sidebar -->
 <aside class="main-sidebar">
   <!-- sidebar: style can be found in sidebar.less -->
   <section class="sidebar">
     <!-- Sidebar user panel -->
     <div class="user-panel">
       <div class="pull-left image">
         <img src="dist/img/iconwater.png" class="img-circle" alt="User Image">
       </div>
       <div class="pull-left info">
         <p>Water Monitoring</p>
         <a href="#"><i class="fa fa-circle text-success"></i> Final Project</a>
       </div>
     </div>

     <!-- /.search form -->
     <!-- sidebar menu: : style can be found in sidebar.less -->
     <ul class="sidebar-menu" data-widget="tree">
       <li class="header">MAIN NAVIGATION</li>
       <li class="active treeview menu-open">
         <a href="#">
           <i class="fa fa-dashboard"></i> <span>Quick Monitoring</span>
           <span class="pull-right-container">
             <i class="fa fa-angle-left pull-right"></i>
           </span>
         </a>
<ul class="treeview-menu">
           <li><a href="index.php"><i class="fa fa-circle-o"></i> quick</a></li>
		   </ul>
       </li>
     

       <li class="treeview">
         <a href="#">
           <i class="fa fa-pie-chart"></i>
           <span>Charts</span>
           <span class="pull-right-container">
             <i class="fa fa-angle-left pull-right"></i>
           </span>
         </a>
         <ul class="treeview-menu">
           <li><a href="gsuhu.php"><i class="fa fa-circle-o"></i> Grafik Suhu</a></li>
           <li><a href="gph.php"><i class="fa fa-circle-o"></i> Grafik pH</a></li>
           <li><a href="gtds.php"><i class="fa fa-circle-o"></i> Grafik TDS</a></li>
           <li><a href="gcond.php"><i class="fa fa-circle-o"></i> Grafik Konduktivitas</a></li>
         </ul>
       </li>


   </section>
   <!-- /.sidebar -->
 </aside>

 <!-- Content Wrapper. Contains page content -->
 <div class="content-wrapper">
   <!-- Content Header (Page header) -->
   <section class="content-header">

     <h1>
       Graph
       <small>TDS</small>
     </h1>
     <ol class="breadcrumb">
       <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
       <li class="active">Dashboard</li>
     </ol>
   </section>

   <!-- Main content -->
   <section class="content">
     <!-- Info boxes -->
     <div class="row" id="menuatas">
      <?php include"grafiktds.php"; ?>
     </div>

          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
   </section>
    
   <!-- /.content -->
   
</div>
<!-- ./wrapper -->

<!-- jQuery 3 -->
<script src="bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- FastClick -->
<script src="bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="dist/js/adminlte.min.js"></script>
<!-- Sparkline -->
<script src="bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
<!-- jvectormap  -->
<script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
<script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
<!-- SlimScroll -->
<script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- ChartJS -->
<script src="bower_components/Chart.js/Chart.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="dist/js/pages/dashboard2.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="dist/js/demo.js"></script>

<script language="javascript" type="text/javascript" src="js/jquery.js"></script>
	<script language="javascript" type="text/javascript" src="js/jquery.flot.js"></script>
	
<script src="http://code.jquery.com/jquery-3.1.1.js"></script>

<script type="text/javascript">
    function doRefresh(){
        $("#menuatas").load("grafiktds.php");
		
		
		
    }
    $(function() {
        setInterval(doRefresh, 10000);
    });
</script>



</body>
</html>
