using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using Space_Invaders.Core.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Entities
{
    public class Enemy : AnimatedSprite
    {
        private Vector2 _position;
        public int Width { get; set; }
        public int Height { get; set; }
        private string _type;
        private Rectangle Area
        {
            get => new Rectangle((int)_position.X, (int)_position.Y, Width, Height);
        }

        public Enemy(Vector2 position, int width, int height, string type)
        {
            _position = position;
            Width = width;
            Height = height;
            _type = type;
        }
        public void Update(GameTime gameTime, float xIncrement, float yIncrement)
        {
            _position.X += xIncrement;
            _position.Y += yIncrement;
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            base.Draw(batch, _position);
        }

        public bool IsColliding(Rectangle position)
        {
            return Area.Intersects(position);
        }
    }
}
