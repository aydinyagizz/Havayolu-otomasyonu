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
    public partial class Musteri_ekle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");
        public Musteri_ekle()
        {
            InitializeComponent();
        }
        private void listele()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri_bilgileri",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                // bilgiler listeleniyor 
                ListViewItem list = new ListViewItem();
                list.Text = read["musteri_id"].ToString();
                list.SubItems.Add(read["musteri_adi"].ToString());
                list.SubItems.Add(read["musteri_soyadi"].ToString());
                list.SubItems.Add(read["musteri_tc"].ToString());
                list.SubItems.Add(read["musteri_cinsiyet"].ToString());
                list.SubItems.Add(read["musteri_tel"].ToString());
                list.SubItems.Add(read["musteri_dogumTarihi"].ToString());
                list.SubItems.Add(read["musteri_email"].ToString());
                listView1.Items.Add(list);
            }
            baglanti.Close();

        }

        private void Musteri_ekle_Load(object sender, EventArgs e)
        {
            //sayfa yüklendiğinde bilgilerin listelenmesi
            listele();
            label8.Visible=false;
            tarih.MaxDate = tarih.Value;
        }

        public void temizle()
        {

            txtbox_adi.Text = "";
            txtbox_mail.Text = "";
            txtbox_soyadi.Text = "";
            txtbox_tc.Text = "";
            maskettxt_telefon.Text = "";
            rdbtn_erkek.Checked = false;
            rdbtn_kadin.Checked = false;
            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
            btn_kaydet.Visible = true;
            btn_guncelle.Visible = true;
        }
        string cins = "";
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            //textbox'ların boşluğunu kontrol etme
            if(txtbox_tc.Text.Trim()==""|| txtbox_adi.Text.Trim() == "" || txtbox_mail.Text.Trim() == "" || txtbox_soyadi.Text.Trim() == "")
            {
                lbl_uyari.Text="Zorunlu alanları doldurunuz";
                lbl_uyari.Show();
            }
            else if (txtbox_tc.TextLength <11)
            {
                lbl_uyari.Text = "Tc karakter sınırına ulaşınız";
                lbl_uyari.Show();
            }
           else {
                
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT  INTO musteri_bilgileri(musteri_adi, musteri_soyadi, musteri_tc, musteri_cinsiyet, musteri_tel, musteri_dogumTarihi, musteri_email) VALUES (@musteriadi, @musterisoyadi, @musteritc, @mustericinsiyet, @musteritel, @musteridogumTarihi, @musteriemail)",  baglanti);
                komut.Parameters.AddWithValue("@musteriadi",txtbox_adi.Text.ToString());
                komut.Parameters.AddWithValue("@musterisoyadi",txtbox_soyadi.Text.ToString());
                komut.Parameters.AddWithValue("@musteritc", txtbox_tc.Text.ToString());
                if (rdbtn_erkek.Checked)
                {
                    cins = "erkek";
                }
                else if (rdbtn_kadin.Checked)
                {
                    cins = "kadin";
                }
                komut.Parameters.AddWithValue("@mustericinsiyet", cins.ToString());
                komut.Parameters.AddWithValue("@musteritel", maskettxt_telefon.Text.ToString());
                komut.Parameters.AddWithValue("@musteridogumTarihi", tarih.Text.ToString());
                komut.Parameters.AddWithValue("@musteriemail", txtbox_mail.Text.ToString());
                komut.ExecuteNonQuery();
                lbl_uyari.Visible = false;
                MessageBox.Show("Kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                
                baglanti.Close();
                listele();
            }
        }

        private void txtbox_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece harf girişi ve sebolleri engelleme
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtbox_soyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece harf girişi sebolleri engelleme
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtbox_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayı girişi sebolleri engelleme
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //müşteri aradaki kişiye tıklandığında bilgilerin müşteri bilgilerine aktarılması

            label8.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            txtbox_adi.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            txtbox_soyadi.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            txtbox_tc.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();

            string cinsiyet=listView1.SelectedItems[0].SubItems[4].Text.ToString();
            if (cinsiyet=="erkek")
            {
                rdbtn_erkek.Select();
            }
            else if (cinsiyet=="kadin")
            {
                rdbtn_kadin.Select();
            }
            maskettxt_telefon.Text = listView1.SelectedItems[0].SubItems[5].ToString();
            tarih.Text = listView1.SelectedItems[0].SubItems[6].Text.ToString();
            txtbox_mail.Text = listView1.SelectedItems[0].SubItems[7].Text.ToString();
            btn_kaydet.Visible = false;

        }

        private void txtbox_ara_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri_bilgileri where musteri_adi+musteri_soyadi+musteri_tc like '%"+txtbox_ara.Text+"%'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                // bilgiler listeleniyor 
                ListViewItem list = new ListViewItem();
                list.Text = read["musteri_id"].ToString();
                list.SubItems.Add(read["musteri_adi"].ToString());
                list.SubItems.Add(read["musteri_soyadi"].ToString());
                list.SubItems.Add(read["musteri_tc"].ToString());
                list.SubItems.Add(read["musteri_cinsiyet"].ToString());
                list.SubItems.Add(read["musteri_tel"].ToString());
                list.SubItems.Add(read["musteri_dogumTarihi"].ToString());
                list.SubItems.Add(read["musteri_email"].ToString());
                listView1.Items.Add(list);
            }
            baglanti.Close();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE musteri_bilgileri SET musteri_adi=@musteriadi, musteri_soyadi=@musterisoyadi, musteri_tc=@musteritc, musteri_cinsiyet=@mustericinsiyet, musteri_tel=@musteritel, musteri_dogumTarihi=@musteridogumTarihi, musteri_email=@musteriemail WHERE musteri_id=" + label8.Text+"", baglanti);
            komut.Parameters.AddWithValue("@musteriadi", txtbox_adi.Text.ToString());
            komut.Parameters.AddWithValue("@musterisoyadi", txtbox_soyadi.Text.ToString());
            komut.Parameters.AddWithValue("@musteritc", txtbox_tc.Text.ToString());
            if (rdbtn_erkek.Checked)
            {
                cins = "erkek";
            }
            else if (rdbtn_kadin.Checked)
            {
                cins = "kadin";
            }
            komut.Parameters.AddWithValue("@mustericinsiyet", cins.ToString());
            komut.Parameters.AddWithValue("@musteritel", maskettxt_telefon.Text.ToString());
            komut.Parameters.AddWithValue("@musteridogumTarihi", tarih.Text.ToString());
            komut.Parameters.AddWithValue("@musteriemail", txtbox_mail.Text.ToString());
            komut.ExecuteNonQuery();
            lbl_uyari.Visible = false;
            MessageBox.Show("Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();

            baglanti.Close();
            listele();
            btn_kaydet.Visible = true;
        }

        
    }
}
