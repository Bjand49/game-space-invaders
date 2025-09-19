using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Core.Graphics;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private AnimatedSprite _enemy1;
        private AnimatedSprite _enemy2;
        private AnimatedSprite _enemy3;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        // Defines the slime sprite.

        // Defines the bat sprite.
        private Sprite _bat;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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

            // retrieve the slime region from the atlas.
            // Create the slime animated sprite from the atlas.
            _enemy1 = atlas.CreateAnimatedSprite("enemy1-animation");
            _enemy1.Scale = new Vector2(4.0f, 4.0f);
            _enemy2 = atlas.CreateAnimatedSprite("enemy2-animation");
            _enemy2.Scale = new Vector2(4.0f, 4.0f);
            _enemy3 = atlas.CreateAnimatedSprite("enemy3-animation");
            _enemy3.Scale = new Vector2(4.0f, 4.0f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _enemy1.Update(gameTime);
            _enemy2.Update(gameTime);
            _enemy3.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch to prepare for rendering.
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
            _enemy1.Draw(_spriteBatch, Vector2.One);
            _enemy2.Draw(_spriteBatch, new Vector2(18*4, 0));
            _enemy3.Draw(_spriteBatch, new Vector2(36*4, 0));

            // Always end the sprite batch when finished.
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
