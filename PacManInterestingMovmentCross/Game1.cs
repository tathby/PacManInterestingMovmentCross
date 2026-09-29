using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleMovementWGravity;


namespace PacManInterestingMovmentCross
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PacMan pacMan;
        SpriteFont font;
        float acceleration = 500f;
        float maxSpeed = 300f;
        float deceleration = 700f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacMan = new PacMan(Content.Load<Texture2D>("pacManSingle"),
                new Vector2(GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2),
                new Vector2(1, 0), 10);

            font = Content.Load<SpriteFont>("Arial");
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //UpdateGravity
            pacMan.UpdatePacmanKeepOnScreen(
              GraphicsDevice.Viewport.Width,
              GraphicsDevice.Viewport.Height);
            UpdatePacmanSpeed(gameTime);
            UpdateKeyboardInput();


            pacMan.Update(gameTime);






            base.Update(gameTime);
        }

        /*private void UpdateGravity()
        {
            foreach (PacMan pac in pacManList)
            {
                pac.PacManDir += GravityDir * GravityAccel;
            }
        }*/



        private void UpdatePacmanSpeed(GameTime gameTime)
        {
            //Speed for next frame
            if (pacMan.PacManSpeed < 3000)
            {
                if (Keyboard.GetState().GetPressedKeys().Length > 0) //If there is any key press, the length of the Array of keys returned by GetPressedKeys wil be greater that 0
                {
                    pacMan.PacManSpeed += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;  //Key down pacman has speed
                }
                else
                {
                    pacMan.PacManSpeed -= deceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;    //No key down stop
                }
                if (pacMan.PacManSpeed < 0)
                    pacMan.PacManSpeed = 0;
            }
        }

        private void UpdateKeyboardInput()
        {
            Vector2 input = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                input.Y -= 1;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                input.Y += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                input.X -= 1;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                input.X += 1;

            if (input != Vector2.Zero)
            {
                input.Normalize();
                pacMan.PacManDir = input;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            pacMan.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
