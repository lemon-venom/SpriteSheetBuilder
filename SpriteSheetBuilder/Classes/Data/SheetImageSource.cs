using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetBuilder
{ 
    public class SheetImageSource
    {
        public SheetImageSource(string filename)
        {
            FileName = filename;
        }

        public String FileName;
        
        #region Properties

        [CategoryAttribute("Image Source Properties"),
         DescriptionAttribute("The number total cells")]
        public int CellCount
        {
            get { return _cellCount; }
            set { _cellCount = value; }
        }
        private int _cellCount = 0;
        
        [CategoryAttribute("Image Source Properties"),
         DescriptionAttribute("The height of the cells")]
        public int CellHeight
        {
            get { return _cellHeight; }
            set { _cellHeight = value; }
        }
        private int _cellHeight = 0;

        [CategoryAttribute("Image Source Properties"),
         DescriptionAttribute("The width of the cells")]
        public int CellWidth
        {
            get { return _cellWidth; }
            set { _cellWidth = value; }
        }
        private int _cellWidth = 0;
        
        [CategoryAttribute("Image Source Properties"),
         DescriptionAttribute("The number of cell columns")]
        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        private int _columns = 0;

        [BrowsableAttribute(false)]
        public bool Exists
        {
            get { return _fileExists; }
            set { _fileExists = value; }
        }
        private bool _fileExists = true;

        [BrowsableAttribute(false)]
        public Palette Palette
        {
            get { return _palette; }
        }
        private Palette _palette = new Palette();

        #endregion
    }
}
