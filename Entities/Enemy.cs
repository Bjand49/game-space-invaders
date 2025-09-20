using Space_Invaders.Core.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Entities
{
    public class Enemy : AnimatedSprite
    {
        private float x;
        private float y;

        public Enemy()
        {
        }

        public Enemy(Animation animation) : base(animation)
        {
        }
    }
}
