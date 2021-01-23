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
    public partial class Musteri_sec : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source= AYDıN ; Initial Catalog= UcakOtomasyon  ;  Integrated Security=True ");

        public Musteri_sec()
        {
            InitializeComponent();
        }

        private void listele()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri_bilgileri", baglanti);
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

       

        private void Musteri_sec_Load(object sender, EventArgs e)
        {
            listele();
        }

        Bilet_satis bilet_Satis = (Bilet_satis)Application.OpenForms["Bilet_satis"];

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
           bilet_Satis.txtbox_adi.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            bilet_Satis.txtbox_soyadi.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            bilet_Satis.txtbox_tc.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            string cins = listView1.SelectedItems[0].SubItems[4].Text.ToString();
            if (cins == "erkek")
            {
                bilet_Satis.rdbtn_erkek.Select();
            }
            else
            {
                bilet_Satis.rdbtn_kadin.Select();
            }

            this.Hide();
           
        }
    }
}
