using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using static Ideal.ReNamer.Properties.Settings;
using static System.String;

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

        /// <summary>
        /// Make sure that src, dest and file exist on disk
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="file"></param>
        /// <returns>true if all three exist</returns>
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
        /// <param name="sourceFolder">Source Folder containng files to be processed.</param>
        /// <param name="destFolder">Destination Folder.  Can be the same value as the Source Folder if renaming in place is desired.</param>
        /// <param name="wbkFilename">The filename of an Excel workbook containing filenames to be processed.</param>
        /// <param name="continueOnError">Test Mode.  False= supress copying to destination.</param>
        /// <param name="hasHeaders">True if a header row is expected to be in row one of the Excel document.</param>
        /// <param name="makeZips">True causes a zip file to be made.</param>
        /// <param name="rowCount">The number of rows found in the Excel spreadsheet.</param>
        /// <param name="copiedCount">The number of files which were actually copied.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="IOException"></exception>
        public void CopyFiles(string sourceFolder, string destFolder, string wbkFilename, 
            bool continueOnError, bool hasHeaders, bool makeZips, 
            ref int rowCount, ref int copiedCount)
        {
            const string MESSAGE = "Value cannot be null or empty.";
            if (IsNullOrEmpty(sourceFolder))
                throw new ArgumentException(MESSAGE,nameof(sourceFolder));
            if (IsNullOrEmpty(destFolder))
                throw new ArgumentException(MESSAGE,nameof(destFolder));
            if (IsNullOrEmpty(wbkFilename))
                throw new ArgumentException(MESSAGE,nameof(wbkFilename));

            if (new DirectoryInfo(sourceFolder).GetFileSystemInfos("*.*").Length == 0)
                throw new ApplicationException($"No Files were found in the source folder {sourceFolder} !");

            DirectoryInfo diDestination = new DirectoryInfo(destFolder);

            if (!diDestination.Exists) diDestination.Create();

            Dictionary<int, string> excel = ExcelProcessor.ImportOfficeOpenXmlWorkbook(wbkFilename, hasHeaders);
            rowCount = excel.Count;
            if (rowCount == 0)
                throw new ApplicationException($"There were no rows to process within {wbkFilename}.");
            List<FileListEntry> fiBadList = new List<FileListEntry>();
            SourceFolder = sourceFolder;

            DestFolder = destFolder;
            WorkbookFilename = wbkFilename;
            string cellA1 = excel.First().Value.Split('|')[0];
            if (!hasHeaders)
            {
                if (!cellA1.Contains("."))
                {
                    throw new ApplicationException("Headers were not expected, yet the first row is not a file.");
                }
            }

            foreach (KeyValuePair<int, string> entry in excel)
            {
                FileInfo fi = new FileInfo($@"{SourceFolder}\{entry.Value.Split('|')[0]}");
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(entry.Value.Split('|')[1]);
                FileListEntry e = new FileListEntry
                {
                    ExistingFilename = fi.FullName,
                    NewNameInDestinationFolder = $@"{DestFolder}\{nameWithoutExtension}{fi.Extension}",
                    NewNameInSourceFolder = $@"{SourceFolder}\{nameWithoutExtension}{fi.Extension}",
                    ExistingFileExists = fi.Exists,
                    RowNumber = entry.Key
                };

                if (e.ExistingFileExists)
                {
                    if (!continueOnError) continue;
                    File.Copy(fi.FullName, e.NewNameInDestinationFolder, true);
                    copiedCount++;
                }
                else
                {
                    fiBadList.Add(e);
                }
            }
            int cBad = fiBadList.Count;
            if (cBad == 0)
            {
                MakeZipFiles(diDestination);
                return;
            }
            ApplicationException ex = new ApplicationException(
                $"{cBad} row{(cBad > 1 ? "s" : "")} contained non-existent files.");
            ex.Data.Add("BadList", fiBadList);
            throw ex;
        }

        private static void MakeZipFiles(DirectoryInfo diDestination)
        {
            string dir = diDestination.Parent.FullName;
            string zipPath = $@"{dir}\{diDestination.Name}.zip";
            dir = diDestination.FullName;
            ZipFile.CreateFromDirectory(dir, zipPath);
            string destZipPath = $@"{dir}\{diDestination.Name}.zip";
            File.Move(zipPath,destZipPath);

        }
    }
}