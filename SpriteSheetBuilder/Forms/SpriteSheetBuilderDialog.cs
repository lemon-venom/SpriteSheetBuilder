using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public partial class SpriteSheetBuilderDialog : Form, ISpriteSheetBuilderDialog
    {
        #region Constructors

        public SpriteSheetBuilderDialog()
        {
            InitializeComponent();

            spriteSheetBuilder = new SpriteSheetBuilderControl();

            SpriteSheetBuilderControl spriteSheetBuilderControl = (SpriteSheetBuilderControl)spriteSheetBuilder;

            spriteSheetBuilderControl.Dock = DockStyle.Fill;
            
            this.Controls.Add(spriteSheetBuilderControl);

            spriteSheetBuilderControl.BringToFront();

            spriteSheetBuilder.Enabled = false;
        }

        #endregion

        #region Private Variables

        private List<string>        _recentlyOpenedFiles = new List<string>();

        ISpriteSheetBuilderControl  spriteSheetBuilder;

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
            ofdAddImages.CheckFileExists = true;
            ofdAddImages.CheckPathExists = true;
            ofdAddImages.DefaultExt = "png";
            ofdAddImages.Filter = "PNG Files|*.png";
            ofdAddImages.FileName = string.Empty;
            ofdAddImages.Multiselect = true;
            ofdAddImages.RestoreDirectory = true;

            if (ofdAddImages.ShowDialog() == DialogResult.OK)
            {
                spriteSheetBuilder.AddImages(ImageSourceType.Single, ofdAddImages.FileNames);
            }
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
        }

        #endregion

        private void standardBgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enable the selected item
            standardBgToolStripMenuItem.Checked = true;

            // Disable the others
            darkBgToolStripMenuItem.Checked = false;

            vividBgToolStripMenuItem.Checked = false;

            neonBgToolStripMenuItem.Checked = false;

            pastelBgToolStripMenuItem.Checked = false;

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardLight;
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

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.StandardDark;
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

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Vivid;
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

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Neon;
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

            spriteSheetBuilder.BackgroundColorScheme = BackgroundColorScheme.Pastel;
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
