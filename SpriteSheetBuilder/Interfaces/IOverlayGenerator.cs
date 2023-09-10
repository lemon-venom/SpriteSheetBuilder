using System.Drawing;

namespace SpriteSheetBuilder
{
    public interface IOverlayGenerator
    {
        Bitmap Generate(SpriteSheetBuildFile spriteSheetBuildFile);

        Bitmap OverlayImage { get; }

        void Regenerate();
    }
}
