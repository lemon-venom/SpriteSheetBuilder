using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpriteSheetBuilder
{
    public partial class EditBackgroundThemesDialog : Form
    {
        public EditBackgroundThemesDialog()
        {
            InitializeComponent();

            _backgroundGenerator = new CheckeredBackgroundGenerator(); // Someday might want other patterns, but only one for now.

            _backgroundGenerator.BackgroundColorScheme = BackgroundColorScheme.UserDefined;

            _lstThemes = new List<ColorTheme>();

            _changed = false;

            tsbDelete.Enabled = false;
        }

        private IBackgroundGenerator _backgroundGenerator;

        private List<ColorTheme> _lstThemes;

        public bool Changed
        {
            get { return _changed; }
        }
        private bool _changed = false;

        public List<ColorTheme> Themes
        {
            get { return _lstThemes; }
            set 
            { 
                _lstThemes = value;

                lbxThemes.Items.Clear();

                foreach (ColorTheme theme in _lstThemes)
                {
                    lbxThemes.Items.Add(theme.Name);
                }
            }
        }

        private void refreshPreview()
        {
            _backgroundGenerator.Regenerate();

            pbBgPreview.Refresh();
        }

        private void pbBgPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmpBackground = _backgroundGenerator.GenerateBackground(pbBgPreview.Width, pbBgPreview.Height);

            g.DrawImage(bmpBackground, new Point(0, 0));
        }

        private void EditBackgroundThemesForm_Load(object sender, System.EventArgs e)
        {
            refreshPreview();
        }

        private void tsbAddNew_Click(object sender, System.EventArgs e)
        {
            int nextAutonumber = -1;

            string baseName = "New Theme";

            string nameToCheckFor = baseName;

            int index = -1;

            bool nameInUse = false;

            do
            {
                nextAutonumber++;

                if (nextAutonumber > 0)
                {
                    nameToCheckFor = baseName + " " + nextAutonumber.ToString();
                }

                index = lbxThemes.Items.IndexOf(nameToCheckFor);

                nameInUse = (index >= 0);


            } while (nameInUse == true);

            ColorTheme newColorTheme = new ColorTheme(nameToCheckFor, Color.LightGray, Color.White);

            Utilities.NameValidator.AddName(nameToCheckFor, "bgtheme");

            lbxThemes.Items.Add(nameToCheckFor);

            _lstThemes.Add(newColorTheme);

            _changed = true;
        }

        private void tsbDelete_Click(object sender, System.EventArgs e)
        {
            if (lbxThemes.SelectedIndex >= 0 && lbxThemes.SelectedIndex < _lstThemes.Count)
            {
                if (MessageBox.Show("Delete " + _lstThemes[lbxThemes.SelectedIndex].Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Utilities.NameValidator.DeleteName(_lstThemes[lbxThemes.SelectedIndex].Name, "bgtheme");

                    _lstThemes.RemoveAt(lbxThemes.SelectedIndex);

                    lbxThemes.Items.RemoveAt(lbxThemes.SelectedIndex);

                    GC.Collect();

                    _changed = true;
                }
            }
        }

        private void EditBackgroundThemesForm_ResizeEnd(object sender, System.EventArgs e)
        {
            refreshPreview();
        }

        private void EditBackgroundThemesForm_SizeChanged(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                refreshPreview();
            }
        }

        private void lbxThemes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lbxThemes.SelectedIndex >= 0 && lbxThemes.SelectedIndex < _lstThemes.Count)
            {
                tsbDelete.Enabled = true;

                ColorTheme theme = _lstThemes[lbxThemes.SelectedIndex];

                pgProperties.SelectedObject = theme;

                _backgroundGenerator.BackgroundColor1 = theme.Color1;

                _backgroundGenerator.BackgroundColor2 = theme.Color2;

                refreshPreview();
            }
        }

        private void pgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.Label.ToUpper())
            {
                case "COLOR1":

                    _backgroundGenerator.BackgroundColor1 = (Color)e.ChangedItem.Value;

                    break;

                case "COLOR2":

                    _backgroundGenerator.BackgroundColor2 = (Color)e.ChangedItem.Value;

                    break;

                case "NAME":

                    _changed = true;

                    lbxThemes.Items[lbxThemes.SelectedIndex] = e.ChangedItem.Value as string;

                    break;
            }

            refreshPreview();
        }

    }
}
