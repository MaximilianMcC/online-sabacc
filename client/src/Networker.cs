using System.Net.Sockets;
using System.Text;

class Networker
{
	private static NetworkStream stream;

	public static void Network(string ip, int port)
	{
		// Connect to the server
		TcpClient server = new TcpClient(ip, port);
		stream = server.GetStream();

		// Ask to join the game
		RequestToJoinGame();
	}

	private static void RequestToJoinGame()
	{
		// Ask the server for a UUID and to
		// get registered to the game
		Networking.SendPacket("join", stream);

		// Get the response
		string uuid = Networking.ReceivePacket(stream);
		Console.WriteLine("Got UUID " + uuid);
	}

	public static void RequestToStartGame()
	{
		// Ask to start (politely)
		Networking.SendPacket("start", stream);

		// Get the hand and say that we started the game
		string hand = Networking.ReceivePacket(stream);
		foreach (string cardPacket in hand.Split(" "))
		{
			CardManager.Hand.Add(new Card(cardPacket));
		}

		// Say that we started the game
		Program.GameStarted = true;
	}
}