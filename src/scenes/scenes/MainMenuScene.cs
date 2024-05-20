using System.Numerics;

class MainMenuScene : Scene
{
	private Button hostGameButton;
	private Button joinGameButton;
	private Button quitButton;

	public MainMenuScene() : base("Main Menu") { }

	public override void Start()
	{
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
		SceneManager.SetScene(new HostGameScene());
	}

	private void JoinGame()
	{
		// Chuck the player on the join game scene
		SceneManager.SetScene(new JoinGameScene());
	}
}