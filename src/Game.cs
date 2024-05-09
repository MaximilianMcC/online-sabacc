using System.Numerics;
using Raylib_cs;

class Game
{
	//! debug
	private static Button button;

	public static void Run()
	{
		// Setup raylib stuff
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
		Raylib.InitWindow(400, 300, "online sabacc play free online now games unblocked free games for kids video game gamer online free sabacc game video gamers online gambling games big win");
		Raylib.SetTargetFPS(60);

		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}
		CleanUp();
	}

	public static void Start()
	{
		// Load everything
		Assets.LoadAssets();
		Settings.ReloadSettings();

		//! debug
		button = new Button("Lorem Ipsum", new Vector2(10, 10), new Vector2(500, 230), Test, true);
	}

	private static void Update()
	{
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			Settings.UseAurebesh = !Settings.UseAurebesh;
			Settings.ReloadSettings();
			UiHandler.ReloadTextSizes();
		}

		button.Update();
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		button.Render();

		Raylib.EndDrawing();
	}

	private static void CleanUp()
	{
		Assets.UnloadAssets();

		//! Make sure this is always closed last
		Raylib.CloseWindow();
	}


	private static void Test()
	{
		Console.WriteLine("testing rn");
	}
}