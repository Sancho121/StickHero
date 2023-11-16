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
        private const int firstPlatformWidth = 100;
        private const int PlatformHeight = 145;
        private const int PlatformY = 515;
        private const int bonusZoneWidth = 20;
        private const int bonusZoneHeight = 5;

        public StickHeroGame(int gameSpeed, int heroSpeed)
        {
            this.gameSpeed = gameSpeed;
            this.heroSpeed = heroSpeed;
            firstPlatform = new Rectangle(0, PlatformY, firstPlatformWidth, PlatformHeight);
        }

        public void Restart()
        {
            Score = 0;
            GenerateNextLevel();
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
                            GenerateNextLevel();
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
                        Restart();
                    }
                    break;
                default:
                    break;
            }
        }

        private void GenerateNextLevel()
        {
            gameState = GameState.WaitingAction;
            secondPlatformX = random.Next(15, 37) * 10;
            secondPlatformWidth = random.Next(4, 8) * 10;
            secondPlatform = new Rectangle(secondPlatformX, PlatformY, secondPlatformWidth, PlatformHeight);
            bonusZone = new Rectangle(secondPlatformX + (secondPlatformWidth / 2) - (bonusZoneWidth / 2), PlatformY, bonusZoneWidth, bonusZoneHeight);
            hero = new Hero();
            stick = new Stick();
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
