using GameStage.Graphics.Drawing2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStage.Graphics
{
    internal class RenderLayer2D : IRenderLayer
    {
        private SpriteBatch _spriteBatch;

        private List<IDrawable2D> _drawable2Ds;

        private RenderTarget2D _renderTarget;

        public RenderLayer2D()
        {
            _spriteBatch = new SpriteBatch(Engine.game.GraphicsDevice);
            _drawable2Ds = new List<IDrawable2D>();
            _renderTarget = new RenderTarget2D(Engine.game.GraphicsDevice, Engine.game.GraphicsDevice.Viewport.Width, Engine.game.GraphicsDevice.Viewport.Height);
        }

        ~RenderLayer2D()
        {
            _spriteBatch.Dispose();
            _drawable2Ds.Clear();
        }

        public void AddToLayer(object drawable)
        {
            // this method's implementation is a little dangerous i think ^ 
            // might have to rethink the way drawables are handled between 2D and 3D renderers

            // check that drawable is actually a 2D drawable
            if (!drawable.GetType().IsSubclassOf(typeof(IDrawable2D)))
            {
                throw new ArgumentException("Attempted to add a none 2D Drawable object to this render layer");
            }
            // add it to the list
            _drawable2Ds.Add((IDrawable2D)drawable);
        }

        public void Render(GameTime gameTime)
        {
            Engine.game.GraphicsDevice.SetRenderTarget(_renderTarget);
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (IDrawable2D drawable in _drawable2Ds)
            {
                drawable.Draw(_spriteBatch);
            }
            _spriteBatch.End();
        }

        public Texture2D GetRenderTexture()
        {
            return _renderTarget;
        }
    }
}
