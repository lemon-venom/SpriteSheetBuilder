using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    #region Delegates

    public delegate void ColorInfoSelectedHandler(object sender, ColorInfoSelectedEventArgs e);

    #endregion

    public partial class PaletteControl : UserControl, IPaletteControl
    {
        #region Events

        public event ColorInfoSelectedHandler ColorInfoSelected;

        #endregion

        #region Constructors

        public PaletteControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        private Bitmap          _bmpPalette = null;

        private Color           _mouseOverColor = Color.White;

        private ColorInfo       _mouseOverColorInfo = null;

        private int             _mouseOverSwatchIndex = -1;

        private MouseState      _mouseState = new MouseState();

        private Palette         _palette;

        private bool            _regenerate = false;

        private float           _scale = 2.0f;

        #endregion

        #region Properties

        public Palette Palette 
        { 
            get { return _palette; }
            set 
            { 
                _palette = value;

                pbPalette.Refresh();
            }
        }

        public PaletteVisualization Visualization 
        {
            get 
            {
                if (_palette == null)
                {
                    return PaletteVisualization.Swatches;
                }
                else
                {
                    return _palette.Visualization;
                }
            }
            set 
            {
                if (_palette != null)
                {
                    _palette.Visualization = value;


                    if (_palette.Visualization == PaletteVisualization.Histogram)
                    {
                        // Currently this is hosted in a fixed panel size, so it doens't need the v scroll.
                        // This isn't the right solution, because it could be hosted anywhere. But for now this 
                        // is fine, just be aware it will need to change if it gets hosted in a different container.
                        vScroll.Visible = false;
                    }
                    else
                    {
                        vScroll.Visible = true;
                    }

                    refreshImage();

                    resize();
                }
            }
        }

        public int MappedPaletteIndex 
        {
            get { return _mappedPaletteIndex; }
            set 
            { 
                _mappedPaletteIndex = value;

                refreshImage();

                pbPalette.Refresh();
            }
        }
        private int _mappedPaletteIndex = -1;


        #endregion

        #region Private Functions

        private void refreshImage()
        {
            _regenerate = true;

            pbPalette.Refresh();
        }

        private void resetScrollbars()
        {
            if (_bmpPalette != null)
            {
                int vScrollMax = _bmpPalette.Height - pbPalette.Height;

                if (vScrollMax > 0)
                {
                    vScroll.Maximum = vScrollMax;
                }
                else
                {
                    vScroll.Maximum = vScroll.Minimum;
                }

                int hScrollMax = _bmpPalette.Width - pbPalette.Width;

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
            pbPalette.Width = this.ClientSize.Width - vScroll.Width - 1;
            pbPalette.Height = this.ClientSize.Height - hScroll.Height - 1;

            hScroll.Top = pbPalette.ClientSize.Height;
            hScroll.Width = pbPalette.ClientSize.Width;

            vScroll.Left = pbPalette.ClientSize.Width;
            vScroll.Height = pbPalette.ClientSize.Height;

            resetScrollbars();

            pbPalette.Refresh();
        }

        #endregion

        #region Event Handlers

        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbPalette.Refresh();
        }

        private void pbPalette_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseState.X = e.X;

            _mouseState.Y = e.Y;

            refreshImage();
        }

        private void pbPalette_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseState.IsMouseDown = true;

            switch (_palette.Visualization)
            {
                case PaletteVisualization.Swatches:

                    if (_mouseOverSwatchIndex > -1)
                    {
                        ColorDialog cdlg = new ColorDialog();

                        cdlg.ShowDialog(this);

                        Color mappedColor = cdlg.Color;

                        if (Palette.PaletteMaps[_mappedPaletteIndex].Map.ContainsKey(_mouseOverColor) == false)
                        {
                            Palette.PaletteMaps[_mappedPaletteIndex].Map.Add(_mouseOverColor, mappedColor);
                        }
                        else
                        {
                            Palette.PaletteMaps[_mappedPaletteIndex].Map[_mouseOverColor] = mappedColor;
                        }
                    }

                    break;

                case PaletteVisualization.Histogram:

                    if (_mouseOverColorInfo != null)
                    {
                        OnColorInfoSelected(new ColorInfoSelectedEventArgs(_mouseOverColorInfo));
                    }

                    break;
            }            
        }

        private void pbPalette_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseState.IsMouseDown = false;
        }

        private void pbPalette_Paint(object sender, PaintEventArgs e)
        {
            _mouseOverSwatchIndex = -1;

            Color mouseOverColor = Color.White;

            _mouseOverColorInfo = null;

            // Generate the palette image if it hasn't been already
            if (_palette == null) { return; }
            
            if (_bmpPalette == null || _regenerate == true)
            {
                _regenerate = false;

                if (_bmpPalette != null)
                {
                    _bmpPalette.Dispose();
                }

                switch (_palette.Visualization)
                {
                    case PaletteVisualization.Swatches:

                        int borderSize = 1;

                        int paletteColumns = 4;

                        int swatchSize = (int)(8 * _scale);

                        int singlePaletteWidth = (paletteColumns * swatchSize);

                        int paletteSeparatorWidth = swatchSize;

                        int paletteWidth = singlePaletteWidth;

                        bool mappingSelected = _mappedPaletteIndex >= 0 && _mappedPaletteIndex < Palette.PaletteMaps.Count;

                        if (mappingSelected == true)
                        {
                            paletteWidth = (singlePaletteWidth * 2) + paletteSeparatorWidth;
                        }

                        int bitmapWidth = paletteWidth + borderSize;

                        int paletteRows = (int)Math.Ceiling((double)_palette.Colors.Count / (double)paletteColumns);

                        int bitmapHeight = (paletteRows * swatchSize) + borderSize;

                        _bmpPalette = new Bitmap(bitmapWidth, bitmapHeight);

                        Graphics gBitmap = Graphics.FromImage(_bmpPalette);

                        resetScrollbars();

                        // Probably a plain white background is fine for palettes.
                        gBitmap.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bitmapWidth, bitmapHeight));

                        // Determine which swatch the mouse is over. Could be on either the main palette or the mapping.
                        int mainPaletteX = 0;

                        int offsetToMapping = borderSize + singlePaletteWidth + paletteSeparatorWidth;

                        if (_mouseState.X < singlePaletteWidth)
                        {
                            mainPaletteX = _mouseState.X - borderSize;
                        }
                        else 
                        {
                            mainPaletteX = _mouseState.X - offsetToMapping;
                        }

                        int mouseOverSwatchXIndex = (int)(Math.Floor((double)mainPaletteX / swatchSize));
   
                        int mouseOverSwatchX = mouseOverSwatchXIndex * swatchSize;

                        int mouseOverSwatchYIndex = (int)(Math.Floor((double)_mouseState.Y / swatchSize));

                        int mouseOverSwatchY = mouseOverSwatchYIndex * swatchSize;

                        int mouseOverMappedSwatchX = mouseOverSwatchX + offsetToMapping;

                        int mouseOverMappedSwatchY = mouseOverSwatchY;

                        int mouseOverSwatchIndex = (mouseOverSwatchYIndex * paletteColumns) + mouseOverSwatchXIndex;

                        int row = 0;
                        int col = 0;

                        int index = 0;

                        foreach (Color c in _palette.Colors.Keys)
                        {
                            int x = col * swatchSize;
                            int y = row * swatchSize;

                            // Draw the default palette
                            gBitmap.FillRectangle(new SolidBrush(c), x, y, swatchSize, swatchSize);
                            gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1.0f), x, y, swatchSize, swatchSize);

                            // Draw the selected map.

                            if (_mappedPaletteIndex >= 0 && _mappedPaletteIndex < Palette.PaletteMaps.Count)
                            {
                                Color mappedColor = Color.White;

                                bool mappingExists = false;

                                if (Palette.PaletteMaps[_mappedPaletteIndex].Map.ContainsKey(c))
                                {
                                    mappedColor = Palette.PaletteMaps[_mappedPaletteIndex].Map[c];
                                    
                                    mappingExists = true;
                                }

                                if (mouseOverSwatchIndex == index)
                                {
                                    _mouseOverColor = c;
                                }

                                int mapX = borderSize + singlePaletteWidth + paletteSeparatorWidth + (col * swatchSize);
   
                                gBitmap.FillRectangle(new SolidBrush(mappedColor), mapX, y, swatchSize, swatchSize);
                                gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1.0f), mapX, y, swatchSize, swatchSize);

                                if (mappingExists == false)
                                {
                                    gBitmap.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(mapX, y), new Point(mapX + swatchSize, y + swatchSize));
                                    gBitmap.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(mapX, y + swatchSize), new Point(mapX + swatchSize, y));
                                }
                            }

                            col++;

                            if (col >= paletteColumns)
                            {
                                col = 0;

                                row++;
                            }

                            index++;
                        }

                        // Draw the selector
                        if (mouseOverSwatchXIndex >= 0 && mouseOverSwatchXIndex < paletteColumns && mouseOverSwatchIndex < _palette.Colors.Keys.Count && mappingSelected == true)
                        {
                            _mouseOverSwatchIndex = mouseOverSwatchIndex;

                            Pen selector = new Pen(new SolidBrush(Color.Orange), 3.0f);

                            //selector.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                            gBitmap.DrawRectangle(selector, mouseOverSwatchX, mouseOverSwatchY, swatchSize, swatchSize);

                            gBitmap.DrawRectangle(selector, mouseOverMappedSwatchX, mouseOverMappedSwatchY, swatchSize, swatchSize);
                        }

                        gBitmap.Dispose();

                        break;

                    case PaletteVisualization.Histogram:

                        borderSize = 20;

                        paletteColumns = _palette.Colors.Count;

                        swatchSize = (int)(8 * _scale);

                        bitmapWidth = (paletteColumns * swatchSize) + (borderSize * 2);

                        paletteRows = 10;

                        int separationPadding = 15;

                        int footerHeight = swatchSize + separationPadding;

                        int histogramHeight = paletteRows * swatchSize;

                        bitmapHeight = histogramHeight + footerHeight + (borderSize * 2);

                        _bmpPalette = new Bitmap(bitmapWidth, bitmapHeight);

                        gBitmap = Graphics.FromImage(_bmpPalette);

                        resetScrollbars();

                        // Probably a plain white background is fine for palettes.
                        gBitmap.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bitmapWidth, bitmapHeight));

                        int maxColorCount = 0;

                        foreach (ColorInfo ci in _palette.Colors.Values)
                        {
                            if (ci.Count > maxColorCount)
                            {
                                maxColorCount = ci.Count;
                            }
                        }

                        col = 0;

                        foreach (KeyValuePair<Color, ColorInfo> kvp in _palette.Colors)
                        {
                            float scaledHeight = (float)kvp.Value.Count / (float)maxColorCount;

                            int barHeight = (int)(scaledHeight * histogramHeight);

                            int x = borderSize + (col * swatchSize);

                            int y = borderSize + (histogramHeight - barHeight);

                            gBitmap.FillRectangle(new SolidBrush(kvp.Key), x, y, swatchSize, barHeight);
                            gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1.0f), x, y, swatchSize, barHeight);

                            gBitmap.FillRectangle(new SolidBrush(kvp.Key), x, borderSize + histogramHeight + separationPadding, swatchSize, swatchSize);
                            gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1.0f), x, borderSize + histogramHeight + separationPadding, swatchSize, swatchSize);

                            col++;
                        }

                        // Render the overlay. This really isn't the right place to do this, it should render the bitmap, and then
                        // render the overlay on top on mouse move. But it's fine, there's unliktely to be a noticable performance hit.
                        col = 0;

                        foreach (KeyValuePair<Color, ColorInfo> kvp in _palette.Colors)
                        {
                            float scaledHeight = (float)kvp.Value.Count / (float)maxColorCount;

                            int barHeight = (int)(scaledHeight * histogramHeight);

                            int x = borderSize + (col * swatchSize);

                            int y = borderSize + (histogramHeight - barHeight);

                            if (_mouseState.X >= x - hScroll.Value && _mouseState.X < x - hScroll.Value + swatchSize)
                            {
                                _mouseOverColorInfo = kvp.Value;

                                gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Orange), 3.0f), x, y, swatchSize, barHeight);

                                int swatchY = borderSize + histogramHeight + separationPadding;

                                gBitmap.DrawRectangle(new Pen(new SolidBrush(Color.Orange), 3.0f), x, swatchY, swatchSize, swatchSize);

                                string count = kvp.Value.Count.ToString();

                                Font f = new Font(FontFamily.GenericSansSerif, 8.0f);

                                SizeF stringSize = gBitmap.MeasureString(count, f);

                                gBitmap.DrawString(count, f, new SolidBrush(Color.Black), new PointF((float)x + ((float)swatchSize / 2.0f) - ((float)stringSize.Width / 2.0f), (float)swatchY + (float)stringSize.Height + 5.0f));
                            }

                            col++;
                        }

                        gBitmap.Dispose();

                        break;
                }

            }
            
            Graphics g = e.Graphics;

            int hscrollOffset = -1 * hScroll.Value;

            int vscrollOffset = -1 * vScroll.Value;

            // Scale the sprite sheet.
            int sourceWidth = _bmpPalette.Width;

            int sourceHeight = _bmpPalette.Height;

            // Scale the destination by the scaling factor.
            int destinationWidth = sourceWidth;

            int destinationHeight = sourceHeight;

            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(hscrollOffset, vscrollOffset, destinationWidth, destinationHeight);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.DrawImage(_bmpPalette, destRect, 0, 0, sourceWidth, sourceHeight, GraphicsUnit.Pixel, null);
        }

        private void PaletteControl_Load(object sender, EventArgs e)
        {
            resize();
        }

        private void PaletteControl_Resize(object sender, System.EventArgs e)
        {
            resize();
        }

        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbPalette.Refresh();
        }


        #endregion

        #region Event Dispatchers

        protected virtual void OnColorInfoSelected(ColorInfoSelectedEventArgs e)
        {
            ColorInfoSelected?.Invoke(this, e);
        }

        #endregion
    }

    #region Event Args

    public class ColorInfoSelectedEventArgs : System.EventArgs
    {
        public ColorInfoSelectedEventArgs(ColorInfo colorInfo)
        {
            _colorInfo = colorInfo;
        }

        public ColorInfo SelectedColorInfo
        {
            get { return _colorInfo; }
        }
        private ColorInfo _colorInfo = null;
    }

    #endregion

    public interface IPaletteControl
    {
        #region Events

        event ColorInfoSelectedHandler ColorInfoSelected;

        #endregion

        int MappedPaletteIndex { get; set; }

        Palette Palette { get; set; }

        PaletteVisualization Visualization { get; set; }
    }
}
