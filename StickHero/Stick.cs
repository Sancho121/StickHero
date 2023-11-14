using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StickHero
{
    class Stick
    {
        public Point stickStartPoint = new Point(100, 515);
        public Point stickEndPoint = new Point(100, 515);
        private int stickCurrentLenght;
        private int stickAngle = -90;
        private int stickMaxLenght = 450;
        private Pen blackPen = new Pen(Color.Black, 2);

        public void DrawStick(Graphics graphics)
        {
            graphics.DrawLine(blackPen, stickStartPoint, stickEndPoint);
        }

        public void GrowStick(int gameSpeed)
        {
            stickEndPoint.Y -= gameSpeed;
            stickCurrentLenght += gameSpeed;
        }

        public void DropStick()
        {
            stickAngle += 5;
            if (StickHeroGame.gameState == GameState.DropStick && stickAngle > 0)
            {
                stickAngle = 0;
                StickHeroGame.gameState = GameState.MoveHero;
            }
            stickEndPoint.X = (int)(stickStartPoint.X + stickCurrentLenght * Math.Cos(stickAngle * Math.PI / 180));
            stickEndPoint.Y = (int)(stickStartPoint.Y + stickCurrentLenght * Math.Sin(stickAngle * Math.PI / 180));
        }

        public bool IsStickInVerticalPosition()
        {
            return stickAngle == 90;
        }

        public bool IsStickAchieveMaximumLength()
        {
            return stickCurrentLenght >= stickMaxLenght;
        }
    }
}
