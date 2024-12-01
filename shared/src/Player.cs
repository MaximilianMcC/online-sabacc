public class Player
{
	public List<Card> Hand;

	public int GetHandValue()
	{
		return Hand.Sum(card => card.Value);
	}
}