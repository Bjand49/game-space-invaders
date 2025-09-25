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
        private float _x = 0;
        private float _y;
        private TimeSpan _lastUpdated = new TimeSpan();
        private static readonly float SCALE = 4.0f;
        private static readonly float X_INCREMENT = 4.0f;
        private static readonly int ROW_ENEMY_AMOUNT = 12;
        private static readonly int ORIGIN_OFFSET = -22;
        private List<AnimatedSprite> _enemies;
        public Row(TextureAtlas atlas, string type, float y)
        {
            _enemies = new List<AnimatedSprite>();
            for (int i = 1; i <= ROW_ENEMY_AMOUNT; i++)
            {
                var enemy = atlas.CreateAnimatedSprite(type);
                enemy.Scale = new Vector2(SCALE, SCALE);
                enemy.Origin = new Vector2(i * ORIGIN_OFFSET, y);
                _enemies.Add(enemy);
            }
        }
        public void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime > _lastUpdated.Add(new TimeSpan(0,0,1)))
            {
                _x += 10;
                _lastUpdated = gametime.TotalGameTime;
            }
            if(_x > 100)
            {
                _y += 20;
                _x = 0;
            }
            _enemies.ForEach(x =>
            {
                x.Update(gametime);

            });

        }
        public void Draw(SpriteBatch batch)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Draw(batch, new Vector2(enemy.Origin.X + _x, enemy.Origin.Y + _y));
            }
        }
    }
}
