using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Files
{
    /// <summary>
    /// undefined file type
    /// </summary>
    public class NotSpecificFileDataSource : FileDataSource, IFileTypeSpecification
    {
        public NotSpecificFileDataSource(string fileName) : base(fileName)
        {
            FileType = FileTypeEnum.NotSpecific;
        }
        public override Task<string> Handle()
        {
            return Task.FromResult(FileName);
        }
    }
}
