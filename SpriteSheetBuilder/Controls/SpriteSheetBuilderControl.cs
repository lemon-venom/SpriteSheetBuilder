using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SpriteSheetBuilder
{
    #region Delegates

    public delegate void BuildFinishedHandler(object sender, BuildFinishedEventArgs e);

    public delegate void BuildStartedHandler(object sender, BuildStartedEventArgs e);

    public delegate void ThemesChangedHandler(object sender, ThemesChangedEventArgs e);

    #endregion


    public partial class SpriteSheetBuilderControl : UserControl, ISpriteSheetBuilderControl
    {
        #region Events

        public event BuildFinishedHandler   BuildFinished;

        public event BuildStartedHandler    BuildStarted;

        public event ThemesChangedHandler   ThemesChanged;

        #endregion

        #region Constructors

        public SpriteSheetBuilderControl()
        {
            InitializeComponent();

            _progressDialog = new ProgressDialog(true);

            _progressDialog.CancelClicked += SpriteSheetBuilderControl_ProgressCancelClicked;
        }

        #endregion

        #region Private Variables

        private IBackgroundGenerator    _backgroundGenerator = new CheckeredBackgroundGenerator();

        private Bitmap                  _bmpSpriteSheet;

        private string                  _buildFileName = string.Empty;
        
        private bool                    _changesMade = false;

        private bool                    _isMouseDown = false;

        private List<ColorTheme>        _lstColorThemes = new List<ColorTheme>();
        
        private int                     _mouseX = 0;

        private int                     _mouseY = 0;

        private IOverlayGenerator       _overlayGenerator = new SheetBoundariesOverlayGenerator(); 

        private IProgressForm           _progressDialog;

        private SpriteSheetBuildFile    _spriteSheetBuildFile = new SpriteSheetBuildFile();

        #endregion

        #region Properties

        public BackgroundColorScheme BackgroundColorScheme
        {
            get
            {
                return _backgroundGenerator.BackgroundColorScheme;
            }
            set
            {
                _backgroundGenerator.BackgroundColorScheme = value;

                _backgroundGenerator.Regenerate();

                pbSheetPreview.Refresh();
            }
        }

        public bool ChangesMade
        {
            get { return _changesMade; }
        }

        public string CurrentBuildFileName
        {
            get { return _buildFileName; }
        }

        public Guid SelectedThemeId
        {
            get
            {
                return _selectedThemeId;
            }
        }
        private Guid _selectedThemeId;

        public int SelectedThemeIndex
        {
            get { return _themeIndex; }
            set
            {
                if (value >= 0 && value < _lstColorThemes.Count)
                {
                    _themeIndex = value;

                    _selectedThemeId = _lstColorThemes[_themeIndex].Id;

                    _backgroundGenerator.BackgroundColor1 = _lstColorThemes[_themeIndex].Color1;

                    _backgroundGenerator.BackgroundColor2 = _lstColorThemes[_themeIndex].Color2;

                    _backgroundGenerator.Regenerate();

                    pbSheetPreview.Refresh();
                }
            }
        }
        int _themeIndex = -1;

        public double Scale
        {
            get { return _scale; }
            set 
            {
                // Limit scale to a minimum of 0.25
                if (value >= 0.25)
                {
                    _scale = value;

                    // Resize the background
                    _backgroundGenerator.Regenerate();

                    _overlayGenerator.Regenerate();

                    resetScrollbars();

                    pbSheetPreview.Refresh();
                }
            }
        }
        private double _scale = 1;

        public bool ShowBoundaries
        {
            get { return _showBoundaries; }
            set
            {
                _showBoundaries = value;

                _overlayGenerator.Regenerate();

                pbSheetPreview.Refresh();
            }
        }
        private bool _showBoundaries = true;

        public List<ColorTheme> Themes 
        {
            get { return _lstColorThemes; } 
        }

        #endregion

        #region Public Functions

        public void AddImages(ImageSourceType imageSourceType, string[] filenames)
        {
        }

        public void BuildAlphaMask()
        {
            // Build can only happen if all parameters are set.
            if (_spriteSheetBuildFile.CellHeight == 0 || _spriteSheetBuildFile.CellWidth == 0 || _spriteSheetBuildFile.Columns == 0)
            {
                MessageBox.Show("Insufficient build parameters. Make sure the cell width, cell height, and columns parameters are set.");

                return;
            }

            if (_spriteSheetBuildFile.ImageSourceList.Count == 0)
            {
                MessageBox.Show("No image sources have been added to the sprite sheet. At least one image source must exist.");

                return;
            }

            // Dispose of the old bitmap object.
            if (_bmpSpriteSheet != null)
            {
                _bmpSpriteSheet.Dispose();
            }

            // Need to do an initial pass to determine how many images there are in total, from all sources.
            int imageCounter = 0;

            for (int i = 0; i < _spriteSheetBuildFile.ImageSourceList.Count; i++)
            {
                SheetImageSource imageSource = _spriteSheetBuildFile.ImageSourceList[i];

                imageCounter += imageSource.CellCount;
            }

            int bitmapWidth = _spriteSheetBuildFile.BorderWidth + (_spriteSheetBuildFile.Columns * _spriteSheetBuildFile.CellWidth);

            int rows = Convert.ToInt32(Math.Ceiling(((double)imageCounter / (double)_spriteSheetBuildFile.Columns)));

            int bitmapHeight = _spriteSheetBuildFile.BorderWidth + (rows * _spriteSheetBuildFile.CellHeight);

            _bmpSpriteSheet = new Bitmap(bitmapWidth, bitmapHeight);

            Graphics g = Graphics.FromImage(_bmpSpriteSheet);

            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), new System.Drawing.Rectangle(0, 0, bitmapWidth, bitmapHeight));

            imageCounter = 0;

            for (int i = 0; i < _spriteSheetBuildFile.ImageSourceList.Count; i++)
            {
                SheetImageSource imageSource = _spriteSheetBuildFile.ImageSourceList[i];

                Bitmap spriteImage = new Bitmap(imageSource.FileName);

                Bitmap alphaMaskImage = new Bitmap(spriteImage.Size.Width, spriteImage.Size.Height);

                Graphics gAlphaMask = Graphics.FromImage(alphaMaskImage);

                gAlphaMask.FillRegion(new SolidBrush(_spriteSheetBuildFile.BackgroundColor), new Region(new System.Drawing.Rectangle(0, 0, spriteImage.Size.Height, spriteImage.Size.Width)));

                gAlphaMask.Dispose();

                // Copy 
                for (int img_y = 0; img_y < spriteImage.Height; img_y++)
                {
                    for (int img_x = 0; img_x < spriteImage.Width; img_x++)
                    {
                        Color spriteColor = spriteImage.GetPixel(img_x, img_y);

                        // Copy the alpha channel from the sprite to the alpha channel of the mask.
                        Color alphaColor = Color.Transparent;

                        if (_spriteSheetBuildFile.AlphaChannel == AlphaChannel.Red)
                        {
                            alphaColor = Color.FromArgb(255, spriteColor.A, 0, 0);
                        }
                        else if (_spriteSheetBuildFile.AlphaChannel == AlphaChannel.Green)
                        {
                            alphaColor = Color.FromArgb(255, 0, spriteColor.A, 0);
                        }
                        else if (_spriteSheetBuildFile.AlphaChannel == AlphaChannel.Blue)
                        {
                            alphaColor = Color.FromArgb(255, 0, 0, spriteColor.A);
                        }
                        else if (_spriteSheetBuildFile.AlphaChannel == AlphaChannel.Grayscale)
                        {
                            alphaColor = Color.FromArgb(255, spriteColor.A, spriteColor.A, spriteColor.A);
                        }

                        // Set the alpha color pixel from the sprite bitmap to the alpha bitmap.
                        alphaMaskImage.SetPixel(img_x, img_y, alphaColor);
                    }
                }

                for (int j = 0; j < imageSource.CellCount; j++)
                {
                    int sourceCol = j % imageSource.Columns;

                    int sourceRow = Convert.ToInt32(Math.Floor((float)(j / imageSource.Columns)));

                    int destCol = imageCounter % _spriteSheetBuildFile.Columns;

                    int destRow = Convert.ToInt32(Math.Floor((float)(imageCounter / _spriteSheetBuildFile.Columns)));

                    int destX = destCol * _spriteSheetBuildFile.CellWidth;

                    // Apply a transform for alignment.
                    switch (_spriteSheetBuildFile.HorizontalAlignment)
                    {
                        case SheetCellHorizontalAlignment.Center:

                            destX += ((_spriteSheetBuildFile.CellWidth / 2) - (imageSource.CellWidth / 2));

                            break;
                    }

                    int destY = destRow * _spriteSheetBuildFile.CellHeight;

                    // Apply a transform for alignment.
                    switch (_spriteSheetBuildFile.VerticalAlignment)
                    {
                        case SheetCellVerticalAlignment.Bottom:

                            destY += (_spriteSheetBuildFile.CellHeight - imageSource.CellHeight);

                            break;
                    }

                    System.Drawing.Rectangle sourceRect = new System.Drawing.Rectangle(sourceCol * imageSource.CellWidth, 0, imageSource.CellWidth, imageSource.CellHeight);

                    System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(destX, destY, imageSource.CellWidth, imageSource.CellHeight);

                    //g.DrawImage(spriteImage, destRect, 0, 0, destRect.Width, destRect.Height, GraphicsUnit.Pixel, attr);
                    g.DrawImage(alphaMaskImage, destRect, sourceRect, GraphicsUnit.Pixel);

                    imageCounter++;
                }

                alphaMaskImage.Dispose();

                spriteImage.Dispose();
            }

            resize();

            lblInitialized.Visible = false;

            pbSheetPreview.Refresh();
            
            g.Dispose();
        }

        public void BuildSheet()
        {
            // Build can only happen if all parameters are set.
            if (_spriteSheetBuildFile.CellHeight == 0 || _spriteSheetBuildFile.CellWidth == 0 || _spriteSheetBuildFile.Columns == 0)
            {
                // This shows the message box behind the progress form. change it to return the error so it can show after the form is hidden. TODO
                MessageBox.Show("Insufficient build parameters. Make sure the cell width, cell height, and columns parameters are set.");

                return;
            }

            if (_spriteSheetBuildFile.ImageSourceList.Count == 0)
            {
                MessageBox.Show("No image sources have been added to the sprite sheet. At least one image source must exist.");

                return;
            }

            _progressDialog.Show(this);

            _progressDialog.SetCaption("Building sprite sheet...");

            _progressDialog.SetStatus("Building...");

            _progressDialog.CenterToScreen();

            btnBuild.Enabled = false;
            btnPalette.Enabled = false;
            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;
            pgImageSource.Enabled = false;
            pgSpriteSheet.Enabled = false;
            lstbxFiles.Enabled = false;
            btnExport.Enabled = false;

            OnBuildStarted(new BuildStartedEventArgs());

            bgWorkerBuildSheet.RunWorkerAsync();
        }

        public void EditThemes()
        {
            EditBackgroundThemesDialog themeEditor = new EditBackgroundThemesDialog();

            themeEditor.Themes = _lstColorThemes;

            themeEditor.ShowDialog(this);

            if (themeEditor.Changed == true)
            {
                _backgroundGenerator.Regenerate();

                pbSheetPreview.Refresh();

                OnThemesChanged(new ThemesChangedEventArgs());

                saveColorThemesList();
            }
        }

        public void ExportSheet()
        {
            exportSheet();
        }

        public void NewSpriteSheet()
        {
            newSpriteSheet();
        }

        public void OpenBuildFile(string filename)
        {
            openBuildFile(filename);
        }

        public void SaveBuildFile()
        {
            saveBuildFile();
        }

        #endregion

        #region Private Functions

        private void addImages(ImageSourceType imageSourceType, string[] filenames)
        {
            foreach (string filename in filenames)
            {
                SheetImageSource newSheetImageSource = new SheetImageSource(filename);

                Bitmap spriteImage;

                switch (imageSourceType)
                {
                    case ImageSourceType.Single:

                        newSheetImageSource.CellCount = 1;

                        newSheetImageSource.Columns = 1;

                        // Get the height and width from the image.
                        spriteImage = new Bitmap(filename);

                        newSheetImageSource.CellWidth = spriteImage.Width;

                        newSheetImageSource.CellHeight = spriteImage.Height;

                        spriteImage.Dispose();

                        break;

                    case ImageSourceType.Strip:

                        // Get the height and width from the image.
                        spriteImage = new Bitmap(filename);

                        newSheetImageSource.CellHeight = spriteImage.Height;

                        spriteImage.Dispose();

                        break;
                }

                extractPaletteFromImage(newSheetImageSource);

                _spriteSheetBuildFile.ImageSourceList.Add(newSheetImageSource);

                lstbxFiles.Items.Add(filename);

                _changesMade = true;
            }
        }

        private void addTheme(ColorTheme colorTheme)
        {
            Utilities.NameValidator.AddName(colorTheme.Name, "bgtheme");

            _lstColorThemes.Add(colorTheme);
        }

        private void buildSheet()
        {
            _backgroundGenerator.Regenerate();

            _overlayGenerator.Regenerate();

            // Dispose of the old bitmap object.
            if (_bmpSpriteSheet != null)
            {
                _bmpSpriteSheet.Dispose();
            }

            int columnsWidth = _spriteSheetBuildFile.Columns * _spriteSheetBuildFile.CellWidth;

            int paddingsWidth = (_spriteSheetBuildFile.Columns - 1) * _spriteSheetBuildFile.CellPadding;

            int borderWidth = (_spriteSheetBuildFile.BorderWidth * 2); // Border on each side.

            int bitmapWidth = columnsWidth + paddingsWidth + borderWidth;

            // Need to do an initial pass to determine how many images there are in total, from all sources.
            int totalImages = 0;

            for (int i = 0; i < _spriteSheetBuildFile.ImageSourceList.Count; i++)
            {
                SheetImageSource imageSource = _spriteSheetBuildFile.ImageSourceList[i];

                totalImages += imageSource.CellCount;
            }

            int rows = Convert.ToInt32(Math.Ceiling(((double)totalImages / (double)_spriteSheetBuildFile.Columns)));

            int rowsHeight = rows * _spriteSheetBuildFile.CellHeight;

            int paddingsHeight = (rows - 1) * _spriteSheetBuildFile.CellPadding;

            int borderHeight = (_spriteSheetBuildFile.BorderWidth * 2); // Border on each side.

            int bitmapHeight = rowsHeight + paddingsHeight + borderHeight;

            if (bitmapWidth > 0 && bitmapHeight > 0)
            {
                _bmpSpriteSheet = new Bitmap(bitmapWidth, bitmapHeight);

                Graphics g = Graphics.FromImage(_bmpSpriteSheet);

                // Offset the top left corner by the border size.
                int borderSize = _spriteSheetBuildFile.BorderWidth;

                g.FillRectangle(new SolidBrush(_spriteSheetBuildFile.BackgroundColor), new System.Drawing.Rectangle(borderSize, borderSize, bitmapWidth, bitmapHeight));

                int imageCounter = 0;

                for (int i = 0; i < _spriteSheetBuildFile.ImageSourceList.Count; i++)
                {
                    SheetImageSource imageSource = _spriteSheetBuildFile.ImageSourceList[i];

                    if (File.Exists(imageSource.FileName))
                    {
                        Bitmap spriteImageSource = new Bitmap(imageSource.FileName);

                        Bitmap spriteImageResult = new Bitmap(imageSource.FileName);

                        for (int j = 0; j < imageSource.CellCount; j++)
                        {
                            int sourceCol = j % imageSource.Columns;

                            int sourceRow = Convert.ToInt32(Math.Floor((float)(j / imageSource.Columns)));

                            int destCol = imageCounter % _spriteSheetBuildFile.Columns;

                            int destRow = Convert.ToInt32(Math.Floor((float)(imageCounter / _spriteSheetBuildFile.Columns)));

                            int destX = destCol * _spriteSheetBuildFile.CellWidth + borderSize;

                            // Apply a transform for alignment.
                            switch (_spriteSheetBuildFile.HorizontalAlignment)
                            {
                                case SheetCellHorizontalAlignment.Center:

                                    destX += ((_spriteSheetBuildFile.CellWidth / 2) - (imageSource.CellWidth / 2));

                                    break;

                                case SheetCellHorizontalAlignment.Right:

                                    destX += (_spriteSheetBuildFile.CellWidth - imageSource.CellWidth);

                                    break;
                            }

                            // Adjust by the padding value if this is not the first column.
                            if (destCol > 0)
                            {
                                destX += (_spriteSheetBuildFile.CellPadding * destCol);
                            }

                            int destY = destRow * _spriteSheetBuildFile.CellHeight + borderSize;

                            // Apply a transform for alignment
                            switch (_spriteSheetBuildFile.VerticalAlignment)
                            {
                                case SheetCellVerticalAlignment.Center:

                                    destY += ((_spriteSheetBuildFile.CellHeight / 2) - (imageSource.CellHeight / 2));

                                    break;

                                case SheetCellVerticalAlignment.Bottom:

                                    destY += (_spriteSheetBuildFile.CellHeight - imageSource.CellHeight);

                                    break;
                            }

                            // Adjust by the padding value if this is not the first row.
                            if (destRow > 0)
                            {
                                destY += (_spriteSheetBuildFile.CellPadding * destRow);
                            }

                            int sourceX = (sourceCol * (imageSource.CellWidth + imageSource.CellPadding)) + imageSource.Border;

                            int sourceY = (sourceRow * (imageSource.CellHeight + imageSource.CellPadding)) + imageSource.Border;

                            Rectangle sourceRect = new System.Drawing.Rectangle(sourceX, sourceY, imageSource.CellWidth, imageSource.CellHeight);

                            Rectangle destRect = new System.Drawing.Rectangle(destX, destY, imageSource.CellWidth, imageSource.CellHeight);

                            // Perform the palette mapping.
                            for (int y = 0; y < spriteImageSource.Height; y++)
                            {
                                for (int x = 0; x < spriteImageSource.Width; x++)
                                {
                                    Color sourcePixel = spriteImageSource.GetPixel(x, y);

                                    Color sourcePixelFullAlpha = Color.FromArgb(255, sourcePixel.R, sourcePixel.G, sourcePixel.B);

                                    // Implement palette swaps.

                                    PaletteMap paletteMap = null;

                                    for (int k = 0; k < _spriteSheetBuildFile.Palette.PaletteMaps.Count; k++)
                                    {
                                        if (_spriteSheetBuildFile.Palette.PaletteMaps[k].Id == _spriteSheetBuildFile.PaletteMapId)
                                        {
                                            paletteMap = _spriteSheetBuildFile.Palette.PaletteMaps[k];

                                            break;
                                        }
                                    }

                                    if (paletteMap != null)
                                    {
                                        if (paletteMap.Map.ContainsKey(sourcePixelFullAlpha))
                                        {
                                            Color mappedPixel = paletteMap.Map[sourcePixelFullAlpha];

                                            if (mappedPixel != sourcePixelFullAlpha)
                                            {
                                                // Reapply the source pixel alpha to the mapped color.
                                                Color finalMapping = Color.FromArgb(sourcePixel.A, mappedPixel.R, mappedPixel.G, mappedPixel.B);

                                                spriteImageResult.SetPixel(x, y, finalMapping);
                                            }
                                            else
                                            {
                                                // Mapping to itself.
                                                spriteImageResult.SetPixel(x, y, sourcePixel);
                                            }
                                        }
                                        else
                                        {
                                            spriteImageResult.SetPixel(x, y, sourcePixel);
                                        }
                                    }
                                }
                            }

                            //g.DrawImage(spriteImage, destRect, 0, 0, destRect.Width, destRect.Height, GraphicsUnit.Pixel, attr);
                            g.DrawImage(spriteImageResult, destRect, sourceRect, GraphicsUnit.Pixel);

                            imageCounter++;

                            bgWorkerBuildSheet.ReportProgress((int)(((double)imageCounter / (double)totalImages) * 100));

                            if (bgWorkerBuildSheet.CancellationPending)
                            {
                                break;
                            }
                        }

                        spriteImageSource.Dispose();

                        spriteImageResult.Dispose();
                    }

                    if (bgWorkerBuildSheet.CancellationPending)
                    {
                        break;
                    }
                }

                g.Dispose();
            }
            else
            {
                MessageBox.Show("Failed to create bitmap.");
            }
        }

        private void deleteSelectedImages()
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstbxFiles);

            selectedItems = lstbxFiles.SelectedItems;

            if (lstbxFiles.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < _spriteSheetBuildFile.ImageSourceList.Count; j++)
                    {
                        if (_spriteSheetBuildFile.ImageSourceList[j].FileName == selectedItems[i].ToString())
                        {
                            foreach (KeyValuePair<Color, ColorInfo> kvp in _spriteSheetBuildFile.ImageSourceList[j].Palette.Colors)
                            {
                                Color color = kvp.Key;

                                if (_spriteSheetBuildFile.Palette.Colors.ContainsKey(color))
                                {
                                    _spriteSheetBuildFile.Palette.Colors[color].Count--;

                                    _spriteSheetBuildFile.Palette.Colors[color].PresentInFiles.Remove(_spriteSheetBuildFile.ImageSourceList[j].FileName);

                                    if (_spriteSheetBuildFile.Palette.Colors[color].Count < 0)
                                    {
                                        System.Diagnostics.Debug.Print("Color reference counter went below 0. This shouldn't happen.");

                                        _spriteSheetBuildFile.Palette.Colors[color].Count = 0;
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Debug.Print("Color not found in global palette. This shouldn't happen.");
                                }
                            }

                            _spriteSheetBuildFile.ImageSourceList.RemoveAt(j);

                            _changesMade = true;

                            break;
                        }
                    }

                    lstbxFiles.Items.Remove(selectedItems[i]);
                }
            }
        }

        private void editPalettes()
        {
            EditPalettesDialog editPalettesForm = new EditPalettesDialog();

            editPalettesForm.ShowDialog(this, _spriteSheetBuildFile, _backgroundGenerator);
        }

        private void exportSheet()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();

                saveDialog.AddExtension = true;
                saveDialog.RestoreDirectory = true;
                saveDialog.DefaultExt = "png";
                saveDialog.Filter = "PNG Files|*.png";

                // Bring up the save dialog if it has not been saved yet, or if save as was clicked.
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    _bmpSpriteSheet.Save(saveDialog.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void extractPaletteFromImage(SheetImageSource imageSource)
        {
            try
            {
                // Bail if the image doesn't exist. Try again if the user corrects the missing file.
                if (File.Exists(imageSource.FileName) == false)
                {
                    return;
                }

                Bitmap spriteImage = new Bitmap(imageSource.FileName);

                for (int x = 0; x < spriteImage.Width; x++)
                {
                    for (int y = 0; y < spriteImage.Height; y++)
                    {
                        Color pixelColor = spriteImage.GetPixel(x, y);

                        // If this is full transparency, ignore it.
                        if (pixelColor.A > 0)
                        {
                            // Ignore transparency, just use the base color.
                            Color pixelColorFullAlpha = Color.FromArgb(255, pixelColor.R, pixelColor.G, pixelColor.B);

                            // Add to the image palette.
                            if (imageSource.Palette.Colors.ContainsKey(pixelColorFullAlpha) == false)
                            {
                                imageSource.Palette.Colors.Add(pixelColorFullAlpha, new ColorInfo());

                                // Increment the global palette.
                                if (_spriteSheetBuildFile.Palette.Colors.ContainsKey(pixelColorFullAlpha) == false)
                                {
                                    // Pretty sure this shouldn't happen. Should be stored and loaded in the file layout.
                                    // Just to be safe, add it here anyway.
                                    ColorInfo newColorInfo = new ColorInfo();

                                    newColorInfo.Count = 1;

                                    newColorInfo.PresentInFiles.Add(imageSource.FileName);

                                    _spriteSheetBuildFile.Palette.Colors.Add(pixelColorFullAlpha, newColorInfo);
                                }
                                else
                                {
                                    _spriteSheetBuildFile.Palette.Colors[pixelColorFullAlpha].PresentInFiles.Add(imageSource.FileName);

                                    _spriteSheetBuildFile.Palette.Colors[pixelColorFullAlpha].Count++;
                                }
                            }

                        }
                    }
                }

                spriteImage.Dispose();
            }
            catch (Exception ex) { 

            }
        }

        private void loadThemes()
        {
            string themesListRaw = Properties.Settings.Default["Themes"].ToString();

            char delimiter = (char)(255);

            foreach (string theme in themesListRaw.Split(delimiter))
            {
                if (theme != string.Empty)
                {
                    ColorTheme colorTheme;

                    if (ColorTheme.TryParse(theme, out colorTheme))
                    {
                        addTheme(colorTheme);
                    }
                }
            }
        }

        private void newSpriteSheet()
        {
            resetUi();

            // Create a new sprite sheet builder and clear the UI.
            _spriteSheetBuildFile = new SpriteSheetBuildFile();

            lstbxFiles.Items.Clear();

            pgSpriteSheet.SelectedObject = _spriteSheetBuildFile;

            pgSpriteSheet.Enabled = true;

            _changesMade = false;

            _buildFileName = string.Empty;

            lblInitialized.Visible = true;

            pbSheetPreview.BackColor = SystemColors.ControlDarkDark;

            btnExport.Enabled = false;

            Utilities.NameValidator.ClearAllNames("palette");

            // Create a palette name of empty string, for the default palette, so it can be selected from the dropdown.
            Utilities.NameValidator.AddName(string.Empty, "palette");
        }

        private void openBuildFile(string filename)
        {
            string fileConents = File.ReadAllText(filename);

            string[] fileData = fileConents.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string errorMessage = "Unable to open the sprite sheet build file. It's either missing data or incorrectly formatted.";

            // There should be a minimum of 3 lines, for the height, width, rows, and columns values.
            if (fileData.Length < 3)
            {
                MessageBox.Show(errorMessage);

                return;
            }

            try
            {
                newSpriteSheet();

                int headerSize = Convert.ToInt32(fileData[0]);
                int fieldsPerFile = Convert.ToInt32(fileData[1]);

                _spriteSheetBuildFile.Palette.Colors.Clear();

                _spriteSheetBuildFile.CellHeight = Convert.ToInt32(fileData[2]);
                _spriteSheetBuildFile.CellWidth = Convert.ToInt32(fileData[3]);
                _spriteSheetBuildFile.Columns = Convert.ToInt32(fileData[4]);
                _spriteSheetBuildFile.VerticalAlignment = (SheetCellVerticalAlignment)Convert.ToUInt32(fileData[5]);
                _spriteSheetBuildFile.HorizontalAlignment = (SheetCellHorizontalAlignment)Convert.ToUInt32(fileData[6]);

                if (headerSize >= 8)
                {
                    _spriteSheetBuildFile.Palette.DeserializeFromString(fileData[7]);
                }

                if (headerSize >= 9)
                {
                    var colorStr = fileData[8].Split(',');

                    Color bgColor = Color.FromArgb(Convert.ToInt32(colorStr[3]), Convert.ToInt32(colorStr[0]), Convert.ToInt32(colorStr[1]), Convert.ToInt32(colorStr[2]));

                    _spriteSheetBuildFile.BackgroundColor = bgColor;
                }

                if (headerSize >= 10)
                {
                    var alphaChannel = fileData[9];
                                       
                    _spriteSheetBuildFile.AlphaChannel = (AlphaChannel)Convert.ToUInt32(alphaChannel);
                }

                if (headerSize >= 11)
                {
                    _spriteSheetBuildFile.CellPadding = Convert.ToInt32(fileData[10]);
                }

                if (headerSize >= 12)
                {
                    _spriteSheetBuildFile.BorderWidth = Convert.ToInt32(fileData[10]);
                }

                for (int i = headerSize; i < fileData.Length; i += fieldsPerFile)
                {
                    string fileName = fileData[i];

                    SheetImageSource sheetImageSource = new SheetImageSource(fileName);

                    if (fieldsPerFile > 1)
                    {
                        sheetImageSource.CellWidth = Convert.ToInt32(fileData[i + 1]);
                        sheetImageSource.CellHeight = Convert.ToInt32(fileData[i + 2]);
                        sheetImageSource.Columns = Convert.ToInt32(fileData[i + 3]);
                        sheetImageSource.CellCount = Convert.ToInt32(fileData[i + 4]);
                    }

                    // Padding and Border added as a part of an updated layout.
                    if (fieldsPerFile > 5)
                    {
                        sheetImageSource.Border = Convert.ToInt32(fileData[i + 5]);
                        sheetImageSource.CellPadding = Convert.ToInt32(fileData[i + 6]);
                    }

                    _spriteSheetBuildFile.ImageSourceList.Add(sheetImageSource);

                    extractPaletteFromImage(sheetImageSource);
                }

                // Check for any unused colors in the palette and ask the user if they want to clear them.
                List<Color> emptyColors = new List<Color>();

                foreach (KeyValuePair<Color, ColorInfo> kvp in _spriteSheetBuildFile.Palette.Colors)
                {
                    if (kvp.Value.Count == 0)
                    {
                        emptyColors.Add(kvp.Key);
                    }
                }

                if (emptyColors.Count > 0)
                {
                    string msg = "There are " + emptyColors.Count.ToString() + " colors in the palette that are not in any of the images. Do you want to remove them from the palette?";

                    if (MessageBox.Show(msg, "Remove Unused Colors?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (Color c in emptyColors)
                        {
                            _spriteSheetBuildFile.Palette.Colors.Remove(c);
                        }
                    }
                }

                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorMessage);
            }

            _changesMade = false;

            resetUi();

            showMissingFilesDialog();

            _buildFileName = filename;

            pgSpriteSheet.SelectedObject = _spriteSheetBuildFile;
        }

        private void resetScrollbars()
        {
            if (_bmpSpriteSheet != null)
            {
                int vScrollMax = (int)(_bmpSpriteSheet.Height * _scale) - pbSheetPreview.Height;

                if (vScrollMax > 0)
                {
                    vsSpriteSheet.Maximum = vScrollMax;
                }
                else
                {
                    vsSpriteSheet.Maximum = vsSpriteSheet.Minimum;
                }

                int hScrollMax = (int)(_bmpSpriteSheet.Width * _scale) - pbSheetPreview.Width;

                if (hScrollMax > 0)
                {
                    hsSpriteSheet.Maximum = hScrollMax;
                }
                else
                {
                    hsSpriteSheet.Maximum = hsSpriteSheet.Minimum;
                }
            }
        }

        private void resetUi()
        {
            lblInitialized.Text = "Sheet Not Built\r\nClick The Build Sheet Button To Generate The Sprite Sheet";

            pgImageSource.SelectedObject = null;

            btnExport.Enabled = false;
        }

        private void resize()
        {
            pbSheetPreview.Width = scImages.Panel2.ClientSize.Width - vsSpriteSheet.Width;
            pbSheetPreview.Height = scImages.Panel2.ClientSize.Height - hsSpriteSheet.Height;

            hsSpriteSheet.Top = pbSheetPreview.ClientSize.Height;
            hsSpriteSheet.Width = pbSheetPreview.ClientSize.Width;

            vsSpriteSheet.Left = pbSheetPreview.ClientSize.Width;
            vsSpriteSheet.Height = pbSheetPreview.ClientSize.Height;

            resetScrollbars();

            pbSheetPreview.Refresh();
        }

        private void saveBuildFile()
        {
            try
            {
                string defaultName = String.Empty;

                bool showDialog = false;

                if (String.IsNullOrEmpty(_buildFileName) == true)
                {
                    showDialog = true;
                }
                else
                {
                    defaultName = _buildFileName;
                }

                if (showDialog == true)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();

                    saveDialog.DefaultExt = "build";
                    saveDialog.AddExtension = true;
                    saveDialog.RestoreDirectory = true;
                    saveDialog.Filter = "Sprite Sheet Build Files (*.build)|*.build";
                    saveDialog.FileName = Path.GetFileName(defaultName);
                    //saveDialog.InitialDirectory = project.ProjectFolderFullPath;

                    // Bring up the save dialog if it has not been saved yet, or if save as was clicked.
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        _buildFileName = saveDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                try
                {
                    string fileContents = string.Empty;

                    int headerFields = 12;
                    int fieldsPerFile = 7;
                    fileContents += headerFields.ToString() + Environment.NewLine;
                    fileContents += fieldsPerFile.ToString() + Environment.NewLine;
                    fileContents += _spriteSheetBuildFile.CellHeight.ToString() + Environment.NewLine;
                    fileContents += _spriteSheetBuildFile.CellWidth.ToString() + Environment.NewLine;
                    fileContents += _spriteSheetBuildFile.Columns.ToString() + Environment.NewLine;
                    fileContents += Convert.ToUInt32(_spriteSheetBuildFile.VerticalAlignment).ToString() + Environment.NewLine;
                    fileContents += Convert.ToUInt32(_spriteSheetBuildFile.HorizontalAlignment).ToString() + Environment.NewLine;

                    string palette = _spriteSheetBuildFile.Palette.SerializeToString();

                    fileContents += (palette + Environment.NewLine);

                    Color bgColor = _spriteSheetBuildFile.BackgroundColor;

                    fileContents += bgColor.R.ToString() + "," + bgColor.G.ToString() + "," + bgColor.B.ToString() + "," + bgColor.A.ToString() + Environment.NewLine;

                    fileContents += Convert.ToUInt32(_spriteSheetBuildFile.AlphaChannel).ToString() + Environment.NewLine;

                    fileContents += _spriteSheetBuildFile.CellPadding + Environment.NewLine;

                    fileContents += _spriteSheetBuildFile.BorderWidth;

                    // Rows can be calculated implicitly using the total images and the columns.

                    foreach (SheetImageSource imageSource in _spriteSheetBuildFile.ImageSourceList)
                    {
                        fileContents += Environment.NewLine + imageSource.FileName;
                        fileContents += Environment.NewLine + imageSource.CellWidth.ToString();
                        fileContents += Environment.NewLine + imageSource.CellHeight.ToString();
                        fileContents += Environment.NewLine + imageSource.Columns.ToString();
                        fileContents += Environment.NewLine + imageSource.CellCount.ToString();
                        fileContents += Environment.NewLine + imageSource.Border.ToString();
                        fileContents += Environment.NewLine + imageSource.CellPadding.ToString();
                    }

                    File.WriteAllText(_buildFileName, fileContents);

                    _changesMade = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error Saving Sprite Sheet Build File", MessageBoxButtons.OK);
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveColorThemesList()
        {
            string colorThemesList = string.Empty;

            char delimiter = (char)(255);

            foreach (ColorTheme theme in _lstColorThemes)
            {
                if (colorThemesList != string.Empty)
                {
                    colorThemesList += delimiter;
                }

                colorThemesList += theme.ToString();
            }

            Properties.Settings.Default["Themes"] = colorThemesList;

            Properties.Settings.Default.Save();
        }

        private void showAddFilesDialog(ImageSourceType imageSourceType)
        {
            ofdAddImages.CheckFileExists = true;
            ofdAddImages.CheckPathExists = true;
            ofdAddImages.DefaultExt = "png";
            ofdAddImages.Filter = "PNG Files|*.png";
            ofdAddImages.FileName = string.Empty;
            ofdAddImages.Multiselect = true;
            ofdAddImages.RestoreDirectory = true;

            if (ofdAddImages.ShowDialog() == DialogResult.OK)
            {
                addImages(imageSourceType, ofdAddImages.FileNames);
            }
        }

        private void showMissingFilesDialog()
        {
            int missingFiles = 0;

            foreach (SheetImageSource imageSource in _spriteSheetBuildFile.ImageSourceList)
            {
                if (File.Exists(imageSource.FileName) == false)
                {
                    imageSource.Exists = false;

                    missingFiles++;
                }
            }

            lstbxFiles.Items.Clear();

            if (missingFiles > 0)
            {
                MissingFilesDialog missingFilesDialog = new MissingFilesDialog(_spriteSheetBuildFile);

                missingFilesDialog.ShowDialog(this);

                btnFixErrors.Visible = false;

                if (missingFilesDialog.MissingFileCount > 0)
                {
                    btnFixErrors.Visible = true;
                }
                else
                {
                    btnFixErrors.Visible = false;
                }
            }

            foreach (SheetImageSource imageSource in _spriteSheetBuildFile.ImageSourceList)
            {
                // Retry to extract palettes. Currently doing all files, but this could be optimized
                // to only check for images that were changed.
                // Potentially could be slow for very large list of files.
                extractPaletteFromImage(imageSource);

                lstbxFiles.Items.Add(imageSource.FileName);
            }
        }

        #endregion

        #region Event Handlers

        private void bgWorkerBuildSheet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            buildSheet();
        }

        private void bgWorkerBuildSheet_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _progressDialog.SetStatus(e.ProgressPercentage.ToString() + "% done.");
        }

        private void bgWorkerBuildSheet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnPalette.Enabled = true;
            btnBuild.Enabled = true;
            btnMoveDown.Enabled = true;
            btnMoveUp.Enabled = true;
            pgImageSource.Enabled = true;
            pgSpriteSheet.Enabled = true;
            lstbxFiles.Enabled = true;
            btnExport.Enabled = true;

            lblInitialized.Visible = false;

            _progressDialog.Hide();

            OnBuildFinished(new BuildFinishedEventArgs());

            resize();

            pbSheetPreview.Refresh();

            // TODO Raise an event that the sheet is finished building, so the host form can reenable menu items
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            BuildSheet();
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Remove image source files from the list?", "Remove Image Source Files?", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                deleteSelectedImages();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportSheet();
        }

        private void btnFixErrors_Click(object sender, EventArgs e)
        {
            showMissingFilesDialog();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstbxFiles.SelectedIndices.Count == 1)
            {
                int selectedIndex = lstbxFiles.SelectedIndices[0];

                if (selectedIndex > 0)
                {
                    int newIndex = selectedIndex - 1;

                    var selectedItem = lstbxFiles.SelectedItem;

                    var imageSource = _spriteSheetBuildFile.ImageSourceList[selectedIndex];

                    _spriteSheetBuildFile.ImageSourceList.RemoveAt(selectedIndex);

                    _spriteSheetBuildFile.ImageSourceList.Insert(newIndex, imageSource);

                    // Removing removable element
                    lstbxFiles.Items.Remove(selectedItem);

                    // Insert it in new position
                    lstbxFiles.Items.Insert(newIndex, selectedItem);

                    // Restore selection
                    lstbxFiles.SetSelected(newIndex, true);
                }
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstbxFiles.SelectedIndices.Count == 1)
            {
                int selectedIndex = lstbxFiles.SelectedIndices[0];

                if (selectedIndex < lstbxFiles.Items.Count - 1)
                {
                    int newIndex = selectedIndex + 1;

                    var selectedItem = lstbxFiles.SelectedItem;

                    var imageSource = _spriteSheetBuildFile.ImageSourceList[selectedIndex];

                    _spriteSheetBuildFile.ImageSourceList.RemoveAt(selectedIndex);

                    _spriteSheetBuildFile.ImageSourceList.Insert(newIndex, imageSource);

                    // Removing removable element
                    lstbxFiles.Items.Remove(selectedItem);

                    // Insert it in new position
                    lstbxFiles.Items.Insert(newIndex, selectedItem);

                    // Restore selection
                    lstbxFiles.SetSelected(newIndex, true);
                }
            }
        }

        private void btnPalette_Click(object sender, EventArgs e)
        {
            editPalettes();

            // Refresh the property grid, in case the selected palette was deleted.
            pgSpriteSheet.Refresh();
        }

        private void hsSpriteSheet_Scroll(object sender, ScrollEventArgs e)
        {
            pbSheetPreview.Refresh();
        }

        private void lstbxFiles_DoubleClick(object sender, EventArgs e)
        {
            string selectedImageName = lstbxFiles.Items[lstbxFiles.SelectedIndex].ToString();

            int selectedImageIndex = 0;

            // Stupid linear search.
            for (int i = 0; i < _spriteSheetBuildFile.ImageSourceList.Count; i++)
            {
                if (_spriteSheetBuildFile.ImageSourceList[i].FileName == selectedImageName)
                {
                    selectedImageIndex = i;

                    break;
                }
            }

            var imageSource = _spriteSheetBuildFile.ImageSourceList[selectedImageIndex];

            Utilities.ImageViewer.ShowImage(this, imageSource, _backgroundGenerator);
        }

        private void lstbxFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult res = MessageBox.Show("Remove image source files from the list?", "Remove Image Source Files?", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    deleteSelectedImages();
                }
            }
        }

        private void lstbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstbxFiles);

            btnMoveUp.Enabled = lstbxFiles.SelectedIndices.Count == 1;
            btnMoveDown.Enabled = lstbxFiles.SelectedIndices.Count == 1;

            selectedItems = lstbxFiles.SelectedItems;

            List<SheetImageSource> lstImageSources = new List<SheetImageSource>();

            for (int i = 0; i < lstbxFiles.SelectedIndices.Count; i++)
            {
                int selectedIndex = lstbxFiles.SelectedIndices[i];

                lstImageSources.Add(_spriteSheetBuildFile.ImageSourceList[selectedIndex]);
            }

            pgImageSource.SelectedObjects = lstImageSources.ToArray();
        }

        private void pbSheetPreview_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;

            _mouseX = e.X;

            _mouseY = e.Y;
        }

        private void pbSheetPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown == true)
            {
                int deltaX = _mouseX - e.X;

                int deltaY = _mouseY - e.Y;

                System.Diagnostics.Debug.Print(deltaX.ToString() + ", " + deltaY.ToString());

                _mouseX = e.X;

                _mouseY = e.Y;

                if (hsSpriteSheet.Value + deltaX < hsSpriteSheet.Minimum)
                {
                    hsSpriteSheet.Value = hsSpriteSheet.Minimum;
                }
                else if (hsSpriteSheet.Value + deltaX > hsSpriteSheet.Maximum)
                {
                    hsSpriteSheet.Value = hsSpriteSheet.Maximum;
                }
                else
                {
                    hsSpriteSheet.Value += deltaX;
                }

                if (vsSpriteSheet.Value + deltaY < vsSpriteSheet.Minimum)
                {
                    vsSpriteSheet.Value = vsSpriteSheet.Minimum;
                }
                else if (vsSpriteSheet.Value + deltaY > vsSpriteSheet.Maximum)
                {
                    vsSpriteSheet.Value = vsSpriteSheet.Maximum;
                }
                else
                {
                    vsSpriteSheet.Value += deltaY;
                }

                pbSheetPreview.Refresh();
            }
        }

        private void pbSheetPreview_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void pbSheetPreview_Paint(object sender, PaintEventArgs e)
        {
            if (_bmpSpriteSheet != null)
            {
                Graphics g = e.Graphics;

                Bitmap bmpBackground = _backgroundGenerator.GenerateBackground((int)(_bmpSpriteSheet.Width * _scale), (int)(_bmpSpriteSheet.Height * _scale));

                g.DrawImage(bmpBackground, new Point(0, 0));

                int hscrollOffset = -1 * hsSpriteSheet.Value;

                int vscrollOffset = -1 * vsSpriteSheet.Value;

                // Scale the sprite sheet.
                int sourceWidth = _bmpSpriteSheet.Width;

                int sourceHeight = _bmpSpriteSheet.Height;

                // Scale the destination by the scaling factor.
                int destinationWidth = (int)(sourceWidth * _scale);

                int destinationHeight = (int)(sourceHeight * _scale);

                System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(hscrollOffset, vscrollOffset, destinationWidth, destinationHeight);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.DrawImage(_bmpSpriteSheet, destRect, 0, 0, _bmpSpriteSheet.Width, _bmpSpriteSheet.Height, GraphicsUnit.Pixel, null);

                if (_showBoundaries == true)
                {
                    Bitmap bmpOverlay = _overlayGenerator.Generate(_spriteSheetBuildFile);

                    g.DrawImage(bmpOverlay, destRect, 0, 0, bmpOverlay.Width, bmpOverlay.Height, GraphicsUnit.Pixel, null);
                }
            }
        }

        private void pgSpriteSheet_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.Label.ToUpper())
            {
                case "PALETTE":
                    // Palette isn't saved as part of the build file layout.
                    // Don't need to flag it as a change.
                    break;

                case "BORDER WIDTH":

                    _backgroundGenerator.Regenerate();

                    _overlayGenerator.Regenerate();

                    _changesMade = true;

                    break;

                default:

                    // Everything else affects the file layout. Flag it as having changed.

                    _changesMade = true;

                    break;
            }

        }

        private void scImages_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resize();
        }

        private void SpriteSheetBuilderControl_Load(object sender, EventArgs e)
        {
            pgSpriteSheet.Focus();

            pgSpriteSheet.SelectedObject = _spriteSheetBuildFile;

            loadThemes();

            OnThemesChanged(new ThemesChangedEventArgs());

            resize();
        }

        private void SpriteSheetBuilderControl_ProgressCancelClicked(object sender, EventArgs e)
        {
            bgWorkerBuildSheet.CancelAsync();
        }

        private void SpriteSheetBuilderControl_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void tsmiAddSingleImage_Click(object sender, EventArgs e)
        {
            showAddFilesDialog(ImageSourceType.Single);
        }

        private void tsmiAddImageSheet_Click(object sender, EventArgs e)
        {
            showAddFilesDialog(ImageSourceType.Sheet);
        }

        private void tsmiAddImageStrip_Click(object sender, EventArgs e)
        {
            showAddFilesDialog(ImageSourceType.Strip);
        }

        private void vsSpriteSheet_Scroll(object sender, ScrollEventArgs e)
        {
            pbSheetPreview.Refresh();
        }

        #endregion

        #region Event Dispatchers

        protected virtual void OnBuildFinished(BuildFinishedEventArgs e)
        {
            BuildFinished?.Invoke(this, e);
        }

        protected virtual void OnBuildStarted(BuildStartedEventArgs e)
        {
            BuildStarted?.Invoke(this, e);
        }


        protected virtual void OnThemesChanged(ThemesChangedEventArgs e)
        {
            ThemesChanged?.Invoke(this, e);
        }


        #endregion
    }

    #region Event Args

    public class BuildFinishedEventArgs : System.EventArgs
    {
        public BuildFinishedEventArgs()
        {
        }
    }

    public class BuildStartedEventArgs : System.EventArgs
    {
        public BuildStartedEventArgs()
        {
        }
    }

    public class ThemesChangedEventArgs : System.EventArgs
    {
        public ThemesChangedEventArgs()
        {
        }
    }

    #endregion

    public interface ISpriteSheetBuilderControl
    {
        #region Events

        event BuildFinishedHandler BuildFinished;

        event BuildStartedHandler BuildStarted;

        event ThemesChangedHandler ThemesChanged;

        #endregion


        #region Properties

        BackgroundColorScheme BackgroundColorScheme { get; set; }

        bool ChangesMade { get; }

        bool Enabled { get; set; }

        string CurrentBuildFileName { get; }

        Guid SelectedThemeId { get; }

        int SelectedThemeIndex { get; set; }

        List<ColorTheme> Themes { get; }

        double Scale { get; set; }

        bool ShowBoundaries { get; set; }

        #endregion

        #region Public Functions

        void AddImages(ImageSourceType imageSourceType, string[] filenames);

        void BuildAlphaMask();

        void BuildSheet();

        void EditThemes();

        void ExportSheet();

        void NewSpriteSheet();

        void OpenBuildFile(string filename);

        void SaveBuildFile();

        #endregion
    }
}
