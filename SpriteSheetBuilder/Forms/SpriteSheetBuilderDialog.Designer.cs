namespace SpriteSheetBuilder
{
    partial class SpriteSheetBuilderDialog
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
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgThemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
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
            // 
            // singleImageToolStripMenuItem
            // 
            this.singleImageToolStripMenuItem.Enabled = false;
            this.singleImageToolStripMenuItem.Name = "singleImageToolStripMenuItem";
            this.singleImageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.singleImageToolStripMenuItem.Text = "From Single Image";
            this.singleImageToolStripMenuItem.Click += new System.EventHandler(this.singleImageToolStripMenuItem_Click);
            // 
            // stripToolStripMenuItem
            // 
            this.stripToolStripMenuItem.Enabled = false;
            this.stripToolStripMenuItem.Name = "stripToolStripMenuItem";
            this.stripToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.stripToolStripMenuItem.Text = "From Strip";
            this.stripToolStripMenuItem.Click += new System.EventHandler(this.stripToolStripMenuItem_Click);
            // 
            // sheetToolStripMenuItem
            // 
            this.sheetToolStripMenuItem.Enabled = false;
            this.sheetToolStripMenuItem.Name = "sheetToolStripMenuItem";
            this.sheetToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sheetToolStripMenuItem.Text = "From Sheet";
            this.sheetToolStripMenuItem.Click += new System.EventHandler(this.sheetToolStripMenuItem_Click);
            // 
            // buildSpriteSheetToolStripMenuItem
            // 
            this.buildSpriteSheetToolStripMenuItem.Enabled = false;
            this.buildSpriteSheetToolStripMenuItem.Name = "buildSpriteSheetToolStripMenuItem";
            this.buildSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.buildSpriteSheetToolStripMenuItem.Text = "Build Sprite Sheet";
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
            this.zoomToolStripMenuItem});
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
            this.customToolStripMenuItem});
            this.backgroundColorSchemeToolStripMenuItem.Name = "backgroundColorSchemeToolStripMenuItem";
            this.backgroundColorSchemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundColorSchemeToolStripMenuItem.Text = "Background Theme";
            // 
            // standardBgToolStripMenuItem
            // 
            this.standardBgToolStripMenuItem.Checked = true;
            this.standardBgToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standardBgToolStripMenuItem.Name = "standardBgToolStripMenuItem";
            this.standardBgToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.standardBgToolStripMenuItem.Text = "Standard";
            this.standardBgToolStripMenuItem.Click += new System.EventHandler(this.standardBgToolStripMenuItem_Click);
            // 
            // darkBgToolStripMenuItem
            // 
            this.darkBgToolStripMenuItem.Name = "darkBgToolStripMenuItem";
            this.darkBgToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.darkBgToolStripMenuItem.Text = "Dark";
            this.darkBgToolStripMenuItem.Click += new System.EventHandler(this.darkBgToolStripMenuItem_Click);
            // 
            // vividBgToolStripMenuItem
            // 
            this.vividBgToolStripMenuItem.Name = "vividBgToolStripMenuItem";
            this.vividBgToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.vividBgToolStripMenuItem.Text = "Vivid";
            this.vividBgToolStripMenuItem.Click += new System.EventHandler(this.vividBgToolStripMenuItem_Click);
            // 
            // neonBgToolStripMenuItem
            // 
            this.neonBgToolStripMenuItem.Name = "neonBgToolStripMenuItem";
            this.neonBgToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.neonBgToolStripMenuItem.Text = "Neon";
            this.neonBgToolStripMenuItem.Click += new System.EventHandler(this.neonBgToolStripMenuItem_Click);
            // 
            // pastelBgToolStripMenuItem
            // 
            this.pastelBgToolStripMenuItem.Name = "pastelBgToolStripMenuItem";
            this.pastelBgToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pastelBgToolStripMenuItem.Text = "Pastel";
            this.pastelBgToolStripMenuItem.Click += new System.EventHandler(this.pastelBgToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomToolStripMenuItem.Text = "Scaling";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Checked = true;
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "1x";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem5.Text = "2x";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem6.Text = "3x";
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
            // 
            // SpriteSheetBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 604);
            this.Controls.Add(this.msMainMenu);
            this.MinimizeBox = false;
            this.Name = "SpriteSheetBuilderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite Sheet Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpriteSheetBuilderDialog_FormClosing);
            this.Load += new System.EventHandler(this.SpriteSheetBuilderDialog_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem pastelBgToolStripMenuItem;
    }
}