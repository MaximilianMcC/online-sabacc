class UiHandler
{
	public static List<UiElement> UiElements = new List<UiElement>();

	public static void ReloadTextSizes()
	{
		foreach (UiElement element in UiElements)
		{
			element.ReloadText();
		}
	}
}