using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static Ideal.ReNamer.Properties.Settings;
using static System.String;

namespace Ideal.ReNamer
{
    public partial class FrmRenamer : Form
    {
        public FrmRenamer()
        {
            InitializeComponent();
            _renamer = new Renamer();
            SourceFolder = Default.SourceFolder;
            DestinationFolder = Default.DestFolder;
            WorkbookFilename = Default.WorkbookFilename;
        }

        private readonly Renamer _renamer;

        #region Properties

        public string SourceFolder
        {
            get { return tbxSourceFolder.Text; }
            set { tbxSourceFolder.Text = value; }
        }

        public string DestinationFolder
        {
            get { return tbxDestFolder.Text; }
            set { tbxDestFolder.Text = value; }
        }

        public string WorkbookFilename
        {
            get { return tbxWorkbookFilename.Text; }
            set { tbxWorkbookFilename.Text = value; }
        }

        public bool HasHeaders
        {
            get { return chkHasHeaders.Checked; }
            set { chkHasHeaders.Checked = value; }
        }

        public bool ContinueOnError
        {
            get { return chkContinue.Checked; }
            set { chkContinue.Checked = value; }
        }

        public bool CreateZip
        {
            get { return chkMakeZips.Checked; }
            set { chkMakeZips.Checked = value; }
        }

        public Renamer Renamer => _renamer;

        #endregion

        #region Methods

        public void FindSourceFolder()
        {
            ctlFolderBrowserDialogSource.Description = "Locate Source Folder";
            ctlFolderBrowserDialogSource.ShowNewFolderButton = false;
            string t = tbxSourceFolder.Text;
            if (!IsNullOrEmpty(t))
            {
                DirectoryInfo di = new DirectoryInfo(t);
                if (di.Exists)
                {
                    ctlFolderBrowserDialogSource.SelectedPath = di.FullName;
                }
            }
            if (!ctlFolderBrowserDialogSource.ShowDialog(this).Equals(DialogResult.OK)) return;
            Renamer.SourceFolder = ctlFolderBrowserDialogSource.SelectedPath;
            SourceFolder = Renamer.SourceFolder;
            EnableControls();
        }

        public void FindDestinationFolder()
        {
            ctlFolderBrowserDialogDest.Description = "Locate Destination Folder";
            ctlFolderBrowserDialogDest.ShowNewFolderButton = true;
            string t = tbxDestFolder.Text;
            if (!IsNullOrEmpty(t))
            {
                DirectoryInfo di = new DirectoryInfo(t);
                if (di.Exists)
                {
                    ctlFolderBrowserDialogDest.SelectedPath = di.FullName;
                }
            }
            if (!ctlFolderBrowserDialogDest.ShowDialog(this).Equals(DialogResult.OK)) return;
            Renamer.DestFolder = ctlFolderBrowserDialogDest.SelectedPath;
            DestinationFolder = Renamer.DestFolder;
            EnableControls();
        }

        public void FindExcelFile()
        {
            string t = tbxWorkbookFilename.Text;
            ctlOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!IsNullOrEmpty(t))
            {
                try
                {
                    FileInfo fi = new FileInfo(t);
                    if (fi.Exists)
                    {
                        ctlOpenFileDialog.FileName = t;
                        ctlOpenFileDialog.InitialDirectory = fi.DirectoryName;
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(t);
                        if (di.Exists)
                            ctlOpenFileDialog.InitialDirectory = di.FullName;
                    }
                }
                catch (Exception)
                {
                    // intentional walk
                }
            }
            if (!ctlOpenFileDialog.ShowDialog(this).Equals(DialogResult.OK)) return;
            Renamer.WorkbookFilename = ctlOpenFileDialog.FileName;
            WorkbookFilename = Renamer.WorkbookFilename;
            EnableControls();
        }

        public void Run()
        {
            if (tbxSourceFolder.Text.Equals(tbxDestFolder.Text))
            {
                DialogResult r =  MessageBox.Show(
                    "The source folder is the same as the destination folder!" 
                    + "\r\n\nEssentially this will rename the files in the source folder to the new names." 
                    + "\r\nPress OK to continue or CANCEL to abort.", 
                    "Are you sure?.", MessageBoxButtons.OKCancel);
                if (r == DialogResult.Cancel)
                    return;
            }
            int cTotal = 0;
            int copiedCount = 0;
            try
            {
                UseWaitCursor = true;
                btnRun.Enabled = false;
                Renamer.CopyFiles(
                    tbxSourceFolder.Text, 
                    tbxDestFolder.Text, 
                    tbxWorkbookFilename.Text,
                    chkContinue.Checked, 
                    chkHasHeaders.Checked,
                    chkMakeZips.Checked,
                    ref cTotal,
                    ref copiedCount
                );
                EnableControls();
                UseWaitCursor = false;
                MessageBox.Show(
                    chkContinue.Checked
                        ? $"{copiedCount} of {cTotal} files were copied successfully."
                        : $"All {cTotal} files existed, but none were copied.\r\n" 
                        + $"Check \"Continue on Error\" to actually copy the files."
                );
            }
            catch (ApplicationException ex)
            {
                int cBad = 0;
                List<FileListEntry> bad = ex.Data["BadList"] as List<FileListEntry>;
                if (bad != null) cBad = bad.Count;

                //Compose and show exception message in FrmError:
                StringBuilder sb = new StringBuilder();
                if (cBad > 0)
                {
                    sb.Append($"{copiedCount} of {cTotal} files were actually copied.");
                    sb.Append(cBad > 0
                        ? $"  {cBad} file{(cBad > 1 ? "s " : "")} did not exist."
                        : "");
                    sb.Append("\r\n\n");
                    foreach (FileListEntry f in (List<FileListEntry>) ex.Data["BadList"])
                    {
                        sb.Append($"Row {f.RowNumber}: {f.ExistingFilename}\r\n");
                    }
                }
                else
                {
                    sb.Append(ex.Message);
                }
                using (FrmError frm = new FrmError())
                {
                    frm.ErrorMessage = sb.ToString();
                    frm.ShowDialog();
                }
            }
            finally
            {
                EnableControls();
                UseWaitCursor = false;
            }
        }

        private void EnableControls()
        {
            btnRun.Enabled = Renamer.ArePropertiesValid(tbxSourceFolder.Text, tbxDestFolder.Text,
                tbxWorkbookFilename.Text);
        }

        #endregion

        #region Event Handlers

        private void btnFindSourceFolder_Click(object sender, EventArgs e)
        {
            FindSourceFolder();
        }

        private void btnFindDestFolder_Click(object sender, EventArgs e)
        {
            FindDestinationFolder();
        }

        private void btnExcelFile_click(object sender, EventArgs e)
        {
            FindExcelFile();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRenamer_Load(object sender, EventArgs e)
        {
            Height = Default.Height;
            Width = Default.Width;
            EnableControls();
        }

        private void FrmRenamer_ResizeEnd(object sender, EventArgs e)
        {
            Default.Height = Height;
            Default.Width = Width;
            Default.Save();
        }

        private void TextChanging(object sender, EventArgs e)
        {
            EnableControls();
        }

        #endregion

    }
}
