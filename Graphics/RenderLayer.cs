using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStage.Graphics
{
    public class RenderLayer
    {
        public enum Mode
        {
            TwoDimensional, 
            ThreeDimensional
        }

        private IRenderLayer _renderLayer;

        public RenderLayer(Mode renderMode = Mode.TwoDimensional)
        {
            switch (renderMode)
            {
                case Mode.ThreeDimensional:
                    throw new NotImplementedException("3D drawing is currently not supported!");
                default:
                    _renderLayer = new RenderLayer2D();
                    break;
            }
        }

        public void Render(GameTime gameTime)
        {
            _renderLayer.Render(gameTime);
        }

        public Texture2D GetRenderTexture()
        {
            return _renderLayer.GetRenderTexture();
        }

        public void ForceRenderNextFrame()
        {
            throw new NotImplementedException();
            // todo
        }
    }
}
