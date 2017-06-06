using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Boundless.ReNamer.Properties;
using static System.String;
using static Boundless.ReNamer.Properties.Settings;

namespace Boundless.ReNamer
{
    public class Renamer
    {
        private string _sourceFolder;
        private string _destFolder;
        private string _workbookFilename;

        public bool ContinueOnBad { get; set; }

        public Renamer()
        {
            _sourceFolder = Default.SourceFolder;
            _destFolder = Default.DestFolder;
            _workbookFilename = Default.WorkbookFilename;
        }

        public string SourceFolder
        {
            get { return _sourceFolder; }
            set
            {
                _sourceFolder = value;
                Default.SourceFolder = _sourceFolder;
                Default.Save();
            }
        }

        public string DestFolder
        {
            get { return _destFolder; }
            set
            {
                _destFolder = value;
                Default.DestFolder = _destFolder;
                Default.Save();
            }
        }

        public string WorkbookFilename
        {
            get { return _workbookFilename; }
            set
            {
                _workbookFilename = value;
                Default.WorkbookFilename = _workbookFilename;
                Default.Save();
            }
        }

        public bool ArePropertiesValid(string src, string dest, string file)
        {
            bool en;
            try
            {
                en = !IsNullOrEmpty(src);
                en = en && !IsNullOrEmpty(dest);
                en = en && !IsNullOrEmpty(file);
                if (en)
                {
                    en = new DirectoryInfo(src).Exists;
                    en = en && new DirectoryInfo(dest).Exists;
                    en = en && new FileInfo(file).Exists;
                }
            }
            catch (Exception)
            {
                en = false;
            }
            return en;
        }

        /// <summary>
        /// Copies files listed in the Excel worksheet specified by wbkFileName from the sourceFolder to the destFolder
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        /// <param name="wbkFilename"></param>
        /// <param name="continueOnError"></param>
        /// <param name="hasHeaders"></param>
        /// <returns>Number of files which were copied.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public int CopyFiles(string sourceFolder, string destFolder, string wbkFilename, bool continueOnError, bool hasHeaders)
        {
            int ret = 0;
            string s = "Value cannot be null or empty.";
            if (IsNullOrEmpty(sourceFolder))
                throw new ArgumentException(s,nameof(sourceFolder));
            if (IsNullOrEmpty(destFolder))
                throw new ArgumentException(s,nameof(destFolder));
            if (IsNullOrEmpty(wbkFilename))
                throw new ArgumentException(s,nameof(wbkFilename));
            DirectoryInfo diDestination = new DirectoryInfo(destFolder);

            if (!diDestination.Exists) diDestination.Create();

            Dictionary<int, string> excel = ExcelProcessor.ImportOfficeOpenXmlWorkbook(wbkFilename, hasHeaders);
            List<FileListEntry> fiBadList = new List<FileListEntry>();
            SourceFolder = sourceFolder;
            DestFolder = destFolder;
            WorkbookFilename = wbkFilename;
            string cellA1 = excel.First().Value.Split('|')[0];
            if (hasHeaders)
            {
               // if (cellA1.Contains("."))
               // {
               //     throw new ApplicationException("Headers were expected, yet the first row looks like a file.");
               // }
            }
            else
            {
                if (!cellA1.Contains("."))
                {
                    throw new ApplicationException("Headers were not expected, yet the first row is not a file.");
                }
            }

            foreach (KeyValuePair<int, string> entry in excel)
            {
                FileInfo fi = new FileInfo($@"{SourceFolder}\{entry.Value.Split('|')[0]}");
                FileListEntry e = new FileListEntry
                {
                    ExistingFilename = fi.FullName,
                    NewNameInDestinationFolder = $@"{DestFolder}\{entry.Value.Split('|')[1]}{fi.Extension}",
                    NewNameInSourceFolder = $@"{SourceFolder}\{entry.Value.Split('|')[1]}{fi.Extension}",
                    ExistingFileExists = fi.Exists,
                    RowNumber = entry.Key
                };

                if (e.ExistingFileExists)
                {
                    if (continueOnError)
                    {
                        File.Copy(fi.FullName, e.NewNameInDestinationFolder, true);
                    }
                    ret++;
                }
                else
                {
                    fiBadList.Add(e);
                }
            }
            int cBad = fiBadList.Count;
            if (cBad > 0)
            {
                ApplicationException ex = new ApplicationException(
                    $"{cBad} row{(cBad > 1 ? "s" : "")} contained non-existent files.");
                ex.Data.Add("BadList", fiBadList);
                throw ex;
            }
            return ret;
        }
    }
}