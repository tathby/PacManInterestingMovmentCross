using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleMovementWGravity
{
    public class PacMan
    {
        public Vector2 PacManLoc;
        public Vector2 PacManDir;
        public float PacManSpeed;

        Texture2D PacManTexture;

        public PacMan(
            Texture2D texture,
            Vector2 location,
            Vector2 direction,
            float speed)
        {
            PacManTexture = texture;
            PacManLoc = location;
            PacManDir = direction;
            PacManSpeed = speed;
        }

        public void Update(GameTime gameTime)
        {
            PacManLoc += PacManDir *
                          PacManSpeed *
                          (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                PacManTexture,
                PacManLoc,
                Color.White
            );
        }

        public void UpdatePacmanKeepOnScreen(int screenWidth, int screenHeight)
        {
            if (PacManLoc.X >
                screenWidth - PacManTexture.Width)
            {
                PacManDir *= new Vector2(-1, 1);

                PacManLoc.X =
                    screenWidth - PacManTexture.Width;
            }

            if (PacManLoc.X < 0)
            {
                PacManDir *= new Vector2(-1, 1);

                PacManLoc.X = 0;
            }

            if (PacManLoc.Y >
                screenHeight - PacManTexture.Height)
            {
                PacManDir *= new Vector2(1, -1);

                PacManLoc.Y =
                    screenHeight - PacManTexture.Height;
            }

            if (PacManLoc.Y < 0)
            {
                PacManDir *= new Vector2(1, -1);

                PacManLoc.Y = 0;
            }
        }
    }
}