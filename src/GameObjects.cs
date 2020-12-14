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
    public class GameObjects
    {
        public Sprite _sprite;
        private bool _alive;
        private Bitmap _image;
        private ObjectTypes _objectType;
        public float X { get => SplashKit.SpriteX(_sprite); set => SplashKit.SpriteSetX(_sprite, value); }

        public float Y { get => SplashKit.SpriteY(_sprite); set => SplashKit.SpriteSetY(_sprite, value); }

        public float Width { get => SplashKit.SpriteWidth(_sprite); }
        public float Height { get => SplashKit.SpriteHeight(_sprite); }
        public bool Alive { get => _alive; set => _alive = value; }
        public Bitmap Image { get => _image; set => _image = value; }

        public ObjectTypes ObjectType { get => _objectType; set => _objectType = value; }

        public Sprite ObjectSprite { get => _sprite; }
        public GameObjects(Bitmap bitmap, float x, float y)
        {
            Alive = true;
            _image = bitmap;
            _sprite = SplashKit.CreateSprite(_image);

            SplashKit.SpriteSetX(_sprite, x);
            SplashKit.SpriteSetY(_sprite, y);
        }
        public GameObjects(Bitmap bitmap)
        {
            Alive = true;
            _image = bitmap;
            _sprite = SplashKit.CreateSprite(_image);
        }
        public GameObjects()
        {
            Alive = true;
        }

        public void Draw()
        {
            SplashKit.DrawSprite(_sprite);
        }
    }
}
