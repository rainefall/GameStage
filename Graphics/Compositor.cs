using Microsoft.Xna.Framework;

namespace GameStage.Graphics
{
    public class Compositor
    {
        public bool clearColour = true;

        public List<RenderLayer> renderLayers;

        public Compositor(GraphicsDeviceManager gdm)
        {
            renderLayers = new List<RenderLayer>();
        }

        public void Render(GameTime gameTime)
        {
            // have to keep cornflower blue
            // it would be sacrilege to remove it
            if (clearColour)
                Application.game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
