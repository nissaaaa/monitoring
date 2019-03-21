# monitoring
adalah aplikasi monitoring perairan dangkal dengan bantuan USV. terdapat 3 bagian yaitu: <br>
<strong>1. program hadware <br></strong>
   program hardware disini digunakan untuk menalankan hardware agar dapat merekam data parameter kualitas air dengan menggunakan sensor pH, suhu dan TDS serta GPS untuk tracking USV pada mikrokontroler dan untuk dapat mengirim data ke server. komunikasi yang dipakai adalah melalui radio 3DR 433MHz. bahasa yang digunakan adalah bahasa c++ dengan editor arduino. <br>
<strong>2. aplikasi desktop<br></strong>
   aplikasi dekstop digunakan untuk menerima data dari hardware , menampilkannya dalam bentuk numerik dan grafik, menampilkan tracking posisi USV dan mengirim data ke server/database. bahasa yang digunakan adalah c# dan editor yang digunakan adalah visual studio. terdapat library yang dibutuhkan seperti <strong>bunifu</strong> agar tampilan lebih menarik, <strong>zedgraph</strong> agar dapat menampilkan grafik dan <strong>devexpress</strong> untuk dapat menggunakan fitur control yang lebih lengkap. <strong>PUTAR VIDEO DEMO </strong> untuk meilihat bagaimana aplikasi ini berjalan </br>
<strong>3. aplikasi web<br></strong>
  aplikasi ini juga dibuat dalam bentuk web yang dapat menampilkan data hasil monitoring secara realtime. 
