using System.Numerics;
using Raylib_cs;

class Game
{
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
	}

	private static void Update()
	{
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			Settings.UseAurebesh = !Settings.UseAurebesh;
			Settings.ReloadSettings();
		}
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		Raylib.DrawTextEx(Settings.Font, "Sabacc (gambling rn)", new Vector2(20, 164), 45f, (45f / 10f), Color.White);

		Raylib.EndDrawing();
	}

	private static void CleanUp()
	{
		Assets.UnloadAssets();

		//! Make sure this is always closed last
		Raylib.CloseWindow();
	}
}