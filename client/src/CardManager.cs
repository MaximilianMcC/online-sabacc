using System.Numerics;
using Raylib_cs;

class CardManager
{
	public static List<Card> Hand;
	private static Dictionary<string, Texture2D> cardTextures;

	public static void LoadCards()
	{
		// Store all the cards in an array so 
		// they can be easily gotten via their
		// stringified version thingy (easy as)
		cardTextures = new Dictionary<string, Texture2D>();
		
		// Get all of the cards, then loop over them all
		List<Card> cards = Sabacc.GenerateDeck();
		foreach (Card card in cards)
		{
			// Get the string representation of the card
			string cardString = card.ToString();

			// Check for if the card has already been added
			//? this should just be for the 0 but good to have anyways
			if (cardTextures.ContainsKey(cardString)) continue;

			// Add the current card
			string cardPath = $"./assets/cards/card_{cardString}.png";
			cardTextures.Add(cardString, AssetManager.LoadTexture(cardPath));
		}

		// Manually add the card back
		cardTextures.Add("back", AssetManager.LoadTexture("./assets/cards/back.png"));

		// Also make the empty hand while we're here
		Hand = new List<Card>();
	}

	public static void Draw()
	{
		// Draw all the cards in the players hand
		Vector2 position = new Vector2(100);
		foreach (Card card in Hand)
		{
			Raylib.DrawTextureV(cardTextures[card.ToString()], position, Color.White);
			position.X += cardTextures[card.ToString()].Width;
		}
	}
}