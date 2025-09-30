using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using Space_Invaders.Core.Graphics;
using Space_Invaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public static class EnemyFactory
    {
        public static Enemy GetEnemy(TextureAtlas atlas, string type, Vector2 position)
        {
            Enemy enemy;
            Animation animation;

            switch (type)
            {
                case "small":
                    animation = atlas.GetAnimation("small-enemy-animation");
                    enemy = new Enemy(position, 12, 8, type)
                    {
                        Animation = animation,
                    };
                    break;
                case "medium":
                    animation = atlas.GetAnimation("medium-enemy-animation");
                    enemy = new Enemy(position, 10, 9, type)
                    {
                        Animation = animation,
                    };
                    break;
                case "big":
                    animation = atlas.GetAnimation("big-enemy-animation");
                    enemy = new Enemy(position, 14, 8, type)
                    {
                        Animation = animation,
                    };
                    break;

                default:
                    throw new NotImplementedException();
            }
            enemy.Scale = new Vector2(3f, 3f);
            return enemy;

        }
    }
}
