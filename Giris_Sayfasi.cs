using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AydınHavayolu
{
    public partial class Giris_Sayfasi : Form
    {
        public Giris_Sayfasi()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Kullanici_giris.rutbe==1)
            {
                biletSatışToolStripMenuItem.Visible = true;
                müşteriEkleToolStripMenuItem1.Visible = true;
                uçaklarToolStripMenuItem.Visible = true;
                pilotİşlemleriToolStripMenuItem.Visible = true;
                uçuşEkleToolStripMenuItem.Visible = true;
                ayarlarToolStripMenuItem.Visible = true;

            }
            if (Kullanici_giris.rutbe == 2)
            {
                uçaklarToolStripMenuItem.Visible = false;
                pilotİşlemleriToolStripMenuItem.Visible = false;
                uçuşEkleToolStripMenuItem.Visible = false;
            }
        }
        
        Musteri_ekle Musteri_Ekle;
        private void müşteriEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(Musteri_Ekle==null || Musteri_Ekle.IsDisposed)
            {
                Musteri_Ekle = new Musteri_ekle();
                Musteri_Ekle.MdiParent=this;
                Musteri_Ekle.Show();
            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        Bilet_satis Bilet_Satis;
        private void biletSatışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Bilet_Satis == null || Bilet_Satis.IsDisposed)
            {
                Bilet_Satis = new Bilet_satis();
                Bilet_Satis.MdiParent = this;
                Bilet_Satis.Show();
            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 
       
        Ucak_ekle_duzenle Ucak_Ekle;
        private void uçakEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ucak_Ekle == null || Ucak_Ekle.IsDisposed)
            {
                Ucak_Ekle = new Ucak_ekle_duzenle();
                Ucak_Ekle.MdiParent = this;
                Ucak_Ekle.Show();
            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        Pilot_ekle pilot_Ekle;
        private void pilotEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pilot_Ekle == null || pilot_Ekle.IsDisposed)
            {
                pilot_Ekle = new Pilot_ekle();
                pilot_Ekle.MdiParent = this;
                pilot_Ekle.Show();
            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        Pilot_Bilgisi_Guncelle pilot_Guncelle;
        private void pilotSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pilot_Guncelle == null || pilot_Guncelle.IsDisposed)
            {
                pilot_Guncelle = new Pilot_Bilgisi_Guncelle();
                pilot_Guncelle.MdiParent = this;
                pilot_Guncelle.Show();

            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        ucus_ekle_duzenle Ucus_Ekle_Duzenle;
        private void uçuşEkleDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ucus_Ekle_Duzenle == null || Ucus_Ekle_Duzenle.IsDisposed)
            {
                Ucus_Ekle_Duzenle = new ucus_ekle_duzenle();
                Ucus_Ekle_Duzenle.MdiParent = this;
                Ucus_Ekle_Duzenle.Show();

            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        Eski_ucus_listele Eski_Ucus_Listele;

        private void eskiUçuşListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Eski_Ucus_Listele == null || Eski_Ucus_Listele.IsDisposed)
            {
                Eski_Ucus_Listele = new Eski_ucus_listele();
                Eski_Ucus_Listele.MdiParent = this;
                Eski_Ucus_Listele.Show();

            }
            else
            {
                MessageBox.Show("Zaten sayfa açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
