using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders
{
    public class FontHandler
    {
        private SpriteFont _font;
        public FontHandler()
        {

        }
        public void LoadFonts(ContentManager content)
        {
            _font = content.Load<SpriteFont>("fonts/04B_30");
        }
        public void Write(Vector2 position, Color color, string message, SpriteBatch batch)
        {
            var textSize = _font.MeasureString(message);
            var origin = textSize * 0.5f;

            // Draw centered text
            batch.DrawString(
                _font,
                message,
                position,
                color
            );
        }
    }
}