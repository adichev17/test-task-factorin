using FileFolderWatcher.Enums;

namespace FileFolderWatcher.Interfaces
{
    /// <summary>
    /// file operations interface
    /// </summary>
    public interface IFileOperationSpecification
    {
        /// <summary>
        /// process the operation
        /// </summary>
        /// <param name="path">full path to file</param>
        /// <returns></returns>
        Task<string> Handle(string path);
    }
}
