using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ödev_Proje
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");
        private void aracsayisi()
        {
            int aracsayisi = listView1.Items.Count;
            label2.Text = Convert.ToString(aracsayisi);
        }
        private void kullanıcılarıgörüntüle()
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * from Araçlar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["Marka"].ToString();
                ekle.SubItems.Add(oku["Model"].ToString());
                ekle.SubItems.Add(oku["Plaka"].ToString());
                ekle.SubItems.Add(oku["Yıl"].ToString());
                ekle.SubItems.Add(oku["Kilometre"].ToString());
                ekle.SubItems.Add(oku["Vites"].ToString());
                ekle.SubItems.Add(oku["Yakıt"].ToString());
                ekle.SubItems.Add(oku["Renk"].ToString());


               
                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            kullanıcılarıgörüntüle();
            aracsayisi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("Delete from Araçlar where Marka='" + listView1.CheckedItems[0].Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Kayıt Silindi...!");
                listView1.Items.Clear();
                kullanıcılarıgörüntüle();
                aracsayisi();

        }
    }
}