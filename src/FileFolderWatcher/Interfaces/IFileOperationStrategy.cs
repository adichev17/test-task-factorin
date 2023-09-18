using FileFolderWatcher.Enums;

namespace FileFolderWatcher.Interfaces
{
    /// <summary>
    /// file operations interface
    /// </summary>
    public interface IFileOperationStrategy
    {
        /// <summary>
        /// process the operation
        /// </summary>
        /// <returns></returns>
        Task<string> Handle();
    }
}
