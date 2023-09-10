using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    #region Delegates

    public delegate void CancelClickedHandler(object sender, CancelClickedEventArgs e);

    #endregion

    public partial class ProgressDialog : Form, IProgressForm
    {
        public event CancelClickedHandler CancelClicked;

        public ProgressDialog(bool marquee)
        {
            InitializeComponent();

            if (marquee == true)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        public int ProgressPercentage
        {
            get
            {
                return _progressPercentage;
            }

            set
            {
                _progressPercentage = value;

                progressBar.Value = _progressPercentage;
            }
        }
        private int _progressPercentage;

        public void CenterToScreen()
        {
            base.CenterToScreen();
        }

        public void SetCaption(string caption)
        {
            lbCaption.Text = caption;

            lbCaption.Refresh();
        }

        public void SetStatus(string status)
        {
            lbStatus.Text = status;

            lbStatus.Refresh();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 192, 192, 255), Color.White, 0.0f))
            {
                e.Graphics.FillRectangle(brush, panel4.ClientRectangle);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.WhiteSmoke, Color.White, 0.0f))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }
        }

        private void llbCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnCancelClicked(new CancelClickedEventArgs());
        }

        #region Event Dispatchers

        protected virtual void OnCancelClicked(CancelClickedEventArgs e)
        {
            CancelClicked?.Invoke(this, e);
        }

        #endregion

    }

    #region Event Args

    public class CancelClickedEventArgs : System.EventArgs
    {
        public CancelClickedEventArgs()
        {
        }
    }

    #endregion

    public interface IProgressForm
    {
        #region Events

        event CancelClickedHandler CancelClicked;
        
        #endregion

        void SetCaption(string caption);

        void SetStatus(string status);

        // Derived from base.
        int Width { get; set; }
        int Height { get; set; }
        int Bottom { get; }
        int Left { get; set; }
        int Top { get; set; }
        bool TopLevel { get; set; }

        int ProgressPercentage { get; set; }

        void CenterToScreen();
        void Close();
        void Hide();
        void Show(IWin32Window owner);
    }
}
