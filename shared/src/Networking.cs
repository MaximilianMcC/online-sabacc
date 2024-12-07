using System.Net.Sockets;
using System.Text;

public class Networking
{
	public static void SendPacket(string data, NetworkStream stream)
	{
		// Convert, then send the packet
		byte[] messageBytes = Encoding.UTF8.GetBytes(data);
		stream.Write(messageBytes, 0, messageBytes.Length);

		Console.WriteLine($"Sent packet '{data}'");
	}

	public static string ReceivePacket(NetworkStream stream)
	{
		// Get the packet, then convert it
		byte[] buffer = new byte[1024];
		int bytesRead = stream.Read(buffer, 0, buffer.Length);
		string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

		Console.WriteLine($"Received packet '{data}'");
		return data;
	}
}