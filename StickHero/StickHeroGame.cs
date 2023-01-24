using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StickHero
{
    class StickHeroGame
    {
        private Image heroImage = Properties.Resources.Hero;

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(heroImage, 30, 340);
        }
    }
}
