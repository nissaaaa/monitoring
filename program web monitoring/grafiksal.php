<?php
$host = MySQLi_connect("192.168.43.224","root","", "parameter");
$search_sql = "SELECT * FROM datasensor";
$query=mysqli_query($host, $search_sql);
?>

	<link href="css/examples.css" rel="stylesheet" type="text/css">
	<!--[if lte IE 8]><script language="javascript" type="text/javascript" src="../../excanvas.min.js"></script><![endif]-->
	<script language="javascript" type="text/javascript" src="js/jquery.js"></script>
	<script language="javascript" type="text/javascript" src="js/jquery.flot.js"></script>
	
	<script type="text/javascript">

	$(function() {

		// We use an inline data source in the example, usually data would
		// be fetched from a server

		var data = [],
			//totalPoints = 500;
			totalPoints = <?php echo $jml=mysqli_num_rows($query);?>;

		function getRandomData() {

			if (data.length > 0)
				data = data.slice(1);

			// Do a random walk

			//while (data.length < totalPoints) {
				<?php while($isi=mysqli_fetch_array($query)){?>

				//var prev = data.length > 0 ? data[data.length - 1] : 50,
					//y = prev + Math.random() * 10 - 5;
					y = <?php echo $isi['dissolve'];?>
			

				data.push(y);
			<?php } ?>

			// Zip the generated y values with the x values

			var res = [];
			for (var i = 0; i < data.length; ++i) {
				res.push([i, data[i]])
			}

			return res;
		}

		// Set up the control widget

		var updateInterval = 100;
		$("#updateInterval").val(updateInterval).change(function () {
			var v = $(this).val();
			if (v && !isNaN(+v)) {
				updateInterval = +v;
				if (updateInterval < 1) {
					updateInterval = 1;
				} else if (updateInterval > 100) {
					updateInterval = 100;
				}
				$(this).val("" + updateInterval);
			}
		});

		var plot = $.plot("#placeholder", [ getRandomData() ], {
			series: {
				shadowSize: 0	// Drawing is faster without shadows
			},
			yaxis: {
				

				<?php 
			
			
				$search_sql2 = "SELECT MAX(dissolve+200) as max from datasensor";
					$query2=mysqli_query($host, $search_sql2);
				$max = mysqli_fetch_array($query2); 
				?>
				min: 0,
				max: <?php echo $max['max'];?>
			},
			xaxis: {
				<?php
				$search_sql3 = "SELECT MAX(no) as max from datasensor";
					$query3=mysqli_query($host, $search_sql3);
				$max = mysqli_fetch_array($query3); 
				?>
			}
		});

		function update() {

			plot.setData([getRandomData()]);

			// Since the axes don't change, we don't need to call plot.setupGrid()

			plot.draw();
			setTimeout(update, updateInterval);
		}

		update();

		// Add the Flot version string to the footer

		//$("#footer").prepend("Flot " + $.plot.version + " &ndash; ");
	});

	</script>


	<div id="content">

		<div class="demo-container">
			<div id="placeholder" class="demo-placeholder"></div>
		</div>		
		<!--p>Time between updates: <input id="updateInterval" type="text" value="" style="text-align: right; width:5em"> milliseconds</p-->

	</div>


	

