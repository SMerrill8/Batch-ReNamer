using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private StringCollection _workbookFilenames;

        public bool ContinueOnBad { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public Renamer()
        {
            _sourceFolder = Default.SourceFolder ?? "";
            _destFolder = Default.DestFolder ?? "";
            _workbookFilenames = Default.WorkbookFilenames ?? new StringCollection();
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

        /// <summary>
        /// All of the filenames
        /// </summary>
        public StringCollection WorkbookFilenames
        {
            get { return _workbookFilenames; }
            set
            {
                _workbookFilenames = value;
                Default.WorkbookFilenames = _workbookFilenames;
                Default.Save();
            }
        }

        /// <summary>
        /// Make sure that src, dest and file exist on disk
        /// </summary>
        /// <returns>true if SourceFolder, and all Excel files exist, and the DestFolder is non-null.</returns>
        public bool ArePropertiesValid()
        {
            string src = SourceFolder;
            StringCollection files = WorkbookFilenames;

            bool en;
            try
            {
                en = !IsNullOrEmpty(src);
                en = en && !IsNullOrEmpty(DestFolder);
                en = files.Cast<string>().Aggregate(en, (current, f) => current && !IsNullOrEmpty(f));
                if (en)
                {
                    en = new DirectoryInfo(src).Exists;
                    en = files.Cast<string>().Aggregate(en, (current, f) => current && new FileInfo(f).Exists);
                }
            }
            catch (Exception)
            {
                en = false;
            }
            return en;
        }

        /// <summary>
        /// Recursive folder purge
        /// </summary>
        /// <param name="di"></param>
        private void PurgeFolder(DirectoryInfo di)
        {
            if (!di.Exists) return;
            foreach (FileInfo f in di.GetFiles())
            {
                f.Delete();
            }
            foreach (DirectoryInfo d in di.GetDirectories())
            {
                PurgeFolder(d);
            }
            di.Delete();
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
        /// <param name="fiList">A list of every result, whether copied or not.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="IOException"></exception>
        public void CopyFiles(string sourceFolder, string destFolder, string wbkFilename, 
            bool continueOnError, bool hasHeaders, bool makeZips, 
            ref List<FileListEntry> fiList)
        {
            // Validate parameters:
            const string MESSAGE = "Value cannot be null or empty.";      
            if (IsNullOrEmpty(sourceFolder))
                throw new ArgumentException(MESSAGE, nameof(sourceFolder));
            if (IsNullOrEmpty(destFolder))
                throw new ArgumentException(MESSAGE, nameof(destFolder));
            if (IsNullOrEmpty(wbkFilename))
                throw new ArgumentException(MESSAGE, nameof(wbkFilename));
            
            if (new DirectoryInfo(sourceFolder).GetFileSystemInfos("*.*").Length == 0)
                throw new ApplicationException($"No Files were found in the source folder {sourceFolder} !");

            // Create Destination folder if it doesn't exist:
            DirectoryInfo diDestination = new DirectoryInfo(destFolder);
            if (!diDestination.Exists)
            diDestination.Create();

            // Re-create subfolder using Excel filename without extension:
            diDestination = new DirectoryInfo($@"{diDestination.FullName}\{Path.GetFileNameWithoutExtension(wbkFilename)}");
            PurgeFolder(diDestination);
            diDestination.Create();

            destFolder = diDestination.FullName;

            // Import the Excel document into the dictionary:
            Dictionary<int, string> excel = ExcelProcessor.ImportOfficeOpenXmlWorkbook(wbkFilename, hasHeaders);
            int rowCount = excel.Count;
            if (rowCount == 0)
                throw new ApplicationException($"There were no rows to process within {wbkFilename}.");
            
            SourceFolder = sourceFolder;

            // If headers are not expected, the first row must be a filename, which means it contains a dot:
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
                    ControllingWorkbook = wbkFilename,
                    ExistingFilename = fi.FullName,
                    NewNameInDestinationFolder = $@"{destFolder}\{nameWithoutExtension}{fi.Extension}",
                    NewNameInSourceFolder = $@"{SourceFolder}\{nameWithoutExtension}{fi.Extension}",
                    ExistingFileExists = fi.Exists,
                    RowNumber = entry.Key
                };

                if (e.ExistingFileExists)
                {
                    if (!continueOnError) continue;
                    File.Copy(fi.FullName, e.NewNameInDestinationFolder, true);
                }
                fiList.Add(e);
            }
            if (fiList.TrueForAll(x => x.ExistingFileExists))
            {
                Renamer.MakeZipFiles(diDestination);
            }
        }

        public static void MakeZipFiles(DirectoryInfo diDestination)
        {
            string dir = diDestination.Parent.FullName;
            string zipPath = $@"{dir}\{diDestination.Name}.zip";
            dir = diDestination.FullName;
            if (File.Exists(zipPath)) File.Delete(zipPath);
            ZipFile.CreateFromDirectory(dir, zipPath);
            string destZipPath = $@"{dir}\{diDestination.Name}.zip";
            if (File.Exists(destZipPath)) File.Delete(destZipPath);
            File.Move(zipPath,destZipPath);
        }
    }
}