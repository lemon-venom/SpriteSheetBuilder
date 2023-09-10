using System.Drawing;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public partial class ImageViewerDialog : Form, IImageViewerDialog
    {
        public ImageViewerDialog()
        {
            InitializeComponent();
        }

        public IBackgroundGenerator BackgroundGenerator
        {
            set
            {
                imageViewer.BackgroundGenerator = value;
            }
        }

        public void Show(IWin32Window owner, SheetImageSource imageSource)
        {
            imageViewer.ImageSource = imageSource;

            this.Show(owner);
        }

        public void ShowDialog(IWin32Window owner, SheetImageSource imageSource)
        {
            imageViewer.ImageSource = imageSource;

            this.ShowDialog(owner);
        }
    }

    public interface IImageViewerDialog
    {
        #region Properties

        // Derived from base.
        int Width { get; set; }
        int Height { get; set; }
        int Bottom { get; }
        int Left { get; set; }
        int Top { get; set; }
        bool TopLevel { get; set; }

        #endregion

        #region Public Functions

        void Show(IWin32Window owner, SheetImageSource imageSource);
        void ShowDialog(IWin32Window owner, SheetImageSource imageSource);

        void Hide();
        void Close();

        #endregion
    }
}
