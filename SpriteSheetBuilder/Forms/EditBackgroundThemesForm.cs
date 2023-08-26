using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public partial class EditBackgroundThemesForm : Form
    {
        public EditBackgroundThemesForm()
        {
            InitializeComponent();
        }


        private void btnColor1_Click(object sender, System.EventArgs e)
        {
            colorDialog.ShowDialog();

            btnColor1.BackColor = colorDialog.Color;
        }

        private void btnColor2_Click(object sender, System.EventArgs e)
        {
            colorDialog.ShowDialog();

            btnColor2.BackColor = colorDialog.Color;
        }
    }
}
