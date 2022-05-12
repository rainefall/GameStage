using Microsoft.Xna.Framework;

namespace GameStage.State
{
    // A scene describes how to process input from the server, and what to send to it.
    public abstract class Scene
    {
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);

        public virtual void OnCreate() { }
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnDestroy() { }
        
    }
}
