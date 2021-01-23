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
    public partial class Eski_ucus_listele : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");
        DateTime tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());

        public Eski_ucus_listele()
        {
            InitializeComponent();
        }
        private void listele()
        {

            //bilgiler listeleniyor
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucus_bilgileri where kalkıs_tarihi < @tarih ", baglanti);
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
        private void Eski_ucus_listele_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ucus_bilgileri WHERE ucacak_ucak+ ucus_kodu like '%" + txt_ara.Text + "%' AND kalkıs_tarihi < @tarih ", baglanti);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
