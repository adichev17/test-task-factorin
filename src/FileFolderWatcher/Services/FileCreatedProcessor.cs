using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Services.FileHandlers.EventCreated;

namespace FileFolderWatcher.Services
{
    public class FileCreatedProcessor : IFileOperationSpecification
    {
        private readonly IFileHandlerStrategy _fileHandlerStrategy;

        public FileCreatedProcessor(FileTypeEnum fileTypeEnum)
        {
            _fileHandlerStrategy = fileTypeEnum switch
            {
                FileTypeEnum.Html => new HtmlCreatedHandlerStrategy(),
                FileTypeEnum.Css => new CssCreatedHandlerStrategy(),
                FileTypeEnum.NotSpecific => new NotSpecificCreatedHandlerStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(fileTypeEnum), fileTypeEnum, null)
            };
        }

        /// <summary>
        /// file handler by strategy
        /// </summary>
        /// <param name="path">full path to file</param>
        /// <returns>text</returns>
        public async Task<string> Handle(string path)
        {
           var text = await _fileHandlerStrategy.Handle(path);
           return text;
        }
    }
}
