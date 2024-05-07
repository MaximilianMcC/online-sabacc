using Raylib_cs;

class Game
{
    public static void Run()
    {
        Raylib.SetTraceLogLevel(TraceLogLevel.Warning);

        // Setup raylib stuff
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
        Raylib.InitWindow(400, 300, "online sabacc play free online now games unblocked free games for kids video game gamer online free sabacc game video gamers");
        Raylib.SetTargetFPS(60);

        Start();
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Render();
        }
        CleanUp();
    }

    public static void Start()
    {

    }

    private static void Update()
    {

    }

    private static void Render()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Magenta);

        Raylib.DrawText("sabacceroni", 10, 10, 50, Color.White);

        Raylib.EndDrawing();
    }

    private static void CleanUp()
    {
        Raylib.CloseWindow();
    }
}