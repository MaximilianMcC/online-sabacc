using System.Net.Sockets;

public class Player
{
	public NetworkStream Stream;
	public string Uuid;
	public List<Card> Hand;

	public int GetHandValue()
	{
		return Hand.Sum(card => card.Value);
	}

	public override string ToString()
	{
		return Uuid;
	}
}