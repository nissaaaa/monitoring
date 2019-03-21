<?php
$host = MySQLi_connect("192.168.43.224","root","", "parameter");
$search_sql = "SELECT * FROM datasensor ORDER BY no DESC";
$query=mysqli_query($host, $search_sql);
?>
  <div class="col-md-3 col-sm-6 col-xs-12">
    <div class="info-box">
      <span class="info-box-icon bg-aqua"><img src="dist/img/SUHU.png" alt="User Image" height="90%"></span>

      <div class="info-box-content">
        <span class="info-box-text">SUHU</span>
        <?php
         $data = mysqli_fetch_row($query);
           ?>
           <span class='info-box-number' id="suhu"><?php echo number_format ( $data[1], 2);?></span>


      </div>
      <!-- /.info-box-content -->
    </div>
    <!-- /.info-box -->
  </div>
  <!-- /.col -->
  <div class="col-md-3 col-sm-6 col-xs-12">
    <div class="info-box">
      <span class="info-box-icon bg-red"><img src="dist/img/phmeasur.png" alt="User Image" height="90%"></span>

      <div class="info-box-content">
        <span class="info-box-text">pH</span>
        <span class="info-box-number" id="ph"><?php echo number_format( $data[2],2);?></span>
      </div>
      <!-- /.info-box-content -->
    </div>
    <!-- /.info-box -->
  </div>
  <!-- /.col -->

  <!-- fix for small devices only -->
  <div class="clearfix visible-sm-block"></div>

  <div class="col-md-3 col-sm-6 col-xs-12">
    <div class="info-box">
    <!-- /  <span class="info-box-icon bg-green"><i class="ion ion-ios-cart-outline"></i></span>-->
<span class="info-box-icon bg-green"><img src="dist/img/salinity.png" alt="User Image" height="90%"></span>
      <div class="info-box-content">
        <span class="info-box-text">TDS</span>
        <span class="info-box-number" id="tds"><?php echo number_format ($data[3],2);?></span>
      </div>
      <!-- /.info-box-content -->
    </div>
    <!-- /.info-box -->
  </div>
  <!-- /.col -->

  <div class="col-md-3 col-sm-6 col-xs-12">
    <div class="info-box">
      <span class="info-box-icon bg-yellow"><img src="dist/img/SUHU.png" alt="User Image" height="90%"></i></span>

      <div class="info-box-content">
        <span class="info-box-text">COND</span>
        <span class="info-box-number" id="sal"><?php echo number_format ($data[4],2);?></span>
      </div>
      <!-- /.info-box-content -->
    </div>
    <!-- /.info-box -->
  </div>
  <!-- /.col -->
