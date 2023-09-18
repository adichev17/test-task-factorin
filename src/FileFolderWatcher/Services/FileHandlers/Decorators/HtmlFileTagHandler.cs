using FileFolderWatcher.Enums;
using FileFolderWatcher.Services.FileHandlers.Decorators.Base;
using FileFolderWatcher.Services.FileHandlers.Files.Base;
using HtmlAgilityPack;

namespace FileFolderWatcher.Services.FileHandlers.Decorators
{
    public class HtmlFileTagHandler : FileDataSourceDecorator
    {
        public string Tag { get; set; }
        public HtmlFileTagHandler(FileDataSource dataSource, string tag, FileOperationEnum operation) : base(dataSource, operation)
        {
            Tag = tag;
        }

        public override async Task<string> Handle()
        {
            var fileName = Path.GetFileNameWithoutExtension(base.FullPath);
            var doc = new HtmlDocument();
            doc.Load(base.FullPath);
            var divCount = doc.DocumentNode.Descendants(Tag).Count();
            var result = $"{fileName}-{base.Operation}-{divCount}";
            return await Task.FromResult(result);
        }
    }
}
