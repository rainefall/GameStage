using Microsoft.Xna.Framework;
using GameStage.Graphics;
using GameStage.State;

namespace GameStage
{
	public class Application : Game
	{
		// static reference to application class, the base of the entire engine
		public static Application game;

		// window manager
		public GraphicsDeviceManager gdm;

		// scene stack controller
		public Director director;

		// render layer controller
		public Compositor compositor;

		private ECS.World wrld;

		// create singleton game instance
		static Application()
		{
			game = new Application();
		}

		private Application()
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
			// this is just to test that returned entities are unique
			ECS.Entity a = wrld.AddEntity();
			Console.WriteLine("ent A: " + a.Id.ToString());
			ECS.Entity b = wrld.AddEntity();
			Console.WriteLine("ent A: " + a.Id.ToString());
			Console.WriteLine("ent B: " + b.Id.ToString());

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


			// render console
#if DEBUG
			// render debug overlay
#endif
			base.Draw(gameTime);
		}
	}
}
