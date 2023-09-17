using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;

namespace FileFolderWatcher.Services.FileHandlers.EventCreated
{
    public class CssCreatedHandlerStrategy : IFileHandlerStrategy
    {
        public async Task<string> Handle(string path)
        {
            int leftBracketCount = 0;
            int rightBracketCount = 0;

            var fileName = Path.GetFileNameWithoutExtension(path);

            string text = await File.ReadAllTextAsync(path);

            text.AsParallel().ForAll(symbol =>
            {
                switch (symbol)
                {
                    case '{':
                        Interlocked.Increment(ref leftBracketCount);
                        break;
                    case '}':
                        Interlocked.Increment(ref rightBracketCount);
                        break;
                }
            });

            return $"{fileName}-{FileOperationEnum.Created}-{leftBracketCount == rightBracketCount}";
        }
    }
}
