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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
               MessageBox.Show(" Boş Alan Bırakmayınız..! ");
            }
            else
            {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("insert into Kullanıcılar (Kullanıcı_Adı,Şifre) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show(" Kayıt Başarılı..! ");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false)
            {              
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
                MessageBox.Show("Kullanıcı Adı Veya Şifreniz 10 Karakter İle Sınırlıdır !");
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
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }
    }
}
