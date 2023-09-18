using FileFolderWatcher.Enums;
using FileFolderWatcher.Regex;
using FileFolderWatcher.Services.FileHandlers.Decorators.Base;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Decorators
{
    public class FilePunctuationMarkHandler : FileDataSourceDecorator
    {
        public FilePunctuationMarkHandler(FileDataSource dataSource, FileOperationEnum operation) : base(dataSource,
            operation)
        {
        }

        public override async Task<string> Handle()
        {
            string text = await File.ReadAllTextAsync(base.FullPath);
            var punctuationMarksCount = RegexExtension.PunctuationMarks().Count(text);
            return $"{base.FileName}-{base.Operation}-{punctuationMarksCount}";
        }
    }
}
