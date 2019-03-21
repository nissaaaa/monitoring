<?php
$host = mysql_connect("localhost","root","");

if($host){
	//echo "koneksi host berhasil.<br/>";
}else{
	echo "koneksi gagal.<br/>";
}
// isikan dengan nama database yang akan di hubungkan
$db = mysql_select_db("parameter");

if($db){
	//echo "koneksi database berhasil.";
}else{
	echo "koneksi database gagal.";
}
?>
