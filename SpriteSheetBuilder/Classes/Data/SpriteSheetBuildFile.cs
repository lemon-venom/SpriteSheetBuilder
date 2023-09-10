using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetBuilder
{
    #region Enums

    public enum SheetCellVerticalAlignment
    {
        Top = 1,
        Bottom = 2,
        Center = 3
    };

    public enum SheetCellHorizontalAlignment
    {
        Left = 1,
        Right = 2,
        Center = 3
    };

    public enum AlphaChannel
    {
        Red = 1,
        Green = 2,
        Blue = 3,
        Grayscale = 4
    };
    
    #endregion

    public class SpriteSheetBuildFile
    {
        public SpriteSheetBuildFile()
        {

        }

        #region Private Variables
        #endregion

        #region Properties

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The number of cell columns")]
        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        private int _columns = 0;

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The height of the cells"),
         DisplayNameAttribute("Cell Height")]
        public int CellHeight
        {
            get { return _cellHeight; }
            set { _cellHeight = value; }
        }
        private int _cellHeight = 0;

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The width of the cells"),
         DisplayNameAttribute("Cell Width")]
        public int CellWidth
        {
            get { return _cellWidth; }
            set { _cellWidth = value; }
        }
        private int _cellWidth = 0;


        [BrowsableAttribute(false)]
        public List<SheetImageSource> ImageSourceList
        {
            get { return _imageSourceList; }
            set { _imageSourceList = value; }
        }
        private List<SheetImageSource> _imageSourceList = new List<SheetImageSource>();

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The vertical alignment of the cells in the final sheet."),
         DisplayNameAttribute("Vertical Alignment")]
        public SheetCellVerticalAlignment VerticalAlignment
        {
            get { return _sheetCellVerticalAlignment; }
            set { _sheetCellVerticalAlignment = value; }
        }
        private SheetCellVerticalAlignment _sheetCellVerticalAlignment = SheetCellVerticalAlignment.Top;


        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The horizontal alignment of the cells in the final sheet."),
         DisplayNameAttribute("Horizontal Alignment")]
        public SheetCellHorizontalAlignment HorizontalAlignment
        {
            get { return _sheetCellHorizontalAlignment; }
            set { _sheetCellHorizontalAlignment = value; }
        }
        private SheetCellHorizontalAlignment _sheetCellHorizontalAlignment = SheetCellHorizontalAlignment.Left;

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The channel of the alpha value in the final alpha mask sheet."),
         BrowsableAttribute(false)]
        public AlphaChannel AlphaChannel
        {
            get { return _alphaChannel; }
            set { _alphaChannel = value; }
        }
        private AlphaChannel _alphaChannel = AlphaChannel.Red;

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The background color of the final sheet."),
         DisplayNameAttribute("Background Color")]
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }
        private Color _backgroundColor = Color.Transparent;

        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The width of the sprite sheet border in pixels"),
         DisplayNameAttribute("Border Width")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }
        private int _borderWidth = 0;

        //[CategoryAttribute("Build Settings"),
        // DescriptionAttribute("Color mappings to change the palette in the exported image."),
        // DisplayNameAttribute("Palette Map")]
        //[Editor(typeof(PaletteMapTypeEditor), typeof(UITypeEditor))]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        // Changing this to just select a user defined palette name.


        [BrowsableAttribute(false)]
        public Palette Palette
        {
            get { return _palette; }
            set { _palette = value; }
        }
        private Palette _palette = new Palette();

        // Convert palette name to ID. This ensures palette name can be displayed to the user
        // instead of the ID, and will also be fine to change the selected palette's name.
        [CategoryAttribute("Build Settings"), 
         DisplayName("Palette"),
         TypeConverter(typeof(PaletteMapConverter))]
        public string PaletteName
        {
            get
            {
                if (_paletteMapId == Guid.Empty)
                {
                    return string.Empty;
                }
                else
                {
                    for (int i = 0; i < Palette.PaletteMaps.Count; i++)
                    {
                        if (Palette.PaletteMaps[i].Id == _paletteMapId)
                        {
                            return Palette.PaletteMaps[i].Name;
                        }
                    }                    
                }

                return string.Empty; // Shouldn't happen, but just in case...
            }
            set
            {
                for (int i = 0; i < Palette.PaletteMaps.Count; i++)
                {
                    if (Palette.PaletteMaps[i].Name.ToUpper() == value.ToUpper())
                    {
                        _paletteMapId = Palette.PaletteMaps[i].Id;

                        return;
                    }
                }

                _paletteMapId = Guid.Empty;
            }
        }

        [BrowsableAttribute(false)]
        public Guid PaletteMapId
        {
            get
            {
                return _paletteMapId;
            }
        }
        private Guid _paletteMapId = Guid.Empty;



        [CategoryAttribute("Build Settings"),
         DescriptionAttribute("The padding between cells"),
         DisplayNameAttribute("Cell Padding")]
        public int CellPadding
        {
            get { return _padding; }
            set { _padding = value; }
        }
        private int _padding = 0;

        #endregion

        #region Public Functions
        #endregion

        #region Private Functions
        #endregion

        #region Event Handlers
        #endregion

    }
}
