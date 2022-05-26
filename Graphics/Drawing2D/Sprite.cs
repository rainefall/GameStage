using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStage.Graphics.Drawing2D
{
    public class Sprite : IDrawable2D
    {
        public Texture2D texture { get; set; }
        public Rectangle dstRect;
        public Rectangle srcRect;
        public Color colour;
        public float rotation;
        public Vector2 origin;
        public SpriteEffects flip;
        public float depth;

        public Sprite(Texture2D tex)
        {
            texture = tex;
        }

        public Sprite(string path)
        {
            throw new NotImplementedException();
            // load string from path
        }

        public Sprite(int width, int height)
        {
            texture = new Texture2D(Engine.game.GraphicsDevice, width, height);
        }

        // deconstructor
        ~Sprite()
        {
            texture.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, dstRect, srcRect, colour, rotation, origin, flip, depth);
        }
    }
}
