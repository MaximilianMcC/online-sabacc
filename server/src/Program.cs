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

		Console.WriteLine("Server on");
		while (true)
		{
			// Get the connecting client
			using TcpClient client = listener.AcceptTcpClient();
			using NetworkStream stream = client.GetStream();
			Console.WriteLine("Found a client");

			// Get the incoming packet
			// TODO: Put in shared
			byte[] buffer = new byte[1024];
			int bytesRead = stream.Read(buffer, 0, buffer.Length);
			string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

			// Check for what they wanna do
			// TODO: Don't do this way
			// TODO: Put somewhere else
			if (data == "start")
			{
				Game game = new Game();
				game.Start();
			}

			// Flick them a response
			string response = "erhm";
			byte[] responseBytes = Encoding.UTF8.GetBytes(response);
			stream.Write(responseBytes, 0, responseBytes.Length);
		}
	}
}