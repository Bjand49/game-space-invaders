using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Core.Graphics;
using SpaceInvaders.Entities;
using System.Collections.Generic;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private List<Row> _rows;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        // Defines the slime sprite.

        // Defines the bat sprite.
        private Sprite _bat;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.PreferredBackBufferWidth = 1200;
            //_graphics.PreferredBackBufferHeight = 840;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //  Create a TextureAtlas instance from the atlas
            TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

            _rows = new List<Row>(){
                new Row(atlas, "small-enemy-animation",0),
                new Row(atlas, "medium-enemy-animation",-20),
                new Row(atlas, "medium-enemy-animation",-40),
                new Row(atlas, "big-enemy-animation",-60),
                new Row(atlas, "big-enemy-animation",-80)
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //_enemy1.Update(gameTime);
            //_enemy2.Update(gameTime);
            //_enemy3.Update(gameTime);
            _rows.ForEach(x=> x.Update(gameTime));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch to prepare for rendering.
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
            //_enemy1.Draw(_spriteBatch, Vector2.One);
            //_enemy2.Draw(_spriteBatch, new Vector2(18 * 4, 0));
            //_enemy3.Draw(_spriteBatch, new Vector2(36 * 4, 0));
            _rows.ForEach(x => x.Draw(_spriteBatch));

            // Always end the sprite batch when finished.
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
