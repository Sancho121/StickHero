using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StickHero
{
    class StickHeroGame
    {           
        private Rectangle firstPlatform;
        private Rectangle secondPlatform;
        private Hero hero;

        public void Restart()
        {
            firstPlatform = new Rectangle(0, 515, 100, 145);
            secondPlatform = new Rectangle(150, 515, 50, 145);
            hero = new Hero();
        }

        public void DrawHeroAndPlatforms(Graphics graphics)
        {
            hero.DrawHero(graphics);
            graphics.FillRectangle(Brushes.Black, firstPlatform);
            graphics.FillRectangle(Brushes.Black, secondPlatform);
        }       
    }
}
