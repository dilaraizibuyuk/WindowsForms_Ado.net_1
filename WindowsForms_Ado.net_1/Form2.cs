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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
            SqlConnection baglanti = new SqlConnection("server=localhost; Database=KuzeyYeli;user=sa;password=12345");

        private void Form2_Load(object sender, EventArgs e)
        {
            //disconnected mimari
            SqlDataAdapter adp = new SqlDataAdapter("select * from Urunler",baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt); //adpdeki bilgiyi dtye doldurur
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["UrunID"].Visible = false;
            dataGridView1.Columns["KategoriID"].Visible = false;
            dataGridView1.Columns["TedarikciID"].Visible = false;

        }
        private void urunlistele()
        {
            //disconnected mimari
            SqlDataAdapter adp = new SqlDataAdapter("select * from Urunler", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt); //adpdeki bilgiyi dtye doldurur
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["UrunID"].Visible = false;
            dataGridView1.Columns["KategoriID"].Visible = false;
            dataGridView1.Columns["TedarikciID"].Visible = false;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            string urunad = txtUrunAdi.Text;
            decimal fiyat = nudFiyat.Value;
            decimal stok = nudStok.Value;
            komut.CommandText =string.Format( "insert Urunler (UrunAdi,Fiyat,Stok) values('{0}',{1},{2})",urunad,fiyat,stok);
            komut.Connection = baglanti;
            baglanti.Open();
            int sonuc=komut.ExecuteNonQuery();
            if (sonuc>0)
            {
                MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                urunlistele();
            }
            else
            {
                MessageBox.Show("Kayıt ekleme sırasında bir hata oluştu.");
            }
            baglanti.Close();
        }

        private void btn_kategori_Click(object sender, EventArgs e)
        {

        }
    }
}
