using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public partial class SimpleImageControl : UserControl, IImageControl
    {
        public SimpleImageControl()
        {
            InitializeComponent();
        }

        #region Private Variables

        private Bitmap _bmpImage;

        private double _scale = 3.0;

        private IBackgroundGenerator _backgroundGenerator = new CheckeredBackgroundGenerator();

        private bool _isMouseDown = false;

        private int _mouseX = 0;

        private int _mouseY = 0;

        #endregion

        #region Properties

        public SheetImageSource ImageSource
        {
            set
            {
                // Load the file.
                if (_bmpImage != null)
                {
                    _bmpImage.Dispose();
                }

                if (File.Exists(value.FileName))
                {
                    _bmpImage = new Bitmap(value.FileName);
                }
                else
                {
                    MessageBox.Show("File " + value.FileName + " was not found. It may have been moved.", "File Not Found", MessageBoxButtons.OK);
                }
            }
        }

        public IBackgroundGenerator BackgroundGenerator
        {
            set
            {
                _backgroundGenerator = value;
            }
        }

        #endregion

        #region Private Functions


        private void resetScrollbars()
        {
            if (_bmpImage != null)
            {
                int vScrollMax = (int)(_bmpImage.Height * _scale) - pbImage.Height;

                if (vScrollMax > 0)
                {
                    vScroll.Maximum = vScrollMax;
                }
                else
                {
                    vScroll.Maximum = vScroll.Minimum;
                }

                int hScrollMax = (int)(_bmpImage.Width * _scale) - pbImage.Width;

                if (hScrollMax > 0)
                {
                    hScroll.Maximum = hScrollMax;
                }
                else
                {
                    hScroll.Maximum = hScroll.Minimum;
                }
            }
        }

        private void resize()
        {
            pbImage.Width = this.ClientSize.Width - vScroll.Width - 1;
            pbImage.Height = this.ClientSize.Height - hScroll.Height - 1;

            hScroll.Top = pbImage.ClientSize.Height;
            hScroll.Width = pbImage.ClientSize.Width;

            vScroll.Left = pbImage.ClientSize.Width;
            vScroll.Height = pbImage.ClientSize.Height;

            resetScrollbars();

            pbImage.Refresh();
        }

        #endregion

        #region Event Handlers

        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbImage.Refresh();
        }

        private void ImageControl_Load(object sender, System.EventArgs e)
        {
            resize();
        }

        private void ImageControl_Resize(object sender, System.EventArgs e)
        {
            resize();
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;

            _mouseX = e.X;

            _mouseY = e.Y;
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown == true)
            {
                int deltaX = _mouseX - e.X;

                int deltaY = _mouseY - e.Y;

                _mouseX = e.X;

                _mouseY = e.Y;

                if (hScroll.Value + deltaX < hScroll.Minimum)
                {
                    hScroll.Value = hScroll.Minimum;
                }
                else if (hScroll.Value + deltaX > hScroll.Maximum)
                {
                    hScroll.Value = hScroll.Maximum;
                }
                else
                {
                    hScroll.Value += deltaX;
                }

                if (vScroll.Value + deltaY < vScroll.Minimum)
                {
                    vScroll.Value = vScroll.Minimum;
                }
                else if (vScroll.Value + deltaY > vScroll.Maximum)
                {
                    vScroll.Value = vScroll.Maximum;
                }
                else
                {
                    vScroll.Value += deltaY;
                }

                pbImage.Refresh();
            }
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            if (_bmpImage != null)
            {
                Graphics g = e.Graphics;

                int hscrollOffset = -1 * hScroll.Value;

                int vscrollOffset = -1 * vScroll.Value;

                int centerCanvasX = (int)((float)pbImage.Width / 2.0f);

                int centerCanvasY = (int)((float)pbImage.Height / 2.0f);

                int centerImageX = (int)((float)(_bmpImage.Width * _scale) / 2.0f);

                int centerImageY = (int)((float)(_bmpImage.Height * _scale) / 2.0f);

                int x = centerCanvasX - centerImageX;

                int y = centerCanvasY - centerImageY;

                // If the left side of the image is extends off canvas, it should be positioned to align to the left instead of centered.
                if (x < 0)
                {
                    x = 0;
                }

                // If the top side of the image is extends off canvas, it should be positioned to align to top left instead of centered.                
                if (y < 0)
                {
                    y = 0;
                }

                Bitmap bmpBackground = _backgroundGenerator.GenerateBackground((int)(_bmpImage.Width * _scale), (int)(_bmpImage.Height * _scale));

                g.DrawImage(bmpBackground, new Point(x, y));

                // Scale the sprite sheet.
                int sourceWidth = _bmpImage.Width;

                int sourceHeight = _bmpImage.Height;

                // Scale the destination by the scaling factor.
                int destinationWidth = (int)(sourceWidth * _scale);

                int destinationHeight = (int)(sourceHeight * _scale);

                System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x + hscrollOffset, y + vscrollOffset, destinationWidth, destinationHeight);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.DrawImage(_bmpImage, destRect, 0, 0, _bmpImage.Width, _bmpImage.Height, GraphicsUnit.Pixel, null);
            }
        }

        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbImage.Refresh();
        }

        #endregion
    }


    public interface IImageControl
    {

    }
}
