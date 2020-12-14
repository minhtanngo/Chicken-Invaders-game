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
    public class Burger : Obstacle
    {
        public Burger(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            Hearts = 4;
        }
        public override void TakeEffect(Chicken c)
        {
            c.Hearts = c.Hearts - 1;
        }
    }
}
