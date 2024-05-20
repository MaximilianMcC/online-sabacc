using System.Numerics;
using Raylib_cs;

class JoinGameScene : Scene
{

	public JoinGameScene() : base("Joining a game") { }

	public override void Start()
	{

	}

	public override void Update()
	{

	}

	public override void Render()
	{
		Raylib.DrawTextEx(Settings.Font, "joining a game rn", Vector2.Zero, 50f, (50f / 10f), Color.White);
	}

	public override void CleanUp()
	{

	}
}