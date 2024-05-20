using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
	public static TcpListener TcpServer;
	public static TcpClient TcpClient;
	public static int Port = 3000;

	public static void RunServer()
	{
		// Make a new server and run it
		// asynchronously 
		Thread serverThread = new Thread(Network);
	}

	public static void Network()
	{
		// Make a new TCP server
		TcpServer = new TcpListener(IPAddress.Any, Port);
		TcpServer.Start();

		// Make a new TCP client so that we can
		// interact with the server
		TcpClient = TcpServer.AcceptTcpClient();
		NetworkStream stream = TcpClient.GetStream();

		// Networking.Network();
		while (true)
		{
			// TODO: Change the buffer size if needed
			// Create a buffer to store the incoming bytes
			// from all the clients and whatnot
			byte[] buffer = new byte[1024];

			// Actually read the data
			int bytesRead = stream.Read(buffer, 0, buffer.Length);
			string content = Encoding.ASCII.GetString(buffer);

			// Process the data
			string responseOutput = ProcessRequest(content);

			// Send back the response to the client
			buffer = Encoding.ASCII.GetBytes(responseOutput);
			stream.Write(buffer, 0, buffer.Length);
		}
	}

	// TODO: Call this somewhere
	public static void StopNetworking()
	{
		// Get rid of everything
		TcpClient.Close();
		TcpServer.Stop();
	}


	private static string ProcessRequest(string content)
	{
		/*
			- Probably first check for the packet identifier
			  (number saying what the packet does)

			- Check for the UUID for the player
			  (let us know who we dealing with)

			- Check for the move identifier
			  (number saying what the player did)
			
			- Do the move on the server side

			- Send the response to all the other
			  currently connected clients in the game
		*/


		return "big stinkers";
	}

}