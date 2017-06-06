using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.String;
using static Boundless.ReNamer.Properties.Settings;

namespace Boundless.ReNamer
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
            if (!IsNullOrEmpty(t))
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
            if (!IsNullOrEmpty(t))
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
            if (!IsNullOrEmpty(t))
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
            try
            {
                UseWaitCursor = true;
                btnRun.Enabled = false;
                int fileCount = Renamer.CopyFiles(
                    tbxSourceFolder.Text, 
                    tbxDestFolder.Text, 
                    tbxWorkbookFilename.Text,
                    chkContinue.Checked, 
                    chkHasHeaders.Checked
                );
                EnableControls();
                UseWaitCursor = false;
                MessageBox.Show(
                    chkContinue.Checked
                        ? $"{fileCount} Files were copied successfully."
                        : $"All {fileCount} files existed, but none were copied.\r\nCheck \"Continue on Error\" to actually copy the files."
                );
            }
            catch (ApplicationException ex)
            {
                string s = "";
                if (ex.Data.Values.Count == 0)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
                else
                {
                    foreach (FileListEntry f in (List<FileListEntry>) ex.Data["BadList"])
                    {
                        s += $"Row {f.RowNumber}: {f.ExistingFilename}\r\n";
                    }

                    using (FrmError frm = new FrmError())
                    {
                        frm.TestMode = !chkContinue.Checked;
                        frm.ErrorMessage = s;
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
