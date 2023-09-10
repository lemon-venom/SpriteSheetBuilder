namespace SpriteSheetBuilder
{
    partial class PaletteControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPalette = new System.Windows.Forms.PictureBox();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPalette
            // 
            this.pbPalette.Location = new System.Drawing.Point(3, 3);
            this.pbPalette.Name = "pbPalette";
            this.pbPalette.Size = new System.Drawing.Size(433, 266);
            this.pbPalette.TabIndex = 1;
            this.pbPalette.TabStop = false;
            this.pbPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPalette_Paint);
            this.pbPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPalette_MouseDown);
            this.pbPalette.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPalette_MouseMove);
            this.pbPalette.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPalette_MouseUp);
            // 
            // vScroll
            // 
            this.vScroll.Location = new System.Drawing.Point(627, 0);
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(16, 127);
            this.vScroll.TabIndex = 2;
            this.vScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
            // 
            // hScroll
            // 
            this.hScroll.Location = new System.Drawing.Point(0, 353);
            this.hScroll.Name = "hScroll";
            this.hScroll.Size = new System.Drawing.Size(244, 16);
            this.hScroll.TabIndex = 3;
            this.hScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
            // 
            // PaletteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hScroll);
            this.Controls.Add(this.vScroll);
            this.Controls.Add(this.pbPalette);
            this.Name = "PaletteControl";
            this.Size = new System.Drawing.Size(643, 369);
            this.Load += new System.EventHandler(this.PaletteControl_Load);
            this.Resize += new System.EventHandler(this.PaletteControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbPalette;
        private System.Windows.Forms.VScrollBar vScroll;
        private System.Windows.Forms.HScrollBar hScroll;
    }
}
