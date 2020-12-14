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
    public class AddHeart : GameObjects,IMove
    {
        public AddHeart(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            ObjectType = ObjectTypes.AddHeart;
        }
        public AddHeart(Bitmap bitmap) : base(bitmap)
        {
            X = SplashKit.Rnd(0, 600);
            Y = 0;
            if (X < 0) { X = 0; }
            else if( X > 600 - Width)
            {
                X = 600 - Width;
            }
        }
        public bool Collision(GameObjects obj)
        {
            return SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite);
        }
        public void GoDown(float GoDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + GoDown);
        }
        public void TakeAffect(Chicken c)
        {
            c.Hearts += 1;
        }
    }
}
