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
    public partial class Gidis_Ucus_listele : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Gidis_Ucus_listele()
        {
            InitializeComponent();
        }
        private void listele()
        {

            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucus_bilgileri where nereden=@nereden and nereye=@nereye and kalkıs_tarihi>=@tarih", baglanti);
            komut.Parameters.AddWithValue("@nereden", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@nereye", textBox2.Text.ToString());
            komut.Parameters.AddWithValue("@tarih",Convert.ToDateTime( dateTimePicker1.Value.ToString()));
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

        private void Ucus_listele_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        Bilet_satis bilet_Satis= (Bilet_satis)Application.OpenForms["Bilet_satis"];
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bilet_Satis.groupBox1.Visible = true;
            bilet_Satis.lbl_fiyat.Text = listView1.SelectedItems[0].SubItems[9].Text.ToString();
            bilet_Satis.lbl_nereden.Text = listView1.SelectedItems[0].SubItems[4].Text.ToString();
            bilet_Satis.lbl_nereye.Text = listView1.SelectedItems[0].SubItems[5].Text.ToString();
            bilet_Satis.lbl_tarih.Text = listView1.SelectedItems[0].SubItems[6].Text.ToString();
            bilet_Satis.lbl_saat.Text = listView1.SelectedItems[0].SubItems[7].Text.ToString();

            bilet_Satis.btn_donusListele.Visible = true;
          

            this.Close();
        }
    }
}
