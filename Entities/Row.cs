using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
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
        private string _id;
        private float _x = 10;
        private float _y;
        private TimeSpan _lastUpdated = new TimeSpan();
        private bool _movingRight = true;
        private static readonly float SCALE = 3.0f;
        private static readonly float X_INCREMENT = 10.0f;
        private static readonly int ROW_ENEMY_AMOUNT = 12;
        private static readonly int X_OFFSET = 55;
        private static readonly int Y_OFFSET = 50;
        private List<Enemy> _enemies = new List<Enemy>();
        public Row(TextureAtlas atlas, string type, int index)
        {
            _id = index.ToString();

            _y = index * Y_OFFSET;
            for (int i = 0; i <= ROW_ENEMY_AMOUNT; i++)
            {
                var position = new Vector2(i * X_OFFSET + X_OFFSET * 1.5f, _y + Y_OFFSET * 1.5f);
                _enemies.Add(EnemyFactory.GetEnemy(atlas, type, position));
            }
        }
        public void Update(GameTime gametime, List<Bullet> bullets)
        {
            var xIncrement = 0f;
            var yIncrement = 0f;

            if (gametime.TotalGameTime > _lastUpdated.Add(new TimeSpan(0, 0, 0, 0, 200)))
            {
                xIncrement = _movingRight ? X_INCREMENT : -X_INCREMENT;
                _lastUpdated = gametime.TotalGameTime;
                if (_x + xIncrement >= 100 || _x + xIncrement < 10)
                {
                    _movingRight = !_movingRight;
                    yIncrement += 20;
                    xIncrement = 0f;
                }
                _x += xIncrement;
                _y += yIncrement;
            }
            var relevantBullets = bullets.Where(x => x.Position.Y <= _y + 20 * SCALE && x.Position.Y >= _y);
            if (relevantBullets.Any())
            {

            }

            _enemies.ForEach(x =>
            {
                x.Update(gametime, xIncrement, yIncrement);

            });
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (var enemy in _enemies)
            {
                var location = new Vector2(enemy.Origin.X + _x, enemy.Origin.Y + _y);
                enemy.Draw(batch);
            }
        }
    }
}
