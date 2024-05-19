abstract class Scene
{
    public string Name { get; set; }

    public abstract void Start();
    public abstract void Update();
    public abstract void Render();
    public abstract void CleanUp();
}