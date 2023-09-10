using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpriteSheetBuilder
{
    public partial class EditPalettesDialog : Form, IEditPalettesForm
    {
        public EditPalettesDialog()
        {
            InitializeComponent();
        }

        private IBackgroundGenerator    _backgroundGenerator;

        private bool                    _changed = false;

        private SpriteSheetBuildFile    _spriteSheetBuildFile;

        public void Show(IWin32Window owner, SpriteSheetBuildFile spriteSheetBuildFile, IBackgroundGenerator backgroundGenerator)
        {
            _backgroundGenerator = backgroundGenerator;

            _spriteSheetBuildFile = spriteSheetBuildFile;

            _spriteSheetBuildFile.Palette.Visualization = PaletteVisualization.Swatches;

            paletteMaps.Palette = _spriteSheetBuildFile.Palette;

            paletteGraph.Palette = _spriteSheetBuildFile.Palette;

            lbxPalettes.DataSource = _spriteSheetBuildFile.Palette.PaletteMaps;

            paletteGraph.ColorInfoSelected += EditPalettesForm_ColorInfoSelected;

            this.Show(owner);
        }

        public void ShowDialog(IWin32Window owner, SpriteSheetBuildFile spriteSheetBuildFile, IBackgroundGenerator backgroundGenerator)
        {
            // SpriteSheetBuilder stores a palette, which itself stores child palettes. These are the palette maps.
            _backgroundGenerator = backgroundGenerator;

            _spriteSheetBuildFile = spriteSheetBuildFile;

            _spriteSheetBuildFile.Palette.Visualization = PaletteVisualization.Swatches;

            paletteMaps.Palette = _spriteSheetBuildFile.Palette;

            paletteGraph.Palette = _spriteSheetBuildFile.Palette;

            lbxPalettes.DataSource = _spriteSheetBuildFile.Palette.PaletteMaps;

            paletteGraph.ColorInfoSelected += EditPalettesForm_ColorInfoSelected;

            this.ShowDialog(owner);
        }

        private void resize()
        {
            panelMapHost.Width = this.ClientSize.Width;
            panelMapHost.Height = this. ClientSize.Height - panelMapHost.Top;

            panelGraphHost.Width = this.ClientSize.Width;
            panelGraphHost.Height = this.ClientSize.Height - panelMapHost.Top;

            scMain.Width = panelMapHost.ClientSize.Width;
            scMain.Height = panelMapHost.ClientSize.Height - paletteMaps.Top;
        }

        #region Event Handlers

        private void EditPalettesForm_ColorInfoSelected(object sender, ColorInfoSelectedEventArgs e)
        {
            lbxPresentInFiles.Items.Clear();

            foreach (var filepath in e.SelectedColorInfo.PresentInFiles)
            {
                lbxPresentInFiles.Items.Add(filepath);
            }
        }

        private void lbxPalettes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            paletteMaps.MappedPaletteIndex = lbxPalettes.SelectedIndex;

            if (paletteMaps.MappedPaletteIndex >= 0 && paletteMaps.MappedPaletteIndex < paletteMaps.Palette.PaletteMaps.Count)
            {
                pgProperties.SelectedObject = paletteMaps.Palette.PaletteMaps[paletteMaps.MappedPaletteIndex];
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            panelGraphHost.Visible = true;

            panelMapHost.Visible = false;

            paletteGraph.Visualization = PaletteVisualization.Histogram;

            resize();

            paletteGenericToolStripMenuItem_Click(sender, e);
        }

        private void paletteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            panelMapHost.Visible = true;

            panelGraphHost.Visible = false;

            paletteMaps.Visualization = PaletteVisualization.Swatches;

            resize();

            paletteGenericToolStripMenuItem_Click(sender, e);
        }

        private void paletteGenericToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            foreach (ToolStripMenuItem tsdd in tsbddVisualization.DropDownItems)
            {
                if (((ToolStripMenuItem)sender).Name == tsdd.Name)
                {
                    tsdd.Checked = true;
                }
                else
                {
                    tsdd.Checked = false;
                }
            }
        }

        private void EditPalettesForm_Resize(object sender, System.EventArgs e)
        {
            resize();
        }

        private void EditPalettesForm_Load(object sender, System.EventArgs e)
        {
            resize();
        }

        private void tsbAddNew_Click(object sender, System.EventArgs e)
        {
            int nextAutonumber = -1;

            string baseName = "New Palette";

            string nameToCheckFor = baseName;

            bool nameInUse = false;

            do
            {
                nextAutonumber++;

                if (nextAutonumber > 0)
                {
                    nameToCheckFor = baseName + " " + nextAutonumber.ToString();
                }

                nameInUse = false;

                foreach (PaletteMap paletteMap in lbxPalettes.Items)
                {
                    if (paletteMap.Name.ToUpper() == nameToCheckFor.ToUpper())
                    {
                        nameInUse = true;

                        break;
                    }
                }

            } while (nameInUse == true);

            PaletteMap newPalette = new PaletteMap(nameToCheckFor);

            _spriteSheetBuildFile.Palette.PaletteMaps.Add(newPalette);

            Utilities.NameValidator.AddName(nameToCheckFor, "palette");

            if (_spriteSheetBuildFile.Palette.PaletteMaps.Count == 1)
            {
                // Bug in listbox where when adding the first item via a bound listbox, it selects it but
                // the selected index changed event doesnt fire. 
                // https://stackoverflow.com/questions/44748117/listbox-selectedindexchanged-not-firing-on-first-occasion=
                // Force it to fire manually.
                lbxPalettes.SelectedIndex = -1;
                lbxPalettes.SelectedIndex = 0;
            }

            _changed = true;
        }

        private void tsbDelete_Click(object sender, System.EventArgs e)
        {
            if (lbxPalettes.SelectedIndex >= 0 && lbxPalettes.SelectedIndex < _spriteSheetBuildFile.Palette.PaletteMaps.Count)
            {
                string paletteName = _spriteSheetBuildFile.Palette.PaletteMaps[lbxPalettes.SelectedIndex].Name;

                if (MessageBox.Show("Delete " + paletteName + "?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Utilities.NameValidator.DeleteName(paletteName, "palette");

                    _spriteSheetBuildFile.Palette.PaletteMaps.RemoveAt(lbxPalettes.SelectedIndex);

                    GC.Collect(); // Make sure destructor is called.

                    _changed = true;
                }
            }
        }

        private void pgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.Label.ToUpper())
            {
                case "NAME":

                    _changed = true;

                    _spriteSheetBuildFile.Palette.PaletteMaps.ResetItem(lbxPalettes.SelectedIndex);

                    break;
            }
        }

        #endregion

        private void lbPresentInFiles_Click(object sender, EventArgs e)
        {

        }

        private void lbxPresentInFiles_DoubleClick(object sender, EventArgs e)
        {
            string selectedImageName = lbxPresentInFiles.Items[lbxPresentInFiles.SelectedIndex].ToString();

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
    }

    public interface IEditPalettesForm
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

        void Show(IWin32Window owner, SpriteSheetBuildFile spriteSheetBuildFile, IBackgroundGenerator backgroundGenerator);
        void ShowDialog(IWin32Window owner, SpriteSheetBuildFile spriteSheetBuildFile, IBackgroundGenerator backgroundGenerator);

        void Hide();
        void Close();

        #endregion
    }
}
