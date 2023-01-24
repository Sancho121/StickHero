using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickHero
{
    public partial class Form1 : Form
    {
        StickHeroGame stickHeroGame = new StickHeroGame();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            stickHeroGame.Draw(e.Graphics);
            e.Graphics.FillRectangle(Brushes.Black, 150, 400, 50, 160);
        }
    }
}
