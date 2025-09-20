using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Core.Graphics;
using Space_Invaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Entities
{
    public class Row
    {
        private float x;
        private float y;
        private List<AnimatedSprite> _enemies;
        public Row(TextureAtlas atlas, string type, float y)
        {
            _enemies = new List<AnimatedSprite>();
            x = 0;
            for (int i = 0; i < 12; i++)
            {
                var enemy = atlas.CreateAnimatedSprite(type);
                enemy.Scale = new Vector2(4.0f, 4.0f);
                enemy.Origin = new Vector2(x, y);
                x -= 22;
                _enemies.Add(enemy);
            }
        }
        public void Update(GameTime gametime)
        {
            _enemies.ForEach(x => x.Update(gametime));
        }
        public void Draw(SpriteBatch batch)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Draw(batch, new Vector2(enemy.Origin.X, enemy.Origin.Y));
            }
        }
    }
}
