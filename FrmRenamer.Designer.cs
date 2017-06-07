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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbxSourceFolder = new System.Windows.Forms.TextBox();
            this.tbxDestFolder = new System.Windows.Forms.TextBox();
            this.btnFindSourceFolder = new System.Windows.Forms.Button();
            this.btnFindDestFolder = new System.Windows.Forms.Button();
            this.btnExcelFile = new System.Windows.Forms.Button();
            this.tbxWorkbookFilename = new System.Windows.Forms.TextBox();
            this.lblDirections = new System.Windows.Forms.Label();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            this.chkHasHeaders = new System.Windows.Forms.CheckBox();
            this.ctlFolderBrowserDialogSource = new System.Windows.Forms.FolderBrowserDialog();
            this.ctlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ctlFolderBrowserDialogDest = new System.Windows.Forms.FolderBrowserDialog();
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 5;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlp.Controls.Add(this.btnCancel, 1, 6);
            this.tlp.Controls.Add(this.btnRun, 3, 6);
            this.tlp.Controls.Add(this.tbxSourceFolder, 1, 1);
            this.tlp.Controls.Add(this.tbxDestFolder, 1, 2);
            this.tlp.Controls.Add(this.btnFindSourceFolder, 3, 1);
            this.tlp.Controls.Add(this.btnFindDestFolder, 3, 2);
            this.tlp.Controls.Add(this.btnExcelFile, 3, 3);
            this.tlp.Controls.Add(this.tbxWorkbookFilename, 1, 3);
            this.tlp.Controls.Add(this.lblDirections, 1, 0);
            this.tlp.Controls.Add(this.chkContinue, 2, 4);
            this.tlp.Controls.Add(this.chkHasHeaders, 1, 4);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(5);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 7;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.Size = new System.Drawing.Size(982, 285);
            this.tlp.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(18, 239);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 41);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(829, 239);
            this.btnRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(132, 41);
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
            this.tlp.SetColumnSpan(this.tbxSourceFolder, 2);
            this.tbxSourceFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Ideal.ReNamer.Properties.Settings.Default, "SourceFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxSourceFolder.Location = new System.Drawing.Point(18, 32);
            this.tbxSourceFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSourceFolder.Name = "tbxSourceFolder";
            this.tbxSourceFolder.Size = new System.Drawing.Size(801, 22);
            this.tbxSourceFolder.TabIndex = 2;
           
            this.tbxSourceFolder.Text = global::Ideal.ReNamer.Properties.Settings.Default.SourceFolder;
            this.tbxSourceFolder.TextChanged += new System.EventHandler(this.TextChanging);
            // 
            // tbxDestFolder
            // 
            this.tbxDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp.SetColumnSpan(this.tbxDestFolder, 2);
            this.tbxDestFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Ideal.ReNamer.Properties.Settings.Default, "DestFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxDestFolder.Location = new System.Drawing.Point(18, 77);
            this.tbxDestFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbxDestFolder.Name = "tbxDestFolder";
            this.tbxDestFolder.Size = new System.Drawing.Size(801, 22);
            this.tbxDestFolder.TabIndex = 3;
            this.tbxDestFolder.Text = global::Ideal.ReNamer.Properties.Settings.Default.DestFolder;
            this.tbxDestFolder.TextChanged += new System.EventHandler(this.TextChanging);
            // 
            // btnFindSourceFolder
            // 
            this.btnFindSourceFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindSourceFolder.Location = new System.Drawing.Point(829, 32);
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
            this.btnFindDestFolder.Location = new System.Drawing.Point(829, 77);
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
            this.btnExcelFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExcelFile.Location = new System.Drawing.Point(829, 122);
            this.btnExcelFile.Margin = new System.Windows.Forms.Padding(5);
            this.btnExcelFile.Name = "btnExcelFile";
            this.btnExcelFile.Size = new System.Drawing.Size(132, 35);
            this.btnExcelFile.TabIndex = 6;
            this.btnExcelFile.Text = "&Excel File";
            this.btnExcelFile.UseVisualStyleBackColor = true;
            this.btnExcelFile.Click += new System.EventHandler(this.btnExcelFile_click);
            // 
            // tbxWorkbookFilename
            // 
            this.tbxWorkbookFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp.SetColumnSpan(this.tbxWorkbookFilename, 2);
            this.tbxWorkbookFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Ideal.ReNamer.Properties.Settings.Default, "WorkbookFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxWorkbookFilename.Location = new System.Drawing.Point(18, 122);
            this.tbxWorkbookFilename.Margin = new System.Windows.Forms.Padding(5);
            this.tbxWorkbookFilename.Name = "tbxWorkbookFilename";
            this.tbxWorkbookFilename.Size = new System.Drawing.Size(801, 22);
            this.tbxWorkbookFilename.TabIndex = 7;
            this.tbxWorkbookFilename.Text = global::Ideal.ReNamer.Properties.Settings.Default.WorkbookFilename;
            this.tbxWorkbookFilename.TextChanged += new System.EventHandler(this.TextChanging);
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.tlp.SetColumnSpan(this.lblDirections, 2);
            this.lblDirections.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDirections.Location = new System.Drawing.Point(16, 0);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(222, 27);
            this.lblDirections.TabIndex = 10;
            this.lblDirections.Text = "Choose the Folders and Excel File";
            // 
            // chkContinue
            // 
            this.chkContinue.AutoSize = true;
            this.chkContinue.Checked = true;
            this.chkContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContinue.Location = new System.Drawing.Point(298, 167);
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
            this.chkHasHeaders.Location = new System.Drawing.Point(16, 165);
            this.chkHasHeaders.Name = "chkHasHeaders";
            this.chkHasHeaders.Size = new System.Drawing.Size(204, 21);
            this.chkHasHeaders.TabIndex = 11;
            this.chkHasHeaders.Text = "First row contains headers?";
            this.chkHasHeaders.UseVisualStyleBackColor = true;
            // 
            // ctlFolderBrowserDialogSource
            // 
            this.ctlFolderBrowserDialogSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FrmRenamer
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(982, 285);
            this.Controls.Add(this.tlp);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1000, 330);
            this.Name = "FrmRenamer";
            this.ShowIcon = false;
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
        private System.Windows.Forms.TextBox tbxWorkbookFilename;
        private System.Windows.Forms.FolderBrowserDialog ctlFolderBrowserDialogSource;
        private System.Windows.Forms.OpenFileDialog ctlOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog ctlFolderBrowserDialogDest;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.CheckBox chkHasHeaders;
        private System.Windows.Forms.CheckBox chkContinue;
    }
}

