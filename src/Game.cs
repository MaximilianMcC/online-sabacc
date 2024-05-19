using System.Numerics;
using Raylib_cs;

class Game
{

	public static Scene Scene { get; set; }

	public static void Run()
	{
		// Setup raylib stuff
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
		Raylib.InitWindow(800, 600, "online sabacc play free online now games unblocked free games for kids video game gamer online free sabacc game video gamers online gambling games big win");
		Raylib.SetTargetFPS(144);

		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}
		Close();
	}

	public static void Start()
	{
		// Load everything
		Assets.LoadAssets();
		Settings.ReloadSettings();

		// Start with the main menu scene
		Scene = new MainMenuScene();
		Scene.Start();
	}

	private static void Update()
	{
		//! debug thing for toggle between English and Aurebesh
		// TODO: Remove
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			Settings.UseAurebesh = !Settings.UseAurebesh;
			Settings.ReloadSettings();
			UiHandler.ReloadTextSizes();
		}

		// Update the current scene
		Scene.Update();
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		// Draw the current scene
		Scene.Render();

		Raylib.EndDrawing();
	}

	public static void Close()
	{
		// Close the current scene
		Scene.CleanUp();

		// Unload everything
		Assets.UnloadAssets();

		// Kill raylib
		//! Make sure this is always done last
		Raylib.CloseWindow();
	}
}