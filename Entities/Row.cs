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
        private float _x = 10;
        private float _y;
        private TimeSpan _lastUpdated = new TimeSpan();
        private bool _movingRight = true;
        private static readonly float SCALE = 3.0f;
        private static readonly float X_INCREMENT = 10.0f;
        private static readonly int ROW_ENEMY_AMOUNT = 12;
        private static readonly int X_OFFSET = -25;
        private static readonly int Y_OFFSET = -30;
        private List<AnimatedSprite> _enemies;
        public Row(TextureAtlas atlas, string type, int index)
        {
            _enemies = new List<AnimatedSprite>();
            for (int i = 0; i <= ROW_ENEMY_AMOUNT; i++)
            {
                var enemy = atlas.CreateAnimatedSprite(type);
                enemy.Scale = new Vector2(SCALE, SCALE);
                enemy.Origin = new Vector2(i * X_OFFSET + X_OFFSET * 0.5f, index * Y_OFFSET + Y_OFFSET * 0.5f);
                _enemies.Add(enemy);
            }
        }
        public void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime > _lastUpdated.Add(new TimeSpan(0, 0, 0, 0, 100)))
            {
                _x += _movingRight ? X_INCREMENT : -X_INCREMENT;
                _lastUpdated = gametime.TotalGameTime;
                if (_x >= 100 || _x < 10)
                {
                    _movingRight = !_movingRight;
                    _y += 20;
                }

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
