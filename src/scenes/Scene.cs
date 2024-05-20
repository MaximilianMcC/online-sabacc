abstract class Scene
{
    public string Name { get; private set; }

    public Scene(string name)
    {
        // Assign the scenes name
        Name = name;
    }

    public abstract void Start();
    public abstract void Update();
    public abstract void Render();
    public abstract void CleanUp();
}