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
    public interface IMove
    {
        float X { get; set; }
        float Y { get; set; }
        float Height { get; }
        float Width { get; }
        ObjectTypes ObjectType { get; set; }
        bool Collision(GameObjects obj);
        void Draw();
        void GoDown(float GoDown);
    }
}
