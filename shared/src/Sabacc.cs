public class Sabacc
{
	public static List<Card> GenerateDeck()
	{
		// The full deck of cards
		//? Not using an array so I get linq
		List<Card> deck = new List<Card>();

		// Three different suits of positive
		deck.AddRange(GenerateCardSuite(true, Suite.Circle));
		deck.AddRange(GenerateCardSuite(true, Suite.Triangle));
		deck.AddRange(GenerateCardSuite(true, Suite.Square));

		// Three different suits of negative
		deck.AddRange(GenerateCardSuite(false, Suite.Circle));
		deck.AddRange(GenerateCardSuite(false, Suite.Triangle));
		deck.AddRange(GenerateCardSuite(false, Suite.Square));

		// Two sylops's (0)
		deck.Add(new Card() { Value = 0, Suite = Suite.Sylop });
		deck.Add(new Card() { Value = 0, Suite = Suite.Sylop });

		// Shuffle the deck, then return it
		Shuffle(ref deck);
		return deck;
	}

	private static Card[] GenerateCardSuite(bool positive, Suite suite)
	{
		// Every suite has 10 cards
		Card[] cards = new Card[10];

		// Cards 1 - 10
		for (int i = 0; i < cards.Length; i++)
		{
			cards[i] = new Card()
			{
				// Depending of if it's positive or negative
				// set the multiplier thingy
				//? + 1 because i = 0
				Value = (i + 1) * (positive ? 1 : -1),
				Suite = suite
			};
		}

		// Give back the cards
		return cards;
	}

	private static void Shuffle(ref List<Card> cards)
	{
		// Shuffle the cards using a random number
		Random random = new Random();
		cards = cards.OrderBy(card => random.NextDouble()).ToList();
	}
}