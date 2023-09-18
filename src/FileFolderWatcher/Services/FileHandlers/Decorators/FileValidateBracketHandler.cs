using FileFolderWatcher.Enums;
using FileFolderWatcher.Services.FileHandlers.Decorators.Base;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Decorators
{
    public class FileValidateBracketHandler : FileDataSourceDecorator
    {
        public FileValidateBracketHandler(FileDataSource dataSource, FileOperationEnum operation) : base(dataSource, operation)
        {
        }

        public override async Task<string> Handle()
        {
            int leftBracketCount = 0;
            int rightBracketCount = 0;

            string text = await File.ReadAllTextAsync(base.FullPath);

            //todo: or we can use Regex
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

            return $"{base.FileName}-{base.Operation}-{leftBracketCount == rightBracketCount}";
        }
    }
}
