public class Player
{
	public string Uuid;
	public List<Card> Hand;

	public int GetHandValue()
	{
		return Hand.Sum(card => card.Value);
	}
}