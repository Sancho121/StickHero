using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace StickHero
{
    class StickHeroGame
    {
        public static GameState gameState;
        public int Score { get; private set; } = 0;
        private int gameSpeed;
        private int heroSpeed;
        private Rectangle firstPlatform;
        private Rectangle secondPlatform;
        private Rectangle bonusZone;
        private Hero hero;
        private Stick stick;
        private Random random = new Random();
        private int secondPlatformX;
        private int secondPlatformWidth;

        public StickHeroGame(int gameSpeed, int heroSpeed)
        {
            this.gameSpeed = gameSpeed;
            this.heroSpeed = heroSpeed;
        }

        public void Restart()
        {
            gameState = GameState.WaitingAction;
            secondPlatformX = random.Next(15, 37) * 10;
            secondPlatformWidth = random.Next(4, 8) * 10;
            firstPlatform = new Rectangle(0, 515, 100, 145);
            secondPlatform = new Rectangle(secondPlatformX, 515, secondPlatformWidth, 145);
            bonusZone = new Rectangle(secondPlatformX + (secondPlatformWidth / 2) - 10, 515, 20, 5);
            hero = new Hero();
            stick = new Stick();
        }

        public void DrawGameElements(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.FillRectangle(Brushes.Black, firstPlatform);
            graphics.FillRectangle(Brushes.Black, secondPlatform);
            graphics.FillRectangle(Brushes.Yellow, bonusZone);
            hero.DrawHero(graphics);
            stick.DrawStick(graphics);           
        }
        
        public void Update()
        {
            switch (gameState)
            {
                case GameState.WaitingAction:
                    break;
                case GameState.GrowStick:
                    stick.GrowStick(gameSpeed);

                    if (stick.IsStickAchieveMaximumLength())
                        gameState = GameState.DropStick;
                    break;
                case GameState.DropStick:
                    stick.DropStick();
                    break;
                case GameState.MoveHero:
                    hero.MoveHero(heroSpeed);

                    if (IsHeroGetEndOfStick())
                    {
                        if (IsEndOfStickHitSecondPlatform())
                        {
                            if (IsEndOfStickTouchBonusZone())
                            {
                                Score += 2;
                            }
                            else
                            {
                                Score++;
                            }
                            Restart();
                        }
                        else
                        {
                            gameState = GameState.FallHeroAndStick;
                        }
                    }
                    break;
                case GameState.FallHeroAndStick:
                    hero.DropHero(heroSpeed);
                    stick.DropStick();

                    if (stick.IsStickInVerticalPosition())
                    {
                        Score = 0;
                        Restart();
                    }
                    break;
                default:
                    break;
            }
        }

        private bool IsHeroGetEndOfStick()
        {
            return hero.heroPosition.X + hero.heroImage.Width == stick.stickEndPoint.X;
        }

        private bool IsEndOfStickHitSecondPlatform()
        {
            return stick.stickEndPoint.X >= secondPlatform.X &&
                   stick.stickEndPoint.X <= secondPlatform.X + secondPlatform.Width;
        }

        private bool IsEndOfStickTouchBonusZone()
        {
            return stick.stickEndPoint.X >= bonusZone.X &&
                   stick.stickEndPoint.X <= bonusZone.X + bonusZone.Width;
        }
    }
}
