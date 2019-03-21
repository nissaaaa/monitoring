<?php
$host = MySQLi_connect("localhost","root","", "parameter");
$search_sql = "SELECT * FROM datasensor";
$query=mysqli_query($host, $search_sql);
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<title>Flot Examples: Real-time updates</title>
	<link href="../examples.css" rel="stylesheet" type="text/css">
	<!--[if lte IE 8]><script language="javascript" type="text/javascript" src="../../excanvas.min.js"></script><![endif]-->
	<script language="javascript" type="text/javascript" src="../../jquery.js"></script>
	<script language="javascript" type="text/javascript" src="../../jquery.flot.js"></script>
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
					y = <?php echo $isi['suhu'];?>
			

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
				<?php $max = mysqli_fetch_array(mysql_query("SELECT MAX(suhu+10) as max from datasensor")); ?>
				min: 0,
				max: <?php echo $max['max'];?>
			},
			xaxis: {
				<?php $max2 = mysqli_fetch_array(mysql_query("SELECT MAX(no) as max from datasensor")); ?>
				min: 0,
				max: <?php echo $max2['max'];?>
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
</head>
<body>

	<div id="header">
		<h2>Real-time updates</h2>
	</div>

	<div id="content">

		<div class="demo-container">
			<div id="placeholder" class="demo-placeholder"></div>
		</div>

		<p>You can update a chart periodically to get a real-time effect by using a timer to insert the new data in the plot and redraw it.</p>

		<p>Time between updates: <input id="updateInterval" type="text" value="" style="text-align: right; width:5em"> milliseconds</p>

	</div>

	<div id="footer">
		Copyright &copy; 2007 - 2014 IOLA and Ole Laursen
	</div>

</body>
</html>