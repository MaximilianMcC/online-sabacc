using System.Numerics;
using Raylib_cs;

class HostGameScene : Scene
{

	public HostGameScene() : base("Hosting a game") { }


	public override void Start()
	{

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