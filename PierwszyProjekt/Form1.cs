using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PierwszyProjekt
{
    public partial class Form1 : Form
    {

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
            using (connection = new SqlConnection(@"Data Source=MIKO-LAPTOP;Initial Catalog=DaneMeteo;Integrated Security=True"))
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;

                flowLayoutPanel1.Controls.Clear();
                var stacja = comboBox1.SelectedItem;
                var data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var pogoda = connection.Query<string>(
                    "SELECT Wynik FROM Pomiar WHERE Pomiar.NazwaStacji = '" +
                    stacja + "' AND Data = '" + data + "' " +
                    "ORDER BY NazwaPomiaru,Godzina");
                foreach (var item in pogoda)
                {
                    flowLayoutPanel1.Controls
                         .Add(GenerateTextBox(item.ToString()));
                    
                }

            }

        }
        private TextBox GenerateTextBox(string text)
        {
            return new TextBox()
            {
                Text = text,
                Width = 40,
                ReadOnly = true
            };
        }

    }
}
