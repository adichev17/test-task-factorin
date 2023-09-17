using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using HtmlAgilityPack;

namespace FileFolderWatcher.Services.FileHandlers.EventCreated
{
    public class HtmlCreatedHandlerStrategy : IFileHandlerStrategy
    {
        public async Task<string> Handle(string path, FileOperationEnum operation)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var doc = new HtmlDocument();
            doc.Load(path);
            var divCount = doc.DocumentNode.Descendants("div").Count();
            var result = $"{fileName}-{operation}-{divCount}";
            return await Task.FromResult(result);
        }
    }
}
