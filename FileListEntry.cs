namespace Boundless.ReNamer
{
    public class FileListEntry
    {
        public int RowNumber { get; set; }
        public string ExistingFilename { get; set; }
        public string NewNameInSourceFolder { get; set; }
        public string NewNameInDestinationFolder { get; set; }
        public bool ExistingFileExists { get; set; }
    }
}