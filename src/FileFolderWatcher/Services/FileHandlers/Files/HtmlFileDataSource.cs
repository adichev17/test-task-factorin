using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Files
{
    /// <summary>
    /// HTML file
    /// </summary>
    public class HtmlFileDataSource : FileDataSource, IFileTypeSpecification
    {
        public HtmlFileDataSource(string path) : base(path)
        {
            FileType = FileTypeEnum.Html;
        }
        public override Task<string> Handle()
        {
            return Task.FromResult(FileName);
        }
    }
}
