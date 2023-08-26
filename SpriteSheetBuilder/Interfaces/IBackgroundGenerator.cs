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
        Pastel = 5
    }
    
    public interface IBackgroundGenerator
    {
        Bitmap GenerateBackground(int width, int height);
        
        Bitmap BackgroundImage { get; }

        BackgroundColorScheme BackgroundColorScheme { get; set; }
        
        void Regenerate();
    }
}
