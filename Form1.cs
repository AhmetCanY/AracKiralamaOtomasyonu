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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kullanıcılar where Kullanıcı_Adı='" + textBox1.Text + "'and Şifre='" + textBox2.Text + "'", baglantı);            
            OleDbDataReader dr = komut.ExecuteReader();

            if (dr.Read()) 
            {
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Tekrar Deneyiniz!");
            }
            baglantı.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yanıt;
            yanıt = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yanıt == DialogResult.Yes)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for (int i = 1; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
            timer1.Interval = 1500;
            timer1.Stop();
            if (progressBar1.Value == 100)
            {
                MessageBox.Show(" Hoşgeldiniz ");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
