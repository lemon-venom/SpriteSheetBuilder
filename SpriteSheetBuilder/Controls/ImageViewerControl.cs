using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public partial class ImageViewerControl : UserControl, IImageViewerControl
    {
        public ImageViewerControl()
        {
            InitializeComponent();
        }

        public IBackgroundGenerator BackgroundGenerator
        {
            set
            {
                image.BackgroundGenerator = value;
            }
        }

        public SheetImageSource ImageSource
        {
            set
            {
                image.ImageSource = value;

                palette.Palette = value.Palette;
            }
        }
    }

    public interface IImageViewerControl
    {
        SheetImageSource ImageSource { set; }
    }
}
