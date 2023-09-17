using System.Text.RegularExpressions;
using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;

namespace FileFolderWatcher.Services.FileHandlers.EventCreated
{
    public partial class NotSpecificCreatedHandlerStrategy : IFileHandlerStrategy
    {
        public async Task<string> Handle(string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            string text = await File.ReadAllTextAsync(path);
            var punctuationMarksCount = PunctuationMarks().Count(text);
            return $"{fileName}-{FileOperationEnum.Created}-{punctuationMarksCount}";
        }

        [GeneratedRegex("\\p{P}")]
        private static partial Regex PunctuationMarks();
    }
}
