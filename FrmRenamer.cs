using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Ideal.ReNamer.Properties.Settings;
using static System.String;

namespace Ideal.ReNamer
{
    public partial class FrmRenamer : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmRenamer()
        {
            InitializeComponent();
            _renamer = new Renamer();
            InitializeWorkbookFilenames(Renamer.WorkbookFilenames);
            SourceFolder = Renamer.SourceFolder;
            DestinationFolder = Renamer.DestFolder;
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
            set
            {
                tbxDestFolder.Text = value;
            }
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

        private void AddWorkbookFilename(string value)
        {
            if (!clbWorkbookFilenames.Items.Contains(value))
                 clbWorkbookFilenames.Items.Add(value, true);
        }

        private void AddWorkbookFilenames(string[] fileNames)
        {
            foreach (string v in fileNames)
            {
                AddWorkbookFilename(v);
            }
        }
        private void InitializeWorkbookFilenames(StringCollection renamerWorkbookFilenames)
        {
            clbWorkbookFilenames.Items.Clear();
            foreach (string v in renamerWorkbookFilenames)
            {
                AddWorkbookFilename(v);
            }
        }

        private StringCollection CheckedWorkbooks()
        {
            StringCollection ret = new StringCollection();
            foreach (object checkedItem in clbWorkbookFilenames.CheckedItems)
            {
                ret.Add((string) checkedItem);
            }
            return ret;
        }

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

        public void AddExcelFile()
        {
            string t = (string) clbWorkbookFilenames.SelectedItem;
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
            AddWorkbookFilenames(ctlOpenFileDialog.FileNames);
            EnableControls();
        }


        public void Run()
        {
            StringBuilder sb = new StringBuilder();  // use sb to return the results
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
            List<FileListEntry> gb = new List<FileListEntry>();
            try
            {
                UseWaitCursor = true;
                btnRun.Enabled = false;
                foreach (string v in CheckedWorkbooks())
                {
                    Renamer.CopyFiles(
                        tbxSourceFolder.Text,
                        tbxDestFolder.Text,
                        v,
                        chkContinue.Checked,
                        chkHasHeaders.Checked,
                        chkMakeZips.Checked,
                        ref gb
                    );
                }

                int cTotal = gb.Count;
                int cBad = gb.Count(x => !x.ExistingFileExists);
                int cGood = gb.Count - cBad;
                if (cBad > 0)
                {
                    sb.Append($"ERROR: {cBad} row{(cBad > 1 ? "s contain" : " contained")} non-existent files.\r\n\r\n");
                }

                sb.Append($"The first row {(chkHasHeaders.Checked ? "contained": "did not contain")} headers; ");
                sb.Append(
                    chkContinue.Checked
                        ? $"{cGood} of {cTotal} files were copied successfully.\r\n\n"
                        : $"No files were actually copied.\r\nCheck \"Continue on Error\" to actually copy the files.\r\n\n");
                foreach (FileListEntry f  in gb)
                {
                    string sExists = $"\r\n{(f.ExistingFileExists ? "" : "  FAILED: File did not exist\r\n\r\n")}";
                    sb.Append(
                        $"Row {f.RowNumber}: COPY \"{f.ExistingFilename}\" \"{f.NewNameInDestinationFolder}\":{sExists}");
                }
            }
            catch (ApplicationException ex)
            {
                sb.Append("Exception:");
                sb.Append(ex.Message);
            }
            finally
            {
                using (FrmResult frm = new FrmResult())
                {
                    frm.Message = sb.ToString();
                    frm.ShowDialog();
                }
                EnableControls();
                UseWaitCursor = false;
            }
        }

        private void EnableControls()
        {
            btnRun.Enabled = Renamer.ArePropertiesValid();
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
            AddExcelFile();
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

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            clbWorkbookFilenames.Items.Clear();
            _renamer.WorkbookFilenames.Clear();
        }

        #endregion

        private void ctlOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
