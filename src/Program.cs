class Program
{
	public static void Main(string[] args)
	{
		// Check for if we want to use
		// aurebesh for the font
		Settings.UseAurebesh = ((args.Length >= 1) && (args[0].ToLower() == "true"));


		// Run the game
		Game.Run();
	}
}