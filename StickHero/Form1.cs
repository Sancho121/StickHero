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
        StickHeroGame stickHeroGame = new StickHeroGame(10, 5);        
        
        public Form1()
        {
            InitializeComponent();
            stickHeroGame.Restart();
            timer1.Interval = 1;
            scoreLabel.Text = stickHeroGame.Score.ToString();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            stickHeroGame.DrawGameElements(e.Graphics);           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stickHeroGame.Update();
            scoreLabel.Text = stickHeroGame.Score.ToString();
            this.pictureBox1.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
         {
            if (e.KeyCode == Keys.Space && StickHeroGame.gameState == GameState.WaitingAction)
            {
                timer1.Start();
                StickHeroGame.gameState = GameState.GrowStick;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && StickHeroGame.gameState == GameState.GrowStick)
            {
                StickHeroGame.gameState = GameState.DropStick;
            }
        }
    }
}
