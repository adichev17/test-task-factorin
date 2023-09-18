namespace FileFolderWatcher.Interfaces
{
    public interface IFileTypeSpecification
    {
        /// <summary>
        /// process the operation
        /// </summary>
        /// <param name="path">full path to file</param>
        /// <returns></returns>
        Task<string> Handle();
    }
}
