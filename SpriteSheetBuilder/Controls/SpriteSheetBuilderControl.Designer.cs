namespace SpriteSheetBuilder
{
    partial class SpriteSheetBuilderControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpriteSheetBuilderControl));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.scImages = new System.Windows.Forms.SplitContainer();
            this.scFilesProperties = new System.Windows.Forms.SplitContainer();
            this.scExportImport = new System.Windows.Forms.SplitContainer();
            this.scExport = new System.Windows.Forms.SplitContainer();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnPalette = new System.Windows.Forms.Button();
            this.pgSpriteSheet = new System.Windows.Forms.PropertyGrid();
            this.scImport = new System.Windows.Forms.SplitContainer();
            this.mnuButtonAddImages = new SpriteSheetBuilder.MenuButton();
            this.cmnuAddImages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddSingleImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddImageStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddImageSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnFixErrors = new System.Windows.Forms.Button();
            this.lstbxFiles = new System.Windows.Forms.ListBox();
            this.pgImageSource = new System.Windows.Forms.PropertyGrid();
            this.lblInitialized = new System.Windows.Forms.Label();
            this.vsSpriteSheet = new System.Windows.Forms.VScrollBar();
            this.hsSpriteSheet = new System.Windows.Forms.HScrollBar();
            this.pbSheetPreview = new System.Windows.Forms.PictureBox();
            this.bgWorkerBuildSheet = new System.ComponentModel.BackgroundWorker();
            this.ofdAddImages = new System.Windows.Forms.OpenFileDialog();
            this.ttButtonInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scImages)).BeginInit();
            this.scImages.Panel1.SuspendLayout();
            this.scImages.Panel2.SuspendLayout();
            this.scImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scFilesProperties)).BeginInit();
            this.scFilesProperties.Panel1.SuspendLayout();
            this.scFilesProperties.Panel2.SuspendLayout();
            this.scFilesProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scExportImport)).BeginInit();
            this.scExportImport.Panel1.SuspendLayout();
            this.scExportImport.Panel2.SuspendLayout();
            this.scExportImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scExport)).BeginInit();
            this.scExport.Panel1.SuspendLayout();
            this.scExport.Panel2.SuspendLayout();
            this.scExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scImport)).BeginInit();
            this.scImport.Panel1.SuspendLayout();
            this.scImport.Panel2.SuspendLayout();
            this.scImport.SuspendLayout();
            this.cmnuAddImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSheetPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.scImages, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 519F));
            this.tlpMain.Size = new System.Drawing.Size(964, 519);
            this.tlpMain.TabIndex = 3;
            // 
            // scImages
            // 
            this.scImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scImages.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scImages.Location = new System.Drawing.Point(3, 3);
            this.scImages.Name = "scImages";
            // 
            // scImages.Panel1
            // 
            this.scImages.Panel1.Controls.Add(this.scFilesProperties);
            // 
            // scImages.Panel2
            // 
            this.scImages.Panel2.Controls.Add(this.lblInitialized);
            this.scImages.Panel2.Controls.Add(this.vsSpriteSheet);
            this.scImages.Panel2.Controls.Add(this.hsSpriteSheet);
            this.scImages.Panel2.Controls.Add(this.pbSheetPreview);
            this.scImages.Size = new System.Drawing.Size(958, 513);
            this.scImages.SplitterDistance = 333;
            this.scImages.TabIndex = 3;
            this.scImages.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scImages_SplitterMoved);
            // 
            // scFilesProperties
            // 
            this.scFilesProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFilesProperties.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scFilesProperties.IsSplitterFixed = true;
            this.scFilesProperties.Location = new System.Drawing.Point(0, 0);
            this.scFilesProperties.Name = "scFilesProperties";
            this.scFilesProperties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scFilesProperties.Panel1
            // 
            this.scFilesProperties.Panel1.Controls.Add(this.scExportImport);
            // 
            // scFilesProperties.Panel2
            // 
            this.scFilesProperties.Panel2.Controls.Add(this.pgImageSource);
            this.scFilesProperties.Size = new System.Drawing.Size(333, 513);
            this.scFilesProperties.SplitterDistance = 442;
            this.scFilesProperties.TabIndex = 0;
            this.scFilesProperties.TabStop = false;
            // 
            // scExportImport
            // 
            this.scExportImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scExportImport.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scExportImport.IsSplitterFixed = true;
            this.scExportImport.Location = new System.Drawing.Point(0, 0);
            this.scExportImport.Name = "scExportImport";
            this.scExportImport.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scExportImport.Panel1
            // 
            this.scExportImport.Panel1.Controls.Add(this.scExport);
            // 
            // scExportImport.Panel2
            // 
            this.scExportImport.Panel2.Controls.Add(this.scImport);
            this.scExportImport.Size = new System.Drawing.Size(333, 442);
            this.scExportImport.SplitterDistance = 176;
            this.scExportImport.TabIndex = 2;
            this.scExportImport.TabStop = false;
            // 
            // scExport
            // 
            this.scExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scExport.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scExport.IsSplitterFixed = true;
            this.scExport.Location = new System.Drawing.Point(0, 0);
            this.scExport.Name = "scExport";
            this.scExport.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scExport.Panel1
            // 
            this.scExport.Panel1.Controls.Add(this.btnExport);
            this.scExport.Panel1.Controls.Add(this.btnBuild);
            this.scExport.Panel1.Controls.Add(this.btnPalette);
            // 
            // scExport.Panel2
            // 
            this.scExport.Panel2.Controls.Add(this.pgSpriteSheet);
            this.scExport.Size = new System.Drawing.Size(333, 176);
            this.scExport.SplitterDistance = 25;
            this.scExport.SplitterWidth = 1;
            this.scExport.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(45, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(36, 23);
            this.btnExport.TabIndex = 6;
            this.ttButtonInfo.SetToolTip(this.btnExport, "Export Sheet");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Image = ((System.Drawing.Image)(resources.GetObject("btnBuild.Image")));
            this.btnBuild.Location = new System.Drawing.Point(3, 0);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(36, 23);
            this.btnBuild.TabIndex = 5;
            this.ttButtonInfo.SetToolTip(this.btnBuild, "Build Sheet");
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnPalette
            // 
            this.btnPalette.Image = ((System.Drawing.Image)(resources.GetObject("btnPalette.Image")));
            this.btnPalette.Location = new System.Drawing.Point(87, 0);
            this.btnPalette.Name = "btnPalette";
            this.btnPalette.Size = new System.Drawing.Size(36, 23);
            this.btnPalette.TabIndex = 4;
            this.ttButtonInfo.SetToolTip(this.btnPalette, "Palette Tools");
            this.btnPalette.UseVisualStyleBackColor = true;
            this.btnPalette.Click += new System.EventHandler(this.btnPalette_Click);
            // 
            // pgSpriteSheet
            // 
            this.pgSpriteSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSpriteSheet.Enabled = false;
            this.pgSpriteSheet.HelpVisible = false;
            this.pgSpriteSheet.Location = new System.Drawing.Point(0, 0);
            this.pgSpriteSheet.Name = "pgSpriteSheet";
            this.pgSpriteSheet.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgSpriteSheet.Size = new System.Drawing.Size(333, 150);
            this.pgSpriteSheet.TabIndex = 0;
            this.pgSpriteSheet.ToolbarVisible = false;
            this.pgSpriteSheet.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgSpriteSheet_PropertyValueChanged);
            // 
            // scImport
            // 
            this.scImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scImport.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scImport.IsSplitterFixed = true;
            this.scImport.Location = new System.Drawing.Point(0, 0);
            this.scImport.Name = "scImport";
            this.scImport.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scImport.Panel1
            // 
            this.scImport.Panel1.Controls.Add(this.mnuButtonAddImages);
            this.scImport.Panel1.Controls.Add(this.btnMoveDown);
            this.scImport.Panel1.Controls.Add(this.btnDeleteImage);
            this.scImport.Panel1.Controls.Add(this.btnMoveUp);
            this.scImport.Panel1.Controls.Add(this.btnFixErrors);
            // 
            // scImport.Panel2
            // 
            this.scImport.Panel2.Controls.Add(this.lstbxFiles);
            this.scImport.Size = new System.Drawing.Size(333, 262);
            this.scImport.SplitterDistance = 25;
            this.scImport.SplitterWidth = 1;
            this.scImport.TabIndex = 2;
            // 
            // mnuButtonAddImages
            // 
            this.mnuButtonAddImages.Image = ((System.Drawing.Image)(resources.GetObject("mnuButtonAddImages.Image")));
            this.mnuButtonAddImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuButtonAddImages.Location = new System.Drawing.Point(3, 3);
            this.mnuButtonAddImages.Menu = this.cmnuAddImages;
            this.mnuButtonAddImages.Name = "mnuButtonAddImages";
            this.mnuButtonAddImages.ShowMenuUnderCursor = true;
            this.mnuButtonAddImages.Size = new System.Drawing.Size(39, 22);
            this.mnuButtonAddImages.TabIndex = 9;
            this.ttButtonInfo.SetToolTip(this.mnuButtonAddImages, "Add Images");
            this.mnuButtonAddImages.UseVisualStyleBackColor = true;
            // 
            // cmnuAddImages
            // 
            this.cmnuAddImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSingleImage,
            this.tsmiAddImageStrip,
            this.tsmiAddImageSheet});
            this.cmnuAddImages.Name = "cmnuAddImages";
            this.cmnuAddImages.Size = new System.Drawing.Size(107, 70);
            // 
            // tsmiAddSingleImage
            // 
            this.tsmiAddSingleImage.Name = "tsmiAddSingleImage";
            this.tsmiAddSingleImage.Size = new System.Drawing.Size(106, 22);
            this.tsmiAddSingleImage.Text = "Single";
            this.tsmiAddSingleImage.Click += new System.EventHandler(this.tsmiAddSingleImage_Click);
            // 
            // tsmiAddImageStrip
            // 
            this.tsmiAddImageStrip.Name = "tsmiAddImageStrip";
            this.tsmiAddImageStrip.Size = new System.Drawing.Size(106, 22);
            this.tsmiAddImageStrip.Text = "Strip";
            this.tsmiAddImageStrip.Click += new System.EventHandler(this.tsmiAddImageStrip_Click);
            // 
            // tsmiAddImageSheet
            // 
            this.tsmiAddImageSheet.Name = "tsmiAddImageSheet";
            this.tsmiAddImageSheet.Size = new System.Drawing.Size(106, 22);
            this.tsmiAddImageSheet.Text = "Sheet";
            this.tsmiAddImageSheet.Click += new System.EventHandler(this.tsmiAddImageSheet_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(117, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(36, 22);
            this.btnMoveDown.TabIndex = 7;
            this.ttButtonInfo.SetToolTip(this.btnMoveDown, "Move Image Down");
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteImage.Image")));
            this.btnDeleteImage.Location = new System.Drawing.Point(43, 3);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(36, 22);
            this.btnDeleteImage.TabIndex = 10;
            this.ttButtonInfo.SetToolTip(this.btnDeleteImage, "Delete Selected Images");
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(80, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(36, 22);
            this.btnMoveUp.TabIndex = 6;
            this.ttButtonInfo.SetToolTip(this.btnMoveUp, "Move Image Up");
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnFixErrors
            // 
            this.btnFixErrors.Image = ((System.Drawing.Image)(resources.GetObject("btnFixErrors.Image")));
            this.btnFixErrors.Location = new System.Drawing.Point(159, 3);
            this.btnFixErrors.Name = "btnFixErrors";
            this.btnFixErrors.Size = new System.Drawing.Size(36, 22);
            this.btnFixErrors.TabIndex = 8;
            this.ttButtonInfo.SetToolTip(this.btnFixErrors, "Fix Missing Images");
            this.btnFixErrors.UseVisualStyleBackColor = true;
            this.btnFixErrors.Visible = false;
            this.btnFixErrors.Click += new System.EventHandler(this.btnFixErrors_Click);
            // 
            // lstbxFiles
            // 
            this.lstbxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbxFiles.FormattingEnabled = true;
            this.lstbxFiles.IntegralHeight = false;
            this.lstbxFiles.Location = new System.Drawing.Point(0, 0);
            this.lstbxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lstbxFiles.Name = "lstbxFiles";
            this.lstbxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxFiles.Size = new System.Drawing.Size(333, 236);
            this.lstbxFiles.TabIndex = 1;
            this.lstbxFiles.SelectedIndexChanged += new System.EventHandler(this.lstbxFiles_SelectedIndexChanged);
            this.lstbxFiles.DoubleClick += new System.EventHandler(this.lstbxFiles_DoubleClick);
            this.lstbxFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstbxFiles_KeyDown);
            // 
            // pgImageSource
            // 
            this.pgImageSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgImageSource.HelpVisible = false;
            this.pgImageSource.Location = new System.Drawing.Point(0, 0);
            this.pgImageSource.Name = "pgImageSource";
            this.pgImageSource.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgImageSource.Size = new System.Drawing.Size(333, 67);
            this.pgImageSource.TabIndex = 1;
            this.pgImageSource.ToolbarVisible = false;
            // 
            // lblInitialized
            // 
            this.lblInitialized.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInitialized.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInitialized.ForeColor = System.Drawing.Color.White;
            this.lblInitialized.Location = new System.Drawing.Point(0, 0);
            this.lblInitialized.Name = "lblInitialized";
            this.lblInitialized.Size = new System.Drawing.Size(621, 513);
            this.lblInitialized.TabIndex = 3;
            this.lblInitialized.Text = "No Sprite Sheet Build File Is Loaded\r\nStart A New Sprite Sheet Or Load One From D" +
    "isk\r\n";
            this.lblInitialized.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vsSpriteSheet
            // 
            this.vsSpriteSheet.LargeChange = 1;
            this.vsSpriteSheet.Location = new System.Drawing.Point(318, 0);
            this.vsSpriteSheet.Name = "vsSpriteSheet";
            this.vsSpriteSheet.Size = new System.Drawing.Size(16, 284);
            this.vsSpriteSheet.TabIndex = 2;
            this.vsSpriteSheet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsSpriteSheet_Scroll);
            // 
            // hsSpriteSheet
            // 
            this.hsSpriteSheet.LargeChange = 1;
            this.hsSpriteSheet.Location = new System.Drawing.Point(0, 284);
            this.hsSpriteSheet.Name = "hsSpriteSheet";
            this.hsSpriteSheet.Size = new System.Drawing.Size(318, 16);
            this.hsSpriteSheet.TabIndex = 1;
            this.hsSpriteSheet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsSpriteSheet_Scroll);
            // 
            // pbSheetPreview
            // 
            this.pbSheetPreview.BackColor = System.Drawing.Color.Black;
            this.pbSheetPreview.Location = new System.Drawing.Point(0, 0);
            this.pbSheetPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbSheetPreview.Name = "pbSheetPreview";
            this.pbSheetPreview.Size = new System.Drawing.Size(318, 284);
            this.pbSheetPreview.TabIndex = 0;
            this.pbSheetPreview.TabStop = false;
            this.pbSheetPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSheetPreview_Paint);
            this.pbSheetPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSheetPreview_MouseDown);
            this.pbSheetPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSheetPreview_MouseMove);
            this.pbSheetPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSheetPreview_MouseUp);
            // 
            // bgWorkerBuildSheet
            // 
            this.bgWorkerBuildSheet.WorkerReportsProgress = true;
            this.bgWorkerBuildSheet.WorkerSupportsCancellation = true;
            this.bgWorkerBuildSheet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerBuildSheet_DoWork);
            this.bgWorkerBuildSheet.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerBuildSheet_ProgressChanged);
            this.bgWorkerBuildSheet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerBuildSheet_RunWorkerCompleted);
            // 
            // SpriteSheetBuilderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpMain);
            this.Name = "SpriteSheetBuilderControl";
            this.Size = new System.Drawing.Size(964, 519);
            this.Load += new System.EventHandler(this.SpriteSheetBuilderControl_Load);
            this.Resize += new System.EventHandler(this.SpriteSheetBuilderControl_Resize);
            this.tlpMain.ResumeLayout(false);
            this.scImages.Panel1.ResumeLayout(false);
            this.scImages.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scImages)).EndInit();
            this.scImages.ResumeLayout(false);
            this.scFilesProperties.Panel1.ResumeLayout(false);
            this.scFilesProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFilesProperties)).EndInit();
            this.scFilesProperties.ResumeLayout(false);
            this.scExportImport.Panel1.ResumeLayout(false);
            this.scExportImport.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scExportImport)).EndInit();
            this.scExportImport.ResumeLayout(false);
            this.scExport.Panel1.ResumeLayout(false);
            this.scExport.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scExport)).EndInit();
            this.scExport.ResumeLayout(false);
            this.scImport.Panel1.ResumeLayout(false);
            this.scImport.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scImport)).EndInit();
            this.scImport.ResumeLayout(false);
            this.cmnuAddImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSheetPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.SplitContainer scImages;
        private System.Windows.Forms.SplitContainer scFilesProperties;
        private System.Windows.Forms.SplitContainer scExportImport;
        private System.Windows.Forms.SplitContainer scExport;
        private System.Windows.Forms.PropertyGrid pgSpriteSheet;
        private System.Windows.Forms.SplitContainer scImport;
        private System.Windows.Forms.ListBox lstbxFiles;
        private System.Windows.Forms.PropertyGrid pgImageSource;
        private System.Windows.Forms.VScrollBar vsSpriteSheet;
        private System.Windows.Forms.HScrollBar hsSpriteSheet;
        private System.Windows.Forms.PictureBox pbSheetPreview;
        private System.Windows.Forms.Label lblInitialized;
        private System.ComponentModel.BackgroundWorker bgWorkerBuildSheet;
        private System.Windows.Forms.OpenFileDialog ofdAddImages;
        private System.Windows.Forms.ContextMenuStrip cmnuAddImages;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSingleImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddImageStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddImageSheet;
        private System.Windows.Forms.ToolTip ttButtonInfo;
        private MenuButton mnuButtonAddImages;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnFixErrors;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnPalette;
    }
}
