using System.Numerics;
using Raylib_cs;

class HostGameScene : Scene
{

	public override void Start()
	{
		// Set the scenes name
		// TODO: Do this automatically somehow as a property or something
		Name = "Game setup";

		// Unload the previous scene
		Game.Scene.CleanUp();
	}

	public override void Update()
	{

	}

	public override void Render()
	{
		Raylib.DrawTextEx(Settings.Font, "Hosting a game rn (yo'uare the host)", Vector2.Zero, 50f, (50f / 10f), Color.White);
	}

	public override void CleanUp()
	{

	}
}