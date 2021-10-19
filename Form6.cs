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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");
        
        private void Form6_Load(object sender, EventArgs e)
        {
            listView1.Hide();
            kullanıcılarıgörüntüle();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marka="", plaka="",yıl="",kilometre="",vites="",yakıt="",renk="";
            marka=comboBox1.Text;plaka=textBox2.Text;yıl=comboBox2.Text;kilometre=textBox2.Text;vites=comboBox3.Text;yakıt=comboBox5.Text;renk=comboBox4.Text;
            string[] bilgiler={marka,plaka,yıl,kilometre,vites,yakıt,renk};
            bool kayıtkontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox2.Text)
                {
                    kayıtkontrol = true;
                    MessageBox.Show("Bu Plaka da araç mevcuttur..!");
                }
            }
            if (kayıtkontrol == false)
            { 
                 ListViewItem lst=new ListViewItem(bilgiler);
                 if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "")
                 {
                     baglantı.Open();
                     OleDbCommand komut = new OleDbCommand("insert into Araçlar (Marka,Model,Plaka,Yıl,Kilometre,Vites,Yakıt,Renk) values('" + comboBox1.Text.ToString() + "','" + comboBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox4.Text.ToString() + "')", baglantı);
                     komut.ExecuteNonQuery();
                     baglantı.Close();
                     textBox1.Clear();
                     textBox2.Clear();
                     comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                     comboBox2.Items.RemoveAt(comboBox2.SelectedIndex);
                     comboBox3.Items.RemoveAt(comboBox3.SelectedIndex);
                     comboBox4.Items.RemoveAt(comboBox4.SelectedIndex);
                     comboBox5.Items.RemoveAt(comboBox5.SelectedIndex);
                     comboBox6.Items.RemoveAt(comboBox6.SelectedIndex);
                     MessageBox.Show(" Kayıt Başarılı..! ");
                 }
                 else
                 {
                     MessageBox.Show("Kayıtlarda bir eksiklik var..!");
                 }
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if(e.KeyChar==(char)13)
            {
            textBox1.Text=string.Format("{0:n0}",double.Parse(textBox1.Text));
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                ekle.SubItems.Add(oku["Yıl"].ToString());
                ekle.SubItems.Add(oku["Kilometre"].ToString());
                ekle.SubItems.Add(oku["Vites"].ToString());
                ekle.SubItems.Add(oku["Yakıt"].ToString());
                ekle.SubItems.Add(oku["Renk"].ToString());
                ekle.SubItems.Add(oku["Plaka"].ToString());
                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            string marka = comboBox1.SelectedItem.ToString();
            if (marka == "Acura")
            {
                string[] model = {"RL"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Alfa Romeo")
            {
                string[] model = {"4C", "33", "145", "146", "147", "155", "156", "159", "164", "166", "Brera", "Giulietta", "GT", "GTV", "MiTo", "Spider" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Anadol")
            {
                string[] model = {"A","SV"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Aston Martin")
            {
                string[] model = {"Cygnet", "DB7", "DB9", "DB11", "DBS", "Rapide", "Vanquish", "Vantage", "Virage"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Audi")
            {
                string[] model = { "A1", "A3", "A4", "A5", "A6", "A7", "A8", "R8", "RS", "S Serisi", "TT", "V8", "80 Serisi", "90 Serisi", "100 Serisi" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Bentley")
            {
                string[] model = {"Brooklands","Continental","Flying Spur","Mulsanne"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "BMW")
            {
                string[] model = {"1 Serisi","2 Serisi","3 Serisi","4 Serisi","5 Serisi","6 Serisi","7 Serisi","8 Serisi","İ Serisi","M Serisi","Z Serisi"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Brilliance")
            {
                string[] model = { "Zhonghua" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Bugatti")
            {
                string[] model = { "Chiron" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Buick")
            {
                string[] model = {"Century","Le Sabre","Park Avenue","Regal","Roadmaster"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Cadillac")
            {
                string[] model = {"BLS","Brougham","CTS","DeVille","Eldorado","Fleetwood","Seville","STS"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Chery")
            {
                string[] model = {"Alia","Chance","Kimo" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Chevrolet")
            {
                string[] model = { "Aveo", "Beretta", "Camaro", "Caprice", "Celebrity", "Corsica", "Corvette", "Cruze", "Epica", "Evanda", "Geo Storm", "Impala", "Kalos", "Lacetti", "Monte Carlo", "Rezzo", "Spark" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Chrysler")
            {
                string[] model = {"200","300 C","300 M","Concorde","Crossfire","LHS","Neon","PT Cruiser","Sebring","Stratus"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Citroën")
            {
                string[] model = {"AX","BX","C-Elysée","C1","C2","C3","C3 Picasso","C4","C4 Picasso","C4 Grand Picasso","C5","C6","C8","Evasion","Saxo","Xantia","XM","Xsara","ZX"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Dacia")
            {
                string[] model = {"Lodgy","Logan","Sandero","Solenza"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Daewoo")
            {
                string[] model = {"Chairman","Espero","Lanos","Leganza","Matiz","Nexia","Nubira","Racer","Super Saloon","Tico"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Daihatsu")
            {
                string[] model = {"Applause","Charade","Copen","Cuore","Materia","Sirion","YRV"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Dodge")
            {
                string[] model = {"Avenger","Challenger","Charger","Magnum","Neon","Spirit","Viper"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "DS Automobiles")
            {
                string[] model = {"DS 3","DS 4","DS 4 Crossback","DS 5"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Ferrari")
            {
                string[] model = {"360","430","456","458","488","512","550","575","599","612","California","F355","FF","F Serisi"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Fiat")
            {
                string[] model = {"124 Spider","126 Bis","500 Ailesi","Albea","Brava","Bravo","Coupe","Croma","Egea","Idea","Linea","Marea","Palio","Panda","Punto","Sedici","Siena","Stilo","Tempra","Tipo","Ulysse","Uno"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Fisker")
            {
                string[] model = { "Karma" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Ford")
            {
                string[] model = {"B-Max","C-Max","Cougar","Crown Victoria","Escort","Festiva","Fiesta","Focus","Fusion","Galaxy","Granada","Grand C-Max","Ka","Mondeo","Mustang","Orion","Scorpio","Sierra","S-Max","Taunus","Taurus","Thunderbird"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Geely")
            {
                string[] model = {"Echo","Emgrand","Familia","FC"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Honda")
            {
                string[] model = {"Accord","City","Civic","CRX","CR-Z","Integra","Jazz","Legend","NSX","Prelude","S2000","Shuttle","Stream"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Hyundai")
            {
                string[] model = {"Accent","Accent Blue","Accent Era","Atos","Centennial","Coupe","Elantra","Excel","Genesis","Getz","Grandeur","Ioniq","i10","i20","i20 Active","i20 Troy","i30","i40","iX20","Matrix","Santamo","S-Coupe","Sonata","Trajet"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Ikco")
            {
                string[] model = { "Samand" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Infiniti")
            {
                string[] model = {"G","I30","M","Q30","Q50","Q60"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Isuzu")
            {
                string[] model = { "Gemini" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Jaguar")
            {
                string[] model = { "Daimler", "F-Type", "Sovereign", "S-Type", "XE", "XF", "XJ", "XJR", "XJS", "XK8", "XKR", "X-Type" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Kia")
            {
                string[] model = { "Capital", "Carens", "Carnival", "Ceed", "Cerato", "Clarus", "Magentis", "Opirus", "Optima", "Picanto", "Pride", "Pro Ceed", "Rio", "Sephia", "Shuma", "Venga" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lada")
            {
                string[] model = { "Kalina", "Priora", "Samara", "VAZ", "Vega"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lamborghini")
            {
                string[] model = { "Aventador", "Gallardo", "Huracan" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lancia")
            {
                string[] model = { "Delta", "Thema", "Y ( Ypsilon )" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lexus")
            {
                string[] model = { "CT", "GS", "IS", "LS", "RC" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lincoln")
            {
                string[] model = { "Continental", "LS", "Mark", "MKS", "Town Car" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Lotus")
            {
                string[] model = { "Elise", "Evora", "Exige" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Maserati")
            {
                string[] model = { "Cambiocorsa", "Ghibli", "GranCabrio", "GranSport", "GranTurismo", "GT", "Quattroporte", "Spyder" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Mazda")
            {
                string[] model = { "2", "3", "5", "6", "MPV", "121", "323", "626", "Lantis", "MX", "Premacy", "RX", "Xedos" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "McLaren")
            {
                string[] model = { "675LT Spider", "720S", "MP4-12C" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Mercedes - Benz")
            {
                string[] model = { "A", "AMG GT", "B", "C", "CL", "CLA", "CLC", "CLK", "CLS", "E", "Maybach S", "R", "S", "SL", "SLC", "SLK", "SLS AMG", "190", "200", "220", "230", "240", "250", "260", "280", "300", "320", "380", "400", "420", "500", "560", "600" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Mercury")
            {
                string[] model = { "Sable" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "MG")
            {
                string[] model = { "F", "ZR" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Mini")
            {
                string[] model = { "Cooper", "Cooper Clubman", "Cooper S", "John Cooper", "One" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Mitsubishi")
            {
                string[] model = { "Attrage", "Carisma", "Colt", "Eclipse", "Galant", "Grandis", "Lancer", "Lancer Evolution", "Space Star" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Morgan")
            {
                string[] model = { "3 Wheeler", "4/4" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Nissan")
            {
                string[] model = { "200 SX", "350 Z", "Almera", "Altima", "Bluebird", "GT-R", "Laurel Altima", "Maxima", "Micra", "Note", "NX Coupe", "Primera", "Pulsar", "Sunny" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Oldsmobile")
            {
                string[] model = {"Cutlass Ciera"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Opel")
            {
                string[] model = { "Adam", "Agila", "Ascona", "Astra", "Calibra", "Cascada", "Corsa", "GT (Roadster)", "Insignia", "Kadett", "Manta", "Meriva", "Omega", "Rekord", "Senator", "Signum", "Tigra", "Vectra", "Zafira" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Peugeot")
            {
                string[] model = { "106", "107", "205", "206", "206", "207", "208", "301", "306", "307", "308", "309", "405", "406", "407", "508", "605", "607", "806", "807", "RCZ" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Plymouth")
            {
                string[] model = { "Laser" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Pontiac")
            {
                string[] model = { "Firebird", "Solstice" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Porsche")
            {
                string[] model = { "718", "911", "944", "Boxster", "Cayman", "Panamera" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Proton")
            {
                string[] model = { "218", "315", "316", "415", "416", "418", "420", "Gen-2", "Savvy", "Waja" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Renault")
            {
                string[] model = { "Clio", "Espace", "Fluence", "Laguna", "Latitude", "Megane", "Modus", "Safrane", "Symbol", "Twizy", "ZOE", "Scenic", "Grand Scenic ", "Talisman", "Twingo", "Vel Satis", "R 5", "R 9", "R 11", "R 12", "R 19", "R 21", "R 25" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Rolls-Royce")
            {
                string[] model = { "Dawn", "Ghost", "Park Ward", "Phantom", "Wraith" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Rover")
            {
                string[] model = { "25", "45", "75", "200", "214", "216", "220", "400", "414", "416", "420", "620", "820", "827" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Saab")
            {
                string[] model = { "900", "9000", "9-3", "9-5" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Seat")
            {
                string[] model = { "Alhambra", "Altea", "Cordoba", "Exeo", "Ibiza", "Leon", "Toledo" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Skoda")
            {
                string[] model = { "Citigo", "Fabia", "Favorit", "Felicia", "Forman", "Octavia", "Rapid", "Roomster", "Superb" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Smart")
            {
                string[] model = { "Forfour", "Fortwo", "Roadster" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Subaru")
            {
                string[] model = { "BRZ", "Impreza", "Justy", "Legacy", "Leone", "Levorg", "SVX", "Vivio" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Suzuki")
            {
                string[] model = { "Alto", "Baleno", "Ignis", "Liana", "Maruti", "S-Cross", "Splash", "Swift", "SX4", "Wagon R" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Tata")
            {
                string[] model = { "Indica", "Indigo", "Manza", "Marina", "Vista" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Tesla")
            {
                string[] model = { "Model S", "Model X" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Tofaş")
            {
                string[] model = { "Doğan", "Kartal", "Murat", "Serçe", "Şahin" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Toyota")
            {
                string[] model = { "Aristo", "Auris", "Avensis", "Camry", "Carina", "Celica", "Corolla", "Corona", "Cressida", "Crown", "GT 86", "Prius", "Starlet", "Supra", "Tercel", "Urban Cruiser", "Verso", "Yaris" };
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Volkswagen")
            {
                string[] model = {"Arteon","Bora","EOS","Golf","Jetta","Lupo","Beetle","Passat","Passat Variant","Phaeton","Polo","Scirocco","Sharan","Touran","Vento","VW CC"};
                comboBox6.Items.AddRange(model);
            }
            if (marka == "Volvo")
            {
                string[] model = { "C30", "C70", "S40", "S60", "S70", "S80", "S90", "V40", "V40 Cross Country", "V50", "V60", "V70", "V90 Cross Country", "240", "440", "460", "760", "850", "940", "960" };
                comboBox6.Items.AddRange(model);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox2.Text;
            if (metin.Length < 7)
            {
                errorProvider1.SetError(textBox2, "Plaka 7 Karakterden Az Olamaz");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
