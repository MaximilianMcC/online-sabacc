class Game
{
	public List<Card> Deck;

	public void Start()
	{
		// Make a new deck
		Deck = Sabacc.GenerateDeck();

		// Print out all the cards
		foreach (Card card in Deck)
		{
			Console.WriteLine(card);
		}
	}
}