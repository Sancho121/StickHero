using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StickHero
{
    class Hero
    {
        private Image heroImage = Properties.Resources.Hero;

        public void DrawHero(Graphics graphics)
        {
            graphics.DrawImage(heroImage, 30, 455);
        }
    }
}
