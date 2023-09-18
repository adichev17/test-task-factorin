using FileFolderWatcher.Constants;
using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Services.FileHandlers.Decorators;
using FileFolderWatcher.Services.FileHandlers.Decorators.Base;
using FileFolderWatcher.Services.FileHandlers.Files;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services
{
    /// <summary>
    /// file processing strategy when creating
    /// </summary>
    public class FileCreatedStrategy : IFileOperationStrategy
    {
        private readonly FileDataSource _fileTypeSpecification;

        public FileCreatedStrategy(string path)
        {
            var fileTypeEnum = GetFileTypeEnum(path);
            _fileTypeSpecification = fileTypeEnum switch
            {
                FileTypeEnum.Html => new HtmlFileDataSource(path),
                FileTypeEnum.Css => new CssFileDataSource(path),
                FileTypeEnum.NotSpecific => new NotSpecificFileDataSource(path),
                _ => throw new ArgumentOutOfRangeException(nameof(fileTypeEnum), fileTypeEnum, null)
            };
        }

        /// <summary>
        /// file handler
        /// </summary>
        /// <returns>text</returns>
        public async Task<string> Handle()
        {
            FileDataSourceDecorator? decorator = _fileTypeSpecification.FileType switch
            {
                FileTypeEnum.Html => new HtmlFileTagHandler(_fileTypeSpecification, HtmlItemKeys.TagDiv,
                    FileOperationEnum.Created),
                FileTypeEnum.Css => new FileValidateBracketHandler(_fileTypeSpecification, FileOperationEnum.Created),
                FileTypeEnum.NotSpecific => new FilePunctuationMarkHandler(_fileTypeSpecification,
                    FileOperationEnum.Created),
                _ => throw new ArgumentOutOfRangeException(nameof(decorator))
            };
            var text = await decorator.Handle();
            return text;
        }

        /// <summary>
        /// Get file type
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns></returns>
        private FileTypeEnum GetFileTypeEnum(string path)
        {
            var fileInfo = new FileInfo(path);
            return !Enum.TryParse(fileInfo.Extension.Replace(".", string.Empty), true, out FileTypeEnum fileTypeEnum)
                ? FileTypeEnum.NotSpecific
                : fileTypeEnum;
        }
    }
}