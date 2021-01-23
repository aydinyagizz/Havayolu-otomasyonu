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
    public partial class Pilot_Bilgisi_Guncelle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Pilot_Bilgisi_Guncelle()
        {
            InitializeComponent();
        }
        private void listele()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from pilot_bilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                // bilgiler listeleniyor 
                ListViewItem list = new ListViewItem();
                list.Text = read["pilot_id"].ToString();
                list.SubItems.Add(read["pilot_adi"].ToString());
                list.SubItems.Add(read["pilot_soyadi"].ToString());
                list.SubItems.Add(read["pilot_tc"].ToString());
                list.SubItems.Add(read["pilot_cinsiyet"].ToString());
                list.SubItems.Add(read["pilot_tel"].ToString());
                list.SubItems.Add(read["pilot_dogumTarihi"].ToString());
                list.SubItems.Add(read["pilot_ehliyet"].ToString());
                list.SubItems.Add(read["pilot_lisans"].ToString());
                listView1.Items.Add(list);
            }
            baglanti.Close();

        }
        private void temizle()
        {
            txtbox_adi.Text = "";
            txtbox_soyadi.Text = "";
            txtbox_tc.Text = "";
            rdbtn_erkek.Checked = false;
            rdbtn_kadin.Checked = false;
            maskettxt_telefon.Text = "";
            comboBox_ehliyet.Text = "";
            comboBox_lisans.Text = "";
            label9.Text = "";

        }
        private void Pilot_Bilgisi_Guncelle_Load(object sender, EventArgs e)
        {
            listele();
            label9.Visible = false;
            tarih.MaxDate = tarih.Value;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label9.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            txtbox_adi.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            txtbox_soyadi.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            txtbox_tc.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();

            string cinsiyet = listView1.SelectedItems[0].SubItems[4].Text.ToString();
            if (cinsiyet == "erkek")
            {
                rdbtn_erkek.Select();
            }
            else if (cinsiyet == "kadin")
            {
                rdbtn_kadin.Select();
            }
            maskettxt_telefon.Text = listView1.SelectedItems[0].SubItems[5].ToString();
            tarih.Text = listView1.SelectedItems[0].SubItems[6].Text.ToString();
            comboBox_ehliyet.Text = listView1.SelectedItems[0].SubItems[7].Text.ToString();
            comboBox_lisans.Text = listView1.SelectedItems[0].SubItems[8].Text.ToString();
            
        }

        private void txtbox_ara_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from pilot_bilgileri where pilot_adi+pilot_soyadi+pilot_tc like '%" + txtbox_ara.Text + "%'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                // bilgiler listeleniyor 
                ListViewItem list = new ListViewItem();
                list.Text = read["pilot_id"].ToString();
                list.SubItems.Add(read["pilot_adi"].ToString());
                list.SubItems.Add(read["pilot_soyadi"].ToString());
                list.SubItems.Add(read["pilot_tc"].ToString());
                list.SubItems.Add(read["pilot_cinsiyet"].ToString());
                list.SubItems.Add(read["pilot_tel"].ToString());
                list.SubItems.Add(read["pilot_dogumTarihi"].ToString());
                list.SubItems.Add(read["pilot_ehliyet"].ToString());
                list.SubItems.Add(read["pilot_lisans"].ToString());
                listView1.Items.Add(list);
            }
            baglanti.Close();
        }
        
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            string cins = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE pilot_bilgileri SET pilot_adi=@pilotadi, pilot_soyadi=@pilotsoyadi, pilot_tc=@pilottc, pilot_cinsiyet=@pilotcinsiyet, pilot_tel=@pilottel, pilot_dogumTarihi=@pilotdogum, pilot_ehliyet=@pilotehliyet, pilot_lisans=@pilotlisans WHERE pilot_id=" +label9.Text+"",baglanti);
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
            komut.Parameters.AddWithValue("@pilotdogum",  tarih.Text.ToString());
            komut.Parameters.AddWithValue("@pilotehliyet", comboBox_ehliyet.Text.ToString());
            komut.Parameters.AddWithValue("@pilotlisans", comboBox_lisans.Text.ToString());

            komut.ExecuteNonQuery();
            MessageBox.Show("Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
            baglanti.Close();
            listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM pilot_bilgileri WHERE pilot_id=@id",baglanti);
            komut.Parameters.AddWithValue("@id", label9.Text.ToString());
            komut.ExecuteNonQuery();

            MessageBox.Show("Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            temizle();
            baglanti.Close();
            listele();

        }

        
    }
}
