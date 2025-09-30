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
            int width;
            int height;
            switch (type)
            {
                case "small":
                    width = 12;
                    height = 8;
                    animation = atlas.GetAnimation("small-enemy-animation");
                    break;

                case "medium":
                    width = 10;
                    height = 9;
                    animation = atlas.GetAnimation("medium-enemy-animation");
                    break;

                case "big":
                    width = 14;
                    height = 8;
                    animation = atlas.GetAnimation("big-enemy-animation");
                    break;

                default:
                    throw new NotImplementedException();
            }
            position.X = position.X + width * 0.5f;
            enemy = new Enemy(position, width, height, type)
            {
                Animation = animation,
            };

            enemy.Scale = new Vector2(3f, 3f);
            return enemy;

        }
    }
}
