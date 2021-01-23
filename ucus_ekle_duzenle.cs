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
    public partial class ucus_ekle_duzenle : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");
        
        public ucus_ekle_duzenle()
        {
            InitializeComponent();
        }


        private void temizle()
        {
            txt_fiyat.Text = "";
            comboBox_ucacakUcak.Text = "";
            comboBox_ucusPilotu.Text = "";
            textBox_ucusKodu.Text = "";
            comboBox_nereden.Text = "";
            comboBox_nereye.Text = "";
            comboBox_kalkısSaati.Text = "";
            comboBox_tahminiUcus.Text = "";
            btn_guncelle.Visible = false;
            btn_ucakEkle.Visible = true;

        }

        private void listele()
        {

            DateTime tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucus_bilgileri where kalkıs_tarihi >=@tarih ", baglanti);
            komut.Parameters.AddWithValue("@tarih", tarih);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = read["ucus_id"].ToString();
                list.SubItems.Add(read["ucacak_ucak"].ToString());
                list.SubItems.Add(read["ucus_pilotu"].ToString());
                list.SubItems.Add(read["ucus_kodu"].ToString());
                list.SubItems.Add(read["nereden"].ToString());
                list.SubItems.Add(read["nereye"].ToString());
                list.SubItems.Add(read["kalkıs_tarihi"].ToString());
                list.SubItems.Add(read["kalkıs_saati"].ToString());
                list.SubItems.Add(read["ucus_suresi"].ToString());
                list.SubItems.Add(read["fiyat"].ToString());
                listView1.Items.Add(list);

            }
            baglanti.Close();
        }
        private void btn_ucakEkle_Click(object sender, EventArgs e)
        {
            if (comboBox_ucacakUcak.Text == "" || comboBox_ucusPilotu.Text == "" || textBox_ucusKodu.Text =="" || comboBox_nereden.Text == "" || comboBox_nereye.Text == "" || comboBox_kalkısSaati.Text == "" || comboBox_tahminiUcus.Text == "" || txt_fiyat.Text=="")
            {
                lbl_uyari.Text = "Zorunlu alanları doldurunuz";
                lbl_uyari.Show();
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO ucus_bilgileri(ucacak_ucak, ucus_pilotu, ucus_kodu, nereden, nereye, kalkıs_tarihi, kalkıs_saati, ucus_suresi, fiyat) VALUES(@ucacakUcak, @ucusPilotu, @ucusKodu, @nereden, @nereye, @kalkısTarihi, @kalkısSaati, @ucusSuresi , @fiyat) ", baglanti);
                komut.Parameters.AddWithValue("@ucacakUcak", comboBox_ucacakUcak.Text.ToString());
                komut.Parameters.AddWithValue("@ucusPilotu", comboBox_ucusPilotu.Text.ToString());
                komut.Parameters.AddWithValue("@ucusKodu",textBox_ucusKodu.Text.ToString());
                komut.Parameters.AddWithValue("@nereden", comboBox_nereden.Text.ToString());
                komut.Parameters.AddWithValue("@nereye", comboBox_nereye.Text.ToString());
                komut.Parameters.AddWithValue("@kalkısTarihi", Convert.ToDateTime(tarih.Value.ToShortDateString()));
                komut.Parameters.AddWithValue("@kalkısSaati", comboBox_kalkısSaati.Text.ToString());
                komut.Parameters.AddWithValue("@ucusSuresi", comboBox_tahminiUcus.Text.ToString());
                komut.Parameters.AddWithValue("@fiyat", txt_fiyat.Text.ToString());


                komut.ExecuteNonQuery();
                lbl_uyari.Visible = false;
                MessageBox.Show("Kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
                temizle();
                listele();

            }
        }
        private void ucakadilistele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucak_bilgileri ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox_ucacakUcak.Items.Add(read["ucak_adi"]);

            }
            baglanti.Close();
        }

        private void pilotlistele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM pilot_bilgileri ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox_ucusPilotu.Items.Add(read["pilot_adi"]);

            }
            baglanti.Close();
        }
        
        private void ucus_ekle_duzenle_Load(object sender, EventArgs e)
        {
            listele();
            label9.Visible = false;
            ucakadilistele();
            pilotlistele();
            tarih.MinDate = tarih.Value;
            

        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE ucus_bilgileri SET ucacak_ucak=@ucacakUcak, ucus_pilotu=@ucusPilotu, ucus_kodu=@ucusKodu, nereden=@nereden, nereye=@nereye, kalkıs_tarihi=@kalkısTarihi, kalkıs_saati=@kalkısSaati, ucus_suresi=@ucusSuresi , fiyat=@fiyat WHERE ucus_id="+label9.Text+"" , baglanti );
            komut.Parameters.AddWithValue("@ucacakUcak", comboBox_ucacakUcak.Text.ToString());
            komut.Parameters.AddWithValue("@ucusPilotu", comboBox_ucusPilotu.Text.ToString());
            komut.Parameters.AddWithValue("@ucusKodu", textBox_ucusKodu.Text.ToString());
            komut.Parameters.AddWithValue("@nereden", comboBox_nereden.Text.ToString());
            komut.Parameters.AddWithValue("@nereye", comboBox_nereye.Text.ToString());
            komut.Parameters.AddWithValue("@kalkısTarihi", Convert.ToDateTime(tarih.Value.ToShortDateString()));
            komut.Parameters.AddWithValue("@kalkısSaati", comboBox_kalkısSaati.Text.ToString());
            komut.Parameters.AddWithValue("@ucusSuresi", comboBox_tahminiUcus.Text.ToString());
            komut.Parameters.AddWithValue("@fiyat", txt_fiyat.Text.ToString());

            komut.ExecuteNonQuery();
            lbl_uyari.Visible = false;
            MessageBox.Show("Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
            baglanti.Close();
            listele();
            btn_guncelle.Visible = false;
            btn_ucakEkle.Visible = true;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM ucus_bilgileri WHERE ucus_id=@id ", baglanti);
            komut.Parameters.AddWithValue("@id", label9.Text.ToString());
            komut.ExecuteNonQuery();

            MessageBox.Show("Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            temizle();
            baglanti.Close();
            listele();

        }

        private void txtbox_ara_TextChanged(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucus_bilgileri WHERE ucacak_ucak+ ucus_kodu like '%" +txtbox_ara.Text+ "%' AND kalkıs_tarihi >=@tarih", baglanti);
            komut.Parameters.AddWithValue("@tarih", tarih);

            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = read["ucus_id"].ToString();
                list.SubItems.Add(read["ucacak_ucak"].ToString());
                list.SubItems.Add(read["ucus_pilotu"].ToString());
                list.SubItems.Add(read["ucus_kodu"].ToString());
                list.SubItems.Add(read["nereden"].ToString());
                list.SubItems.Add(read["nereye"].ToString());
                list.SubItems.Add(read["kalkıs_tarihi"].ToString());
                list.SubItems.Add(read["kalkıs_saati"].ToString());
                list.SubItems.Add(read["ucus_suresi"].ToString());
                listView1.Items.Add(list);

            }
            baglanti.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label9.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            comboBox_ucacakUcak.Text= listView1.SelectedItems[0].SubItems[1].Text.ToString();
            comboBox_ucusPilotu.Text= listView1.SelectedItems[0].SubItems[2].Text.ToString();
            textBox_ucusKodu.Text= listView1.SelectedItems[0].SubItems[3].Text.ToString();
            comboBox_nereden.Text= listView1.SelectedItems[0].SubItems[4].Text.ToString();
            comboBox_nereye.Text= listView1.SelectedItems[0].SubItems[5].Text.ToString();
            tarih.Text= listView1.SelectedItems[0].SubItems[6].Text.ToString();
            comboBox_kalkısSaati.Text= listView1.SelectedItems[0].SubItems[7].Text.ToString();
            comboBox_tahminiUcus.Text= listView1.SelectedItems[0].SubItems[8].Text.ToString();
            txt_fiyat.Text = listView1.SelectedItems[0].SubItems[9].Text.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_guncelle.Visible = true;
            btn_ucakEkle.Visible = false;
        }









        private void iller_ekle_nereye()
        {
            comboBox_nereye.Items.Clear();
            comboBox_nereye.Items.Add("İSTANBUL");
            comboBox_nereye.Items.Add("ANKARA");
            comboBox_nereye.Items.Add("İZMİR");
            comboBox_nereye.Items.Add("ANTALYA");
            comboBox_nereye.Items.Add("MALATYA");
            comboBox_nereye.Items.Add("ELAZIĞ");
            comboBox_nereye.Items.Add("BAYBURT");
            comboBox_nereye.Items.Add("NİĞDE");
            comboBox_nereye.Items.Add("TRABZON");
            comboBox_nereye.Items.Add("K.MARAŞ");
        }
       


        private void comboBox_nereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            iller_ekle_nereye();
            //nereden şehrini seçtikten sonra o şehri nereye alanından silme işlemi
            comboBox_nereye.Items.RemoveAt(comboBox_nereden.SelectedIndex);
            comboBox_nereye.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eski_ucus_listele eski_Ucus = new Eski_ucus_listele();
            eski_Ucus.Show();
        }
    }
}
