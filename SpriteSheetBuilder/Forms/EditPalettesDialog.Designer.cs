namespace SpriteSheetBuilder
{
    partial class EditPalettesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPalettesDialog));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lbxPalettes = new System.Windows.Forms.ListBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.pgProperties = new System.Windows.Forms.PropertyGrid();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scLeft = new System.Windows.Forms.SplitContainer();
            this.tsPalette = new System.Windows.Forms.ToolStrip();
            this.tsbddVisualization = new System.Windows.Forms.ToolStripDropDownButton();
            this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMapHost = new System.Windows.Forms.Panel();
            this.panelGraphHost = new System.Windows.Forms.Panel();
            this.scGraph = new System.Windows.Forms.SplitContainer();
            this.lbxPresentInFiles = new System.Windows.Forms.ListBox();
            this.lbPresentInFiles = new System.Windows.Forms.Label();
            this.scStatsMain = new System.Windows.Forms.SplitContainer();
            this.scFilesList = new System.Windows.Forms.SplitContainer();
            this.paletteGraph = new global::SpriteSheetBuilder.PaletteControl();
            this.paletteMaps = new global::SpriteSheetBuilder.PaletteControl();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scLeft)).BeginInit();
            this.scLeft.Panel1.SuspendLayout();
            this.scLeft.Panel2.SuspendLayout();
            this.scLeft.SuspendLayout();
            this.tsPalette.SuspendLayout();
            this.panelMapHost.SuspendLayout();
            this.panelGraphHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraph)).BeginInit();
            this.scGraph.Panel1.SuspendLayout();
            this.scGraph.Panel2.SuspendLayout();
            this.scGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scStatsMain)).BeginInit();
            this.scStatsMain.Panel1.SuspendLayout();
            this.scStatsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scFilesList)).BeginInit();
            this.scFilesList.Panel1.SuspendLayout();
            this.scFilesList.Panel2.SuspendLayout();
            this.scFilesList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxPalettes
            // 
            this.lbxPalettes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxPalettes.FormattingEnabled = true;
            this.lbxPalettes.Location = new System.Drawing.Point(0, 0);
            this.lbxPalettes.Name = "lbxPalettes";
            this.lbxPalettes.Size = new System.Drawing.Size(266, 190);
            this.lbxPalettes.TabIndex = 4;
            this.lbxPalettes.SelectedIndexChanged += new System.EventHandler(this.lbxPalettes_SelectedIndexChanged);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNew,
            this.tsbDelete});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(498, 23);
            this.tsMain.TabIndex = 9;
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
            this.pgProperties.Size = new System.Drawing.Size(266, 218);
            this.pgProperties.TabIndex = 7;
            this.pgProperties.ToolbarVisible = false;
            this.pgProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgProperties_PropertyValueChanged);
            // 
            // scMain
            // 
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(3, 26);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scLeft);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scMain.Panel2.Controls.Add(this.paletteMaps);
            this.scMain.Size = new System.Drawing.Size(648, 412);
            this.scMain.SplitterDistance = 266;
            this.scMain.TabIndex = 10;
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
            this.scLeft.Panel1.Controls.Add(this.lbxPalettes);
            // 
            // scLeft.Panel2
            // 
            this.scLeft.Panel2.Controls.Add(this.pgProperties);
            this.scLeft.Size = new System.Drawing.Size(266, 412);
            this.scLeft.SplitterDistance = 190;
            this.scLeft.TabIndex = 9;
            // 
            // tsPalette
            // 
            this.tsPalette.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPalette.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbddVisualization});
            this.tsPalette.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPalette.Location = new System.Drawing.Point(0, 0);
            this.tsPalette.Name = "tsPalette";
            this.tsPalette.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPalette.Size = new System.Drawing.Size(1287, 25);
            this.tsPalette.Stretch = true;
            this.tsPalette.TabIndex = 1;
            // 
            // tsbddVisualization
            // 
            this.tsbddVisualization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbddVisualization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paletteToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.tsbddVisualization.Image = ((System.Drawing.Image)(resources.GetObject("tsbddVisualization.Image")));
            this.tsbddVisualization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbddVisualization.Name = "tsbddVisualization";
            this.tsbddVisualization.Size = new System.Drawing.Size(29, 22);
            // 
            // paletteToolStripMenuItem
            // 
            this.paletteToolStripMenuItem.Checked = true;
            this.paletteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
            this.paletteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.paletteToolStripMenuItem.Text = "Mapping";
            this.paletteToolStripMenuItem.Click += new System.EventHandler(this.paletteToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.histogramToolStripMenuItem.Text = "Statistics";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // panelMapHost
            // 
            this.panelMapHost.BackColor = System.Drawing.SystemColors.Control;
            this.panelMapHost.Controls.Add(this.tsMain);
            this.panelMapHost.Controls.Add(this.scMain);
            this.panelMapHost.Location = new System.Drawing.Point(0, 25);
            this.panelMapHost.Name = "panelMapHost";
            this.panelMapHost.Size = new System.Drawing.Size(498, 354);
            this.panelMapHost.TabIndex = 11;
            // 
            // panelGraphHost
            // 
            this.panelGraphHost.BackColor = System.Drawing.SystemColors.Control;
            this.panelGraphHost.Controls.Add(this.scGraph);
            this.panelGraphHost.Location = new System.Drawing.Point(0, 25);
            this.panelGraphHost.Name = "panelGraphHost";
            this.panelGraphHost.Size = new System.Drawing.Size(354, 349);
            this.panelGraphHost.TabIndex = 12;
            this.panelGraphHost.Visible = false;
            // 
            // scGraph
            // 
            this.scGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGraph.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scGraph.IsSplitterFixed = true;
            this.scGraph.Location = new System.Drawing.Point(0, 0);
            this.scGraph.Name = "scGraph";
            this.scGraph.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scGraph.Panel1
            // 
            this.scGraph.Panel1.Controls.Add(this.paletteGraph);
            // 
            // scGraph.Panel2
            // 
            this.scGraph.Panel2.Controls.Add(this.scStatsMain);
            this.scGraph.Size = new System.Drawing.Size(354, 349);
            this.scGraph.SplitterDistance = 250;
            this.scGraph.TabIndex = 1;
            // 
            // lbxPresentInFiles
            // 
            this.lbxPresentInFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxPresentInFiles.FormattingEnabled = true;
            this.lbxPresentInFiles.Location = new System.Drawing.Point(5, 0);
            this.lbxPresentInFiles.Name = "lbxPresentInFiles";
            this.lbxPresentInFiles.Size = new System.Drawing.Size(416, 66);
            this.lbxPresentInFiles.TabIndex = 0;
            this.lbxPresentInFiles.DoubleClick += new System.EventHandler(this.lbxPresentInFiles_DoubleClick);
            // 
            // lbPresentInFiles
            // 
            this.lbPresentInFiles.AutoSize = true;
            this.lbPresentInFiles.ForeColor = System.Drawing.Color.White;
            this.lbPresentInFiles.Location = new System.Drawing.Point(3, 12);
            this.lbPresentInFiles.Name = "lbPresentInFiles";
            this.lbPresentInFiles.Size = new System.Drawing.Size(79, 13);
            this.lbPresentInFiles.TabIndex = 1;
            this.lbPresentInFiles.Text = "Present In Files";
            this.lbPresentInFiles.Click += new System.EventHandler(this.lbPresentInFiles_Click);
            // 
            // scStatsMain
            // 
            this.scStatsMain.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scStatsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scStatsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scStatsMain.Location = new System.Drawing.Point(0, 0);
            this.scStatsMain.Name = "scStatsMain";
            // 
            // scStatsMain.Panel1
            // 
            this.scStatsMain.Panel1.Controls.Add(this.scFilesList);
            this.scStatsMain.Size = new System.Drawing.Size(354, 95);
            this.scStatsMain.SplitterDistance = 421;
            this.scStatsMain.TabIndex = 2;
            // 
            // scFilesList
            // 
            this.scFilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFilesList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scFilesList.IsSplitterFixed = true;
            this.scFilesList.Location = new System.Drawing.Point(0, 0);
            this.scFilesList.Name = "scFilesList";
            this.scFilesList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scFilesList.Panel1
            // 
            this.scFilesList.Panel1.Controls.Add(this.lbPresentInFiles);
            // 
            // scFilesList.Panel2
            // 
            this.scFilesList.Panel2.Controls.Add(this.lbxPresentInFiles);
            this.scFilesList.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.scFilesList.Size = new System.Drawing.Size(421, 95);
            this.scFilesList.SplitterDistance = 25;
            this.scFilesList.TabIndex = 0;
            // 
            // paletteGraph
            // 
            this.paletteGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteGraph.Location = new System.Drawing.Point(0, 0);
            this.paletteGraph.MappedPaletteIndex = -1;
            this.paletteGraph.Name = "paletteGraph";
            this.paletteGraph.Palette = null;
            this.paletteGraph.Size = new System.Drawing.Size(354, 250);
            this.paletteGraph.TabIndex = 0;
            this.paletteGraph.Visualization = global::SpriteSheetBuilder.PaletteVisualization.Swatches;
            // 
            // paletteMaps
            // 
            this.paletteMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteMaps.Location = new System.Drawing.Point(0, 0);
            this.paletteMaps.MappedPaletteIndex = -1;
            this.paletteMaps.Name = "paletteMaps";
            this.paletteMaps.Palette = null;
            this.paletteMaps.Size = new System.Drawing.Size(378, 412);
            this.paletteMaps.TabIndex = 0;
            this.paletteMaps.Visualization = global::SpriteSheetBuilder.PaletteVisualization.Swatches;
            // 
            // EditPalettesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 565);
            this.Controls.Add(this.panelMapHost);
            this.Controls.Add(this.panelGraphHost);
            this.Controls.Add(this.tsPalette);
            this.MinimizeBox = false;
            this.Name = "EditPalettesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditPalettesForm_Load);
            this.Resize += new System.EventHandler(this.EditPalettesForm_Resize);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scLeft.Panel1.ResumeLayout(false);
            this.scLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scLeft)).EndInit();
            this.scLeft.ResumeLayout(false);
            this.tsPalette.ResumeLayout(false);
            this.tsPalette.PerformLayout();
            this.panelMapHost.ResumeLayout(false);
            this.panelMapHost.PerformLayout();
            this.panelGraphHost.ResumeLayout(false);
            this.scGraph.Panel1.ResumeLayout(false);
            this.scGraph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scGraph)).EndInit();
            this.scGraph.ResumeLayout(false);
            this.scStatsMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scStatsMain)).EndInit();
            this.scStatsMain.ResumeLayout(false);
            this.scFilesList.Panel1.ResumeLayout(false);
            this.scFilesList.Panel1.PerformLayout();
            this.scFilesList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFilesList)).EndInit();
            this.scFilesList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ListBox lbxPalettes;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAddNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.PropertyGrid pgProperties;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scLeft;
        private PaletteControl paletteMaps;
        private System.Windows.Forms.ToolStrip tsPalette;
        private System.Windows.Forms.ToolStripDropDownButton tsbddVisualization;
        private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.Panel panelMapHost;
        private System.Windows.Forms.Panel panelGraphHost;
        private PaletteControl paletteGraph;
        private System.Windows.Forms.SplitContainer scGraph;
        private System.Windows.Forms.ListBox lbxPresentInFiles;
        private System.Windows.Forms.SplitContainer scStatsMain;
        private System.Windows.Forms.SplitContainer scFilesList;
        private System.Windows.Forms.Label lbPresentInFiles;
    }
}