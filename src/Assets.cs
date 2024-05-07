using Raylib_cs;

class Assets
{
	public static Font FontEnglish;
	public static Font FontAurebesh;
	public static Texture2D CardGeneratorSpriteSheet;

	public static void LoadAssets()
	{
		// Load both the english, and aurebesh fonts
		FontEnglish = Raylib.LoadFont("./assets/fonts/english.ttf");
		FontAurebesh = Raylib.LoadFont("./assets/fonts/aurebesh.ttf");

		// Load textures
		CardGeneratorSpriteSheet = Raylib.LoadTexture("./assets/textures/cards_spritesheet.png");
	}

	public static void UnloadAssets()
	{
		// Unload both the english, and aurebesh fonts
		Raylib.UnloadFont(FontEnglish);
		Raylib.UnloadFont(FontAurebesh);
	}
}