namespace Ideal.ReNamer
{
    partial class FrmRenamer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRenamer));
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbxSourceFolder = new System.Windows.Forms.TextBox();
            this.tbxDestFolder = new System.Windows.Forms.TextBox();
            this.btnFindSourceFolder = new System.Windows.Forms.Button();
            this.btnFindDestFolder = new System.Windows.Forms.Button();
            this.btnExcelFile = new System.Windows.Forms.Button();
            this.lblDirections = new System.Windows.Forms.Label();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            this.chkHasHeaders = new System.Windows.Forms.CheckBox();
            this.chkMakeZips = new System.Windows.Forms.CheckBox();
            this.clbWorkbookFilenames = new System.Windows.Forms.CheckedListBox();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.ctlFolderBrowserDialogSource = new System.Windows.Forms.FolderBrowserDialog();
            this.ctlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ctlFolderBrowserDialogDest = new System.Windows.Forms.FolderBrowserDialog();
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 6;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlp.Controls.Add(this.btnCancel, 1, 6);
            this.tlp.Controls.Add(this.btnRun, 4, 6);
            this.tlp.Controls.Add(this.tbxSourceFolder, 1, 1);
            this.tlp.Controls.Add(this.tbxDestFolder, 1, 2);
            this.tlp.Controls.Add(this.btnFindSourceFolder, 4, 1);
            this.tlp.Controls.Add(this.btnFindDestFolder, 4, 2);
            this.tlp.Controls.Add(this.btnExcelFile, 4, 3);
            this.tlp.Controls.Add(this.lblDirections, 1, 0);
            this.tlp.Controls.Add(this.chkContinue, 2, 5);
            this.tlp.Controls.Add(this.chkHasHeaders, 1, 5);
            this.tlp.Controls.Add(this.chkMakeZips, 3, 5);
            this.tlp.Controls.Add(this.clbWorkbookFilenames, 1, 3);
            this.tlp.Controls.Add(this.btnClearFiles, 4, 4);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(5);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 7;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlp.Size = new System.Drawing.Size(982, 455);
            this.tlp.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(18, 413);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(828, 413);
            this.btnRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(132, 37);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tbxSourceFolder
            // 
            this.tbxSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp.SetColumnSpan(this.tbxSourceFolder, 3);
            this.tbxSourceFolder.Location = new System.Drawing.Point(18, 22);
            this.tbxSourceFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSourceFolder.Name = "tbxSourceFolder";
            this.tbxSourceFolder.Size = new System.Drawing.Size(800, 22);
            this.tbxSourceFolder.TabIndex = 2;
            this.tbxSourceFolder.TextChanged += new System.EventHandler(this.TextChanging);
            // 
            // tbxDestFolder
            // 
            this.tbxDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp.SetColumnSpan(this.tbxDestFolder, 3);
            this.tbxDestFolder.Location = new System.Drawing.Point(18, 67);
            this.tbxDestFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbxDestFolder.Name = "tbxDestFolder";
            this.tbxDestFolder.Size = new System.Drawing.Size(800, 22);
            this.tbxDestFolder.TabIndex = 3;
            this.tbxDestFolder.TextChanged += new System.EventHandler(this.TextChanging);
            // 
            // btnFindSourceFolder
            // 
            this.btnFindSourceFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindSourceFolder.Location = new System.Drawing.Point(828, 22);
            this.btnFindSourceFolder.Margin = new System.Windows.Forms.Padding(5);
            this.btnFindSourceFolder.Name = "btnFindSourceFolder";
            this.btnFindSourceFolder.Size = new System.Drawing.Size(132, 35);
            this.btnFindSourceFolder.TabIndex = 4;
            this.btnFindSourceFolder.Text = "&Source";
            this.btnFindSourceFolder.UseVisualStyleBackColor = true;
            this.btnFindSourceFolder.Click += new System.EventHandler(this.btnFindSourceFolder_Click);
            // 
            // btnFindDestFolder
            // 
            this.btnFindDestFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindDestFolder.Location = new System.Drawing.Point(828, 67);
            this.btnFindDestFolder.Margin = new System.Windows.Forms.Padding(5);
            this.btnFindDestFolder.Name = "btnFindDestFolder";
            this.btnFindDestFolder.Size = new System.Drawing.Size(132, 35);
            this.btnFindDestFolder.TabIndex = 5;
            this.btnFindDestFolder.Text = "&Destination";
            this.btnFindDestFolder.UseVisualStyleBackColor = true;
            this.btnFindDestFolder.Click += new System.EventHandler(this.btnFindDestFolder_Click);
            // 
            // btnExcelFile
            // 
            this.btnExcelFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExcelFile.Location = new System.Drawing.Point(828, 112);
            this.btnExcelFile.Margin = new System.Windows.Forms.Padding(5);
            this.btnExcelFile.Name = "btnExcelFile";
            this.btnExcelFile.Size = new System.Drawing.Size(132, 31);
            this.btnExcelFile.TabIndex = 6;
            this.btnExcelFile.Text = "Add &Excel File(s)";
            this.btnExcelFile.UseVisualStyleBackColor = true;
            this.btnExcelFile.Click += new System.EventHandler(this.btnExcelFile_click);
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.tlp.SetColumnSpan(this.lblDirections, 3);
            this.lblDirections.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDirections.Location = new System.Drawing.Point(16, 0);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(222, 17);
            this.lblDirections.TabIndex = 10;
            this.lblDirections.Text = "Choose the Folders and Excel File";
            // 
            // chkContinue
            // 
            this.chkContinue.AutoSize = true;
            this.chkContinue.Checked = true;
            this.chkContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContinue.Location = new System.Drawing.Point(298, 376);
            this.chkContinue.Margin = new System.Windows.Forms.Padding(5);
            this.chkContinue.Name = "chkContinue";
            this.chkContinue.Size = new System.Drawing.Size(149, 21);
            this.chkContinue.TabIndex = 8;
            this.chkContinue.Text = "Continue on error?";
            this.chkContinue.UseVisualStyleBackColor = true;
            // 
            // chkHasHeaders
            // 
            this.chkHasHeaders.AutoSize = true;
            this.chkHasHeaders.Checked = true;
            this.chkHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHasHeaders.Location = new System.Drawing.Point(16, 374);
            this.chkHasHeaders.Name = "chkHasHeaders";
            this.chkHasHeaders.Size = new System.Drawing.Size(204, 21);
            this.chkHasHeaders.TabIndex = 11;
            this.chkHasHeaders.Text = "First row contains headers?";
            this.chkHasHeaders.UseVisualStyleBackColor = true;
            // 
            // chkMakeZips
            // 
            this.chkMakeZips.AutoSize = true;
            this.chkMakeZips.Checked = true;
            this.chkMakeZips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMakeZips.Location = new System.Drawing.Point(561, 374);
            this.chkMakeZips.Name = "chkMakeZips";
            this.chkMakeZips.Size = new System.Drawing.Size(104, 21);
            this.chkMakeZips.TabIndex = 12;
            this.chkMakeZips.Text = "Create Zip?";
            this.chkMakeZips.UseVisualStyleBackColor = true;
            // 
            // clbWorkbookFilenames
            // 
            this.tlp.SetColumnSpan(this.clbWorkbookFilenames, 3);
            this.clbWorkbookFilenames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbWorkbookFilenames.FormattingEnabled = true;
            this.clbWorkbookFilenames.Location = new System.Drawing.Point(16, 110);
            this.clbWorkbookFilenames.Name = "clbWorkbookFilenames";
            this.tlp.SetRowSpan(this.clbWorkbookFilenames, 2);
            this.clbWorkbookFilenames.Size = new System.Drawing.Size(804, 258);
            this.clbWorkbookFilenames.TabIndex = 13;
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearFiles.Location = new System.Drawing.Point(826, 332);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(136, 36);
            this.btnClearFiles.TabIndex = 14;
            this.btnClearFiles.Text = "&Clear Files";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // ctlFolderBrowserDialogSource
            // 
            this.ctlFolderBrowserDialogSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ctlOpenFileDialog
            // 
            this.ctlOpenFileDialog.DefaultExt = "*.xlsx";
            this.ctlOpenFileDialog.Filter = "Excel Files|*.xls?";
            this.ctlOpenFileDialog.Multiselect = true;
            this.ctlOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ctlOpenFileDialog_FileOk);
            // 
            // FrmRenamer
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(982, 455);
            this.Controls.Add(this.tlp);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FrmRenamer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch ReNamer";
            this.Load += new System.EventHandler(this.FrmRenamer_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmRenamer_ResizeEnd);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox tbxSourceFolder;
        private System.Windows.Forms.TextBox tbxDestFolder;
        private System.Windows.Forms.Button btnFindSourceFolder;
        private System.Windows.Forms.Button btnFindDestFolder;
        private System.Windows.Forms.Button btnExcelFile;
        private System.Windows.Forms.FolderBrowserDialog ctlFolderBrowserDialogSource;
        private System.Windows.Forms.OpenFileDialog ctlOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog ctlFolderBrowserDialogDest;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.CheckBox chkHasHeaders;
        private System.Windows.Forms.CheckBox chkContinue;
        private System.Windows.Forms.CheckBox chkMakeZips;
        private System.Windows.Forms.CheckedListBox clbWorkbookFilenames;
        private System.Windows.Forms.Button btnClearFiles;
    }
}

