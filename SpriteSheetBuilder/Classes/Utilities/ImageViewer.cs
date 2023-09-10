using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    internal class ImageViewer : IImageViewer
    {
        public void ShowImage(IWin32Window owner, SheetImageSource imageSource, IBackgroundGenerator backgroundGenerator)
        {
            ImageViewerDialog dlg = new ImageViewerDialog();

            backgroundGenerator.Regenerate();

            dlg.BackgroundGenerator = backgroundGenerator;

            dlg.ShowDialog(owner, imageSource);

            // Flag it to regenerate the next time it is used.
            backgroundGenerator.Regenerate();
        }
    }


    public interface IImageViewer
    {
        void ShowImage(IWin32Window owner, SheetImageSource imageSource, IBackgroundGenerator backgroundGenerator);
    }
}
