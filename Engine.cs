using Microsoft.Xna.Framework;
using GameStage.Graphics;
using GameStage.State;

namespace GameStage
{
	public class Engine : Game
	{
		// static reference to application class, the base of the entire engine
		public static Engine game;

		// window manager
		public GraphicsDeviceManager gdm;

		// scene stack controller
		public Director director;

		// render layer controller
		public Compositor compositor;

		private ECS.World wrld;

		// create singleton game instance
		static Engine()
		{
			Environment.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "1");
			game = new Engine();
		}

		public static void Init(Scene initScene, Action? preInit = null, Action? postInit = null)
        {
			if (preInit != null)
				preInit();
			game.RunOneFrame();
			if (postInit != null)
				postInit();
			game.director.NewScene(initScene);
		}

		private Engine()
		{
			// setup graphics device
			gdm = new GraphicsDeviceManager(this);
			// todo, load config
			gdm.PreferredBackBufferWidth = 1280;
			gdm.PreferredBackBufferHeight = 720;
			gdm.IsFullScreen = false;
			gdm.SynchronizeWithVerticalRetrace = true;

			director = new Director();
			compositor = new Compositor(gdm);
			wrld = new ECS.World();
		}
		protected override void Initialize()
		{
			// todo, init engine

			base.Initialize();
		}

		protected override void UnloadContent()
		{
			// todo, unload everything
			base.UnloadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			director.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			// render the compositor
			compositor.Render(gameTime);

			// render console
#if DEBUG
			// render debug overlay
#endif
			base.Draw(gameTime);
		}
	}
}
