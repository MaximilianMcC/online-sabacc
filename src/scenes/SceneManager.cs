class SceneManager
{
	public static Scene CurrentScene { get; private set; }

	public static void SetScene(Scene newScene)
	{
		// Unload the current scene
		//? Null propagation is used here because scene could be null (fancy null check)
		CurrentScene?.CleanUp();

		// Assign the current scene
		// then run its start method
		CurrentScene = newScene;
		CurrentScene.Start();
	}
}