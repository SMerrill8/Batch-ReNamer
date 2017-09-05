namespace Ideal.ReNamer
{
    public class FileListEntry
    {
        public string ControllingWorkbook { get; set; }
        public int RowNumber { get; set; }
        public string ExistingFilename { get; set; }
        public string NewNameInSourceFolder { get; set; }
        public string NewNameInDestinationFolder { get; set; }
        public bool ExistingFileExists { get; set; }
    }
}