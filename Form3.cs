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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");
       private void kullanıcılarıgörüntüle()
       {
           baglantı.Open();
           OleDbCommand komut = new OleDbCommand();
           komut.Connection = baglantı;
           komut.CommandText=("Select * from Kullanıcılar");
           OleDbDataReader oku = komut.ExecuteReader();
           while (oku.Read())
           {
               ListViewItem ekle = new ListViewItem();
               ekle.Text = oku["Kullanıcı_Adı"].ToString();
               ekle.SubItems.Add(oku["Şifre"].ToString());
               listView1.Items.Add(ekle);
           }
           baglantı.Close();
       }

        private void Form3_Load(object sender, EventArgs e)
        {
            kullanıcılarıgörüntüle();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("Delete from Kullanıcılar where Kullanıcı_Adı='" + listView1.CheckedItems[0].Text + "'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt Silindi...!");
            listView1.Items.Clear();
            kullanıcılarıgörüntüle();
        }
    }
}

