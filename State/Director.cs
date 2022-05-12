using Microsoft.Xna.Framework;

namespace GameStage.State
{
    public class Director
    {
        public Stack<Scene> SceneStack { get; }

        public Director()
        {
            SceneStack = new Stack<Scene>();
        }

        public void NewScene(Scene s)
        {
            // if there is a scene at the top of the stack, call its OnExit function
            if (SceneStack.Any())
                SceneStack.Peek().OnExit();

            // create new scene and call its initialize and OnExit functions
            SceneStack.Push(s);
            var scnref = SceneStack.Peek();
            scnref.Initialize();
            scnref.OnEnter();
        }

        public void ExitScene()
        {
            // remove scene from stack and call its OnDestroy function
            // if applicable
            SceneStack.Pop().OnDestroy();

            if (SceneStack.Any())
            {
                // call the previous scene's OnEnter function
                SceneStack.Peek().OnEnter();    
            }
        }

        public void Update(GameTime gameTime)
        {
            // update our currently active scene if there is one
            if (SceneStack.Any())
                SceneStack.Peek().Update(gameTime);
        }
    }
}
