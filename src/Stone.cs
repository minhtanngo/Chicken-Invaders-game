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
    public class Stone : Obstacle
    {
        public Stone(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            Hearts = 2;
        }
        public override void TakeEffect(Chicken c)
        {
            c.Hearts = c.Hearts - 1;
        }
    }
}
