using System.Numerics;
using Raylib_cs;

class Button
{
	public Vector2 Position;
	public Vector2 Size;
	public string Text;

	public Action OnClick;
	public bool Disabled;
	private bool hovered;

	private Color backgroundColor = new Color(255, 0, 0, 255);
	private Color hoveredColor = new Color(230, 0, 0, 255);

	// Make a new button
	// TODO: Replace size with maxSize and make the size dynamic based on text
	public Button(string text, Vector2 position, Vector2 size, Action onClick, bool disabled)
	{
		// Assign stuff
		Text = text;
		Position = position;
		Size = size;
		OnClick = onClick;
		Disabled = disabled;
	}

	public void Update()
	{
		// Check for if the button is disabled and do nothing
		if (Disabled) return;

		// Check for if the user is hovering over the button
		if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(Position, Size)))
		{
			// Update the hover status
			hovered = true;

			// Check for if they wanna click on it then run the click method
			// TODO: Add tab support (enter key and whatnot)
			if (Raylib.IsMouseButtonPressed(MouseButton.Left)) OnClick.Invoke();
		}
		else hovered = false;
		//! Probably bad to be constantly assigning and reassigning but its fine trust
	}

	public void Render()
	{
		// Draw the background
		Color color = hovered ? hoveredColor : backgroundColor;
		Raylib.DrawRectangleV(Position, Size, color);

		// Draw the text
		const float fontSize = 50f;
		Raylib.DrawTextEx(Settings.Font, Text, Position, fontSize, (fontSize / 10), Color.White);
	}
}