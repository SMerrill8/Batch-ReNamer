using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Ideal.ReNamer.Properties.Settings;

namespace Ideal.ReNamer
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
                en = !String.IsNullOrEmpty(src);
                en = en && !String.IsNullOrEmpty(dest);
                en = en && !String.IsNullOrEmpty(file);
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
        /// <param name="sourceFolder">Source Folder containng files to be processed.</param>
        /// <param name="destFolder">Destination Folder.  Can be the same value as the Source Folder if renaming in place is desired.</param>
        /// <param name="wbkFilename">The filename of an Excel workbook containing filenames to be processed.</param>
        /// <param name="continueOnError">Test Mode.  False= supress copying to destination.</param>
        /// <param name="hasHeaders">True if a header row is expected to be in row one of the Excel document.</param>
        /// <param name="rowCount">The number of rows found in the Excel spreadsheet.</param>
        /// <param name="copiedCount">The number of files which were actually copied.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public void CopyFiles(string sourceFolder, string destFolder, string wbkFilename, bool continueOnError, bool hasHeaders, ref int rowCount, ref int copiedCount)
        {
         
            string s = "Value cannot be null or empty.";
            if (String.IsNullOrEmpty(sourceFolder))
                throw new ArgumentException(s,nameof(sourceFolder));
            if (String.IsNullOrEmpty(destFolder))
                throw new ArgumentException(s,nameof(destFolder));
            if (String.IsNullOrEmpty(wbkFilename))
                throw new ArgumentException(s,nameof(wbkFilename));

            if (new DirectoryInfo(sourceFolder).GetFileSystemInfos("*.*").Length == 0)
                throw new ApplicationException($"No Files were found in the source folder {sourceFolder} !");

            DirectoryInfo diDestination = new DirectoryInfo(destFolder);

            if (!diDestination.Exists) diDestination.Create();

            Dictionary<int, string> excel = ExcelProcessor.ImportOfficeOpenXmlWorkbook(wbkFilename, hasHeaders);
            rowCount = excel.Count;
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
                        copiedCount++;
                    }
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
        }
    }
}