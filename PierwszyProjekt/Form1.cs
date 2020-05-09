using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PierwszyProjekt
{
    public partial class Form1 : Form
    {
        DateTime rokWstecz;
        SqlConnection connection;
        public Form1()
        {
            
            InitializeComponent();
            
            using (connection = new SqlConnection(@"Data Source=MIKO-LAPTOP;Initial Catalog=DaneMeteo;Integrated Security=True"))
            {
                DB db = new DB();
                comboBox1.DataSource = db.SelectStacje(connection);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                List<Control> Kontrolki = new List<Control>();
                Kontrolki.Add(pictureBox1);
                Kontrolki.Add(pictureBox2);
                Kontrolki.Add(pictureBox3);
                Kontrolki.Add(pictureBox4);
                Kontrolki.Add(label1);
                Kontrolki.Add(label2);
                Kontrolki.Add(label3);
                Kontrolki.Add(label4);
                Kontrolki.Add(label5);
                Kontrolki.Add(label6);
                Kontrolki.Add(label7);
                Kontrolki.Add(label8);
                Kontrolki.Add(label9);
                Kontrolki.Add(label10);
                Kontrolki.Add(label11);
                Kontrolki.Add(label12);
                Kontrolki.Add(label13);
                Kontrolki.Add(label14);
                Kontrolki.Add(label15);
                Kontrolki.Add(label16);
                Kontrolki.Add(label17);
                Kontrolki.Add(label18);
                Kontrolki.Add(button2);

                foreach (var item in Kontrolki)
                {
                    item.Visible = true;
                }

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
                flowLayoutPanel5.Controls.Clear();
                flowLayoutPanel6.Controls.Clear();
                flowLayoutPanel7.Controls.Clear();
                flowLayoutPanel8.Controls.Clear();

                var stacja = comboBox1.SelectedItem;
                var data = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                rokWstecz = dateTimePicker1.Value.AddYears(-1);
                button2.Text =$"Zobacz {rokWstecz.ToString("d")}";
                GetDataFromDB(stacja, data);

        }
        private void GetDataFromDB(object stacja,string data)
        {
            using (connection = new SqlConnection(@"Data Source=MIKO-LAPTOP;Initial Catalog=DaneMeteo;Integrated Security=True"))
            {
                var pogoda = connection.Query<string>(
                    "SELECT Wynik FROM Pomiar WHERE Pomiar.NazwaStacji = '" +
                     stacja + "' AND Data = '" + data + "' " +
                    "ORDER BY NazwaPomiaru,Godzina");

                if (pogoda.Count() == 0)
                {
                    string brak = "bd";
                    for (int i = 0; i < 4; i++)
                    {
                        flowLayoutPanel2.Controls
                           .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel3.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel4.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel5.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel6.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel7.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        flowLayoutPanel8.Controls
                          .Add(GenerateSimpleTextBox(brak));
                        for (int j = 0; j < 4; j++)
                        {
                            flowLayoutPanel1.Controls
                               .Add(GenerateSimpleTextBox(brak));
                        }
                    }
                }
                else
                {
                    var sredniaStacja = connection.Query<string>(
                        "SELECT AVG(Wynik) FROM Pomiar" +
                        " WHERE Pomiar.NazwaStacji = '" +
                        stacja + "' AND Data = '" + data + "' " +
                        "GROUP BY NazwaPomiaru,NazwaStacji ORDER BY NazwaPomiaru;");

                    var sredniaMiasto = connection.Query<string>(
                        "SELECT AVG(Wynik)" +
                        " FROM Pomiar INNER JOIN Stacja ON Pomiar.NazwaStacji = Stacja.NazwaStacji" +
                        " WHERE Miasto = (SELECT Miasto FROM Stacja WHERE NazwaStacji = '" + stacja + "') AND Pomiar.Data = '" + data + "'" +
                        " GROUP BY NazwaPomiaru; ");

                    var maxStacja = connection.Query<string>(
                       "SELECT MAX(Wynik) FROM Pomiar" +
                       " WHERE Pomiar.NazwaStacji = '" +
                       stacja + "' AND Data = '" + data + "' " +
                       "GROUP BY NazwaPomiaru,NazwaStacji ORDER BY NazwaPomiaru;");

                    var maxMiasto = connection.Query<string>(
                        "SELECT MAX(Wynik)" +
                        " FROM Pomiar INNER JOIN Stacja ON Pomiar.NazwaStacji = Stacja.NazwaStacji" +
                        " WHERE Miasto = (SELECT Miasto FROM Stacja WHERE NazwaStacji = '" + stacja + "') AND Pomiar.Data = '" + data + "'" +
                        " GROUP BY NazwaPomiaru; ");

                    var minStacja = connection.Query<string>(
                       "SELECT MIN(Wynik) FROM Pomiar" +
                       " WHERE Pomiar.NazwaStacji = '" +
                       stacja + "' AND Data = '" + data + "' " +
                       "GROUP BY NazwaPomiaru,NazwaStacji ORDER BY NazwaPomiaru;");

                    var minMiasto = connection.Query<string>(
                        " SELECT MIN(Wynik)" +
                        " FROM Pomiar INNER JOIN Stacja ON Pomiar.NazwaStacji = Stacja.NazwaStacji" +
                        " WHERE Miasto = (SELECT Miasto FROM Stacja WHERE NazwaStacji = '" + stacja + "') AND Pomiar.Data = '" + data + "'" +
                        " GROUP BY NazwaPomiaru; ");

                    int dataRoczna = DateTime.Parse(data).Year;

                    var avgRoczna = connection.Query<string>(
                    "SELECT AVG(Wynik)" +
                    " FROM Pomiar " +
                    " WHERE YEAR(Data) = " + dataRoczna + "" +
                    " GROUP BY NazwaPomiaru; ");


                    int licznik = 0;
                    double[] tab = new double[4];
                    foreach (var item in avgRoczna)
                    {
                        string elem = item.ToString();
                        flowLayoutPanel8.Controls
                             .Add(GenerateSimpleTextBox(elem));
                        tab[licznik] = double.Parse(elem, CultureInfo.InvariantCulture);
                        licznik++;
                    }

                    licznik = 0;
                    int iterator = 0;

                    // cisnienie
                    // opady
                    // predkosc wiatru
                    // temperatura

                    foreach (var item in pogoda)
                    {
                        licznik++;
                        flowLayoutPanel1.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        if (licznik % 4 == 0) iterator++;
                    }
                    iterator = 0;

                    foreach (var item in sredniaStacja)
                    {
                        flowLayoutPanel2.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;

                    }
                    iterator = 0;

                    foreach (var item in sredniaMiasto)
                    {
                        flowLayoutPanel3.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;
                    }
                    iterator = 0;

                    foreach (var item in maxStacja)
                    {
                        flowLayoutPanel4.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;
                    }
                    iterator = 0;

                    foreach (var item in maxMiasto)
                    {
                        flowLayoutPanel5.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;
                    }
                    iterator = 0;

                    foreach (var item in minStacja)
                    {
                        flowLayoutPanel6.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;
                    }
                    iterator = 0;

                    foreach (var item in minMiasto)
                    {
                        flowLayoutPanel7.Controls
                             .Add(GenerateTextBox(item.ToString(), tab[iterator]));
                        iterator++;
                    }
                }
            }
        }
        private TextBox GenerateSimpleTextBox(string text)
        {
            return new TextBox()
            {
                Text = text,
                Width = 40,
                ReadOnly = true
            };
        }
        private TextBox GenerateTextBox(string text,double srednia)
        {
            Color color = Color.Blue;
            Color fColor = Color.White;
            double wartosc = double.Parse(text, CultureInfo.InvariantCulture);
            if (wartosc >= srednia)
            {
                color = Color.Red;
                fColor = Color.Black;
            }
            return new TextBox()
            {
                BackColor=color,
                ForeColor=fColor,
                Text = text,
                Width = 40,
                ReadOnly = true
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel6.Controls.Clear();
            flowLayoutPanel7.Controls.Clear();
            flowLayoutPanel8.Controls.Clear();

            dateTimePicker1.Value = rokWstecz;
            var stacja = comboBox1.SelectedItem;
            GetDataFromDB(stacja, rokWstecz.ToString("yyyy-MM-dd"));

            rokWstecz = dateTimePicker1.Value.AddYears(-1);
            button2.Text = $"Zobacz {rokWstecz.ToString("d")}";

        }
    }
}
