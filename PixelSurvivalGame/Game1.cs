using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pixel_Survival_Game
{
    public class Game1 : Game
    {

        Texture2D playerTexture;
        Vector2 playerPosition;
        float playerSpeed;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
           
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            playerSpeed = 250f;

            _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.DisplayMode.Height;

            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("Player");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();

            int x = mouseState.X, y = mouseState.Y;
            //if (playerPosition.Contains(x, y))
            //{
            //    Console.WriteLine("Inside");
            //}

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
                playerPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.S))
                playerPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.A))
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.D))
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (playerPosition.X > _graphics.PreferredBackBufferWidth - playerTexture.Width / 2)
                playerPosition.X = _graphics.PreferredBackBufferWidth - playerTexture.Width / 2;
            else if (playerPosition.X < playerTexture.Width / 2)
                playerPosition.X = playerTexture.Width / 2;

            if (playerPosition.Y > _graphics.PreferredBackBufferHeight - playerTexture.Height / 2)
                playerPosition.Y = _graphics.PreferredBackBufferHeight - playerTexture.Height / 2;
            else if (playerPosition.Y < playerTexture.Height / 2)
                playerPosition.Y = playerTexture.Height / 2;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            _spriteBatch.Draw(
                playerTexture,
                playerPosition,
                null,
                Color.White,
                0f,
                new Vector2((playerTexture.Width / 2), (playerTexture.Height / 2)),
                1.5f,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
