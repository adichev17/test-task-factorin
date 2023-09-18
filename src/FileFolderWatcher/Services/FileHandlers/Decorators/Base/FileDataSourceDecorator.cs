using FileFolderWatcher.Enums;
using FileFolderWatcher.Services.FileHandlers.Files.Base;

namespace FileFolderWatcher.Services.FileHandlers.Decorators.Base
{
    /// <summary>
    /// abstract class for files decorator
    /// </summary>
    public abstract class FileDataSourceDecorator : FileDataSource
    {
        protected FileDataSource FileDataSource;
        protected FileOperationEnum Operation;

        protected FileDataSourceDecorator(FileDataSource fileDataSource, FileOperationEnum operation) : base(
            fileDataSource.FullPath)
        {
            FileDataSource = fileDataSource;
            Operation = operation;
        }
    }
}
