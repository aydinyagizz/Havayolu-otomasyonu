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

namespace AydınHavayolu
{
    public partial class Kullanici_giris : Form
    {
        public static int rutbe=0;
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Kullanici_giris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if(txt_kadi.Text.Trim()=="" || txt_sifre.Text.Trim()=="")
            {
                lbl_uyari.Text = "Kullanıcı Adı Veya Şifre Boş Geçilemez";
                lbl_uyari.Show();
            }
            else
            {
              
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from kullanicilar where kullanici_adi = @kadi AND sifre= @sifre AND rutbe=1",baglanti);
                komut.Parameters.AddWithValue("@kadi",txt_kadi.Text);
                komut.Parameters.AddWithValue("@sifre",txt_sifre.Text);
                SqlDataReader dr =  komut.ExecuteReader();
                if (dr.Read())
                {

                    rutbe = 1;
                    Giris_Sayfasi gs = new Giris_Sayfasi();
                    gs.Show();
                    this.Hide();
                }
                else
                {
                    lbl_uyari.Text="Kullanıcı Adı Veya Şifre Hatalı";
                    lbl_uyari.Show();
                }
                baglanti.Close();

                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Select * from kullanicilar where kullanici_adi = @kadi AND sifre= @sifre AND rutbe=2", baglanti);
                kmt.Parameters.AddWithValue("@kadi", txt_kadi.Text);
                kmt.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                SqlDataReader sdr = kmt.ExecuteReader();
                if (sdr.Read())
                {

                    rutbe = 2;
                    Giris_Sayfasi gs = new Giris_Sayfasi();
                    gs.Show();
                    this.Hide();
                }
                else
                {
                    lbl_uyari.Text = "Kullanıcı Adı Veya Şifre Hatalı";
                    lbl_uyari.Show();
                }
                baglanti.Close();

            }
        }

        
    }
}
