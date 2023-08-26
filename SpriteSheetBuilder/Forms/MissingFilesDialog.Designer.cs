namespace SpriteSheetBuilder
{
    partial class MissingFilesDialog
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
            this.btnSearchDirectory = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.colMissingFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNewFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scMissingFiles = new System.Windows.Forms.SplitContainer();
            this.scButtons = new System.Windows.Forms.SplitContainer();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bgWorkerSearchDirectory = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.scMissingFiles)).BeginInit();
            this.scMissingFiles.Panel1.SuspendLayout();
            this.scMissingFiles.Panel2.SuspendLayout();
            this.scMissingFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scButtons)).BeginInit();
            this.scButtons.Panel2.SuspendLayout();
            this.scButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchDirectory
            // 
            this.btnSearchDirectory.Location = new System.Drawing.Point(3, 0);
            this.btnSearchDirectory.Name = "btnSearchDirectory";
            this.btnSearchDirectory.Size = new System.Drawing.Size(119, 27);
            this.btnSearchDirectory.TabIndex = 0;
            this.btnSearchDirectory.Text = "Search Directory...";
            this.btnSearchDirectory.UseVisualStyleBackColor = true;
            this.btnSearchDirectory.Click += new System.EventHandler(this.btnSearchDirectory_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMissingFile,
            this.colNewFile,
            this.colStatus});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(793, 475);
            this.lvFiles.TabIndex = 4;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            // 
            // colMissingFile
            // 
            this.colMissingFile.Text = "Missing File";
            this.colMissingFile.Width = 300;
            // 
            // colNewFile
            // 
            this.colNewFile.Text = "New File";
            this.colNewFile.Width = 300;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 78;
            // 
            // scMissingFiles
            // 
            this.scMissingFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMissingFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMissingFiles.IsSplitterFixed = true;
            this.scMissingFiles.Location = new System.Drawing.Point(0, 0);
            this.scMissingFiles.Name = "scMissingFiles";
            this.scMissingFiles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMissingFiles.Panel1
            // 
            this.scMissingFiles.Panel1.Controls.Add(this.lvFiles);
            // 
            // scMissingFiles.Panel2
            // 
            this.scMissingFiles.Panel2.Controls.Add(this.scButtons);
            this.scMissingFiles.Size = new System.Drawing.Size(793, 511);
            this.scMissingFiles.SplitterDistance = 475;
            this.scMissingFiles.TabIndex = 5;
            // 
            // scButtons
            // 
            this.scButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scButtons.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scButtons.IsSplitterFixed = true;
            this.scButtons.Location = new System.Drawing.Point(0, 0);
            this.scButtons.Name = "scButtons";
            // 
            // scButtons.Panel2
            // 
            this.scButtons.Panel2.Controls.Add(this.btnSearchDirectory);
            this.scButtons.Panel2.Controls.Add(this.btnApply);
            this.scButtons.Panel2.Controls.Add(this.btnCancel);
            this.scButtons.Size = new System.Drawing.Size(793, 32);
            this.scButtons.SplitterDistance = 449;
            this.scButtons.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(128, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 27);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgWorkerSearchDirectory
            // 
            this.bgWorkerSearchDirectory.WorkerReportsProgress = true;
            this.bgWorkerSearchDirectory.WorkerSupportsCancellation = true;
            this.bgWorkerSearchDirectory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerSearchDirectory_DoWork);
            this.bgWorkerSearchDirectory.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerSearchDirectory_ProgressChanged);
            this.bgWorkerSearchDirectory.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerSearchDirectory_RunWorkerCompleted);
            // 
            // MissingFilesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 511);
            this.ControlBox = false;
            this.Controls.Add(this.scMissingFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.Name = "MissingFilesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Missing Files";
            this.Load += new System.EventHandler(this.MissingFilesDialog_Load);
            this.scMissingFiles.Panel1.ResumeLayout(false);
            this.scMissingFiles.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMissingFiles)).EndInit();
            this.scMissingFiles.ResumeLayout(false);
            this.scButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scButtons)).EndInit();
            this.scButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchDirectory;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader colMissingFile;
        private System.Windows.Forms.ColumnHeader colNewFile;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.SplitContainer scMissingFiles;
        private System.Windows.Forms.SplitContainer scButtons;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker bgWorkerSearchDirectory;
    }
}