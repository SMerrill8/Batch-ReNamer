using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static Ideal.ReNamer.Properties.Settings;

namespace Ideal.ReNamer
{
    public partial class FrmRenamer : Form
    {
        public FrmRenamer()
        {
            InitializeComponent();
            _renamer = new Renamer();
        }

        private readonly Renamer _renamer;

        #region Properties

        public Renamer Renamer => _renamer;

        #endregion

        #region Helper Methods

        private void FindSourceFolder()
        {
            ctlFolderBrowserDialogSource.Description = "Locate Source Folder";
            ctlFolderBrowserDialogSource.ShowNewFolderButton = false;
            string t = tbxSourceFolder.Text;
            if (!String.IsNullOrEmpty(t))
            {
                DirectoryInfo di = new DirectoryInfo(t);
                if (di.Exists)
                {
                    ctlFolderBrowserDialogSource.SelectedPath = di.FullName;
                }
            }
            if (ctlFolderBrowserDialogSource.ShowDialog(this).Equals(DialogResult.OK))
            {
                Renamer.SourceFolder = ctlFolderBrowserDialogSource.SelectedPath;
                EnableControls();
            }
        }

        private void FindDestinationFolder()
        {
            ctlFolderBrowserDialogDest.Description = "Locate Destination Folder";
            ctlFolderBrowserDialogDest.ShowNewFolderButton = true;
            string t = tbxDestFolder.Text;
            if (!String.IsNullOrEmpty(t))
            {
                DirectoryInfo di = new DirectoryInfo(t);
                if (di.Exists)
                {
                    ctlFolderBrowserDialogDest.SelectedPath = di.FullName;
                }
            }
            if (ctlFolderBrowserDialogDest.ShowDialog(this).Equals(DialogResult.OK))
            {
                Renamer.DestFolder = ctlFolderBrowserDialogDest.SelectedPath;
                EnableControls();
            }
        }

        private void FindExcelFile()
        {
            string t = tbxWorkbookFilename.Text;
            ctlOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!String.IsNullOrEmpty(t))
            {
                try
                {
                    var fi = new FileInfo(t);
                    if (fi.Exists)
                    {
                        ctlOpenFileDialog.FileName = t;
                        ctlOpenFileDialog.InitialDirectory = fi.DirectoryName;
                    }
                    else
                    {
                        var di = new DirectoryInfo(t);
                        if (di.Exists)
                            ctlOpenFileDialog.InitialDirectory = di.FullName;
                    }
                }
                catch (Exception)
                {
                    // intentional walk
                }
            }
            if (ctlOpenFileDialog.ShowDialog(this).Equals(DialogResult.OK))
            {
                Renamer.WorkbookFilename = ctlOpenFileDialog.FileName;
                EnableControls();
            }
        }

        private void Run()
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
                    ref cTotal,
                    ref copiedCount
                );
                EnableControls();
                UseWaitCursor = false;
                MessageBox.Show(
                    chkContinue.Checked
                        ? $"{copiedCount} of {cTotal} files were copied successfully."
                        : $"All {cTotal} files existed, but none were copied.\r\nCheck \"Continue on Error\" to actually copy the files."
                );
            }
            catch (ApplicationException ex)
            {
                int cBad = ex.Data.Values.Count;
                if (cBad == 0)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
                else
                {
                    string errorMessage = $"{copiedCount} of {cTotal} files were actually copied.";
                    if (cBad> 0) errorMessage += $"  {cBad} file{(cBad > 1 ? "s " : "")} did not exist.";
                    errorMessage += "\r\n\n";
                    foreach (FileListEntry f in (List<FileListEntry>) ex.Data["BadList"])
                    {
                        errorMessage += $"Row {f.RowNumber}: {f.ExistingFilename}\r\n";
                    }

                    using (FrmError frm = new FrmError())
                    {
                        frm.ErrorMessage = errorMessage;
                        frm.ShowDialog();
                    }
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
