using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        List<Control> humans = new List<Control>();
        List<Control> zombie = new List<Control>();
        List<Control> soldiers = new List<Control>();
        List<Control> players = new List<Control>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var random = new Random();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                return;
            }

            FillList(int.Parse(textBox1.Text), humans, players, PlayerType.Human, panel1, random);
            FillList(int.Parse(textBox2.Text), zombie, players, PlayerType.Zombie, panel1, random);
            FillList(int.Parse(textBox3.Text), soldiers, players, PlayerType.Soldier, panel1, random);

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            button1.Enabled = true;
            button2.Visible = false;
        }
        private void FillList(int amaunt, List<Control> controls,
            List<Control> allControls, PlayerType playerType, Panel board, Random random)
        {
            for (int i = 0; i < amaunt; i++)
            {
                PictureBox newPlayer = new PictureBox()
                {
                    Height = 20,
                    Width = 20,
                    Location = new Point(random.Next(0, 230), random.Next(0, 230))
                };

                switch (playerType)
                {
                    case PlayerType.Human:
                        newPlayer.Image = Image.FromFile("human.png");
                        break;
                    case PlayerType.Soldier:
                        newPlayer.Image = Image.FromFile("soldier.png");
                        break;
                    case PlayerType.Zombie:
                        newPlayer.Image = Image.FromFile("zombie.png");
                        break;
                    default:
                        break;
                }

                newPlayer.Invalidate();

                controls.Add(newPlayer);
                allControls.Add(newPlayer);
                board.Controls.Add(newPlayer);
            }

        }
        public enum PlayerType
        {
            Human,
            Soldier,
            Zombie
        }
    }
}
