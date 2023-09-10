using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace SpriteSheetBuilder
{
    public partial class SpriteSheetBuilderForm : Form, ISpriteSheetBuilderDialog
    {
        #region Constructors

        public SpriteSheetBuilderForm()
        {
            InitializeComponent();

            spriteSheetBuilder = new SpriteSheetBuilderControl();

            SpriteSheetBuilderControl spriteSheetBuilderControl = (SpriteSheetBuilderControl)spriteSheetBuilder;

            spriteSheetBuilderControl.Dock = DockStyle.Fill;
            
            this.Controls.Add(spriteSheetBuilderControl);

            spriteSheetBuilderControl.BringToFront();

            spriteSheetBuilder.Enabled = false;

            spriteSheetBuilder.BuildStarted += SpriteSheetBuilder_BuildStarted;

            spriteSheetBuilder.BuildFinished += SpriteSheetBuilder_BuildFinished;

            spriteSheetBuilder.ThemesChanged += SpriteSheetBuilder_ThemesChanged;
        }

        #endregion

        #region Private Variables

        private Dictionary<string, ToolStripMenuItem>   _dictThemeMenuItems = new Dictionary<string, ToolStripMenuItem>();

        private List<string>                            _recentlyOpenedFiles = new List<string>();

        ISpriteSheetBuilderControl                      spriteSheetBuilder;

        #endregion

        #region Public Functions

        new public void ShowDialog(IWin32Window owner)
        {
            base.ShowDialog(owner);
        }

        #endregion

        #region Private Functions

        private void addRecentFile(string filePath)
        {
            if (_recentlyOpenedFiles.Contains(filePath) == false)
            {
                if (File.Exists(filePath) == true)
                {
                    _recentlyOpenedFiles.Add(filePath);

                    ToolStripMenuItem mnuRecentFile = new ToolStripMenuItem();

                    // Might want to truncate file names that have long paths?
                    mnuRecentFile.Text = filePath;

                    // Store the full path in the tag.
                    mnuRecentFile.Tag = filePath;

                    mnuRecentFile.Click += new System.EventHandler(this.mnuOpenRecentFile_Click);

                    recentFilesToolStripMenuItem.DropDownItems.Add(mnuRecentFile);

                    recentFilesToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void loadRecentProjectsList()
        {
            string recentlyOpenedFilesListRaw = Properties.Settings.Default["RecentlyOpenedFiles"].ToString();

            char delimiter = (char)(255);

            foreach (string filename in recentlyOpenedFilesListRaw.Split(delimiter))
            {
                addRecentFile(filename);
            }
        }

        private void openBuildFile(string filename)
        {
            if (spriteSheetBuilder.ChangesMade == true)
            {
                DialogResult res = MessageBox.Show("Changes have been made to the current sprite sheet build file. Do you want to save?", "Save Changes?", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Yes)
                {
                    spriteSheetBuilder.SaveBuildFile();
                }
                else if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (string.IsNullOrEmpty(filename))
            {
                OpenFileDialog openDialog = new OpenFileDialog();

                openDialog.CheckFileExists = true;
                openDialog.CheckPathExists = true;
                openDialog.DefaultExt = "build";
                openDialog.Filter = "Sprite Sheet Build Files (*.build)|*.build";
                openDialog.Multiselect = false;
                openDialog.RestoreDirectory = true;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    spriteSheetBuilder.OpenBuildFile(openDialog.FileName);

                    addRecentFile(openDialog.FileName);

                    saveRecentFilesList();

                    enableItems();
                }
            }
            else
            {
                spriteSheetBuilder.OpenBuildFile(filename);

                enableItems();
            }
        }

        private void rebuildThemes()
        {
            // Start fresh.
            customToolStripMenuItem.DropDownItems.Clear();

            bool themeSelected = false;

            foreach (var theme in spriteSheetBuilder.Themes)
            {
                ToolStripMenuItem tsmiTheme = new ToolStripMenuItem();

                tsmiTheme.Text = theme.Name;
                tsmiTheme.Tag = theme.Id;

                tsmiTheme.Click += SpriteSheetBuilderDialog_ThemeClick;

                customToolStripMenuItem.DropDownItems.Add(tsmiTheme);

                // Need to store the menu items on load so the intial item can be checked if needed.
                if (_dictThemeMenuItems.ContainsKey(theme.Name) == false)
                {
                    _dictThemeMenuItems.Add(theme.Name, tsmiTheme);
                }

                if (theme.Id == spriteSheetBuilder.SelectedThemeId && spriteSheetBuilder.BackgroundColorScheme == BackgroundColorScheme.UserDefined)
                {
                    tsmiTheme.Checked = true;

                    themeSelected = true;
                }
            }

            // No theme was selected. The selected theme must have been deleted. Revert to standard.
            if (themeSelected == false && spriteSheetBuilder.BackgroundColorScheme == BackgroundColorScheme.UserDefined)
            {
                standardBgToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        private void saveRecentFilesList()
        {
            string recentlyOpenedFilesList = string.Empty;

            char delimiter = (char)(255);

            foreach (string filename in _recentlyOpenedFiles)
            {
                if (recentlyOpenedFilesList != string.Empty)
                {
                    recentlyOpenedFilesList += delimiter;
                }

                recentlyOpenedFilesList += filename;
            }

            Properties.Settings.Default["RecentlyOpenedFiles"] = recentlyOpenedFilesList;

            Properties.Settings.Default.Save();
        }

        private void enableItems()
        {
            //tsbAddImages.Enabled = true;
            //tsbExportSpriteSheet.Enabled = true;
            sheetToolStripMenuItem.Enabled = true;
            singleImageToolStripMenuItem.Enabled = true;
            stripToolStripMenuItem.Enabled = true;

            addImagesToolStripMenuItem.Enabled = true;
            buildSpriteSheetToolStripMenuItem.Enabled = true;
            saveSpriteSheetBuildFileToolStripMenuItem.Enabled = true;
            buildAlphaMaskSheetToolStripMenuItem.Enabled = true;

            spriteSheetBuilder.Enabled = true;
        }

        #endregion

        #region Event Handlers

        private void bgThemesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSheetBuilder.EditThemes();
        }

        private void mnuOpenRecentFile_Click(object sender, System.EventArgs e)
        {
            string fileNameToOpen = ((ToolStripMenuItem)sender).Tag.ToString();

            if (spriteSheetBuilder.CurrentBuildFileName != fileNameToOpen)
            {
                openBuildFile(fileNameToOpen);
            }
        }

        private void openSpriteSheetBuildFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openBuildFile(string.Empty);
        }

        private void saveSpriteSheetBuildFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSheetBuilder.SaveBuildFile();
        }

        private void singleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //spriteSheetBuilder.AddImages();
        }

        private void stripToolStripMenuItem_Click(object sender, EventArgs e)
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
                spriteSheetBuilder.AddImages(ImageSourceType.Strip, ofdAddImages.FileNames);
            }
        }

        private void sheetToolStripMenuItem_Click(object sender, EventArgs e)
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
                spriteSheetBuilder.AddImages(ImageSourceType.Sheet, ofdAddImages.FileNames);
            }
        }

        private void SpriteSheetBuilderDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ShowInTaskbar == false)
            {
                e.Cancel = true;

                this.Hide();
            }
        }

        private void exportSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSheetBuilder.ExportSheet();
        }

        private void newSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableItems();

            spriteSheetBuilder.NewSpriteSheet();
        }

        private void buildSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSheetBuilder.BuildSheet();

            exportSheetToolStripMenuItem.Enabled = true;
        }

        private void buildAlphaMaskSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSheetBuilder.BuildAlphaMask();

            exportSheetToolStripMenuItem.Enabled = true;
        }

        private void SpriteSheetBuilderDialog_Load(object sender, EventArgs e)
        {
            loadRecentProjectsList();

            bool showBoundaries = false;

            if (Boolean.TryParse(Properties.Settings.Default["ShowBoundaries"].ToString(), out showBoundaries))
            {
                if (showBoundaries == true) 
                {
                    showBoundariesToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.ShowBoundaries = true;

                } 
                else 
                {
                    showBoundariesToolStripMenuItem.Checked = false;

                    spriteSheetBuilder.ShowBoundaries = false;
                }
            }



            double scale = 1.0;
            
            Double.TryParse(Properties.Settings.Default["Scale"].ToString(), out scale);

            // Only use 1, 2, and 3 for now. Consider changing later.
            if (scale == 1.0)
            {
                tsScale1x.Checked = true;
            }
            else if (scale == 2.0)
            {
                tsScale2x.Checked = true;
            }
            else if (scale == 3.0)
            {
                tsScale3x.Checked = true;
            }

            spriteSheetBuilder.Scale = scale;

           string themeName = Properties.Settings.Default["SelectedTheme"].ToString();

           switch (themeName)
            {
                case "Light":
                    standardBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardLight;

                    break;

                case "Dark":
                    darkBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardDark;

                    break;

                case "Geode":
                    vividBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Vivid;

                    break;

                case "Radioactive":
                    neonBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Neon;

                    break;

                case "Easter Egg":
                    pastelBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Pastel;

                    break;

                case "Tomato":
                    tomatoBgToolStripMenuItem.Checked = true;

                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Tomato;

                    break;

                default:
                    spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.UserDefined;

                    customToolStripMenuItem.Checked = true;

                    // Look up the theme name.
                    for (int i = 0; i < spriteSheetBuilder.Themes.Count; i++)
                    {
                        if (spriteSheetBuilder.Themes[i].Name == themeName)
                        {
                            spriteSheetBuilder.SelectedThemeIndex = i;

                            _dictThemeMenuItems[themeName].Checked = true;

                            break;
                        }
                    }
                    break;
            }


        }

        private void standardBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            standardBgToolStripMenuItem.Checked = true;

            // Disable the others
            darkBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            tomatoBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardLight;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void darkBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            darkBgToolStripMenuItem.Checked = true;

            // Disable the others
            standardBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            tomatoBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardDark;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void vividBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            vividBgToolStripMenuItem.Checked = true;

            // Disable the others
            standardBgToolStripMenuItem.Checked = false;

            darkBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            tomatoBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Vivid;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void neonBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            neonBgToolStripMenuItem.Checked = true;

            // Disable the others
            standardBgToolStripMenuItem.Checked = false;

            darkBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            tomatoBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Neon;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void pastelBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            pastelBgToolStripMenuItem.Checked = true;

            // Disable the others
            standardBgToolStripMenuItem.Checked = false;

            darkBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            tomatoBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Pastel;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void tomatoBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            tomatoBgToolStripMenuItem.Checked = true;

            // Disable the others
            standardBgToolStripMenuItem.Checked = false;

            darkBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = false;

            foreach (ToolStripMenuItem item in customToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Tomato;

            Properties.Settings.Default["SelectedTheme"] = ((ToolStripMenuItem)sender).Text;

            Properties.Settings.Default.Save();
        }

        private void SpriteSheetBuilder_BuildStarted(object sender, EventArgs e)
        {
            //newSpriteSheetToolStripMenuItem.Enabled = false;
            //openSpriteSheetBuildFileToolStripMenuItem.Enabled = false;
            //saveSpriteSheetBuildFileToolStripMenuItem.Enabled=false;

            // Just do the whole thing to be safe.
            msMainMenu.Enabled = false;
        }

        private void SpriteSheetBuilder_BuildFinished(object sender, EventArgs e)
        {
            msMainMenu.Enabled = true;

            exportSheetToolStripMenuItem.Enabled = true;
        }

        private void SpriteSheetBuilder_ThemesChanged(object sender, EventArgs e)
        {
            rebuildThemes();
        }

        private void SpriteSheetBuilderDialog_ThemeClick(object sender, EventArgs e)
        {
            // Uncheck all other themes.
            tomatoBgToolStripMenuItem.Checked = false;
            standardBgToolStripMenuItem.Checked = false;
            darkBgToolStripMenuItem.Checked = false;
            vividBgToolStripMenuItem.Checked = false;
            pastelBgToolStripMenuItem.Checked = false;
            neonBgToolStripMenuItem.Checked = false;

            customToolStripMenuItem.Checked = true;

            foreach (var item in customToolStripMenuItem.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }

            var menuItem = (ToolStripMenuItem)sender;

            menuItem.Checked = true;

            Properties.Settings.Default["SelectedTheme"] = menuItem.Text;

            Properties.Settings.Default.Save();

            int index = customToolStripMenuItem.DropDownItems.IndexOf(menuItem);

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.UserDefined;

            spriteSheetBuilder.SelectedThemeIndex = index;
        }

        private void tsScale_Click(object sender, EventArgs e)
        {
            // Uncheck all, then recheck the selected item.
            tsScale1x.Checked = false;
            tsScale2x.Checked = false;
            tsScale3x.Checked = false;

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            menuItem.Checked = true;

            double scale = 1.0;

            if (Double.TryParse(menuItem.Tag.ToString(), out scale))
            {
                spriteSheetBuilder.Scale = scale;

                Properties.Settings.Default["Scale"] = scale;

                Properties.Settings.Default.Save();

            }
        }

        #endregion

        private void showBoundariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["ShowBoundaries"] = showBoundariesToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            spriteSheetBuilder.ShowBoundaries = showBoundariesToolStripMenuItem.Checked;
        }

        private void SpriteSheetBuilderDialog_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Subtract:
                case Keys.OemMinus:
                    if (spriteSheetBuilder.Scale > 1)
                    {
                        spriteSheetBuilder.Scale = spriteSheetBuilder.Scale - 1;
                    }
                    break;
                case Keys.Add:
                case Keys.Oemplus:
                    if (spriteSheetBuilder.Scale < 3)
                    {
                        spriteSheetBuilder.Scale = spriteSheetBuilder.Scale + 1;
                    }
                    break;
            }

            tsScale1x.Checked = false;
            tsScale2x.Checked = false;
            tsScale3x.Checked = false;

            switch (spriteSheetBuilder.Scale)
            {
                case 1.0:

                    tsScale1x.Checked = true;

                    break;

                case 2.0:

                    tsScale2x.Checked = true;

                    break;

                case 3.0:

                    tsScale3x.Checked = true;

                    break;
            }
        }
    }

    public interface ISpriteSheetBuilderDialog
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

        void Show(IWin32Window owner);
        void ShowDialog(IWin32Window owner);

        void Hide();
        void Close();

        #endregion
    }
}
