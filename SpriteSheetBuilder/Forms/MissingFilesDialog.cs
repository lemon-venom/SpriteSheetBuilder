using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// todo
// 2. Add custom background themes
// 3. add scaling
// 4. add ability to move via click and drag

namespace SpriteSheetBuilder
{
    public partial class MissingFilesDialog : Form
    {
        #region Constructors

        public MissingFilesDialog(SpriteSheetBuilderDto spriteSheetBuilderDto)
        {
            InitializeComponent();

            _spriteSheetBuilderDto = spriteSheetBuilderDto;

            _progressDialog = new ProgressDialog(true);

            _progressDialog.CancelClicked += MissingFilesDialog_ProgressCancelClicked;
        }

        #endregion

        #region Private Variables

        private IProgressForm           _progressDialog;

        private SpriteSheetBuilderDto   _spriteSheetBuilderDto;

        #endregion

        #region Properties

        // The number of files that are still missing after closing the dialog.
        public int MissingFileCount = 0;

        #endregion

        #region Event Handlers

        private void bgWorkerSearchDirectory_DoWork(object sender, DoWorkEventArgs e)
        {
            MissingFilesDto missingFilesDto = (MissingFilesDto)e.Argument;

            // Loop through the missing files, get the root file name.
            // Look for it recursively in the selected directory.

           List<string> lstMissingFiles = new List<string>();

            // Can't modify a collection when looping over it. Need to create a separate list.
            foreach (KeyValuePair<string, string> kvp in missingFilesDto.OldFileToNewFileMap)
            {
                lstMissingFiles.Add(kvp.Key);
            }

            int filesFound = 0;

            foreach (string filename in lstMissingFiles)
            {
                string filenameNoPath = Path.GetFileName(filename);

                string[] files = Directory.GetFiles(missingFilesDto.SearchDirectory, filenameNoPath, SearchOption.AllDirectories);

                // Eventually I should probably handle if it finds multiple valid files, but for now assume only 1 at most
                // and just take the first one.
                if (files.Length > 0)
                {
                    missingFilesDto.OldFileToNewFileMap[filename] = files[0];

                    filesFound++;

                    bgWorkerSearchDirectory.ReportProgress(filesFound);
                }

                if (bgWorkerSearchDirectory.CancellationPending)
                {
                    missingFilesDto.Cancel = true;

                    break;
                }
            }

            e.Result = missingFilesDto;
        }

        private void bgWorkerSearchDirectory_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progressDialog.SetStatus("Found " + e.ProgressPercentage.ToString() + " files.");
        }

        private void bgWorkerSearchDirectory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MissingFilesDto missingFilesDto = (MissingFilesDto)e.Result;

            if (missingFilesDto.Cancel == false)
            {
                for (int i = 0; i < lvFiles.Items.Count; i++)
                {
                    ListViewItem selectedItem = lvFiles.Items[i];

                    string newFilename = missingFilesDto.OldFileToNewFileMap[selectedItem.SubItems[0].Text];

                    if (string.IsNullOrEmpty(newFilename) == false)
                    {
                        selectedItem.SubItems[1].Text = newFilename;

                        selectedItem.SubItems[2].Text = "Found";
                    }
                }
            }

            _progressDialog.Hide();

            btnSearchDirectory.Enabled = true;
            btnApply.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Update missing files with the new files.
            MissingFileCount = lvFiles.Items.Count;

            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                ListViewItem selectedItem = lvFiles.Items[i];

                string oldFilename = selectedItem.SubItems[0].Text;

                string newFilename = selectedItem.SubItems[1].Text;

                if (string.IsNullOrEmpty(newFilename) == false)
                {
                    // Find the old filename in the dto and update it with the new one.
                    for (int j = 0; j < _spriteSheetBuilderDto.ImageSourceList.Count; j++)
                    {
                        if (_spriteSheetBuilderDto.ImageSourceList[j].FileName == oldFilename)
                        {
                            _spriteSheetBuilderDto.ImageSourceList[j].FileName = newFilename;

                            _spriteSheetBuilderDto.ImageSourceList[j].Exists = true;

                            MissingFileCount--;

                            break;
                        }
                    }
                }

            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSearchDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog();

            DialogResult result = selectFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string searchFolder = selectFolderDialog.SelectedPath + "\\";

                _progressDialog.Show(this);

                _progressDialog.SetCaption("Scanning for files...");

                _progressDialog.SetStatus("Scanning...");

                _progressDialog.CenterToScreen();

                btnSearchDirectory.Enabled = false;
                btnApply.Enabled = false;
                btnCancel.Enabled = false;

                // Pass an object to the background worker that contains everything it needs.
                // 1. The directory to search.
                // 2. A dictionary of the missing files, that will map them to a new file.

                MissingFilesDto missingFilesDto = new MissingFilesDto(searchFolder);

                // Loop through the missing files, get the root file name.
                // Look for it recursively in the selected directory.
                for (int i = 0; i < lvFiles.Items.Count; i++)
                {
                    ListViewItem selectedItem = lvFiles.Items[i];

                    missingFilesDto.OldFileToNewFileMap.Add(selectedItem.SubItems[0].Text, string.Empty);
                }

                bgWorkerSearchDirectory.RunWorkerAsync(missingFilesDto);
            }
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog selectImage = new OpenFileDialog();

            selectImage.CheckFileExists = true;
            selectImage.CheckPathExists = true;
            selectImage.DefaultExt = "png";
            selectImage.Filter = "PNG Files|*.png";
            selectImage.FileName = string.Empty;
            selectImage.Multiselect = false;
            selectImage.RestoreDirectory = true;

            if (selectImage.ShowDialog() == DialogResult.OK)
            {
                lvFiles.SelectedItems[0].SubItems[1].Text = selectImage.FileName;

                lvFiles.SelectedItems[0].SubItems[2].Text = "Found";
            }
        }

        private void MissingFilesDialog_Load(object sender, EventArgs e)
        {
            // Build the list view.
            lvFiles.Items.Clear();

            foreach (SheetImageSourceDto imageSource in _spriteSheetBuilderDto.ImageSourceList)
            {
                if (imageSource.Exists == false)
                {
                    ListViewItem lviMissingFile = new ListViewItem();
                    lviMissingFile.Text = imageSource.FileName;
                    lvFiles.Items.Add(lviMissingFile);

                    ListViewItem.ListViewSubItem lvsiNewFile = new ListViewItem.ListViewSubItem();
                    lvsiNewFile.Text = string.Empty;
                    lviMissingFile.SubItems.Add(lvsiNewFile);

                    ListViewItem.ListViewSubItem lvsiStatus = new ListViewItem.ListViewSubItem();
                    lvsiStatus.Text = "Missing";
                    lviMissingFile.SubItems.Add(lvsiStatus);
                }
            }

            MissingFileCount = lvFiles.Items.Count;

            this.Text = MissingFileCount.ToString() + " Missing Files";
        }

        private void MissingFilesDialog_ProgressCancelClicked(object sender, EventArgs e)
        {
            bgWorkerSearchDirectory.CancelAsync();
        }

        #endregion

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
