using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.MapProviders;
using GMap.NET.CacheProviders;
using ZedGraph;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;  //Its for MySQL  


namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        double curLat, curLng, preLat, preLng;
        string dateinfo;
        List<PointLatLng> list = new List<PointLatLng>();
        GMapRoute r;
        GMarkerGoogle balon;
        int i;
        string[] data = new string[10];
        int datadepanlat, datadepanlng;
        int databelakanglat, databelakanglng;
        bool mapFlag;
        string Temp;
        double time, tick = 0;
        double gsLat, gsLng;
        public string myStr;
        string[] data_data_gambar = new string[300];
        byte[] data_gambar_matang = new byte[40000];
        int[] data_int = new int[20000];
        string[] nama = new string[45];
        int jam, menit, detik, mdetik;
        double gcslat, gcslong;
        double suhu, pH, kond, TDS;
        string[] adc_pitch = new string[4];
        string[] adc_yaw = new string[4];
        string[] arr = new string[4];
        int[] data_int1 = new int[20000];
        int[] data_int5 = new int[20000];
        string simpandata;
        double TDS_max = 12, TDS_persen;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        int counter = 1;
        string sh, ph, dis, bat;
        double selisihlat, selisihlong;
        double suhu2 = 0, suhu3 = 0;
        double jlat, jlong, jx, jy, r1, r2, tinggigcs = 1.55;
        double jx_jy, jy_jx;
        double dropp = 0, pac_receiv = 0, drop_pac, drop_rec, pac_rec;
        decimal pac_loss;
        int data_count = 0, jum_pac = 0;
        double simulasi_time;
        double detik_kirim, detik_terima, detik_detik, jarak, masuk = 0, trough = 0;
        double suhu_good, suhu_medium, suhu_bad, suhu_vbad;
        double pH_good, pH_medium, pH_bad, ph_vbad, ph_excel;
        double tds_good, tds_medium, tds_bad, tds_vbad;
        double hasil_min, hasil_T, hasil_p, hasil_t;
        string jamku, jamku2;
        double excel = 95, good = 80, med = 60, bad = 37.5, vbad = 12.5;
        double good_m, excel_m, bad_m, vbad_m, medium_m;
        double min1, min2, min3, min4, min5, min6, min7, min8, min9, min10, min11, min12, min13, min14, min15, min16, min17, min18, min19, min20,
       min21, min22, min23, min24, min25, min26, min27, min28, min29, min30, min31, min32, min33, min34, min35, min36, min37, min38, min39, min40, min41, min42, min43, min44, min45, min46, min47, min48, min49, min50, min51, min52,
       min53, min54, min55, min56, min57, min58, min59, min60, min61, min62, min63, min64, min65, min66, min67, min68, min69, min70, min71, min72, min73, min74, min75, min76, min77, min78, min79, min80;
        double nilai_x1, nilai_x2, nilai_x3, nilai_x4, nilai_x5, nilai_x6, nilai_x7, nilai_x8, nilai_x9, nilai_x10, nilai_x11, nilai_x12, nilai_x13, nilai_x14, nilai_x15, nilai_x16, nilai_x17, nilai_x18, nilai_x19, nilai_x20, nilai_x21, nilai_x22, nilai_x23, nilai_x24, nilai_x25, nilai_x26, nilai_x27, nilai_x28, nilai_x29, nilai_x30, nilai_x31, nilai_x32, nilai_x33, nilai_x34, nilai_x35, nilai_x36, nilai_x37, nilai_x38, nilai_x39, nilai_x40, nilai_x41, nilai_x42, nilai_x43, nilai_x44, nilai_x45, nilai_x46, nilai_x47, nilai_x48, nilai_x49, nilai_x50, nilai_x51, nilai_x52, nilai_x53, nilai_x54, nilai_x55, nilai_x56, nilai_x57, nilai_x58, nilai_x59, nilai_x60, nilai_x61, nilai_x62, nilai_x63, nilai_x64, nilai_x65, nilai_x66, nilai_x67, nilai_x68, nilai_x69, nilai_x70, nilai_x71, nilai_x72, nilai_x73, nilai_x74, nilai_x75, nilai_x76, nilai_x77, nilai_x78, nilai_x79, nilai_x80, nilaix81;
        double signka1, signka2, signka3, signka4, signka5, signka6, signka7, signka8, signka9, signka10, signka11, signka12, signka13, signka14, signka15, signka16, signka17, signka18, signka19, signka20, signka21, signka22, signka23, signka24, signka25, signka26, signka27;
        double pembilang, penyebut, COA;
        String i_ex = "excellent", i_good = "good", i_med = "medium", i_bad = "bad", i_very = "very bad";
        String indeks_suhu, indeks_pH, indeks_tds ,kualitas;
        double tPut;
        String kode;
        double minimal;
        int panjang;
        MySqlConnection cs = new MySqlConnection("Server=localhost;Database=parameter;UID=root;Password=''");
        MySqlDataAdapter da = new MySqlDataAdapter();
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            i = 0;

            //===================inisialisasi peta==============================
            //=================jika menggunakan proxy===================//
            // GMap.NET.MapProviders.GoogleMapProvider.WebProxy = new WebProxy("proxy3.pens.ac.id",3128);
            //=========================================================//


            gMapControl1.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;//.GoogleSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Position = new PointLatLng(-7.782391, 109.667620);
            gMapControl1.Zoom = 150;
            dateinfo = DateTime.Now.ToString();

            trackBar1.Value = (int)gMapControl1.Zoom;
            //==========================================inisialisasi grafik================================================
            GraphPane dataSuhu = zedGraphControl1.GraphPane;
            dataSuhu.Title.Text = "Data Suhu";
            dataSuhu.Title.FontSpec.FontColor = Color.White;
            dataSuhu.Title.FontSpec.Size = 30;
            dataSuhu.YAxis.Title.Text = "Suhu, °C";
            dataSuhu.XAxis.Title.Text = "waktu, s";
            dataSuhu.Chart.Fill = new Fill(Color.White, Color.Azure, 45.0f);
            dataSuhu.Fill = new Fill(Color.MediumTurquoise);

            GraphPane dataPH = zedGraphControl2.GraphPane;
            dataPH.Title.Text = "Data PH";
            dataPH.Title.FontSpec.FontColor = Color.White;
            dataPH.Title.FontSpec.Size = 30;
            dataPH.YAxis.Title.Text = "PH, ";
            dataPH.XAxis.Title.Text = "waktu, s";
            dataPH.Chart.Fill = new Fill(Color.White, Color.Azure, 45.0f);
            dataPH.Fill = new Fill(Color.MediumTurquoise);

            GraphPane dataDO = zedGraphControl3.GraphPane;
            dataDO.Title.Text = "Data Konduktivitas";
            dataDO.Title.FontSpec.FontColor = Color.White;
            dataDO.Title.FontSpec.Size = 30;
            dataDO.YAxis.Title.Text = "Konduktivitas, mg/l";
            dataDO.XAxis.Title.Text = "waktu, s";
            dataDO.Chart.Fill = new Fill(Color.White, Color.Azure, 45.0f);
            dataDO.Fill = new Fill(Color.MediumTurquoise);

            GraphPane dataTDS = zedGraphControl4.GraphPane;
            dataTDS.Title.Text = "Data TDS";
            dataTDS.Title.FontSpec.FontColor = Color.White;
            dataTDS.Title.FontSpec.Size = 30;
            dataTDS.YAxis.Title.Text = "TDS, mg/l";
            dataTDS.XAxis.Title.Text = "waktu, s";
            dataTDS.Chart.Fill = new Fill(Color.White, Color.Azure, 45.0f);
            dataTDS.Fill = new Fill(Color.MediumTurquoise);

            RollingPointPairList listSuhu = new RollingPointPairList(1200);
            RollingPointPairList listPH = new RollingPointPairList(1200);
            RollingPointPairList listDO = new RollingPointPairList(1200);
            RollingPointPairList listTDS = new RollingPointPairList(1200);

            LineItem curveSuhu = dataSuhu.AddCurve("Suhu", listSuhu, Color.Orange);
            LineItem curvePH = dataPH.AddCurve("PH", listPH, Color.Green);
            LineItem curveDO = dataDO.AddCurve("Konduktivitas", listDO, Color.Blue);
            LineItem curveTDS = dataTDS.AddCurve("TDS", listTDS, Color.Blue);

            dataSuhu.XAxis.Scale.Min = 0;
            dataSuhu.XAxis.Scale.Max = 30;
            dataSuhu.XAxis.Scale.MinorStep = 1;
            dataSuhu.XAxis.Scale.MajorStep = 5;

            dataPH.XAxis.Scale.Min = 0;
            dataPH.XAxis.Scale.Max = 30;
            dataPH.XAxis.Scale.MinorStep = 1;
            dataPH.XAxis.Scale.MajorStep = 5;

            dataDO.XAxis.Scale.Min = 0;
            dataDO.XAxis.Scale.Max = 30;
            dataDO.XAxis.Scale.MinorStep = 1;
            dataDO.XAxis.Scale.MajorStep = 5;

            dataTDS.XAxis.Scale.Min = 0;
            dataTDS.XAxis.Scale.Max = 30;
            dataTDS.XAxis.Scale.MinorStep = 1;
            dataTDS.XAxis.Scale.MajorStep = 5;


            zedGraphControl1.Invalidate();
            zedGraphControl2.Invalidate();
            zedGraphControl3.Invalidate();
            zedGraphControl4.Invalidate();
            zedGraphControl1.AxisChange();
            zedGraphControl2.AxisChange();
            zedGraphControl3.AxisChange();
            zedGraphControl4.AxisChange();
            //label4.Font = new Font("Arial", 10, FontStyle.Bold);
            label5.Font = new Font("Arial", 10, FontStyle.Bold);
            label8.Font = new Font("Arial", 10, FontStyle.Bold);
            label14.Font = new Font("Arial", 10, FontStyle.Bold);
            label39.Font = new Font("Arial", 10, FontStyle.Bold);
            label6.Font = new Font("Arial", 20, FontStyle.Bold);
            label9.Font = new Font("Arial", 20, FontStyle.Bold);
            label40.Font = new Font("Arial", 20, FontStyle.Bold);
            label41.Font = new Font("Arial", 20, FontStyle.Bold);
            //  label40.Font = new Font("Arial", 20, FontStyle.Bold);
            //label12.Font = new Font("Arial", 12, FontStyle.Bold);
            //label13.Font = new Font("Arial", 12, FontStyle.Bold);

            label5.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {


            try
            {
                this.Temp = serialPort1.ReadTo("\r\n");
                masuk++;




            }
            catch
            {
                return;
            }


            this.BeginInvoke(new EventHandler(cek_data));
        }

        private void cek_data(object sender, EventArgs e)
        {

            try
            {
                byte[] data_int = Encoding.ASCII.GetBytes(Temp);

                if (data_int[0] == 87 && data_int[1] == 65 && data_int[2] == 84 && data_int[3] == 69 && data_int[4] == 82)
                {
                    this.tampilkata();
                    data_count = Temp.Length;
                    jum_pac = jum_pac + data_count;
                    label47.Text = Convert.ToString(Temp.Length);
                    label48.Text = Convert.ToString(data_count);
                    label49.Text = Convert.ToString(jum_pac);
                    label26.Text = Convert.ToString(jum_pac);
                   
                    return;

                }


         


            }
            catch
            {
                return;
            }
        }


        private void tampilkata()
        {
            string[] split = Temp.Split(new char[] { ' ' });

            foreach (string s in split)
            {


                if (i > 8)
                {
                    i = 0;
                }

                data[i] = s;
                if (data[0] == "WATER")
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

            }
            i = 0;

            try
            {

                if (data[5].Length == 9)
                {
                    curLat = Convert.ToDouble(data[5]);
                    //curLat = -((Convert.ToDouble(data[6])));
                    //databelakanglat = (int)((curLat % 100) * 10000);
                    //datadepanlat = (int)(curLat / 100);
                    //curLat = datadepanlat + ((int)(databelakanglat / 0.6)) / 1000000.0;
                }

                if (data[6].Length == 10)
                {
                    curLng = Convert.ToDouble(data[6]);
                    //curLng = (Convert.ToDouble(data[7]));
                    //databelakanglng = (int)((curLng % 100) * 10000);
                    //datadepanlng = (int)(curLng / 100);
                    // curLng = datadepanlng + ((int)(databelakanglng / 0.6)) / 1000000.0;
                }

            }
            catch
            {

            }
            try
            {
                suhu = Convert.ToDouble(data[1]);


                pH = Convert.ToDouble(data[2]);

                kond = Convert.ToDouble(data[3]);
                TDS = Convert.ToDouble(data[4]);
                //  detik_kirim = Convert.ToDouble(data[1]);
                detik_kirim = detik_kirim;
                sh = (data[1]);
                ph = (data[3]);
                dis = (data[2]);
                bat = (data[4]);
                kode = Convert.ToString(data[8]);
                if (data[0] == "WATER")
                {

                    pac_receiv++;
                    label16.Text = Convert.ToString(pac_receiv);

                }

                if (Temp.Length < 49 && Temp.Length > 53 && data[0] != "WATER")
                {

                    dropp++;
                    label13.Text = Convert.ToString(dropp);
                }
           
                jamku2 = DateTime.Now.ToString("hh:mm:ss.fff");
                detik_terima = Convert.ToDouble(jamku2);
                jamku = DateTime.Now.ToString("hh:mm:ss.ff");
                detik_terima = Convert.ToDouble(jamku);
                detik_detik = detik_terima - detik_kirim;




            }
            catch
            {

            }
            richTextBox1.AppendText(Temp);
            richTextBox1.AppendText("\r");
            richTextBox1.ScrollToCaret();
            //////////////////////////paket drop///////////
            drop_rec = Convert.ToDouble(label13.Text);
            pac_rec = Convert.ToDouble(label16.Text);
            drop_pac = (drop_rec / pac_rec) * 100;
            pac_loss = Convert.ToDecimal(drop_pac);
            ///////////////////////////////////////////////
            selisihlat = curLat - gcslat;
            selisihlong = curLng - gcslong;

            jlat = selisihlat * 3600;   // konversi ke detik derajat
            jlong = selisihlong * 3600;

            jy = jlat * 30.416;    // 1 detik derajat = 30.416 meter,,, konversi jarak gps ke meter
            jx = jlong * 30.416;

            jx_jy = Math.Abs(jx) / Math.Abs(jy);
            jy_jx = Math.Abs(jy) / Math.Abs(jx);

            r1 = Math.Sqrt(Math.Pow(jx, 2) + Math.Pow(jy, 2)); // resultan
            // r2 = Math.Sqrt(Math.Pow(alti, 2) + Math.Pow(r1, 2));
            jarak = Convert.ToDouble(r1);
            label15.Text = Convert.ToString(jarak) + "  meter";

            //==================================================update data=======================================================================

            suhu3 = suhu - suhu2;
            suhu2 = suhu;
            //label6.Text = Convert.ToString(suhu) + " °C";
            label6.Text = Convert.ToString(suhu) + " °C" + Convert.ToString(suhu3) + " °C";
            label9.Text = Convert.ToString(pH) + "";
            label40.Text = Convert.ToString(kond) + " mg/l";
            label41.Text = Convert.ToString(TDS) + " mg/l";
            label17.Text = Convert.ToString(pac_loss);
            //label13.Text = Convert.ToString(curLat) + "";
            //label15.Text = Convert.ToString(curLng) + " %";
            //TDS_persen = (TDS / TDS_max) * 100;
            //label14.Text = Convert.ToInt32(TDS_persen)+ " %";
            //bunifuCircleProgressbar1.Value = Convert.ToInt32(TDS_persen);
            //bunifuC//ircleProgressbar1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            linearScaleComponent4.Value = Convert.ToSingle(suhu);
            linearScaleComponent6.Value = Convert.ToSingle(pH);
            linearScaleComponent8.Value = Convert.ToSingle(kond);
            linearScaleComponent10.Value = Convert.ToSingle(TDS);
            //arcScaleComponent2.Value = Convert.ToSingle(yaw);
            // arcScaleComponent3.Value = Convert.ToSingle(pitch);
            //int jam1=0, detik1=0, menit1=2;
            label20.Text = DateTime.Now.ToString("hh:mm:ss.ff");
            label19.Text = DateTime.Now.ToString("hh:mm:ss.fff");
            label18.Text = Convert.ToString(detik_detik);


            //===========================================Convert to WQI===================================
            //SUHU====SUHU=====SUHU====
            // suhu3= temperature change
            if (suhu3 <= 5.6 && suhu3 >= 0)
            {
                indeks_suhu = i_good;
            }
            else if (suhu3 >= 5.7 && suhu3 <= 9)
            {
                indeks_suhu = i_med;
            }
            else if (suhu3 > 9 && suhu3 <= 18.5)
            {

                indeks_suhu = i_bad;
            }
            else if (suhu3 > 18.5)
            {
                indeks_suhu = i_very;
            }

            ///PH====PH===PH
            if (pH >= 0 && pH <= 4.96 && pH >= 9.77 && pH <= 14)
            {

                indeks_pH = i_very;
            }
            else if (pH > 4.96 && pH <= 5.85 && pH >= 8.97 && pH <= 9.77)
            {
                indeks_pH = i_bad;
            }
            else if (pH > 5.85 && pH <= 6.47 && pH >= 8.4 && pH <= 8.97)
            {
                indeks_pH = i_med;
            }
            else if (pH > 6.47 && pH <= 7.12 && pH >= 7.8 && pH <= 8.4)
            {
                indeks_pH = i_good;
            }
            else if (pH > 7.12 && pH <= 7.8)
            {

                indeks_pH = i_ex;
            }


            ///TDS==TDS==TDS
            ///
            if (TDS >= 1 && TDS <= 223)
            {
                indeks_tds = i_good;
            }
            else if (TDS >= 224 && TDS <= 376)
            {

                indeks_tds = i_med;
            }
            else if (TDS > 376 && TDS <= 500)
            {
                indeks_tds = i_bad;
            }
            else if (TDS > 500)
            {

                indeks_tds = i_very;
            }

            //===========================================================================================
            ////===========================================FUZZY logic=================================///
            defuzzifikasi();

            //preLatRad = preLat * 2 * Math.PI / 360.0;
            //preLngRad = preLng * 2 * Math.PI / 360.0;
            //curLatRad = curLat * 2 * Math.PI / 360.0;
            //CurLngRad = curLng * 2 * Math.PI / 360.0;
            //dlat = curLatRad - preLatRad;
            //dlng = CurLngRad - preLngRad;
            //SUHU = Convert.ToString(suhu);
            //PH = Convert.ToString(pH);
            //DO = Convert.ToString(kond);
            //BAT = Convert.ToString(tds_persen);


            label70.Text = DateTime.Now.ToString("hh:mm:ss");

            simpandata = "WATER " + DateTime.Now.ToString("hh:mm:ss") + "\t" + suhu + "\t" + pH + "\t" + kond + "\t" + TDS + "\t" + curLat + "\t" + curLng + "\t" + kualitas + "\t" + detik_kirim +"\t"+detik_terima + "\t" + pac_loss + "\t" + tPut;
            StreamWriter tulis = new StreamWriter(@"C:\\Users\\yelsa\\Desktop\\TA\\PERJUANGKAN\\data.txt", true, Encoding.Default);
            tulis.WriteLine(simpandata);
            tulis.Close();

            da.InsertCommand = new MySqlCommand("INSERT INTO datasensor (suhu,ph,kond,TDS, kualitas) VALUES(@suhu,@ph,@kond,@TDS, @kualitas)", cs);
            da.InsertCommand.Parameters.AddWithValue("@suhu", suhu);
            da.InsertCommand.Parameters.AddWithValue("@pH", pH);
            da.InsertCommand.Parameters.AddWithValue("@kond", kond);
            da.InsertCommand.Parameters.AddWithValue("@TDS", TDS);
            da.InsertCommand.Parameters.AddWithValue("@kualitas", kualitas);
           
            
          // da.InsertCommand.Parameters.AddWithValue("@kualitas", 2).Value = kualitas;
            //buka koneksi ke database
            cs.Open();
            //eksekusi query insert
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();

            //===============================grafik======================================================//

            if (zedGraphControl1.GraphPane.CurveList.Count <= 0 && zedGraphControl2.GraphPane.CurveList.Count <= 0 && zedGraphControl3.GraphPane.CurveList.Count <= 0 && zedGraphControl3.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curveSuhu = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curvePH = zedGraphControl2.GraphPane.CurveList[0] as LineItem;
            LineItem curveDO = zedGraphControl3.GraphPane.CurveList[0] as LineItem;
            LineItem curveTDS = zedGraphControl4.GraphPane.CurveList[0] as LineItem;

            if (curveSuhu == null && curvePH == null && curveDO == null && curveTDS == null)
                return;

            IPointListEdit listSuhu = curveSuhu.Points as IPointListEdit;
            IPointListEdit listPH = curvePH.Points as IPointListEdit;
            IPointListEdit listDO = curveDO.Points as IPointListEdit;
            IPointListEdit listTDS = curveTDS.Points as IPointListEdit;

            if (listSuhu == null && listPH == null && listDO == null && listTDS == null)
                return;

            listSuhu.Add(time, suhu);
            listPH.Add(time, pH);
            listDO.Add(time, kond);
            listTDS.Add(time, TDS);


            Scale ySuhuScale = zedGraphControl1.GraphPane.XAxis.Scale;
            Scale yPHScale = zedGraphControl2.GraphPane.XAxis.Scale;
            Scale yDOScale = zedGraphControl3.GraphPane.XAxis.Scale;
            Scale yTDSScale = zedGraphControl4.GraphPane.XAxis.Scale;

            if (time > ySuhuScale.Max - ySuhuScale.MajorStep)
            {
                ySuhuScale.Max = time + ySuhuScale.MajorStep;
                ySuhuScale.Min = ySuhuScale.Max - 30.0;
            }

            if (time < ySuhuScale.Min + ySuhuScale.MajorStep)
            {
                ySuhuScale.Min = time - ySuhuScale.MajorStep;
                ySuhuScale.Max = ySuhuScale.Min + 30.0;
            }

            if (time > yPHScale.Max - yPHScale.MajorStep)
            {
                yPHScale.Max = time + yPHScale.MajorStep;
                yPHScale.Min = yPHScale.Max - 30.0;
            }

            if (time < yPHScale.Min + yPHScale.MajorStep)
            {
                yPHScale.Min = time - yPHScale.MajorStep;
                yPHScale.Max = yPHScale.Min + 30.0;
            }

            if (time > yDOScale.Max - yDOScale.MajorStep)
            {
                yDOScale.Max = time + yDOScale.MajorStep;
                yDOScale.Min = yDOScale.Max - 30.0;
            }

            if (time < yDOScale.Min + yDOScale.MajorStep)
            {
                yDOScale.Min = time - yDOScale.MajorStep;
                yDOScale.Max = yDOScale.Min + 30.0;
            }
            if (time > yTDSScale.Max - yTDSScale.MajorStep)
            {
                yTDSScale.Max = time + yTDSScale.MajorStep;
                yTDSScale.Min = yTDSScale.Max - 30.0;
            }

            if (time < yTDSScale.Min + yTDSScale.MajorStep)
            {
                yTDSScale.Min = time - yTDSScale.MajorStep;
                yTDSScale.Max = yTDSScale.Min + 30.0;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl2.AxisChange();
            zedGraphControl3.AxisChange();
            zedGraphControl4.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl2.Invalidate();
            zedGraphControl3.Invalidate();
            zedGraphControl4.Invalidate();
            //===============================GCS control=================================================//




            //===============================End Of GCS control==========================================//

            //===============================grafik======================================================//

            //================================================tracking====================================================//

            if (mapFlag == true)
            {
                PointLatLng start = new PointLatLng(preLat, preLng);
                PointLatLng end = new PointLatLng(curLat, curLng);
                list.Add(new PointLatLng(preLat, preLng));
                list.Add(new PointLatLng(curLat, curLng));

                r = new GMapRoute(list, "My route");
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                balon.Position = new PointLatLng(curLat, curLng);
                routesOverlay.Routes.Add(r);
                gMapControl1.Overlays.Add(routesOverlay);
                balon.ToolTipText = curLat + ", " + curLng;

                gMapControl1.UpdateRouteLocalPosition(r);
            }

            preLng = curLng;
            preLat = curLat;


        }



        public double good_pt(double a, double b, double x)
        {

            if (x >= a && x <= b)
            {
                good_m = (b - x) / (b - a);

            }
            else if (x >= b)
            {
                good_m = 0;

            }
            else if (x <= a)
            {
                good_m = 1;

            }
            return good_m;
        }


        public double medium_pt(double a, double b, double c, double d, double x)
        {
            ////suhu x

            if (x <= a)
            {
                medium_m = 0;
            }
            else if (x >= d)
            {

                medium_m = 0;
            }
            else if (x <= b && x >= a)
            {
                medium_m = (x - a) / (b - a);
            }
            else if (x <= c && x >= b)
            {
                medium_m = 1;
            }
            else if (x <= d && x >= c)
            {
                medium_m = (d - x) / (d - c);
            }


            return medium_m;
        }


        public double bad_pt(double a, double b, double c, double d, double x)
        {
            ////suhu x

            if (x <= a)
            {
                bad_m = 0;
            }
            else if (x >= d)
            {

                bad_m = 0;
            }
            else if (x <= b && x >= a)
            {
                bad_m = (x - a) / (b - a);
            }
            else if (x <= c && x >= b)
            {
                bad_m = 1;
            }
            else if (x <= d && x >= c)
            {
                bad_m = (d - x) / (d - c);
            }


            return bad_m;
        }

        public double vbad_pt(double a, double b, double x)
        {
            if (x >= a)
            {
                vbad_m = 1;
            }
            else if (x >= a && x <= b)
            {
                vbad_m = (x - a) / (b - a);
            }
            else if (x <= a)
            {
                vbad_m = 0;
            }
            return vbad_m;
        }

        ///////membership pH

        public double vbad_ph(double a, double b, double c, double d, double x)
        {

            if (x >= a && x <= b)
            {
                vbad_m = (b - x) / (b - a);

            }
            else if (x >= c && x <= d)
            {

                vbad_m = (x - c) / (d - c);
            }
            else if (x > b && x < c)
            {
                vbad_m = 0;

            }
            else if (x <= a)
            {
                vbad_m = 1;

            }
            else if (x >= d)
            {
                vbad_m = 1;
            }

            return vbad_m;
        }

        public double bad_ph(double a, double b, double c, double d, double e, double f, double g, double h, double x)
        {

            if (x < a)
            {
                bad_m = 0;
            }
            else if (x > d && x < e)
            {

                bad_m = 0;
            }
            else if (x >= h)
            {
                bad_m = 0;
            }
            else if (x <= b && x >= a)
            {
                bad_m = (x - a) / (b - a);
            }
            else if (x <= f && x >= e)
            {
                bad_m = (x - e) / (f - e);
            }
            else if (x <= c && x >= b)
            {
                bad_m = 1;
            }
            else if (x <= g && x >= f)
            {
                bad_m = 1;
            }

            else if (x <= d && x >= c)
            {
                bad_m = (d - x) / (d - c);
            }
            else if (x <= h && x >= g)
            {
                bad_m = (h - x) / (h - g);

            }
            return bad_m;

        }

        public double med_ph(double a, double b, double c, double d, double e, double f, double g, double h, double x)
        {

            if (x < a)
            {
                medium_m = 0;
            }
            else if (x > d && x < e)
            {

                medium_m = 0;
            }
            else if (x > h)
            {
                medium_m = 0;
            }
            else if (x <= b && x >= a)
            {
                medium_m = (x - a) / (b - a);
            }
            else if (x <= f && x >= e)
            {
                medium_m = (x - e) / (f - e);
            }
            else if (x <= c && x >= b)
            {
                medium_m = 1;
            }
            else if (x <= g && x >= f)
            {
                medium_m = 1;
            }

            else if (x <= d && x >= c)
            {
                medium_m = (d - x) / (d - c);
            }
            else if (x <= h && x >= g)
            {
                medium_m = (h - x) / (h - g);

            }
            return medium_m;

        }
        public double good_ph(double a, double b, double c, double d, double e, double f, double g, double h, double x)
        {

            if (x < a)
            {
                good_m = 0;
            }
            else if (x > d && x < e)
            {

                good_m = 0;
            }
            else if (x >= h)
            {
                good_m = 0;
            }
            else if (x <= b && x >= a)
            {
                good_m = (x - a) / (b - a);
            }
            else if (x <= f && x >= e)
            {
                good_m = (x - e) / (f - e);
            }
            else if (x <= c && x >= b)
            {
                good_m = 1;
            }
            else if (x <= g && x >= f)
            {
                good_m = 1;
            }

            else if (x <= d && x >= c)
            {
                good_m = (d - x) / (d - c);
            }
            else if (x <= h && x >= g)
            {
                good_m = (h - x) / (h - g);

            }
            return good_m;

        }

        public double excel_ph(double a, double b, double c, double d, double x)
        {
            ////suhu x

            if (x < a)
            {
                excel_m = 0;
            }
            else if (x > d)
            {

                excel_m = 0;
            }
            else if (x <= b && x >= a)
            {
                excel_m = (x - a) / (b - a);
            }
            else if (x <= c && x >= b)
            {
                excel_m = 1;
            }
            else if (x <= d && x >= c)
            {
                excel_m = (d - x) / (d - c);
            }


            return excel_m;
        }







        public double Min(double a, double b, double c)
        {

            /// 3 var
            /// 
            if (a < b && a < c) hasil_min = a;
            else if (b < a && b < c) hasil_min = b;
            else if (c < a && c < b) hasil_min = c;
            else if (a == b && a < c) hasil_min = a;
            else if (a == c && a < b) hasil_min = a;
            else if (b == c && b < a) hasil_min = b;
            else if (b == a && b < c) hasil_min = b;
            else if (c == a && c < b) hasil_min = c;
            else if (c == b && c < a) hasil_min = c;
            else if (a == b && a == c && a == 0 && b == a && b == c && b == 0 && c == a && c == b && c == 0) hasil_min = 0;
            else if (a == b && a == c && a == 1 && b == a && b == c && b == 1 && c == a && c == b && c == 1) hasil_min = 1;

           
            return hasil_min;
        }

        public void fuzzifikasi()
        {
            suhu_good = good_pt(3, 5.6, suhu3);
            suhu_medium = medium_pt(5.6, 6.5, 7.8, 9, suhu3);
            suhu_bad = bad_pt(9, 12.2, 15.5, 18.5, suhu3);
            suhu_vbad = vbad_pt(18.5, 50, suhu3);

            ph_excel = excel_ph(7.12, 73.4, 7.5, 7.8, pH);
            pH_good = good_ph(6.47, 6.67, 6.92, 7.12, 7.8, 7.9, 8.08, 8.4, pH);
            pH_medium = med_ph(5.85, 6.05, 6.25, 6.47, 8.4, 8.59, 8.78, 8.97, pH);
            pH_bad = bad_ph(4.96, 5.25, 5.54, 5.85, 8.97, 8.4, 8.75, 9.77, pH);
            ph_vbad = vbad_ph(3.2, 4.96, 9.77, 12, pH);


            tds_good = good_pt(150, 223, TDS);
            tds_medium = medium_pt(223, 273, 323, 376, TDS);
            tds_bad = bad_pt(376, 417, 458, 500, TDS);
            tds_vbad = vbad_pt(500, 550, TDS);



        }





        public void rules()
        {
            fuzzifikasi();

            //rule1

            min1 = Min(suhu_good, tds_good, ph_excel);
            nilai_x1 = good;


            //rule2
            min2 = Min(suhu_good, tds_good, pH_good);
            nilai_x2 = good;

            //rule3
            min3 = Min(suhu_good, tds_good, pH_medium);
            nilai_x3 = good;

            //rule4
            min4 = Min(suhu_good, tds_good, pH_bad);
            nilai_x4 = med;

            //rule5
            min5 = Min(suhu_good, tds_good, ph_vbad);
            nilai_x5 = bad;

            //rule6
            min6 = Min(suhu_good, tds_medium, ph_excel);
            nilai_x6 = good;

            //rule7
            min7 = Min(suhu_good, tds_medium, pH_good);
            nilai_x7 = good;

            //rule8
            min8 = Min(suhu_good, tds_medium, pH_medium);
            nilai_x8 = med;

            //rule9
            min9 = Min(suhu_good, tds_medium, pH_bad);
            nilai_x9 = med;

            //rule10
            min10 = Min(suhu_good, tds_medium, ph_vbad);
            nilai_x10 = bad;

            //rule11
            min11 = Min(suhu_good, tds_bad, ph_excel);
            nilai_x11 = good;

            //rule12
            min12 = Min(suhu_good, tds_bad, pH_good);
            nilai_x12 = good;


            //rule13
            min13 = Min(suhu_good, tds_bad, pH_medium);
            nilai_x13 = med;

            //rule14
            min14 = Min(suhu_good, tds_bad, pH_bad);
            nilai_x14 = med;

            //rule15
            min15 = Min(suhu_good, tds_bad, ph_vbad);
            nilai_x15 = bad;

            //rule16
            min16 = Min(suhu_good, tds_vbad, ph_excel);
            nilai_x16 = good;

            //rule17
            min17 = Min(suhu_good, tds_vbad, pH_good);
            nilai_x17 = good;

            //rule18
            min18 = Min(suhu_good, tds_vbad, pH_medium);
            nilai_x18 = med;

            //rule19
            min19 = Min(suhu_good, tds_vbad, pH_bad);
            nilai_x19 = bad;

            //rule20
            min20 = Min(suhu_good, tds_vbad, ph_vbad);
            nilai_x20 = bad;


            //rule21
            min21 = Min(suhu_medium, tds_good, ph_excel);
            nilai_x21 = good;

            //rule22
            min22 = Min(suhu_medium, tds_good, pH_good);
            nilai_x22 = good;

            //rule23
            min23 = Min(suhu_medium, tds_good, pH_medium);
            nilai_x23 = med;

            //rule24
            min24 = Min(suhu_medium, tds_good, pH_bad);
            nilai_x24 = med;

            //rule25
            min25 = Min(suhu_medium, tds_good, ph_vbad);
            nilai_x25 = bad;

            //rule26
            min26 = Min(suhu_medium, tds_medium, ph_excel);
            nilai_x26 = good;

            //rule27
            min27 = Min(suhu_medium, tds_medium, pH_good);
            nilai_x27 = good;


            //rule28
            min28 = Min(suhu_medium, tds_medium, pH_medium);
            nilai_x28 = med;

            //rule29
            min29 = Min(suhu_medium, tds_medium, pH_bad);
            nilai_x29 = bad;

            //rule30
            min30 = Min(suhu_medium, tds_medium, ph_vbad);
            nilai_x30 = bad;

            //rule31
            min31 = Min(suhu_medium, tds_bad, ph_excel);
            nilai_x31 = good;

            //rule32
            min32 = Min(suhu_medium, tds_bad, pH_good);
            nilai_x32 = good;

            //rule33
            min33 = Min(suhu_medium, tds_bad, pH_medium);
            nilai_x33 = med;

            //rule34
            min34 = Min(suhu_medium, tds_bad, pH_bad);
            nilai_x34 = bad;

            //rule35
            min35 = Min(suhu_medium, tds_bad, ph_vbad);
            nilai_x35 = bad;


            //rule36
            min36 = Min(suhu_medium, tds_vbad, ph_excel);
            nilai_x36 = good;

            //rule37
            min37 = Min(suhu_medium, tds_vbad, pH_good);
            nilai_x37 = med;

            //rule38
            min38 = Min(suhu_medium, tds_vbad, pH_medium);
            nilai_x38 = med;

            //rule39
            min39 = Min(suhu_medium, tds_vbad, pH_bad);
            nilai_x39 = bad;

            //rule40
            min40 = Min(suhu_medium, tds_vbad, ph_vbad);
            nilai_x40 = bad;

            //rule41
            min41 = Min(suhu_bad, tds_good, ph_excel);
            nilai_x41 = good;

            //rule42
            min42 = Min(suhu_bad, tds_good, pH_good);
            nilai_x42 = med;

            //rule43
            min43 = Min(suhu_bad, tds_good, pH_medium);
            nilai_x43 = med;

            //rule44
            min44 = Min(suhu_bad, tds_good, pH_bad);
            nilai_x44 = bad;

            //rule45
            min45 = Min(suhu_bad, tds_good, ph_vbad);
            nilai_x45 = bad;

            //rule46
            min46 = Min(suhu_bad, tds_medium, ph_excel);
            nilai_x46 = med;

            //rule47
            min47 = Min(suhu_bad, tds_medium, pH_good);
            nilai_x47 = med;

            //rule48
            min48 = Min(suhu_bad, tds_medium, pH_medium);
            nilai_x48 = med;

            //rule49
            min49 = Min(suhu_bad, tds_medium, pH_bad);
            nilai_x49 = vbad;

            //rule50
            min50 = Min(suhu_bad, tds_medium, ph_vbad);
            nilai_x50 = vbad;



            //rule51
            min51 = Min(suhu_bad, tds_bad, ph_excel);
            nilai_x51 = med;

            //rule2
            min52 = Min(suhu_bad, tds_bad, pH_good);
            nilai_x52 = med;

            //rule53
            min53 = Min(suhu_bad, tds_bad, pH_medium);
            nilai_x53 = med;

            //rule54
            min54 = Min(suhu_bad, tds_bad, pH_bad);
            nilai_x54 = bad;

            //rule55
            min55 = Min(suhu_bad, tds_bad, ph_vbad);
            nilai_x55 = vbad;

            //rule56
            min56 = Min(suhu_bad, tds_vbad, ph_excel);
            nilai_x56 = med;

            //rule57
            min57 = Min(suhu_bad, tds_vbad, pH_good);
            nilai_x57 = med;

            //rule58
            min58 = Min(suhu_bad, tds_vbad, pH_medium);
            nilai_x58 = bad;

            //rule59
            min59 = Min(suhu_bad, tds_vbad, pH_bad);
            nilai_x59 = bad;

            //rule60
            min60 = Min(suhu_bad, tds_vbad, ph_vbad);
            nilai_x60 = vbad;


            //rule61
            min61 = Min(suhu_vbad, tds_good, ph_excel);
            nilai_x61 = med;

            //rule2
            min62 = Min(suhu_vbad, tds_good, pH_good);
            nilai_x62 = med;

            //rule63
            min63 = Min(suhu_vbad, tds_good, pH_medium);
            nilai_x63 = med;

            //rule64
            min64 = Min(suhu_vbad, tds_good, pH_bad);
            nilai_x64 = bad;

            //rule65
            min65 = Min(suhu_vbad, tds_good, ph_vbad);
            nilai_x65 = bad;

            //rule66
            min66 = Min(suhu_vbad, tds_medium, ph_excel);
            nilai_x66 = med;

            //rule67
            min67 = Min(suhu_vbad, tds_medium, pH_good);
            nilai_x67 = med;

            //rule68
            min68 = Min(suhu_vbad, tds_medium, pH_medium);
            nilai_x68 = bad;

            //rule69
            min69 = Min(suhu_vbad, tds_medium, pH_bad);
            nilai_x69 = bad;

            //rule70
            min70 = Min(suhu_vbad, tds_medium, ph_vbad);
            nilai_x70 = vbad;

            //rule71
            min71 = Min(suhu_vbad, tds_bad, ph_excel);
            nilai_x71 = med;

            //rule2
            min72 = Min(suhu_vbad, tds_bad, pH_good);
            nilai_x72 = med;

            //rule73
            min73 = Min(suhu_vbad, tds_bad, pH_medium);
            nilai_x73 = bad;

            //rule74
            min74 = Min(suhu_vbad, tds_bad, pH_bad);
            nilai_x74 = bad;

            //rule75
            min75 = Min(suhu_vbad, tds_bad, ph_vbad);
            nilai_x75 = vbad;

            //rule76
            min76 = Min(suhu_vbad, tds_vbad, ph_excel);
            nilai_x76 = med;

            //rule77
            min77 = Min(suhu_vbad, tds_vbad, pH_good);
            nilai_x77 = med;

            //rule78
            min78 = Min(suhu_vbad, tds_vbad, pH_medium);
            nilai_x78 = bad;

            //rule79
            min79 = Min(suhu_vbad, tds_vbad, pH_bad);
            nilai_x79 = bad;

            //rule80
            min80 = Min(suhu_vbad, tds_vbad, ph_vbad);
            nilai_x80 = vbad;




        }

        void defuzzifikasi()
        {
            rules();
            //tampil();
            pembilang = (min1 * nilai_x1) + (min2 * nilai_x2) + (min3 * nilai_x3) + (min4 * nilai_x4) + (min5 * nilai_x5) + (min6 * nilai_x6) + (min7 * nilai_x7) + (min8 * nilai_x8) + (min9 * nilai_x9) + (min10 * nilai_x10) + (min11 * nilai_x11) + (min12 * nilai_x12) + (min13 * nilai_x13) +
                          (min14 * nilai_x14) + (min15 * nilai_x15) + (min16 * nilai_x16) + (min17 * nilai_x17) + (min18 * nilai_x18) + (min19 * nilai_x19) + (min20 * nilai_x20) + (min21 * nilai_x21) + (min22 * nilai_x22) + (min23 * nilai_x23) + (min24 * nilai_x24) + (min25 * nilai_x25) + (min26 * nilai_x26) + (min27 * nilai_x27) + (min28 * nilai_x28) + (min29 * nilai_x29) + (min30 * nilai_x30) +
                          +(min31 * nilai_x31) + (min32 * nilai_x32) + (min33 * nilai_x33) + (min34 * nilai_x34) + (min35 * nilai_x35) + (min36 * nilai_x36) + (min37 * nilai_x37) + (min38 * nilai_x38) + (min39 * nilai_x39) + (min40 * nilai_x40)
                          + (min41 * nilai_x41) + (min42 * nilai_x42) + (min43 * nilai_x43) + (min44 * nilai_x44) + (min45 * nilai_x45) + (min46 * nilai_x46) + (min47 * nilai_x47) + (min48 * nilai_x48) + (min49 * nilai_x49) + (min40 * nilai_x50)
                          + (min51 * nilai_x51) + (min52 * nilai_x52) + (min53 * nilai_x53) + (min54 * nilai_x54) + (min55 * nilai_x55) + (min56 * nilai_x56) + (min57 * nilai_x57) + (min58 * nilai_x58) + (min59 * nilai_x59) + (min60 * nilai_x60)
                          + (min61 * nilai_x61) + (min62 * nilai_x62) + (min63 * nilai_x63) + (min64 * nilai_x64) + (min65 * nilai_x65) + (min66 * nilai_x66) + (min67 * nilai_x67) + (min68 * nilai_x68) + (min69 * nilai_x69) + (min70 * nilai_x70)
                          + (min71 * nilai_x71) + (min72 * nilai_x72) + (min73 * nilai_x73) + (min74 * nilai_x74) + (min75 * nilai_x75) + (min76 * nilai_x76) + (min77 * nilai_x77) + (min78 * nilai_x78) + (min79 * nilai_x79) + (min80 * nilai_x80);
            //pembilangKa = min1 * signka1 + min4 * signka4 + min3 * signka3 + min4 * signka4 + min5 * signka5 + min6 * signka6 + min7 * signka7 + min8 * signka8 + min9 * signka9 + min10 * signka10 + min11 * signka11 + min14 * signka14 + min13 * signka13 +
            //           min14 * signka14 + min15 * signka15 + min16 * signka16 + min17 * signka17 + min18 * signka18 + min19 * signka19 + min40 * signka40 + min41 * signka41 + min44 * signka46 + min23 * signka23 + min24 * signka24 + min25 * signka25 + min26 * signka26 + min27 * signka27;
            penyebut = min1 + min2 + min3 + min4 + min5 + min6 + min7 + min8 + min9 + min10 + min11 + min12 + min13 + min14 + min15 + min16 + min17 + min18 + min19 + min20 + min21 + min22 + min23 + min24 + min25 + min26 + min27 +
                min28 + min29 + min30 + min31 + min32 + min33 + min34 + min35 + min36 + min37 + min38 + min39 + min40 + min41 + min42 + min43 + min44 + min45 + min46 + min47 + min48 + min49 + min50 + min51 + min52 +
            min53 + min54 + min55 + min56 + min57 + min58 + min59 + min60 + min61 + min62 + min63 + min64 + min65 + min66 + min67 + min68 + min69 + min70 + min71 + min72 + min73 + min74 + min75 + min76 + min77 + min78 + min79 + min80;
            COA = pembilang / penyebut;
            label11.Text = Convert.ToString(COA);
            label42.Text = Convert.ToString(suhu3);
            label43.Text = Convert.ToString(pH);
            label44.Text = Convert.ToString(min10);
            label45.Text = Convert.ToString(nilai_x1);
            // COAka = pembilangKa / penyebut;
            if (COA >= 91)
            {
                label10.Text = "EXCELENT";
                label10.Font = new Font("Arial", 25, FontStyle.Bold);
                kualitas = "EXCELENT";

            }
            else if (COA <= 90 && COA >= 71)
            {
                label10.Text = "GOOD";
                label10.Font = new Font("Arial", 25, FontStyle.Bold);
                kualitas = "GOOD";

            }
            else if (COA <= 70 && COA >= 51)
            {
                label10.Text = "MEDIUM";
                label10.Font = new Font("Arial", 25, FontStyle.Bold);
                kualitas = "MEDIUM";

            }
            else if (COA <= 50 && COA >= 26)
            {
                label10.Text = "BAD";
                label10.Font = new Font("Arial", 25, FontStyle.Bold);
                kualitas = "BAD";

            }
            else if (COA <= 25)
            //if (COA <= 1 && COA > 0.75)
            {
                label10.Text = "VERY BAD";
                label10.Font = new Font("Arial", 25, FontStyle.Bold);
                kualitas = "VERY BAD";

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {



            if (serialPort1.IsOpen == false)
            {
                try
                {

                    serialPort1.PortName = comboBox3.Text.ToString();
                    serialPort1.BaudRate = Convert.ToInt32(comboBox1.Text);
                    serialPort1.Encoding = Encoding.Default;
                    serialPort1.Open();
                    button4.Text = "Disconnect";
                    serialPort1.Write("pesan");
                    timer1.Start();


                }
                catch
                {
                    MessageBox.Show("Serial Port Error!!");
                }


            }
            else
            {
                try
                {

                    button4.Text = "Connect";
                    serialPort1.Write("stop\r\n");
                    serialPort1.Close();
                    timer1.Stop();
                    //tutup koneksi ke database
                    cs.Close();
                }

                catch { }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string[] myPort;
            myPort = System.IO.Ports.SerialPort.GetPortNames();
            comboBox3.Items.AddRange(myPort);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {

                gcslat = Convert.ToDouble(textBox7.Text);
                gcslong = Convert.ToDouble(textBox8.Text);
                //label57.Text = Convert.ToString(gcslat);
                //label58.Text = Convert.ToString(gcslong);
                gsLat = Convert.ToDouble(textBox7.Text);
                gsLng = Convert.ToDouble(textBox8.Text);
                gMapControl1.Position = new PointLatLng(gsLat, gsLng);
                gMapControl1.Zoom = 18;
                GMapOverlay markersOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(gsLat, gsLng), new Bitmap(@"C:\\Users\\yelsa\\Desktop\\TA\\APPLIKASI_TUGAS_AKHIR _NISA\\PERJUANGKAN\\antena.png"));
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = gsLat + ", " + gsLng;
                markersOverlay.Markers.Add(marker);
                gMapControl1.Overlays.Add(markersOverlay);
                gMapControl1.UpdateMarkerLocalPosition(marker);

            }
            catch
            {
                //return;
                //MessageBox.Show("Belum ada data GPS");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToString(curLat);
            textBox8.Text = Convert.ToString(curLng);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            balon = new GMarkerGoogle(new PointLatLng(gsLat, gsLng), new Bitmap(@"C:\\Users\\yelsa\\Desktop\\TA\\PERJUANGKAN\\winds_white.png"));
            balon.ToolTipText = curLat + ", " + curLng;
            balon.ToolTipMode = MarkerTooltipMode.Always;
            markersOverlay.Markers.Add(balon);
            gMapControl1.Overlays.Add(markersOverlay);

            if (mapFlag == false)
            {
                mapFlag = true;
                button8.Text = "Stop";
            }
            else
            {
                mapFlag = false;
                button8.Text = "Track";
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tick++;
            time = tick / 100.0;
            mdetik = (int)(time * 100) % 100;
            detik = (int)time % 60;
            menit = (int)time / 60;
            jam = (int)time / 3600;
            //trougput
            simulasi_time = time;
            label25.Text = Convert.ToString(simulasi_time);
            tPut = (jum_pac / simulasi_time);
            label24.Text = Convert.ToString(tPut);
            //masuk = masuk * 52;
            //trough =(int)masuk*52;
            //trough = trough / simulasi_time;
            // label24.Text = Convert.ToString(trough);
            label4.Text = Convert.ToString(jam) + ":" + Convert.ToString(menit) + ":" + Convert.ToString(detik) + "." + Convert.ToString(mdetik);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom--;
            trackBar1.Value = (int)gMapControl1.Zoom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom++;
            trackBar1.Value = (int)gMapControl1.Zoom;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBar1.Value;
        }

        private void bunifuGauge1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.Open();
            serialPort1.Write("AAA");
          


        }

        private void button9_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.Open();
            serialPort1.Write("BBB");
           
           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.Open();
            serialPort1.Write("CCC");
           
          
              



        }
    }
}
