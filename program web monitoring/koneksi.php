<?php
$host = MySQLi_connect("192.168.43.224:8080","root","", "parameter");
if($host){
	//echo "koneksi host berhasil.<br/>";
}else{
	echo "koneksi gagal.<br/>";
}
// isikan dengan nama database yang akan di hubungkan
//$db = MySQLi_select_db("parameter");

if("parameter"){
	//echo "koneksi database berhasil.";
}else{
	echo "koneksi database gagal.";
}
?>
