namespace FileFolderWatcher.Interfaces
{
    /// <summary>
    /// file tracking interface
    /// </summary>
    public interface IFileWatcher : IDisposable
    {
        /// <summary>
        /// start tracking file
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StartAsync(CancellationToken cancellationToken);
    }
}
