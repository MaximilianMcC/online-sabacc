namespace gfx;

using System.Runtime.ConstrainedExecution;
using Raylib_cs;

public abstract class CardTextureGenerator
{
    private static List<Texture2D> cardTextures { get; set; } = new List<Texture2D>();
    private static int cardTextureWidth = 48;
    private static int cardTextureHeight = 64;
    private static Texture2D[] baseSpritesheetTextures = new Texture2D[16];
    
    public static void GenerateBaseSpritesheet()
    {
        RenderTexture2D tempSpriteSheetRenderTexture = Raylib.LoadRenderTexture(cardTextureWidth, 
            cardTextureHeight);

        for (int i = 0; i < baseSpritesheetTextures.Length; i++)
        {
            Raylib.BeginTextureMode(tempSpriteSheetRenderTexture);
                Raylib.DrawTexture(tempSpriteSheetRenderTexture.Texture, i * cardTextureWidth, 0, Color.White);
            Raylib.EndTextureMode();
        }
    }

    // TODO: generate deck textures with pixel manipulation and rendertexture layering garbar (c# STINKS)
}