using FileFolderWatcher.Enums;

namespace FileFolderWatcher.Services.FileHandlers.Files.Base
{
    public abstract class FileDataSource
    {
        public string FullPath { get; protected set; }
        public string FileName { get; protected set; }
        public FileTypeEnum FileType { get; protected set; }

        protected FileDataSource(string path)
        {
            FullPath = path;
            FileName = Path.GetFileNameWithoutExtension(path);
        }

        public abstract Task<string> Handle();
    }
}
