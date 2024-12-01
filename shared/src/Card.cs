public class Card
{
	public int Value;
	public Suite Suite;

	public override string ToString()
	{
		char sign = ' ';
		if (Value != 0) sign = (Value > 0) ? '+' : '-';

		return $"{sign}{Math.Abs(Value)}\t{Suite}";
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