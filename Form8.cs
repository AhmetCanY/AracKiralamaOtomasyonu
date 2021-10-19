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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Proje1.mdb");
        private void Form8_Load(object sender, EventArgs e)
        {           
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglantı;
                komut.CommandText = ("Select * from Araçlar");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["Marka"]);
                }
                baglantı.Close();           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("insert into Kiralama (Ad,Soyad,Telefon,Kiralama_Tarihi,Teslim_Tarihi,Adres,Araç,Model) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";

                MessageBox.Show(" Kayıt Başarılı..! ");
            }
            else
            {
                MessageBox.Show("Kayıt Alanlarına Eksiklik Var Lütfen Kontrol Ediniz...!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }   
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string marka = comboBox1.SelectedItem.ToString();
            if (marka == "Acura")
            {
                string[] model = { "RL" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Alfa Romeo")
            {
                string[] model = { "4C", "33", "145", "146", "147", "155", "156", "159", "164", "166", "Brera", "Giulietta", "GT", "GTV", "MiTo", "Spider" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Anadol")
            {
                string[] model = { "A", "SV" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Aston Martin")
            {
                string[] model = { "Cygnet", "DB7", "DB9", "DB11", "DBS", "Rapide", "Vanquish", "Vantage", "Virage" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Audi")
            {
                string[] model = { "A1", "A3", "A4", "A5", "A6", "A7", "A8", "R8", "RS", "S Serisi", "TT", "V8", "80 Serisi", "90 Serisi", "100 Serisi" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Bentley")
            {
                string[] model = { "Brooklands", "Continental", "Flying Spur", "Mulsanne" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "BMW")
            {
                string[] model = { "1 Serisi", "2 Serisi", "3 Serisi", "4 Serisi", "5 Serisi", "6 Serisi", "7 Serisi", "8 Serisi", "İ Serisi", "M Serisi", "Z Serisi" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Brilliance")
            {
                string[] model = { "Zhonghua" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Bugatti")
            {
                string[] model = { "Chiron" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Buick")
            {
                string[] model = { "Century", "Le Sabre", "Park Avenue", "Regal", "Roadmaster" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Cadillac")
            {
                string[] model = { "BLS", "Brougham", "CTS", "DeVille", "Eldorado", "Fleetwood", "Seville", "STS" };
                comboBox2.Items.AddRange(model);
            } 
            if (marka == "Chery")
            {
                string[] model = { "Alia", "Chance", "Kimo" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Chevrolet")
            {
                string[] model = { "Aveo", "Beretta", "Camaro", "Caprice", "Celebrity", "Corsica", "Corvette", "Cruze", "Epica", "Evanda", "Geo Storm", "Impala", "Kalos", "Lacetti", "Monte Carlo", "Rezzo", "Spark" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Chrysler")
            {
                string[] model = { "200", "300 C", "300 M", "Concorde", "Crossfire", "LHS", "Neon", "PT Cruiser", "Sebring", "Stratus" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Citroën")
            {
                string[] model = { "AX", "BX", "C-Elysée", "C1", "C2", "C3", "C3 Picasso", "C4", "C4 Picasso", "C4 Grand Picasso", "C5", "C6", "C8", "Evasion", "Saxo", "Xantia", "XM", "Xsara", "ZX" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Dacia")
            {
                string[] model = { "Lodgy", "Logan", "Sandero", "Solenza" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Daewoo")
            {
                string[] model = { "Chairman", "Espero", "Lanos", "Leganza", "Matiz", "Nexia", "Nubira", "Racer", "Super Saloon", "Tico" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Daihatsu")
            {
                string[] model = { "Applause", "Charade", "Copen", "Cuore", "Materia", "Sirion", "YRV" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Dodge")
            {
                string[] model = { "Avenger", "Challenger", "Charger", "Magnum", "Neon", "Spirit", "Viper" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "DS Automobiles")
            {
                string[] model = { "DS 3", "DS 4", "DS 4 Crossback", "DS 5" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Ferrari")
            {
                string[] model = { "360", "430", "456", "458", "488", "512", "550", "575", "599", "612", "California", "F355", "FF", "F Serisi" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Fiat")
            {
                string[] model = { "124 Spider", "126 Bis", "500 Ailesi", "Albea", "Brava", "Bravo", "Coupe", "Croma", "Egea", "Idea", "Linea", "Marea", "Palio", "Panda", "Punto", "Sedici", "Siena", "Stilo", "Tempra", "Tipo", "Ulysse", "Uno" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Fisker")
            {
                string[] model = { "Karma" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Ford")
            {
                string[] model = { "B-Max", "C-Max", "Cougar", "Crown Victoria", "Escort", "Festiva", "Fiesta", "Focus", "Fusion", "Galaxy", "Granada", "Grand C-Max", "Ka", "Mondeo", "Mustang", "Orion", "Scorpio", "Sierra", "S-Max", "Taunus", "Taurus", "Thunderbird" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Geely")
            {
                string[] model = { "Echo", "Emgrand", "Familia", "FC" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Honda")
            {
                string[] model = { "Accord", "City", "Civic", "CRX", "CR-Z", "Integra", "Jazz", "Legend", "NSX", "Prelude", "S2000", "Shuttle", "Stream" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Hyundai")
            {
                string[] model = { "Accent", "Accent Blue", "Accent Era", "Atos", "Centennial", "Coupe", "Elantra", "Excel", "Genesis", "Getz", "Grandeur", "Ioniq", "i10", "i20", "i20 Active", "i20 Troy", "i30", "i40", "iX20", "Matrix", "Santamo", "S-Coupe", "Sonata", "Trajet" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Ikco")
            {
                string[] model = { "Samand" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Infiniti")
            {
                string[] model = { "G", "I30", "M", "Q30", "Q50", "Q60" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Isuzu")
            {
                string[] model = { "Gemini" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Jaguar")
            {
                string[] model = { "Daimler", "F-Type", "Sovereign", "S-Type", "XE", "XF", "XJ", "XJR", "XJS", "XK8", "XKR", "X-Type" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Kia")
            {
                string[] model = { "Capital", "Carens", "Carnival", "Ceed", "Cerato", "Clarus", "Magentis", "Opirus", "Optima", "Picanto", "Pride", "Pro Ceed", "Rio", "Sephia", "Shuma", "Venga" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lada")
            {
                string[] model = { "Kalina", "Priora", "Samara", "VAZ", "Vega" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lamborghini")
            {
                string[] model = { "Aventador", "Gallardo", "Huracan" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lancia")
            {
                string[] model = { "Delta", "Thema", "Y ( Ypsilon )" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lexus")
            {
                string[] model = { "CT", "GS", "IS", "LS", "RC" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lincoln")
            {
                string[] model = { "Continental", "LS", "Mark", "MKS", "Town Car" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Lotus")
            {
                string[] model = { "Elise", "Evora", "Exige" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Maserati")
            {
                string[] model = { "Cambiocorsa", "Ghibli", "GranCabrio", "GranSport", "GranTurismo", "GT", "Quattroporte", "Spyder" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mazda")
            {
                string[] model = { "2", "3", "5", "6", "MPV", "121", "323", "626", "Lantis", "MX", "Premacy", "RX", "Xedos" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "McLaren")
            {
                string[] model = { "675LT Spider", "720S", "MP4-12C" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mercedes - Benz")
            {
                string[] model = { "A", "AMG GT", "B", "C", "CL", "CLA", "CLC", "CLK", "CLS", "E", "Maybach S", "R", "S", "SL", "SLC", "SLK", "SLS AMG", "190", "200", "220", "230", "240", "250", "260", "280", "300", "320", "380", "400", "420", "500", "560", "600" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mercury")
            {
                string[] model = { "Sable" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "MG")
            {
                string[] model = { "F", "ZR" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mini")
            {
                string[] model = { "Cooper", "Cooper Clubman", "Cooper S", "John Cooper", "One" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mitsubishi")
            {
                string[] model = { "Attrage", "Carisma", "Colt", "Eclipse", "Galant", "Grandis", "Lancer", "Lancer Evolution", "Space Star" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Morgan")
            {
                string[] model = { "3 Wheeler", "4/4" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Nissan")
            {
                string[] model = { "200 SX", "350 Z", "Almera", "Altima", "Bluebird", "GT-R", "Laurel Altima", "Maxima", "Micra", "Note", "NX Coupe", "Primera", "Pulsar", "Sunny" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Oldsmobile")
            {
                string[] model = { "Cutlass Ciera" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Opel")
            {
                string[] model = { "Adam", "Agila", "Ascona", "Astra", "Calibra", "Cascada", "Corsa", "GT (Roadster)", "Insignia", "Kadett", "Manta", "Meriva", "Omega", "Rekord", "Senator", "Signum", "Tigra", "Vectra", "Zafira" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Peugeot")
            {
                string[] model = { "106", "107", "205", "206", "206", "207", "208", "301", "306", "307", "308", "309", "405", "406", "407", "508", "605", "607", "806", "807", "RCZ" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Plymouth")
            {
                string[] model = { "Laser" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Pontiac")
            {
                string[] model = { "Firebird", "Solstice" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Porsche")
            {
                string[] model = { "718", "911", "944", "Boxster", "Cayman", "Panamera" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Proton")
            {
                string[] model = { "218", "315", "316", "415", "416", "418", "420", "Gen-2", "Savvy", "Waja" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Renault")
            {
                string[] model = { "Clio", "Espace", "Fluence", "Laguna", "Latitude", "Megane", "Modus", "Safrane", "Symbol", "Twizy", "ZOE", "Scenic", "Grand Scenic ", "Talisman", "Twingo", "Vel Satis", "R 5", "R 9", "R 11", "R 12", "R 19", "R 21", "R 25" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Rolls-Royce")
            {
                string[] model = { "Dawn", "Ghost", "Park Ward", "Phantom", "Wraith" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Rover")
            {
                string[] model = { "25", "45", "75", "200", "214", "216", "220", "400", "414", "416", "420", "620", "820", "827" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Saab")
            {
                string[] model = { "900", "9000", "9-3", "9-5" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Seat")
            {
                string[] model = { "Alhambra", "Altea", "Cordoba", "Exeo", "Ibiza", "Leon", "Toledo" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Skoda")
            {
                string[] model = { "Citigo", "Fabia", "Favorit", "Felicia", "Forman", "Octavia", "Rapid", "Roomster", "Superb" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Smart")
            {
                string[] model = { "Forfour", "Fortwo", "Roadster" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Subaru")
            {
                string[] model = { "BRZ", "Impreza", "Justy", "Legacy", "Leone", "Levorg", "SVX", "Vivio" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Suzuki")
            {
                string[] model = { "Alto", "Baleno", "Ignis", "Liana", "Maruti", "S-Cross", "Splash", "Swift", "SX4", "Wagon R" };
                comboBox2.Items.AddRange(model); ;
            }
            if (marka == "Tata")
            {
                string[] model = { "Indica", "Indigo", "Manza", "Marina", "Vista" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Tesla")
            {
                string[] model = { "Model S", "Model X" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Tofaş")
            {
                string[] model = { "Doğan", "Kartal", "Murat", "Serçe", "Şahin" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Toyota")
            {
                string[] model = { "Aristo", "Auris", "Avensis", "Camry", "Carina", "Celica", "Corolla", "Corona", "Cressida", "Crown", "GT 86", "Prius", "Starlet", "Supra", "Tercel", "Urban Cruiser", "Verso", "Yaris" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Volkswagen")
            {
                string[] model = { "Arteon", "Bora", "EOS", "Golf", "Jetta", "Lupo", "Beetle", "Passat", "Passat Variant", "Phaeton", "Polo", "Scirocco", "Sharan", "Touran", "Vento", "VW CC" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Volvo")
            {
                string[] model = { "C30", "C70", "S40", "S60", "S70", "S80", "S90", "V40", "V40 Cross Country", "V50", "V60", "V70", "V90 Cross Country", "240", "440", "460", "760", "850", "940", "960" };
                comboBox2.Items.AddRange(model);
            }
        }
    }
}
