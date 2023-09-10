
using static System.ComponentModel.TypeConverter;
using System.ComponentModel;

namespace SpriteSheetBuilder
{
    public class PaletteMapConverter : StringConverter
    {
        internal class GlobalVars
        {
            internal static string[] _listOfPaletteMaps;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // Build a list of 
            return new StandardValuesCollection(GlobalVars._listOfPaletteMaps);
        }
    }
}
