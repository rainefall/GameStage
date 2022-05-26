using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStage.Graphics
{
    public class Compositor
    {
        public bool clearColour = true;

        public List<RenderLayer> renderLayers;

        private SpriteBatch _spriteBatch;

        public Compositor(GraphicsDeviceManager gdm)
        {
            renderLayers = new List<RenderLayer>();
            _spriteBatch = new SpriteBatch(Engine.game.GraphicsDevice);
        }

        public void Render(GameTime gameTime)
        {
            // have to keep cornflower blue
            // it would be sacrilege to remove it
            if (clearColour)
                Engine.game.GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (RenderLayer layer in renderLayers)
            {
                layer.Render(gameTime);
            }

            _spriteBatch.Begin();
            foreach (RenderLayer layer in renderLayers)
            {
                _spriteBatch.Draw(layer.GetRenderTexture(), new Vector2(0, 0), Color.White);
            }
            _spriteBatch.End();
        }
    }
}
