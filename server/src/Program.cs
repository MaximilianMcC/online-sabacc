using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
	private static Game game;

	public static void Main(string[] args)
	{
		// Make, then start the server
		TcpListener listener = new TcpListener(IPAddress.Any, 54321);
		listener.Start();

		
		// TODO: Don't do this
		game = new Game();


		Console.WriteLine("Server on");
		// TODO: Make HandleClient method or something
		while (true)
		{
			// Get the connecting client
			TcpClient client = listener.AcceptTcpClient();

			// Make a new thread just for them (lucky) and
			// handle them for the rest of the game and stuff
			Task.Run(() => HandleClient(client));
		}
	}

	private static void HandleClient(TcpClient client)
	{
		// Get the stream to talk to the client with
		NetworkStream stream = client.GetStream();
		Console.WriteLine("Snagged a client");

		try
		{
			// Keep listening for stuff from the stream
			while (true)
			{
				// Get the incoming packet
				string packet = Networking.ReceivePacket(stream);

				// Check for what they wanna do
				// TODO: Don't do this way
				// TODO: Put somewhere else
				if (packet == "JOIN")
				{
					Console.WriteLine("Player joining");
					string responsePacket = game.AddPlayer(stream);
					Networking.SendPacket(responsePacket, stream);
				}
				else if (packet == "START")
				{
					Console.WriteLine("Game starting");
					game.Start();
				}	
			}
		}
		catch (IOException)
		{
			// Bro left (their loss fr)
			Console.WriteLine("Client disconnected 💔");
		}
		finally
		{
			// Dispose the client
			client.Close();
		}
	}
}