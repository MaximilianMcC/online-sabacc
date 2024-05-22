using System.Numerics;
using Raylib_cs;

class DebugScene : Scene
{

	public DebugScene() : base("Testing rn (doing the debugulations)") { }

	private static Button increaseButton;
	private static Button decreaseButton;
	private static Button resetButton;
	private static Button flipButton;
	private static int counter = 0;

	public override void Start()
	{
		increaseButton = new Button("increase", new Vector2(50, 200), new Vector2(300, 100), (() => counter++), false);
		decreaseButton = new Button("decrease", new Vector2(200, 350), new Vector2(300, 100), (() => counter--), false);
		resetButton = new Button("reset", new Vector2(400, 240), new Vector2(200, 100), (() => counter = 0), false);
		flipButton = new Button("flip", new Vector2(410, 100), new Vector2(100, 100), (() => counter = counter < 0 ? Math.Abs(counter) : -counter ), false);
	}

	public override void Update()
	{
		increaseButton.Update();
		decreaseButton.Update();
		resetButton.Update();
		flipButton.Update();
	}

	public override void Render()
	{
		Raylib.DrawTextEx(Settings.Font, "debugulations", new Vector2(100, 100), 16f, (16f / 10f), Color.White);
		Raylib.DrawTextEx(Settings.Font, $"count: {counter}", new Vector2(100, 120), 16f, (16f / 10f), Color.White);

		increaseButton.Render();
		decreaseButton.Render();
		resetButton.Render();
		flipButton.Render();
	}

	public override void CleanUp()
	{

	}
}