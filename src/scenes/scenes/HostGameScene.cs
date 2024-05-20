using System.Numerics;
using Raylib_cs;

class HostGameScene : Scene
{

	public HostGameScene() : base("Hosting a game") { }


	public override void Start()
	{
		// Make a new server
		Server.RunServer();

		// Make a new client to 
		// join the server with
		
	}

	public override void Update()
	{

	}

	public override void Render()
	{
		Raylib.DrawTextEx(Settings.Font, "Hosting a game rn\n(yo'uare the host)", Vector2.Zero, 24f, (24f / 10f), Color.White);
	}

	public override void CleanUp()
	{

	}
}