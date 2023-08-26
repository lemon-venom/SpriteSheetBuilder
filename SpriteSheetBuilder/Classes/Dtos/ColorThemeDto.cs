using System.Collections.Generic;
using System.Drawing;

namespace SpriteSheetBuilder
{
    internal class ColorThemeDto
    {
        public ColorThemeDto(Color color1, Color color2)
        {
            Color1 = color1;

            Color2 = color2;
        }

        public Color Color1;

        public Color Color2;
    }
}
