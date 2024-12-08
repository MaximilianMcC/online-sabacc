public class Card
{
	public int Value;
	public Suite Suite;

	public Card() {}

	public Card(string stringRepresentation)
	{
		// Separate the value and suit
		string[] sections = stringRepresentation.Split("_");

		// Get the value
		Value = int.Parse(sections[0]);

		// Get the suit
		Suite = (Suite)int.Parse(sections[1]);
	}

	public override string ToString()
	{
		return $"{Value}_{(int)Suite}";
	}
}

public enum Suite
{
	Circle,
	Triangle,
	Square,

	// TODO: Maybe don't put in here
	Sylop
}