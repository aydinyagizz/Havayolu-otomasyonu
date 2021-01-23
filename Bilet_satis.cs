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
    public partial class Bilet_satis : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Bilet_satis()
        {
            InitializeComponent();
        }

        private void btn_DevamEt_Click(object sender, EventArgs e)
        {
            
            label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            if (txtbox_adi.Text == "" || txtbox_soyadi.Text == "" || txtbox_tc.Text == "" || comboBox_nereden.Text=="" || comboBox_nereye.Text=="" || groupBox1.Visible==false)
            {
             MessageBox.Show("Boş Alan Bırakılmamalıdır");
            }
            else
            {
               

                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectedTab = tabPage2;
                btn_gidsListele.Enabled = false;
                btn_donusListele.Enabled = false;
                btn_KisiSec.Enabled = false;
                btn_KisiOlustur.Enabled = false;
                btn_DevamEt.Enabled = false;

            }
        }

        private void radioButton1_TekYon_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5_donus.Visible = false;
            dateTimePicker2_Donus.Visible = false;
            btn_donusListele.Visible = false;
            dateTimePicker1_Gidis.Visible = true;
            btn_gidsListele.Visible = true;
            if (radioButton1_TekYon.Checked && groupBox2.Visible == true)
            {
                groupBox2.Visible = false;
                label_fiyat.Text = "";
                label_nereden.Text = "";
                label_nereye.Text = "";
                label_saat.Text = "";
                label_tarih.Text = "";
            }


        }

        private void radioButton2_CıftYon_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5_donus.Visible = true;
            dateTimePicker2_Donus.Visible = true;
            btn_donusListele.Visible = false;
            dateTimePicker1_Gidis.Visible = true;
            btn_gidsListele.Visible = true;

            if (groupBox1.Visible == true)
            {
                btn_donusListele.Visible = true;
            }
          


        }
        int adet = 1;
             int secildi = 0 ;
        string secim = "";
        private void comboBox3_KoltukSeç_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from bilet_satis where koltuk_secimi=@koltuksecilen", baglanti);
            komut.Parameters.AddWithValue("@koltuksecilen", comboBox3_KoltukSeç.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show("Bu Koltuk Daha Önce Alındı");
                comboBox3_KoltukSeç.Text = "new string";
                secildi = 1;

            }
            dr.Close();
            baglanti.Close();


            if(secildi == 0 && adet<=1 )
            { 
              
            if (rdbtn_erkek.Checked) {
                  
                //klavye girişleri engellenecek unutma!! (özellik kısmında DropDownStyle = DropDownList yaptık)
            if (comboBox3_KoltukSeç.Text == "1A" )
            {
             
                A1.BackColor = Color.LightBlue;
                           

            }
            if (comboBox3_KoltukSeç.Text == "1B" )
            {

                B1.BackColor = Color.LightBlue;
                            secim = secim + "1B";

            }
            if (comboBox3_KoltukSeç.Text == "1C" )
            {

                C1.BackColor = Color.LightBlue;
                      

            }
            if (comboBox3_KoltukSeç.Text == "1D" )
            {

                D1.BackColor = Color.LightBlue;
                    

            }
            if (comboBox3_KoltukSeç.Text == "1E" )
            {

                E1.BackColor = Color.LightBlue;
                     

            }
            if (comboBox3_KoltukSeç.Text == "1F" )
            {

                F1.BackColor = Color.LightBlue;
                     

            }
            if (comboBox3_KoltukSeç.Text == "2A" ) 
            {

                A2.BackColor = Color.LightBlue;
                       

            }
            if (comboBox3_KoltukSeç.Text == "2B" )
            {

                B2.BackColor = Color.LightBlue;
                     

            }
            if (comboBox3_KoltukSeç.Text == "2C" )
            {

                C2.BackColor = Color.LightBlue;
                        

            }
            if (comboBox3_KoltukSeç.Text == "2D" )
            {

                D2.BackColor = Color.LightBlue;
                      

            }
            if (comboBox3_KoltukSeç.Text == "2E")
            {

                E2.BackColor = Color.LightBlue;
                       

            }
            if (comboBox3_KoltukSeç.Text == "2F" )
            {

                F2.BackColor = Color.LightBlue;
                        

            }
            if (comboBox3_KoltukSeç.Text == "3A" )
            {

                A3.BackColor = Color.LightBlue;
                        

            }
                    if (comboBox3_KoltukSeç.Text == "3B")
                    {

                        B3.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "3C")
                    {

                        C3.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "3D")
                    {

                        D3.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "3E")
                    {

                        E3.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "3F")
                    {

                        F3.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4A")
                    {

                        A4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4A")
                    {

                        A4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4B")
                    {

                        B4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4C")
                    {

                        C4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4D")
                    {

                        D4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4E")
                    {

                        E4.BackColor = Color.LightBlue;


                    }
                    if (comboBox3_KoltukSeç.Text == "4F")
                    {

                        F4.BackColor = Color.LightBlue;


                    }

                }




            if (rdbtn_kadin.Checked)
            {
                //klavye girişleri engellenecek unutma!! (özellik kısmında DropDownStyle = DropDownList yaptık)
                if (comboBox3_KoltukSeç.Text == "1A" )
                {
                    
                    A1.BackColor = Color.Pink;
                        


                    }
                if (comboBox3_KoltukSeç.Text == "1B" )
                {

                    B1.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "1C")
                {

                    C1.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "1D" )
                {

                    D1.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "1E" )
                {

                    E1.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "1F"  )
                {

                    F1.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2A" )
                {

                    A2.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2B" )
                {

                    B2.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2C")
                {

                    C2.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2D" )
                {

                    D2.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2E")
                {

                    E2.BackColor = Color.Pink;

                    }
                if (comboBox3_KoltukSeç.Text == "2F")
                {

                    F2.BackColor = Color.Pink;

                }

                    if (comboBox3_KoltukSeç.Text == "3A")
                    {

                        A3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "3B")
                    {

                        B3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "3C")
                    {

                        C3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "3D")
                    {

                        D3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "3E")
                    {

                        E3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "3F")
                    {

                        F3.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4A")
                    {

                        A4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4A")
                    {

                        A4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4B")
                    {

                        B4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4C")
                    {

                        C4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4D")
                    {

                        D4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4E")
                    {

                        E4.BackColor = Color.Pink;


                    }
                    if (comboBox3_KoltukSeç.Text == "4F")
                    {

                        F4.BackColor = Color.Pink;


                    }

                }
                
                
            
              

                if (adet == 1)
                {
                    comboBox3_KoltukSeç.Enabled = false;
                }

            }
           
            
          
           secildi = 0;
          

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

     
        private void btn_KisiOlustur_Click(object sender, EventArgs e)
        {
            Musteri_ekle me = new Musteri_ekle();
            me.Show();
        }

        private void comboBox_nereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            iller_ekle_nereye();
            //nereden şehrini seçtikten sonra o şehri nereye alanından silme işlemi
            comboBox_nereye.Items.RemoveAt(comboBox_nereden.SelectedIndex);
            comboBox_nereye.Text = "";
        }

        private void dateTimePicker1_Gidis_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2_Donus.MinDate = dateTimePicker1_Gidis.Value;
        }

        private void btn_KisiSec_Click(object sender, EventArgs e)
        {
            Musteri_sec ms = new Musteri_sec();
            ms.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Gidis_Ucus_listele ul = new Gidis_Ucus_listele();
            ul.textBox1.Text = comboBox_nereden.Text;
            ul.textBox2.Text = comboBox_nereye.Text;
            ul.dateTimePicker1.Text = dateTimePicker1_Gidis.Text;
           





            ul.Show();
        }

        private void Bilet_satis_Load(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                btn_donusListele.Visible = true;
            }
            label_fiyat.Text = "0";
            lbl_fiyat.Text="0";
            //combobox un 0 ıncı indisin seçili gelmesi (bagaj hakkı)
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            //tarihleri veriyor bugüne
            DateTime bugun = DateTime.Now;
            dateTimePicker1_Gidis.MinDate = bugun;
            dateTimePicker2_Donus.MinDate = bugun;


            //tabcontrol deki 2 . sayfayı gizliyoruz
            tabControl1.TabPages.Remove(tabPage2);


            //visible özellikleri false olması gerekenleri gizliyioruz
            label4.Visible = false;
            label5_donus.Visible = false;
            dateTimePicker2_Donus.Visible = false;
            btn_donusListele.Visible = false;
            dateTimePicker1_Gidis.Visible = false;
            btn_gidsListele.Visible = false;


            label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();




        }
        private void page1_temizle()
        {
            comboBox_nereden.Text = "";
            comboBox_nereye.Text = "";
            radioButton1_TekYon.Checked = false;
            radioButton2_CıftYon.Checked = false;
            txtbox_adi.Text = "";
            txtbox_soyadi.Text = "";
            txtbox_tc.Text = "";
            rdbtn_erkek.Checked = false;
            rdbtn_kadin.Checked = false;

        }
        string cins="";
        private void btn_koltukSecDevamEt_Click(object sender, EventArgs e)
        {
            DialogResult giris = new DialogResult();
            giris = MessageBox.Show("'"+label9.Text+"' ₺ Fiyata Bileti Satın Almak İstiyor musunuz ?", "Satın Al", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (giris == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO bilet_satis(adi,soyadi,tc,cinsiyet,gidis_nereden,gidis_nereye,gidis_kalkisTarihi,gidis_kalkisSaati,gidis_biletFiyati,donus_nereden,donus_nereye,donus_kalkisTarihi,donus_kalkisSaati,donus_biletFiyati,bagaj_hakki,yemek_secimi,koltuk_secimi,toplam_tutar)" +
                    " VALUES (@adi,@soyadi,@tc,@cinsiyet,@gidisNereden,@gidisNereye,@gidisTarihi,@gidisSaati,@gidisbileti,@donusNereden,@donusNereye,@donusTarihi,@donusSaati,@donusBileti,@bagajHakkı,@yemekSecimi,@koltukSeçimi,@toplamTutar)", baglanti);
                komut.Parameters.AddWithValue("@adi", txtbox_adi.Text.ToString());
                komut.Parameters.AddWithValue("@soyadi", txtbox_soyadi.Text.ToString());
                komut.Parameters.AddWithValue("@tc", txtbox_tc.Text.ToString());
                if (rdbtn_erkek.Checked)
                {
                    cins = "erkek";
                }
                else if (rdbtn_kadin.Checked)
                {
                    cins = "kadin";
                }
                komut.Parameters.AddWithValue("@cinsiyet", cins.ToString());
                komut.Parameters.AddWithValue("@gidisNereden", lbl_nereden.Text.ToString());
                komut.Parameters.AddWithValue("@gidisNereye", lbl_nereye.Text.ToString());
                komut.Parameters.AddWithValue("@gidisTarihi",Convert.ToDateTime( dateTimePicker1_Gidis.Value.ToShortDateString()));
                komut.Parameters.AddWithValue("@gidisSaati", lbl_saat.Text.ToString());
                komut.Parameters.AddWithValue("@gidisbileti", lbl_fiyat.Text.ToString());
                komut.Parameters.AddWithValue("@donusNereden", label_nereden.Text.ToString());
                komut.Parameters.AddWithValue("@donusNereye", label_nereye.Text.ToString());
                komut.Parameters.AddWithValue("@donusTarihi", Convert.ToDateTime(dateTimePicker2_Donus.Value.ToShortDateString()));
                komut.Parameters.AddWithValue("@donusSaati", label_saat.Text.ToString());
                komut.Parameters.AddWithValue("@donusBileti", label_fiyat.Text.ToString());
                komut.Parameters.AddWithValue("@bagajHakkı", comboBox1.Text.ToString());
                komut.Parameters.AddWithValue("@yemekSecimi", comboBox2.Text.ToString());
                komut.Parameters.AddWithValue("@koltukSeçimi", comboBox3_KoltukSeç.Text.ToString());
                komut.Parameters.AddWithValue("@toplamTutar", label9.Text.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarıyla Bilet Satılmıştır.");
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.SelectedTab = tabPage1;

                page1_temizle();
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                btn_gidsListele.Enabled = true;
              
                btn_KisiSec.Enabled = true;
                btn_KisiOlustur.Enabled = true;
                btn_DevamEt.Enabled = true;
                


            }
            else if (giris==DialogResult.No){
            }

        }

        private void btn_donusListele_Click(object sender, EventArgs e)
        {
            Donus_ucus_listele ul = new Donus_ucus_listele();
            ul.textBox1.Text = comboBox_nereden.Text;
            ul.textBox2.Text = comboBox_nereye.Text;
            ul.dateTimePicker1.Text = dateTimePicker2_Donus.Text;

            ul.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabPage1;
            tabControl1.TabPages.Remove(tabPage2);
            btn_gidsListele.Enabled = true;
            btn_donusListele.Enabled = true;
            btn_KisiSec.Enabled = true;
            btn_KisiOlustur.Enabled = true;
            btn_DevamEt.Enabled = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                label35.Text = "0";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();


            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label35.Text = "20";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label35.Text = "30";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if(comboBox1.SelectedIndex == 3)
            {
                label35.Text = "40";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                label35.Text = "60";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
            {
                label37.Text = "0";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                label37.Text = "20";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox2.SelectedIndex == 2)
            {
                label37.Text = "15";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox2.SelectedIndex == 3)
            {
                label37.Text = "20";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
            else if (comboBox2.SelectedIndex == 4)
            {
                label37.Text = "15";
                label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

            }
        }

        private void lbl_fiyat_SizeChanged(object sender, EventArgs e)
        {
            label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

        }

        private void label_fiyat_TextChanged(object sender, EventArgs e)
        {
            label9.Text = ((Convert.ToInt32(label35.Text) + Convert.ToInt32(label37.Text)) + Convert.ToInt32(lbl_fiyat.Text) + Convert.ToInt32(label_fiyat.Text)).ToString();

        }

        private void txt_bilet_adet_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_kltk_temizle_Click(object sender, EventArgs e)
        {
        

        }
        private void btntemizle()
        {
            A1.BackColor = Color.Gray;
            B1.BackColor = Color.Gray;
            C1.BackColor = Color.Gray;
            D1.BackColor = Color.Gray;
            E1.BackColor = Color.Gray;
            F1.BackColor = Color.Gray;
            A2.BackColor = Color.Gray;
            B2.BackColor = Color.Gray;
            C2.BackColor = Color.Gray;
            D2.BackColor = Color.Gray;
            E2.BackColor = Color.Gray;
            F2.BackColor = Color.Gray;
            A3.BackColor = Color.Gray;
            B3.BackColor = Color.Gray;
            C3.BackColor = Color.Gray;
            D3.BackColor = Color.Gray;
            E3.BackColor = Color.Gray;
            F3.BackColor = Color.Gray;
            A4.BackColor = Color.Gray;
            B4.BackColor = Color.Gray;
            C4.BackColor = Color.Gray;
            D4.BackColor = Color.Gray;
            E4.BackColor = Color.Gray;
            F4.BackColor = Color.Gray;

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            btntemizle();
            comboBox3_KoltukSeç.Enabled = true;
        }

        private void radioButton2_CıftYon_MouseClick(object sender, MouseEventArgs e)
        {
          
        }
    }
}
