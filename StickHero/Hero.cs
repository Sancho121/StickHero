using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StickHero
{
    class Hero
    {
        public Image heroImage = Properties.Resources.Hero;       
        public Point heroPosition = new Point(30, 455);

        public void DrawHero(Graphics graphics)
        {
            graphics.DrawImage(heroImage, heroPosition);           
        }

        public void MoveHero(int gameSpeed)
        {
            heroPosition.X += gameSpeed;
        }

        public void DropHero(int gameSpeed)
        {
            heroPosition.Y += gameSpeed;
        }
    }
}
