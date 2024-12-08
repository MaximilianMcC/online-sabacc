using System.Net.Sockets;

class Game
{
	// Game stats
	private int round;
	private List<Card> drawPile;
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
		drawPile = Sabacc.GenerateDeck();
		Shuffle(ref drawPile);

		// Take the first card and
		// make it the discard pile
		discardPile = new List<Card>() { TakeCard(drawPile) };
		round = 1;

		// Give all of the players their
		// two starting cards
		foreach (Player player in players)
		{
			player.Hand.Add(TakeCard(drawPile));
			player.Hand.Add(TakeCard(drawPile));
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

		// Do three rounds
		Round();
		Round();
		Round();

		// See who the winner is
		GetWinner();
	}

	private void Round()
	{
		// Say that a new round is starting
		BroadcastPacketToAllPlayers("NEW-ROUND");

		// Loop over every player and let them
		// all have one turn in this round rn
		foreach (Player player in players)
		{
			// Say whose turn it is
			string packet = "PLAYERS-TURN " + player;
			BroadcastPacketToAllPlayers(packet);

			// Wait for the player to request their turn
			string turnPacket = Networking.ReceivePacket(player.Stream);
			string[] packetSections = turnPacket.Split(" ");

			// Check for what turn they do
			if (packetSections[0] == "DRAW")
			{
				// Check for if they wanna pick up a card from
				// the draw pile, or from the discard pile
				//? '0' is the draw pile
				//? '1' is the discard pile
				if (packetSections[1] == "0")
				{
					// Take a card from the draw pile
					// and add it onto the players hand
					player.Hand.Add(TakeCard(drawPile));
				}
				else if (packetSections[1] == "1")
				{
					// Take a card from the discard pile
					// and add it onto the players hand
					player.Hand.Add(TakeCard(discardPile));

					// TODO: If the discard pile is now empty, place a new card in from the draw pile
				}
			}
			else if (packetSections[0] == "SWAP")
			{
				// Swap a card from the players hand
				// with the top card on the discard pile
				Card cardToSwap = new Card(packetSections[1]);
				Card cardToGain = discardPile.First();

				// Remove the cards
				discardPile.Remove(cardToGain);
				player.Hand.Remove(cardToSwap);

				// Actually swap them
				discardPile.Add(cardToSwap);
				player.Hand.Add(cardToGain);
			}
			else if (packetSections[0] == "STAND")
			{
				// Do nothing
			}

			// Tell all the other players
			// what move was just performed
			// TODO: Rename variable
			string playerInformationPacket = $"MOVE {player} {packetSections[0]}";
			BroadcastPacketToAllPlayersExceptOne(playerInformationPacket, player);

			// Send the game state to all players
			// TODO: Maybe do this before the playerInformationPacket is sent
			// TODO: Don't use a loop. Have in method somehow
			foreach (Player playerToGetUpdate in players)
			{
				SendGameState(playerToGetUpdate);
			}
		}
	}

	private void GetWinner()
	{

	}


	
	// Send the same packet to every player
	private void BroadcastPacketToAllPlayers(string packet)
	{
		foreach (Player player in players)
		{
			Networking.SendPacket(packet, player.Stream);
		}
	}

	private void BroadcastPacketToAllPlayersExceptOne(string packet, Player playerToIgnore)
	{
		foreach (Player player in players)
		{
			// Don't send the packet if we're ignoring bro
			if (player == playerToIgnore) continue;

			Networking.SendPacket(packet, player.Stream);
		}
	}

	// Send a player their game state. This includes
	// their hand, and the discard pile
	private void SendGameState(Player player)
	{
		// Say that this has game state stuff
		string packet = "GAME-STATE ";

		// Get the top card of the discard pile
		packet += discardPile.First() + " ";

		// Get the players hand
		packet += string.Join(" ", player.Hand);
		
		// Send it to the player
		Networking.SendPacket(packet, player.Stream);
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