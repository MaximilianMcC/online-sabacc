using System.Net.Sockets;
using System.Text;

class Networker
{
	public static void Network(string ip, int port)
	{
		// Connect to the server
		using TcpClient client = new TcpClient(ip, port);
		using NetworkStream stream = client.GetStream();

		// Send a message
		string message = "well the weather outside is rizzy";
		byte[] messageBytes = Encoding.UTF8.GetBytes(message);
		stream.Write(messageBytes, 0, messageBytes.Length);

		Console.WriteLine("Sent packet to server");

		// Get the incoming packet
		// TODO: Put in shared
		byte[] buffer = new byte[1024];
		int bytesRead = stream.Read(buffer, 0, buffer.Length);
		string data = Encoding.UTF8.GetString(buffer);
	}
}