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

namespace Verileri_Sifreleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KACV7HQ\\SQLEXPRESS;Initial Catalog=VeriSifreleme;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLVERILER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void sifresizlistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLSIFRESIZ",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = TxtAd.Text;
            byte[] adddizi = ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(adddizi);
            
            string soyad = TxtSoyad.Text;
            byte[] soyaddizi = ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String(soyaddizi);

            string mail = TxtMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = TxtSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = TxtHesapNo.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLVERILER (AD,SOYAD,MAIL,SIFRE,HESAPNO) values (@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut.Parameters.AddWithValue("@p1", adsifre);
            komut.Parameters.AddWithValue("@p2", soyadsifre);
            komut.Parameters.AddWithValue("@p3", mailsifre);
            komut.Parameters.AddWithValue("@p4", sifresifre);
            komut.Parameters.AddWithValue("@p5", hesapnosifre);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler Eklendi");

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLSIFRESIZ (AD,SOYAD,MAIL,SIFRE,HESAPNO) values (@a1,@a2,@a3,@a4,@a5)",baglanti);
            komut2.Parameters.AddWithValue("@a1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@a3", TxtMail.Text);
            komut2.Parameters.AddWithValue("@a4", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@a5", TxtHesapNo.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sifresizlistele();
        }
    }
}
