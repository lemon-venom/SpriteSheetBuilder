using System.Drawing;

namespace SpriteSheetBuilder
{
    public class CheckeredBackgroundGenerator : IBackgroundGenerator
    {
        #region Properties

        public Bitmap BackgroundImage
        {
            get { return _bmpBackground; }
        }
        private Bitmap _bmpBackground = null;

        public BackgroundColorScheme BackgroundColorScheme
        {
            get { return _backgroundColorScheme; }
            set { _backgroundColorScheme = value; }
        }
        private BackgroundColorScheme _backgroundColorScheme = BackgroundColorScheme.StandardLight;

        public Color BackgroundColor1
        {
            get { return _backgroundColor1; }
            set { _backgroundColor1 = value; }
        }
        private Color _backgroundColor1 = Color.LightGray;

        public Color BackgroundColor2
        {
            get { return _backgroundColor2; }
            set { _backgroundColor2 = value; }
        }
        private Color _backgroundColor2 = Color.White;

        #endregion

        #region Public Functions

        public void Regenerate()
        {
            _generateBackground = true;
        }
        private bool _generateBackground;
        
        public Bitmap GenerateBackground(int width, int height)
        {
            if (_generateBackground == true || _bmpBackground == null)
            {
                // Dispose of the old background object.
                if (_bmpBackground != null)
                {
                    _bmpBackground.Dispose();
                    _bmpBackground = null;
                }

                _bmpBackground = new Bitmap(width, height);
                
                generateBackground(width, height);
                
                _generateBackground = false;
            }

            return _bmpBackground;
        }

        #endregion

        #region Private Functions

        private void generateBackground(int width, int height)
        {
            Graphics gBackground = Graphics.FromImage(_bmpBackground);

            SolidBrush bColor1;
            SolidBrush bColor2;

            switch (BackgroundColorScheme)
            {
                case BackgroundColorScheme.UserDefined:

                    bColor1 = new SolidBrush(_backgroundColor1);
                    bColor2 = new SolidBrush(_backgroundColor2);

                    break;

                case BackgroundColorScheme.StandardDark:

                    bColor1 = new SolidBrush(Color.FromArgb(44, 44, 44));
                    bColor2 = new SolidBrush(Color.Black);

                    break;

                case BackgroundColorScheme.Vivid:

                    bColor1 = new SolidBrush(Color.Magenta);
                    bColor2 = new SolidBrush(Color.FromArgb(105, 3, 128));

                    break;

                case BackgroundColorScheme.Neon:

                    bColor1 = new SolidBrush(Color.FromArgb(81, 166, 14));
                    bColor2 = new SolidBrush(Color.FromArgb(116, 238, 21));

                    break;

                case BackgroundColorScheme.Pastel:

                    bColor1 = new SolidBrush(Color.FromArgb(224, 215, 255));
                    bColor2 = new SolidBrush(Color.FromArgb(176, 153, 255));

                    break;

                case BackgroundColorScheme.Tomato:

                    bColor1 = new SolidBrush(Color.Tomato);
                    bColor2 = new SolidBrush(Color.LightSalmon);

                    break;

                case BackgroundColorScheme.StandardLight:
                default:

                    bColor1 = new SolidBrush(Color.LightGray);
                    bColor2 = new SolidBrush(Color.White);

                    break;

            }

            bool toggle = true;
            int row = 0;
            int boxSize = 8;
            int sliceOffX = 0;
            int sliceOffY = 0;

            for (int j = 0; j < height + boxSize; j += boxSize)
            {
                for (int i = 0; i < width + boxSize; i += boxSize)
                {
                    sliceOffX = 0;
                    sliceOffY = 0;

                    if (i + boxSize > width)
                    {
                        sliceOffX = (i + boxSize) - width;
                    }

                    if (j + boxSize > height)
                    {
                        sliceOffY = (j + boxSize) - height;
                    }

                    if (toggle)
                    {
                        gBackground.FillRectangle(bColor1, i, j, boxSize - sliceOffX, boxSize - sliceOffY);
                    }
                    else
                    {
                        gBackground.FillRectangle(bColor2, i, j, boxSize - sliceOffX, boxSize - sliceOffY);
                    }

                    toggle = !toggle;
                }

                row++;
                toggle = (row % 2 == 0);
            }

            gBackground.Dispose();
        }
        
        #endregion
    }
}
