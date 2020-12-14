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
    public class Obstacle : GameObjects,IMove
    {
        private int _hearts;

        public int Hearts { get => _hearts; set => _hearts = value; }
        public Obstacle(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            ObjectType = ObjectTypes.Obstacle;
        }
        public Obstacle(Bitmap bitmap) : base(bitmap)
        {
            X = SplashKit.Rnd(0, 600);
            Y = 0;
            if (X < 0) { X = 0; }
            else if (X > 600 - Width) { X = 600 - Width;}

        }
        public void GoDown(float GoDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + GoDown);

        }
        public bool Collision(GameObjects obj)
        {
            return (SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite));
        }
        public virtual void TakeEffect(Chicken c) { }
    }
}
