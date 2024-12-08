using Raylib_cs;

class Program
{
	public static bool GameStarted = false;

	public static void Main(string[] args)
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.InitWindow(800, 600, "Sabacc client");

		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();

			Raylib.BeginDrawing();
			Draw();
			Raylib.EndDrawing();
		}
		CleanUp();
	}

	private static void Start()
	{
		// Get the cards
		CardManager.LoadCards();

		// Do all the networking stuff
		Networker.Network("127.0.0.1", 54321);
	}

	private static void Update()
	{
		// Listen for server information
		Networker.Listen();

		// If we press space then start the game
		if (Raylib.IsKeyPressed(KeyboardKey.Space)) Networker.RequestToStartGame();
	}

	private static void Draw()
	{
		Raylib.ClearBackground(Color.DarkGreen);

		// Game info
		Raylib.DrawText("Game started: " + GameStarted, 10, 10, 30, Color.White);

		// Draw all the cards
		CardManager.Draw();
	}

	private static void CleanUp()
	{
		Raylib.CloseWindow();
	}
}
