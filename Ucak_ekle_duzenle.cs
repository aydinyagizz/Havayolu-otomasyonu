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
    public partial class Ucak_ekle_duzenle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Ucak_ekle_duzenle()
        {
            InitializeComponent();
        }
        private void temizle()
        {
            txtbox_ucakAdi.Text = "";
            txtbox_ucakKodu.Text = "";
            txtbox_ucakTipi.Text = "";
            txtbox_ucakKapasite.Text = "";
            txtbox_ucakBakimTarih.Text = "";
            txtbox_depoKapasite.Text = "";
            txtbox_ucakMenzil.Text = "";
            comboBox_ucakFirma.Text = "";

        }

        private void btn_ucakEkle_Click(object sender, EventArgs e)
        {
            if (txtbox_ucakAdi.Text=="" || txtbox_ucakKodu.Text=="" || txtbox_ucakKapasite.Text=="" || txtbox_ucakTipi.Text=="" ||txtbox_ucakMenzil.Text=="" || txtbox_ucakBakimTarih.Text=="" || txtbox_depoKapasite.Text=="" || comboBox_ucakFirma.Text=="")
            {
                lbl_uyari.Text = "Zorunlu alanları doldurunuz";
                lbl_uyari.Show();
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO ucak_bilgileri(ucak_adi, ucak_kodu, ucak_tipi, ucak_kapasitesi, ucak_bakimTarihi, depo_kapasitesi, ucak_menzili, ucak_firmasi) VALUES (@ucakAdi, @ucakKodu, @ucakTipi, @ucakKapasitesi, @ucakBakımTarihi, @depoKapasitesi, @ucakMenzili, @ucakFirmasi)", baglanti);
                komut.Parameters.AddWithValue("@ucakAdi", txtbox_ucakAdi.Text.ToString());
                komut.Parameters.AddWithValue("@ucakKodu", txtbox_ucakKodu.Text.ToString());
                komut.Parameters.AddWithValue("@ucakTipi", txtbox_ucakTipi.Text.ToString());
                komut.Parameters.AddWithValue("@ucakKapasitesi", txtbox_ucakKapasite.Text.ToString());
                komut.Parameters.AddWithValue("@ucakBakımTarihi", txtbox_ucakBakimTarih.Text.ToString());
                komut.Parameters.AddWithValue("@depoKapasitesi", txtbox_depoKapasite.Text.ToString());
                komut.Parameters.AddWithValue("@ucakMenzili", txtbox_ucakMenzil.Text.ToString());
                komut.Parameters.AddWithValue("@ucakFirmasi", comboBox_ucakFirma.Text.ToString());

                komut.ExecuteNonQuery();
                lbl_uyari.Visible = false;
                MessageBox.Show("Kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                
                baglanti.Close();
                listele();

            }
            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void listele()
        {
            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucak_bilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = read["ucak_id"].ToString();
                list.SubItems.Add(read["ucak_adi"].ToString());
                list.SubItems.Add(read["ucak_kodu"].ToString());
                list.SubItems.Add(read["ucak_tipi"].ToString());
                list.SubItems.Add(read["ucak_kapasitesi"].ToString());
                list.SubItems.Add(read["ucak_bakimTarihi"].ToString());
                list.SubItems.Add(read["depo_kapasitesi"].ToString());
                list.SubItems.Add(read["ucak_menzili"].ToString());
                list.SubItems.Add(read["ucak_firmasi"].ToString());
                listView1.Items.Add(list);

            }
           
            baglanti.Close();

        }


        private void Ucak_ekle_duzenle_Load(object sender, EventArgs e)
        {
            listele();
            label9.Visible = false;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label9.Text= listView1.SelectedItems[0].SubItems[0].Text.ToString();
            txtbox_ucakAdi.Text= listView1.SelectedItems[0].SubItems[1].Text.ToString();
            txtbox_ucakKodu.Text= listView1.SelectedItems[0].SubItems[2].Text.ToString();
            txtbox_ucakTipi.Text= listView1.SelectedItems[0].SubItems[3].Text.ToString();
            txtbox_ucakKapasite.Text= listView1.SelectedItems[0].SubItems[4].Text.ToString();
            txtbox_ucakBakimTarih.Text= listView1.SelectedItems[0].SubItems[5].Text.ToString();
            txtbox_depoKapasite.Text= listView1.SelectedItems[0].SubItems[6].Text.ToString();
            txtbox_ucakMenzil.Text= listView1.SelectedItems[0].SubItems[7].Text.ToString();
            comboBox_ucakFirma.Text= listView1.SelectedItems[0].SubItems[8].Text.ToString();

        }

        private void txtbox_ara_TextChanged(object sender, EventArgs e)
        {
            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucak_bilgileri WHERE ucak_adi+ucak_kodu+ucak_tipi like '%"+txtbox_ara.Text+"%'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = read["ucak_id"].ToString();
                list.SubItems.Add(read["ucak_adi"].ToString());
                list.SubItems.Add(read["ucak_kodu"].ToString());
                list.SubItems.Add(read["ucak_tipi"].ToString());
                list.SubItems.Add(read["ucak_kapasitesi"].ToString());
                list.SubItems.Add(read["ucak_bakimTarihi"].ToString());
                list.SubItems.Add(read["depo_kapasitesi"].ToString());
                list.SubItems.Add(read["ucak_menzili"].ToString());
                list.SubItems.Add(read["ucak_firmasi"].ToString());
                listView1.Items.Add(list);

            }

            baglanti.Close();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE ucak_bilgileri SET   ucak_adi=@ucakAdi, ucak_kodu=@ucakKodu, ucak_tipi=@ucakTipi, ucak_kapasitesi=@ucakKapasitesi, ucak_bakimTarihi=@ucakBakımTarihi, depo_kapasitesi=@depoKapasitesi, ucak_menzili=@ucakMenzili, ucak_firmasi=@ucakFirmasi WHERE ucak_id="+label9.Text+"" , baglanti);
            komut.Parameters.AddWithValue("@ucakAdi", txtbox_ucakAdi.Text.ToString());
            komut.Parameters.AddWithValue("@ucakKodu", txtbox_ucakKodu.Text.ToString());
            komut.Parameters.AddWithValue("@ucakTipi", txtbox_ucakTipi.Text.ToString());
            komut.Parameters.AddWithValue("@ucakKapasitesi", txtbox_ucakKapasite.Text.ToString());
            komut.Parameters.AddWithValue("@ucakBakımTarihi", txtbox_ucakBakimTarih.Text.ToString());
            komut.Parameters.AddWithValue("@depoKapasitesi", txtbox_depoKapasite.Text.ToString());
            komut.Parameters.AddWithValue("@ucakMenzili", txtbox_ucakMenzil.Text.ToString());
            komut.Parameters.AddWithValue("@ucakFirmasi", comboBox_ucakFirma.Text.ToString());

            komut.ExecuteNonQuery();
            lbl_uyari.Visible = false;
            MessageBox.Show("Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();

            baglanti.Close();
            listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM ucak_bilgileri WHERE ucak_id=@id ", baglanti);
            komut.Parameters.AddWithValue("@id", label9.Text.ToString());
            komut.ExecuteNonQuery();

            MessageBox.Show("Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            temizle();
            baglanti.Close();
            listele();

        }
    }
}
