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
        public Vector2 Position;
        private int _width;
        private int _height;
        private readonly float SCALE = 3.0f;
        public int Width
        {
            get
            {
                return (int)(_width * SCALE);
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return (int)(_height * SCALE);
            }
            set
            {
                _height = value;
            }
        }
        private Rectangle Area
        {
            get => new Rectangle(
            (int)(Position.X),
            (int)(Position.Y),
            Width,
            Height);
        }

        public Enemy(Vector2 position, int width, int height, string type)
        {
            Position = position;
            Width = width;
            Height = height;
        }
        public void Update(GameTime gameTime, float xIncrement, float yIncrement)
        {
            Position.X += xIncrement;
            Position.Y += yIncrement;
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            base.Draw(batch, Position, Color);
        }

        public bool IsColliding(Rectangle position)
        {
            return Area.Intersects(position);
        }
        public override string ToString()
        {
            return $"X: {Position.X}, Y: {Position.Y}, Height: {Height}, Width: {Width}";
        }
    }
}
