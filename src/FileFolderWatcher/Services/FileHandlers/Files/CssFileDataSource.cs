using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Files
{
    /// <summary>
    /// CSS file
    /// </summary>
    public class CssFileDataSource : FileDataSource, IFileTypeSpecification
    {
        public CssFileDataSource(string path) : base(path)
        {
            FileType = FileTypeEnum.Css;
        }
        public override Task<string> Handle()
        {
            return Task.FromResult(FileName);
        }
    }
}
