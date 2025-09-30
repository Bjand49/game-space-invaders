using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using Space_Invaders.Core.Graphics;
using Space_Invaders.Entities;
using SpaceInvaders.Entities;
using System.Collections.Generic;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private List<Row> _rows;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite _player;
        private Vector2 _playerPosition;
        private const float MOVEMENT_SPEED = 7.5f;
        private const float MIN_POSITION = 20f;
        private const float MAX_POSITION = 800f;
        private const float SCENE_WIDTH = 800f;
        private KeyboardState _previousKeyboardState;

        private List<Bullet> _bullets = new List<Bullet>();
        private Sprite _bulletSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1100;
            _graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Restart();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //  Create a TextureAtlas instance from the atlas
            TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");
            _rows = new List<Row>(){
                new Row(atlas, "small",0),
                new Row(atlas, "medium",1),
                new Row(atlas, "medium",2),
                new Row(atlas, "big",3),
                new Row(atlas, "big",4),
            };
            _bulletSprite = atlas.CreateSprite("bullet");
            _bulletSprite.Scale = new Vector2(2f, 2f);
            _player = atlas.CreateAnimatedSprite("player-animation");
            _player.Scale = new Vector2(2f, 2f);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            CheckKeyboardInput();
            _rows.ForEach(x => x.Update(gameTime,_bullets));
            _player.Update(gameTime);
            _bullets.ForEach(x => x.Update(gameTime));
            _bullets.RemoveAll(x => x.Position.Y <= 0);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch to prepare for rendering.
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _player.Draw(_spriteBatch, _playerPosition);
            _rows.ForEach(x => x.Draw(_spriteBatch));
            _bullets.ForEach(x => x.Draw(_spriteBatch, _bulletSprite));
            // Always end the sprite batch when finished.
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CheckKeyboardInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float speed = MOVEMENT_SPEED;
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                speed *= 1.5f;
            }

            // If the A or Left keys are down, move the slime left on the screen.
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                _playerPosition.X -= speed;
            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                _playerPosition.X += speed;
            }


            // Creates a bullet at the position of the player ship
            if ((keyboardState.IsKeyDown(Keys.Up) && _previousKeyboardState.IsKeyUp(Keys.Up) ||
                (keyboardState.IsKeyDown(Keys.W) && _previousKeyboardState.IsKeyUp(Keys.W))))
            {
                var newBullet = new Bullet(_playerPosition.X + 12);
                _bullets.Add(newBullet);
            }

            // If the D or Right keys are down, move the slime right on the screen.
            if (_playerPosition.X < MIN_POSITION)
            {
                _playerPosition.X = MIN_POSITION;
            }
            if (_playerPosition.X > MAX_POSITION)
            {
                _playerPosition.X = MAX_POSITION;
            }
            _previousKeyboardState = keyboardState;
        }

        private void Restart()
        {
            _playerPosition = new Vector2(MIN_POSITION, 600f);
        }
    }
}
