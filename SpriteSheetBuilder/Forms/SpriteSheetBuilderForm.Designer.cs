namespace SpriteSheetBuilder
{
    partial class SpriteSheetBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpriteSheetBuilderForm));
            this.ofdAddImages = new System.Windows.Forms.OpenFileDialog();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSpriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpriteSheetBuildFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpriteSheetBuildFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildSpriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAlphaMaskSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vividBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neonBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastelBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomatoBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsScale1x = new System.Windows.Forms.ToolStripMenuItem();
            this.tsScale2x = new System.Windows.Forms.ToolStripMenuItem();
            this.tsScale3x = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgThemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBuild = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbScale = new System.Windows.Forms.ToolStripDropDownButton();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dark = new System.Windows.Forms.ToolStripDropDownButton();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amethystToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easterEggToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBoundariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.configToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(944, 24);
            this.msMainMenu.TabIndex = 4;
            this.msMainMenu.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSpriteSheetToolStripMenuItem,
            this.saveSpriteSheetBuildFileToolStripMenuItem,
            this.openSpriteSheetBuildFileToolStripMenuItem,
            this.addImagesToolStripMenuItem,
            this.buildSpriteSheetToolStripMenuItem,
            this.buildAlphaMaskSheetToolStripMenuItem,
            this.exportSheetToolStripMenuItem,
            this.recentFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSpriteSheetToolStripMenuItem
            // 
            this.newSpriteSheetToolStripMenuItem.Name = "newSpriteSheetToolStripMenuItem";
            this.newSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.newSpriteSheetToolStripMenuItem.Text = "New Sprite Sheet";
            this.newSpriteSheetToolStripMenuItem.Click += new System.EventHandler(this.newSpriteSheetToolStripMenuItem_Click);
            // 
            // saveSpriteSheetBuildFileToolStripMenuItem
            // 
            this.saveSpriteSheetBuildFileToolStripMenuItem.Enabled = false;
            this.saveSpriteSheetBuildFileToolStripMenuItem.Name = "saveSpriteSheetBuildFileToolStripMenuItem";
            this.saveSpriteSheetBuildFileToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.saveSpriteSheetBuildFileToolStripMenuItem.Text = "Save Sprite Sheet Build File";
            this.saveSpriteSheetBuildFileToolStripMenuItem.Click += new System.EventHandler(this.saveSpriteSheetBuildFileToolStripMenuItem_Click);
            // 
            // openSpriteSheetBuildFileToolStripMenuItem
            // 
            this.openSpriteSheetBuildFileToolStripMenuItem.Name = "openSpriteSheetBuildFileToolStripMenuItem";
            this.openSpriteSheetBuildFileToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.openSpriteSheetBuildFileToolStripMenuItem.Text = "Open Sprite Sheet Build File";
            this.openSpriteSheetBuildFileToolStripMenuItem.Click += new System.EventHandler(this.openSpriteSheetBuildFileToolStripMenuItem_Click);
            // 
            // addImagesToolStripMenuItem
            // 
            this.addImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleImageToolStripMenuItem,
            this.stripToolStripMenuItem,
            this.sheetToolStripMenuItem});
            this.addImagesToolStripMenuItem.Enabled = false;
            this.addImagesToolStripMenuItem.Name = "addImagesToolStripMenuItem";
            this.addImagesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.addImagesToolStripMenuItem.Text = "Add Images";
            this.addImagesToolStripMenuItem.Visible = false;
            // 
            // singleImageToolStripMenuItem
            // 
            this.singleImageToolStripMenuItem.Enabled = false;
            this.singleImageToolStripMenuItem.Name = "singleImageToolStripMenuItem";
            this.singleImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.singleImageToolStripMenuItem.Text = "From Single Image";
            this.singleImageToolStripMenuItem.Click += new System.EventHandler(this.singleImageToolStripMenuItem_Click);
            // 
            // stripToolStripMenuItem
            // 
            this.stripToolStripMenuItem.Enabled = false;
            this.stripToolStripMenuItem.Name = "stripToolStripMenuItem";
            this.stripToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stripToolStripMenuItem.Text = "From Strip";
            this.stripToolStripMenuItem.Click += new System.EventHandler(this.stripToolStripMenuItem_Click);
            // 
            // sheetToolStripMenuItem
            // 
            this.sheetToolStripMenuItem.Enabled = false;
            this.sheetToolStripMenuItem.Name = "sheetToolStripMenuItem";
            this.sheetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sheetToolStripMenuItem.Text = "From Sheet";
            this.sheetToolStripMenuItem.Click += new System.EventHandler(this.sheetToolStripMenuItem_Click);
            // 
            // buildSpriteSheetToolStripMenuItem
            // 
            this.buildSpriteSheetToolStripMenuItem.Enabled = false;
            this.buildSpriteSheetToolStripMenuItem.Name = "buildSpriteSheetToolStripMenuItem";
            this.buildSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.buildSpriteSheetToolStripMenuItem.Text = "Build Sprite Sheet";
            this.buildSpriteSheetToolStripMenuItem.Visible = false;
            this.buildSpriteSheetToolStripMenuItem.Click += new System.EventHandler(this.buildSpriteSheetToolStripMenuItem_Click);
            // 
            // buildAlphaMaskSheetToolStripMenuItem
            // 
            this.buildAlphaMaskSheetToolStripMenuItem.Enabled = false;
            this.buildAlphaMaskSheetToolStripMenuItem.Name = "buildAlphaMaskSheetToolStripMenuItem";
            this.buildAlphaMaskSheetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.buildAlphaMaskSheetToolStripMenuItem.Text = "Build Alpha Mask Sheet";
            this.buildAlphaMaskSheetToolStripMenuItem.Visible = false;
            this.buildAlphaMaskSheetToolStripMenuItem.Click += new System.EventHandler(this.buildAlphaMaskSheetToolStripMenuItem_Click);
            // 
            // exportSheetToolStripMenuItem
            // 
            this.exportSheetToolStripMenuItem.Enabled = false;
            this.exportSheetToolStripMenuItem.Name = "exportSheetToolStripMenuItem";
            this.exportSheetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.exportSheetToolStripMenuItem.Text = "Export Sheet";
            this.exportSheetToolStripMenuItem.Visible = false;
            this.exportSheetToolStripMenuItem.Click += new System.EventHandler(this.exportSheetToolStripMenuItem_Click);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.Enabled = false;
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.recentFilesToolStripMenuItem.Text = "Recent Files";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorSchemeToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.showBoundariesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // backgroundColorSchemeToolStripMenuItem
            // 
            this.backgroundColorSchemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardBgToolStripMenuItem,
            this.darkBgToolStripMenuItem,
            this.vividBgToolStripMenuItem,
            this.neonBgToolStripMenuItem,
            this.pastelBgToolStripMenuItem,
            this.tomatoBgToolStripMenuItem,
            this.customToolStripMenuItem});
            this.backgroundColorSchemeToolStripMenuItem.Name = "backgroundColorSchemeToolStripMenuItem";
            this.backgroundColorSchemeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.backgroundColorSchemeToolStripMenuItem.Text = "Background Theme";
            // 
            // standardBgToolStripMenuItem
            // 
            this.standardBgToolStripMenuItem.Name = "standardBgToolStripMenuItem";
            this.standardBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.standardBgToolStripMenuItem.Text = "Light";
            this.standardBgToolStripMenuItem.Click += new System.EventHandler(this.standardBgToolStripMenuItem_Click);
            // 
            // darkBgToolStripMenuItem
            // 
            this.darkBgToolStripMenuItem.Name = "darkBgToolStripMenuItem";
            this.darkBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.darkBgToolStripMenuItem.Text = "Dark";
            this.darkBgToolStripMenuItem.Click += new System.EventHandler(this.darkBgToolStripMenuItem_Click);
            // 
            // vividBgToolStripMenuItem
            // 
            this.vividBgToolStripMenuItem.Name = "vividBgToolStripMenuItem";
            this.vividBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.vividBgToolStripMenuItem.Text = "Geode";
            this.vividBgToolStripMenuItem.Click += new System.EventHandler(this.vividBgToolStripMenuItem_Click);
            // 
            // neonBgToolStripMenuItem
            // 
            this.neonBgToolStripMenuItem.Name = "neonBgToolStripMenuItem";
            this.neonBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.neonBgToolStripMenuItem.Text = "Radioactive";
            this.neonBgToolStripMenuItem.Click += new System.EventHandler(this.neonBgToolStripMenuItem_Click);
            // 
            // pastelBgToolStripMenuItem
            // 
            this.pastelBgToolStripMenuItem.Name = "pastelBgToolStripMenuItem";
            this.pastelBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.pastelBgToolStripMenuItem.Text = "Easter Egg";
            this.pastelBgToolStripMenuItem.Click += new System.EventHandler(this.pastelBgToolStripMenuItem_Click);
            // 
            // tomatoBgToolStripMenuItem
            // 
            this.tomatoBgToolStripMenuItem.Name = "tomatoBgToolStripMenuItem";
            this.tomatoBgToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.tomatoBgToolStripMenuItem.Text = "Tomato";
            this.tomatoBgToolStripMenuItem.Click += new System.EventHandler(this.tomatoBgToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsScale1x,
            this.tsScale2x,
            this.tsScale3x});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zoomToolStripMenuItem.Text = "Scaling";
            // 
            // tsScale1x
            // 
            this.tsScale1x.CheckOnClick = true;
            this.tsScale1x.Name = "tsScale1x";
            this.tsScale1x.Size = new System.Drawing.Size(86, 22);
            this.tsScale1x.Tag = "1";
            this.tsScale1x.Text = "1x";
            this.tsScale1x.Click += new System.EventHandler(this.tsScale_Click);
            // 
            // tsScale2x
            // 
            this.tsScale2x.Name = "tsScale2x";
            this.tsScale2x.Size = new System.Drawing.Size(86, 22);
            this.tsScale2x.Tag = "2";
            this.tsScale2x.Text = "2x";
            this.tsScale2x.Click += new System.EventHandler(this.tsScale_Click);
            // 
            // tsScale3x
            // 
            this.tsScale3x.Name = "tsScale3x";
            this.tsScale3x.Size = new System.Drawing.Size(86, 22);
            this.tsScale3x.Tag = "3";
            this.tsScale3x.Text = "3x";
            this.tsScale3x.Click += new System.EventHandler(this.tsScale_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bgThemesToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // bgThemesToolStripMenuItem
            // 
            this.bgThemesToolStripMenuItem.Name = "bgThemesToolStripMenuItem";
            this.bgThemesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.bgThemesToolStripMenuItem.Text = "Background Themes";
            this.bgThemesToolStripMenuItem.Click += new System.EventHandler(this.bgThemesToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbSave,
            this.tsbOpen,
            this.toolStripSeparator1,
            this.tsbBuild,
            this.tsbExport,
            this.toolStripSeparator2,
            this.tsbScale,
            this.Dark});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(944, 23);
            this.tsMain.TabIndex = 5;
            this.tsMain.Visible = false;
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 20);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 20);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 20);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbBuild
            // 
            this.tsbBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuild.Image = ((System.Drawing.Image)(resources.GetObject("tsbBuild.Image")));
            this.tsbBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuild.Name = "tsbBuild";
            this.tsbBuild.Size = new System.Drawing.Size(23, 20);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(23, 20);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbScale
            // 
            this.tsbScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2});
            this.tsbScale.Image = ((System.Drawing.Image)(resources.GetObject("tsbScale.Image")));
            this.tsbScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScale.Name = "tsbScale";
            this.tsbScale.Size = new System.Drawing.Size(29, 20);
            this.tsbScale.Text = "toolStripDropDownButton1";
            this.tsbScale.ToolTipText = "Scale";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.xToolStripMenuItem.Text = "1x";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(86, 22);
            this.xToolStripMenuItem1.Text = "2x";
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.xToolStripMenuItem2.Text = "3x";
            // 
            // Dark
            // 
            this.Dark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dark.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightToolStripMenuItem,
            this.darkToolStripMenuItem,
            this.amethystToolStripMenuItem,
            this.acidToolStripMenuItem,
            this.easterEggToolStripMenuItem});
            this.Dark.Image = ((System.Drawing.Image)(resources.GetObject("Dark.Image")));
            this.Dark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dark.Name = "Dark";
            this.Dark.Size = new System.Drawing.Size(29, 20);
            this.Dark.ToolTipText = "Background Theme";
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.lightToolStripMenuItem.Text = "Light";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            // 
            // amethystToolStripMenuItem
            // 
            this.amethystToolStripMenuItem.Name = "amethystToolStripMenuItem";
            this.amethystToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.amethystToolStripMenuItem.Text = "Amethyst";
            // 
            // acidToolStripMenuItem
            // 
            this.acidToolStripMenuItem.Name = "acidToolStripMenuItem";
            this.acidToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.acidToolStripMenuItem.Text = "Acid";
            // 
            // easterEggToolStripMenuItem
            // 
            this.easterEggToolStripMenuItem.Name = "easterEggToolStripMenuItem";
            this.easterEggToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.easterEggToolStripMenuItem.Text = "Easter Egg";
            // 
            // showBoundariesToolStripMenuItem
            // 
            this.showBoundariesToolStripMenuItem.CheckOnClick = true;
            this.showBoundariesToolStripMenuItem.Name = "showBoundariesToolStripMenuItem";
            this.showBoundariesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.showBoundariesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.showBoundariesToolStripMenuItem.Text = "Show Boundaries";
            this.showBoundariesToolStripMenuItem.Click += new System.EventHandler(this.showBoundariesToolStripMenuItem_Click);
            // 
            // SpriteSheetBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 604);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMainMenu);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "SpriteSheetBuilderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite Sheet Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpriteSheetBuilderDialog_FormClosing);
            this.Load += new System.EventHandler(this.SpriteSheetBuilderDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpriteSheetBuilderDialog_KeyDown);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdAddImages;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSpriteSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpriteSheetBuildFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSpriteSheetBuildFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildSpriteSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAlphaMaskSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bgThemesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardBgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkBgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vividBgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neonBgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsScale1x;
        private System.Windows.Forms.ToolStripMenuItem tsScale2x;
        private System.Windows.Forms.ToolStripMenuItem tsScale3x;
        private System.Windows.Forms.ToolStripMenuItem pastelBgToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbBuild;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripDropDownButton tsbScale;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton Dark;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amethystToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easterEggToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tomatoBgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBoundariesToolStripMenuItem;
    }
}