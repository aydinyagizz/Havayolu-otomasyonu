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
    public partial class Pilot_ekle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");
        public Pilot_ekle()
        {
            InitializeComponent();
        }
       
        public void temizle()
        {

            txtbox_adi.Text = "";
            txtbox_soyadi.Text = "";
            txtbox_tc.Text = "";
            maskettxt_telefon.Text = "";
            rdbtn_erkek.Checked = false;
            rdbtn_kadin.Checked = false;
            comboBox_ehliyet.Text = "";
            comboBox_lisans.Text = "";

        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (txtbox_adi.Text=="" || txtbox_soyadi.Text=="" || txtbox_tc.Text=="" || maskettxt_telefon.Text=="" || tarih.Text=="" || comboBox_ehliyet.Text=="" || comboBox_lisans.Text=="")
            {
                lbl_uyari.Text = "Zorunlu alanları doldurunuz";
                lbl_uyari.Show();
            }
            else if (txtbox_tc.TextLength < 11)
            {
                lbl_uyari.Text = "Tc karakter sınırına ulaşınız";
                lbl_uyari.Show();
            }
            else
            {
               
                string cins = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO pilot_bilgileri(pilot_adi, pilot_soyadi, pilot_tc, pilot_cinsiyet, pilot_tel, pilot_dogumTarihi, pilot_ehliyet, pilot_lisans) VALUES(@pilotadi, @pilotsoyadi, @pilottc, @pilotcinsiyet, @pilottel, @pilotdogumTarihi, @pilotehliyet, @pilotlisans)", baglanti);
                komut.Parameters.AddWithValue("@pilotadi", txtbox_adi.Text.ToString());
                komut.Parameters.AddWithValue("@pilotsoyadi", txtbox_soyadi.Text.ToString());
                komut.Parameters.AddWithValue("@pilottc", txtbox_tc.Text.ToString());
                if (rdbtn_erkek.Checked)
                {
                    cins = "erkek";
                }
                else if (rdbtn_kadin.Checked)
                {
                    cins = "kadin";
                }
                komut.Parameters.AddWithValue("@pilotcinsiyet", cins.ToString());
                komut.Parameters.AddWithValue("@pilottel", maskettxt_telefon.Text.ToString());
                komut.Parameters.AddWithValue("@pilotdogumTarihi", tarih.Text.ToString());
                komut.Parameters.AddWithValue("@pilotehliyet", comboBox_ehliyet.Text.ToString());
                komut.Parameters.AddWithValue("@pilotlisans", comboBox_lisans.Text.ToString());
              
                komut.ExecuteNonQuery();
                lbl_uyari.Visible = false;
                MessageBox.Show("Kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                baglanti.Close();
            }
        }

        

        private void txtbox_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sayı girişini engelledik
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtbox_soyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sayı girişini engelledik
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtbox_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayı girişi sebolleri engelleme
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Pilot_ekle_Load(object sender, EventArgs e)
        {
            tarih.MaxDate = tarih.Value;
        }

        
    }
}
