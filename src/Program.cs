using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ChickenInvaders
{
    public class Program
    {
        public static void Main()
        {
            Bitmap background = SplashKit.LoadBitmap("background", "background.png");
            Chicken c = new Chicken();
            GameMain game = new GameMain();
            new Window("Chicken Invaders", 600, 800);
            while(!SplashKit.WindowCloseRequested("Chicken Invaders"))
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if(c.Hearts > 0)
                {
                    SplashKit.DrawBitmap(background, 0, -100);
                    SplashKit.DrawText("Hearts: " + c.Hearts, Color.Black, 5, 10);
                    SplashKit.DrawText("Score: " + c.Score, Color.Black, 5, 30);
                    c.Draw();
                    c.Move();
                    SplashKit.HideMouse();
                    game.ResetCollector();
                    game.AddHeart();
                    game.DrawHeart();
                    game.MoveHeart();
                    game.DrawObstacle();
                    game.AddObstacle();
                    game.MoveBullet();
                    game.DrawBullet();
                    game.MoveObstacle();
                    game.AddBullet(c);
                    game.Recover(c);
                    game.Collision(c);
                    game.CollisionBullet(c);

                    if (c.Hearts <= 0)
                    {
                        c.Alive = false;
                    }

                    if (c.Alive == false)
                    {
                        c.Hearts = c.Hearts - 1;
                        c.BulletImage = SplashKit.LoadBitmap("bullet", "bullet.png");
                        c.X = SplashKit.MouseX();
                        c.Y = SplashKit.MouseY();
                        c.Alive = true;
                    }
                    game.CheckObstacle(c);
                    game.Check();
                    game.RemoveObject();
                }
                else
                {
                    SplashKit.DrawText("Game Over", Color.Black, 260, 400);
                    SplashKit.ShowMouse();
                }
                SplashKit.RefreshScreen();
            }
        }
    }
}
