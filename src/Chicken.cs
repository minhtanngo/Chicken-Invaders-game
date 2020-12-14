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
    public class Chicken : GameObjects
    {
        private int _hearts = 3;
        private int _score = 0;
        private int _dame = 1;
        private Bitmap _chickenImage = SplashKit.LoadBitmap("chicken", "chicken.png");
        private Bitmap _bulletImage = SplashKit.LoadBitmap("bullet", "bullet.png");

        public int Hearts { get => _hearts; set => _hearts = value; }
        public int Score { get => _score; set => _score = value; }
        
        public Bitmap ChickenImage { get => _chickenImage; set => _chickenImage = value; }
        public Bitmap BulletImage { get => _bulletImage; set => _bulletImage = value; }
        public int Dame { get => _dame; set => _dame = value; }

        public Chicken(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            ObjectType = ObjectTypes.Chicken;
        }
        public Chicken() : base()
        {
            Image = _chickenImage;
            _sprite = new Sprite(Image);
            SplashKit.SpriteSetX(_sprite, SplashKit.MouseX() - Width / 2);
            SplashKit.SpriteSetY(_sprite, SplashKit.MouseY() - Height / 2);
        }
        public Bullet InitializeBullet()
        {
            Bullet b = new Bullet(_bulletImage, SplashKit.MouseX() - Width / 2 + _bulletImage.Width, SplashKit.MouseY() - Height / 2)
            {
                Dame = 1,
                ObjectType = ObjectTypes.Chicken
            };
            return b;
        }
        public void Move()
        {
            float x = SplashKit.MouseX() - Width / 2;
            float y = SplashKit.MouseY() - Height / 2;
            if (x > 600 - Image.Width) { x = 600 - Image.Width; }
            else if (x < 0) { x = 0; }
            if (y > 800 - Image.Height) { y = 800 - Image.Height; }
            else if (y < 0) { y = 0; }
            SplashKit.SpriteSetX(ObjectSprite, x);    //update X value
            SplashKit.SpriteSetY(ObjectSprite, y);    //update Y value
        }
    }
}
