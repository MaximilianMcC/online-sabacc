using System.Numerics;
using Raylib_cs;

class Button : UiElement
{
	public Vector2 Position;
	private Rectangle rectangle;

	public string Text;
	private Vector2 textPosition;
	private float fontSize;

	public Action OnClick;
	public bool Disabled;
	private bool hovered;
	private bool suicidal; //? Kill the button when its clicked (used when the button should only be pressed once then will disappear) atm it just stops it having the text repositioned

	private readonly Color backgroundColor = new Color(255, 0, 0, 255);
	private readonly Color hoveredColor = new Color(230, 0, 0, 255);
	private readonly Color disabledColorOverlay = new Color(255, 255, 255, 96);
	private const float padding = 25f;
	private const float padding2 = 25f * 2f;

	// Make a new button
	// TODO: Replace size with maxSize and make the size dynamic based on text
	public Button(string text, Vector2 position, Vector2 size, Action onClick, bool isSuicidal)
	{
		// Assign stuff
		Text = text;
		Position = position;
		OnClick = onClick;
		suicidal = isSuicidal;

		// Build a rectangle because its easier to work with
		rectangle = new Rectangle(position, size);

		// Add the element to the UI elements list so
		// it can be updated and indexed
		UiHandler.UiElements.Add(this);

		// Do all the text thingys for the current font
		ReloadText();
	}

	public void Update()
	{
		// Check for if the button is disabled and do nothing
		if (Disabled) return;

		// Check for if the user is hovering over the button
		bool currentlyHovered = false;
		if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rectangle))
		{
			// Update the hover status
			hovered = true;
			currentlyHovered = true;
			Raylib.SetMouseCursor(MouseCursor.PointingHand);

			// Check for if they wanna click on it then run the click method
			// TODO: Add tab support (enter key and whatnot)
			if (Raylib.IsMouseButtonPressed(MouseButton.Left))
			{
				// Kill/remove the button from the
				// ui manager because it wont be used again
				if (suicidal) UiHandler.UiElements.Remove(this);

				// Put the mouse cursor to be normal again
				Raylib.SetMouseCursor(MouseCursor.Default);

				// Click the button 
				OnClick.Invoke();
			}
		}

		// Disable the hover status
		if (hovered == true && currentlyHovered == false)
		{
			hovered = false;
			Raylib.SetMouseCursor(MouseCursor.Default);
		}
	}

	public void Render()
	{
		// Draw the background
		Color color = hovered ? hoveredColor : backgroundColor;
		Raylib.DrawRectangleRec(rectangle, color);

		// Draw the text
		Raylib.DrawTextEx(Settings.Font, Text, textPosition, fontSize, (fontSize / 10), Color.White);

		// If the button is disabled then draw a semi
		// white rectangle over the top to make it
		// look like its kinda grayed out
		if (Disabled) Raylib.DrawRectangleRec(rectangle, disabledColorOverlay);
	}

	// Calculate the size and position of the text because
	// there is a difference in English and Aurebesh
	// TODO: Add new lines if it gets tiny when scaling on the x and there is room on the y
	public override void ReloadText()
	{
		// Figure out what the max allowed width is
		float maxWidth = rectangle.Width - padding2;

		// Make some text with a random fixed font size
		// so we can use it to calculate the scale
		const float fixedFontSize = 100f;
		Vector2 fixedSizeText = Raylib.MeasureTextEx(Settings.Font, Text, fixedFontSize, (fixedFontSize / 10f));

		// Calculate the scale of the text so
		// that it fits in the rectangle then use
		// that to get the font size
		float scale = maxWidth / fixedSizeText.X;
		fontSize = fixedFontSize * scale;

		// Set the text position
		textPosition.X = Position.X + padding;
		textPosition.Y = Position.Y + ((rectangle.Height - fontSize) / 2);
	}
}