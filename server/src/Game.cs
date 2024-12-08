using System.Net.Sockets;

class Game
{
	// Game stats
	private int round;
	private List<Card> deck;
	private List<Card> discardPile;

	// Player stuff
	private List<Player> players;

	public Game()
	{
		players = new List<Player>();
	}

	public string AddPlayer(NetworkStream stream)
	{
		// Get a random UUID for the player, and make
		// an empty hand for them
		string uuid = Guid.NewGuid().ToString();
		List<Card> hand = new List<Card>();

		// Make the player
		players.Add(new Player() {
			Uuid = uuid,
			Hand = hand,

			Stream = stream
		});

		Console.WriteLine("Registered new player with UUID " + uuid);

		// Return the players UUID
		// so they know who they are
		return uuid;
	}

	public void Start()
	{
		// Make a new deck then shuffle it
		deck = Sabacc.GenerateDeck();
		Shuffle(ref deck);

		// Take the first card and
		// make it the discard pile
		discardPile = new List<Card>() { TakeCard(deck) };
		round = 1;

		// Give all of the players their
		// two starting cards
		foreach (Player player in players)
		{
			player.Hand.Add(TakeCard(deck));
			player.Hand.Add(TakeCard(deck));
		}

		// Tell all players that the game is starting
		// and also tell them what their cards are
		// TODO: Don't use another loop
		foreach (Player player in players)
		{
			// Serialize the hand
			string hand = string.Join(" ", player.Hand);
			string packet = "GAME-START " + hand;

			// Send it to the current player
			Networking.SendPacket(packet, player.Stream);
		}
	}






	// return the card at the top of the deck, and remove it
	// from the deck so its like its being taken out
	private Card TakeCard(List<Card> cards)
	{
		Card topCard = cards.First();
		cards.Remove(topCard);

		return topCard;
	}

	private void Shuffle(ref List<Card> cards)
	{
		// Shuffle the cards using a random number
		Random random = new Random();
		cards = cards.OrderBy(card => random.NextDouble()).ToList();
	}
}