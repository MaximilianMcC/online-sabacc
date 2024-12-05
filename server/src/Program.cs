using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		// Make, then start the server
		TcpListener listener = new TcpListener(IPAddress.Any, 54321);
		listener.Start();

		
		// TODO: Don't do this
		Game game = new Game();


		Console.WriteLine("Server on");
		while (true)
		{
			// Get the connecting client
			using TcpClient client = listener.AcceptTcpClient();
			using NetworkStream stream = client.GetStream();

			// Get the incoming packet
			string packet = Networking.ReceivePacket(stream);

			// Check for what they wanna do
			// TODO: Don't do this way
			// TODO: Put somewhere else
			if (packet == "join")
			{
				string responsePacket = game.AddPlayer();
				Networking.SendPacket(responsePacket, stream);
			}
			else if (packet == "start") game.Start();
		}
	}
}