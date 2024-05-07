using Raylib_cs;

class Settings
{
	public static bool UseAurebesh;
	public static Font Font;



	public static void ReloadSettings()
	{
		// Load the font
		if (UseAurebesh) Font = Assets.FontAurebesh;
		else Font = Assets.FontEnglish;
	}
}