class Program
{
	public static void Main(string[] args)
	{
		// Check for if we want to use
		// aurebesh for the font
		Settings.UseAurebesh = ((args.Length >= 1) && (args[0].ToLower() == "true"));

		// Get the port and ip from the console args
		if (args.Length >= 3)
		{
			// Get the args
			string ip = args[1];
			int port = int.Parse(args[2]);

			// Assign them
			
			
		} else Console.WriteLine("argument out of wack (fix it)");

		// Run the game
		Game.Run();
	}
}