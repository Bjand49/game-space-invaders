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
        private bool _isDisposed { get; set; }
        protected ContentManager Content { get; }

        private TimeSpan _lastUpdated = new TimeSpan();
        public Vector2 Origin { get; private set; }

        public Bullet(float xPostion)
        {
            this.Origin = new Vector2(xPostion, 600f);
        }

        public void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime > _lastUpdated.Add(new TimeSpan(0, 0, 0, 0, 100)))
            {
                var origin = this.Origin;
                origin.Y -= 10f;
                this.Origin = origin;
            }
        }

        public void Draw(SpriteBatch batch, Sprite sprite)
        {
            sprite.Draw(batch, this.Origin);
        }
    }
}
