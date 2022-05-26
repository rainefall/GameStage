using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStage.Graphics
{
    internal interface IRenderLayer
    {
        void Render(GameTime gameTime);

        void AddToLayer(object drawable);

        Texture2D GetRenderTexture();
    }
}
