using FileFolderWatcher.Enums;

namespace FileFolderWatcher.Interfaces
{
    /// <summary>
    /// interface file processing strategy 
    /// </summary>
    public interface IFileHandlerStrategy
    {
        /// <summary>
        /// process file
        /// </summary>
        /// <param name="path">full path to file</param>
        /// <param name="operation">file operation</param>
        /// <returns>text result</returns>
        public Task<string> Handle(string path, FileOperationEnum operation);
    }
}
