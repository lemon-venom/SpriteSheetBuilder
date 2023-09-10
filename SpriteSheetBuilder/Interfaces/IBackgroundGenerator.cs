using System.Drawing;

namespace SpriteSheetBuilder
{
    public enum BackgroundColorScheme
    {
        UserDefined = 0,
        StandardLight = 1,
        StandardDark = 2,
        Vivid = 3,
        Neon = 4,
        Pastel = 5,
        Tomato = 6
    }

    // TODO: IBackgroundGenerator and IOverlayGenerator can probably share a common base IImageGenerator interface.
    public interface IBackgroundGenerator
    {
        Bitmap GenerateBackground(int width, int height);
        
        Bitmap BackgroundImage { get; }

        BackgroundColorScheme BackgroundColorScheme { get; set; }

        Color BackgroundColor1 { get; set; }

        Color BackgroundColor2 { get; set; }

        void Regenerate();
    }
}
