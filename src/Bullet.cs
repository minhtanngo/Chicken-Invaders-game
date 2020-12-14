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
    public class Bullet : GameObjects,IMove
    {
        private int _dame;

        public int Dame { get => _dame; set => _dame = value; }
        public Bullet(Bitmap bitmap, float x,float y) : base(bitmap, x, y) { }
        public void GoDown(float GoDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + GoDown);
        }
        public bool Collision(GameObjects obj)
        {
            return (SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite));
        }
    }
}
