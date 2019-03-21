<?php
$host = MySQLi_connect("192.168.43.224","root","", "parameter");
$search_sql = "SELECT * FROM datasensor ORDER BY no DESC";
$query=mysqli_query($host, $search_sql);
?>
 <div class="box-body">
              <div class="row">
			  <?php
         $data = mysqli_fetch_row($query);
           ?>
                <div class="col-md-20" id="kualitas">
				<h1>
                  <p class="text-center">
				  
                    <?php echo $data[5];?>
					
                  </p>
                 </h1> 
                  <!-- /.chart-responsive -->
                </div>
                <!-- /.col -->
                
                  <!-- /.progress-group -->
                 
                  <!-- /.progress-group -->
                  
                  <!-- /.progress-group -->
                  
                  </div>
                  <!-- /.progress-group -->
                </div>