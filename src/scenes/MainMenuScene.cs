using System.Numerics;

class MainMenuScene : Scene
{
	private Button hostGameButton;
	private Button joinGameButton;
	private Button quitButton;

	public override void Start()
	{
		// Set the scenes name
		// TODO: Do this automatically somehow as a property or something
		Name = "Main Menu";

		// Unload the previous scene if one existed.
		// Only case for this should be main menu (here)
		if (Game.Scene != null) Game.Scene.CleanUp();





		// Button initialization
		// TODO: Make them to look half decent
		hostGameButton = new Button("Host game", new Vector2(150, 30), new Vector2(200, 110), HostGame, true);
		joinGameButton = new Button("Join game", new Vector2(150, 160), new Vector2(200, 110), JoinGame, true);

		//! scuffed
		quitButton = new Button("Quit game", new Vector2(150, 400), new Vector2(200, 110), Game.Close, true);
	}

	public override void Update()
	{
		// Update all the ui stuff
		hostGameButton.Update();
		joinGameButton.Update();
		quitButton.Update();
	}

	public override void Render()
	{
		// Render all the ui stuff
		hostGameButton.Render();
		joinGameButton.Render();
		quitButton.Render();
	}

	public override void CleanUp()
	{

	}



	private void HostGame()
	{
		// Chuck the player on the host game scene
		Game.Scene = new HostGameScene();
	}

	private void JoinGame()
	{
		// Chuck the player on the join game scene
		Game.Scene = new JoinGameScene();
	}
}