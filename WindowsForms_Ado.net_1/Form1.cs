using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsForms_Ado.net_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "server=localhost; Database=KuzeyYeli;user=sa;password=12345";
            //baglanti.ConnectionString= "server=localhost; Database=KuzeyYeli; Integrated Security=true" -->sa değil de windows authenticationla bağlanılan durumda böyle kullanılır

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from Urunler";
            komut.Connection = baglanti;

            baglanti.Open();
           SqlDataReader rdr= komut.ExecuteReader();
            while (rdr.Read()) //sqldatareaderın read metodunu kullandık okuyabildiği sürece dönecek döngü
            {
                string ad=rdr["UrunAdi"].ToString();
                string fiyat = rdr["Fiyat"].ToString();
                string stok = rdr["Stok"].ToString();

                lstUrunler.Items.Add(string.Format("{0}-{1}-{2}", ad, fiyat, stok));
            }
            baglanti.Close();

            SqlCommand komut2 = new SqlCommand();
            komut2.CommandText = "select * from Kategoriler";
            komut2.Connection = baglanti;
            baglanti.Open();
            SqlDataReader rdr2 = komut2.ExecuteReader();

            while (rdr2.Read()) 
            {
                string kategoriad = rdr2["KategoriAdi"].ToString();
                string tanim = rdr2["Tanimi"].ToString();
                lstKategoriler.Items.Add(string.Format("{0}-{1}", kategoriad, tanim));
            }
            baglanti.Close();


        }
    }
}