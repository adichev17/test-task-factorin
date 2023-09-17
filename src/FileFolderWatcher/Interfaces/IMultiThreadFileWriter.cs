namespace FileFolderWatcher.Interfaces
{
    /// <summary>
    /// interface for thread-safe writing to a file
    /// </summary>
    public interface IMultiThreadFileWriter
    {
        /// <summary>
        /// thread-safe writing to file
        /// </summary>
        /// <param name="line">text to write</param>
        void WriteLine(string line);
    }
}
