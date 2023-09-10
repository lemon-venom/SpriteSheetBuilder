using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetBuilder
{
    public class SheetBoundariesOverlayGenerator : IOverlayGenerator
    {
        #region Private Variables

        private bool _regenerate;

        #endregion

        #region Properties

        public Bitmap OverlayImage
        {
            get { return _bmpImage; }
        }
        private Bitmap _bmpImage = null;

        #endregion

        #region Public Functions

        public void Regenerate()
        {
            _regenerate = true;
        }

        public Bitmap Generate(SpriteSheetBuildFile spriteSheetBuildFile)
        {
            if (_regenerate == true || _bmpImage == null)
            {
                // Dispose of the old image object.
                if (_bmpImage != null)
                {
                    _bmpImage.Dispose();
                    _bmpImage = null;
                }

                generate(spriteSheetBuildFile);

                _regenerate = false;
            }

            return _bmpImage;
        }

        #endregion

        #region Private Functions

        private void generate(SpriteSheetBuildFile spriteSheetBuildFile)
        {
            // Calculate the boundary parameters.
            int columnsWidth = spriteSheetBuildFile.Columns * spriteSheetBuildFile.CellWidth;

            int paddingsWidth = (spriteSheetBuildFile.Columns - 1) * spriteSheetBuildFile.CellPadding;

            int borderWidth = (spriteSheetBuildFile.BorderWidth * 2); // Border on each side.

            int bitmapWidth = columnsWidth + paddingsWidth + borderWidth;

            // Need to do an initial pass to determine how many images there are in total, from all sources.
            int totalImages = 0;

            for (int i = 0; i < spriteSheetBuildFile.ImageSourceList.Count; i++)
            {
                SheetImageSource imageSource = spriteSheetBuildFile.ImageSourceList[i];

                totalImages += imageSource.CellCount;
            }

            int rows = Convert.ToInt32(Math.Ceiling(((double)totalImages / (double)spriteSheetBuildFile.Columns)));

            int rowsHeight = rows * spriteSheetBuildFile.CellHeight;

            int paddingsHeight = (rows - 1) * spriteSheetBuildFile.CellPadding;

            int borderHeight = (spriteSheetBuildFile.BorderWidth * 2); // Border on each side.

            int bitmapHeight = rowsHeight + paddingsHeight + borderHeight;

            _bmpImage = new Bitmap(bitmapWidth, bitmapHeight);

            Graphics gImage = Graphics.FromImage(_bmpImage);

            // Draw the border.
            Pen pBorder = new Pen(new SolidBrush(Color.Black), borderWidth);

            Pen pPadding = new Pen(new SolidBrush(Color.Black), spriteSheetBuildFile.CellPadding);

            if (borderWidth > 0)
            {
                gImage.DrawRectangle(pBorder, new Rectangle(0, 0, bitmapWidth, bitmapHeight));
            }

            int paddingOffset = (int)Math.Floor((float)spriteSheetBuildFile.CellPadding / 2.0f);

            if (spriteSheetBuildFile.CellPadding > 0)
            {
                // Draw the vertical paddings.
                for (int i = 1; i < spriteSheetBuildFile.Columns; i++)
                {
                    int columnBoundaryX = spriteSheetBuildFile.BorderWidth + paddingOffset + (i * spriteSheetBuildFile.CellWidth) + ((i - 1) * spriteSheetBuildFile.CellPadding);

                    gImage.DrawLine(pPadding, new Point(columnBoundaryX, 0), new Point(columnBoundaryX, spriteSheetBuildFile.BorderWidth + rowsHeight + paddingsHeight));
                }

                for (int i = 1; i < rows; i++)
                {
                    int rowBoundaryY = spriteSheetBuildFile.BorderWidth + paddingOffset + (i * spriteSheetBuildFile.CellHeight) + ((i - 1) * spriteSheetBuildFile.CellPadding);

                    gImage.DrawLine(pPadding, new Point(0, rowBoundaryY), new Point(spriteSheetBuildFile.BorderWidth + columnsWidth + paddingsWidth, rowBoundaryY));
                }
            }

            gImage.Dispose();
        }

        #endregion
    }
}
