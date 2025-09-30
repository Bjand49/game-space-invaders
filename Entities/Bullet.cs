using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Core.Graphics;
using System;
using System.Reflection.Metadata;


namespace SpaceInvaders.Entities
{
    public class Bullet
    {
        private TimeSpan _lastUpdated = new TimeSpan();
        public Vector2 Position;
        public Rectangle Rectangle
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, 2, 3);
        }

        public Bullet(float xPostion)
        {
            Position = new Vector2(xPostion, 600f);
        }

        public void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime > _lastUpdated.Add(new TimeSpan(0, 0, 0, 0, 100)))
            {
                Position.Y -= 10;
            }
        }

        public void Draw(SpriteBatch batch, Sprite sprite)
        {
            sprite.Draw(batch, Position);
        }
    }
}
