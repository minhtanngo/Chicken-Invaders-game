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
    public class GameMain
    {
        private List<IMove> moveObject;
        private List<IMove> _toDelete;
        private List<Bullet> bullet;
        public GameMain()
        {
            moveObject = new List<IMove>();
            bullet = new List<Bullet>();
        }
        public void RemoveObject()
        {
            foreach (IMove obj in _toDelete)
            {
                moveObject.Remove(obj);
            }
        }
        public void ResetCollector()
        {
            _toDelete = new List<IMove>();
        }
        public void AddHeart()
        {
            if (SplashKit.Rnd(0, 50000) % 50000 == 0)
            {
                AddHeart buff = new AddHeart(SplashKit.LoadBitmap("heart", "heart.png"));
                moveObject.Add(buff);

            }
        }
        public void AddObstacle()
        {
            if (SplashKit.Rnd(0, 4000) % 4000 == 0)
            {
                Obstacle b = new Burger(SplashKit.LoadBitmap("burger", "burger.png"), SplashKit.Rnd(0, 500), 0);
                moveObject.Add(b);
            }
            if (SplashKit.Rnd(0, 5000) % 5000 == 0)
            {
                Obstacle b = new Stone(SplashKit.LoadBitmap("stone", "stone.png"), SplashKit.Rnd(0, 500), 0);
                moveObject.Add(b);
            }
        }
        public void DrawHeart()
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is AddHeart)
                {
                    obj.Draw();
                }
            }
        }
        public void DrawObstacle()
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is Obstacle)
                {
                    obj.Draw();
                }
            }
        }
        public void AddBullet(Chicken c)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                bullet.Add(c.InitializeBullet());
            }
        }
        public void DrawBullet()
        {
            foreach (Bullet bu in bullet)
            {
                bu.Draw();
            }
        }
        public void MoveHeart()
        {
            foreach(IMove obj in moveObject)
            {
                if (obj is AddHeart)
                {
                    obj.GoDown(0.05F);
                }
            }
        }
        public void MoveObstacle()
        {
            foreach(IMove obj in moveObject)
            {
                if(obj is Obstacle && obj.GetType() == typeof(Burger))
                {
                    obj.GoDown(0.2f);
                }
                if(obj is Obstacle && obj.GetType() == typeof(Stone))
                {
                    obj.GoDown(0.1f);
                }
            }
        }
        public void MoveBullet()
        {
            foreach (Bullet bu in bullet)
            {
                if (bu.ObjectType == ObjectTypes.Chicken && bu.GetType() == typeof(Bullet))
                {
                    bu.GoDown(-0.1f);
                }
            }
        }
        public void Recover(Chicken c)
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is AddHeart)
                {
                    AddHeart heart = obj as AddHeart;

                    if (heart.Collision(c))
                    {
                        heart.TakeAffect(c);
                        _toDelete.Add(heart);
                    }
                }
            }
        }
        public void CheckObstacle(Chicken c)
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is Obstacle)
                {
                    Obstacle obstacle = obj as Obstacle;
                    if (obstacle.Hearts <= 0)
                    {
                        obstacle.Alive = false;
                        c.Score += 1;
                    }

                    if (obstacle.Alive == false)
                    {
                        _toDelete.Add(obstacle);
                    }
                }
            }
        }
        public void Collision(Chicken c)
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is Obstacle)
                {
                    Obstacle ob = obj as Obstacle;
                    if (ob.Collision(c))
                    {
                        ob.TakeEffect(c);
                        _toDelete.Add(ob);
                    }
                }
            }
        }
        public void CollisionBullet(Chicken c)
        {
            foreach (IMove obj in moveObject)
            {
                if (obj is Obstacle)
                {
                    Obstacle ob = obj as Obstacle;
                    foreach (Bullet bullet in bullet)
                    {
                        if (ob.Collision(bullet))
                        {
                            ob.Hearts -= bullet.Dame;
                            ob.Alive = false;
                            _toDelete.Add(ob);
                        }
                        if (ob.Alive == false)
                        {
                            c.Score = c.Score + 1;
                        }
                    }
                }
            }
        }
        public void Check()
        {
            foreach (IMove obj in moveObject)
            {
                if (obj.Y > SplashKit.ScreenHeight())
                {
                    _toDelete.Add(obj);
                }
            }
        }
    }
}
