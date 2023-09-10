namespace SpriteSheetBuilder
{
    partial class EditBackgroundThemesDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBackgroundThemesDialog));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lbxThemes = new System.Windows.Forms.ListBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.pgProperties = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scLeft = new System.Windows.Forms.SplitContainer();
            this.pbBgPreview = new System.Windows.Forms.PictureBox();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scLeft)).BeginInit();
            this.scLeft.Panel1.SuspendLayout();
            this.scLeft.Panel2.SuspendLayout();
            this.scLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxThemes
            // 
            this.lbxThemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxThemes.FormattingEnabled = true;
            this.lbxThemes.Location = new System.Drawing.Point(0, 0);
            this.lbxThemes.Name = "lbxThemes";
            this.lbxThemes.Size = new System.Drawing.Size(262, 182);
            this.lbxThemes.TabIndex = 4;
            this.lbxThemes.SelectedIndexChanged += new System.EventHandler(this.lbxThemes_SelectedIndexChanged);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNew,
            this.tsbDelete});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(787, 23);
            this.tsMain.TabIndex = 6;
            // 
            // tsbAddNew
            // 
            this.tsbAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddNew.Image")));
            this.tsbAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddNew.Name = "tsbAddNew";
            this.tsbAddNew.Size = new System.Drawing.Size(23, 20);
            this.tsbAddNew.Click += new System.EventHandler(this.tsbAddNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 20);
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // pgProperties
            // 
            this.pgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProperties.HelpVisible = false;
            this.pgProperties.Location = new System.Drawing.Point(0, 0);
            this.pgProperties.Name = "pgProperties";
            this.pgProperties.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgProperties.Size = new System.Drawing.Size(262, 210);
            this.pgProperties.TabIndex = 7;
            this.pgProperties.ToolbarVisible = false;
            this.pgProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgProperties_PropertyValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbBgPreview);
            this.splitContainer1.Size = new System.Drawing.Size(787, 396);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 8;
            // 
            // scLeft
            // 
            this.scLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scLeft.Location = new System.Drawing.Point(0, 0);
            this.scLeft.Name = "scLeft";
            this.scLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scLeft.Panel1
            // 
            this.scLeft.Panel1.Controls.Add(this.lbxThemes);
            // 
            // scLeft.Panel2
            // 
            this.scLeft.Panel2.Controls.Add(this.pgProperties);
            this.scLeft.Size = new System.Drawing.Size(262, 396);
            this.scLeft.SplitterDistance = 182;
            this.scLeft.TabIndex = 9;
            // 
            // pbBgPreview
            // 
            this.pbBgPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbBgPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbBgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBgPreview.Location = new System.Drawing.Point(0, 0);
            this.pbBgPreview.Name = "pbBgPreview";
            this.pbBgPreview.Size = new System.Drawing.Size(521, 396);
            this.pbBgPreview.TabIndex = 5;
            this.pbBgPreview.TabStop = false;
            this.pbBgPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBgPreview_Paint);
            // 
            // EditBackgroundThemesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 419);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMain);
            this.MinimizeBox = false;
            this.Name = "EditBackgroundThemesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditBackgroundThemesForm_Load);
            this.ResizeEnd += new System.EventHandler(this.EditBackgroundThemesForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.EditBackgroundThemesForm_SizeChanged);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.scLeft.Panel1.ResumeLayout(false);
            this.scLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scLeft)).EndInit();
            this.scLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ListBox lbxThemes;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAddNew;
        private System.Windows.Forms.PropertyGrid pgProperties;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer scLeft;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.PictureBox pbBgPreview;
    }
}