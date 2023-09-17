using FileFolderWatcher.Enums;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Models.Configuration;
using Microsoft.Extensions.Options;

namespace FileFolderWatcher.Services
{
    public class FileWatcher : IFileWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly IMultiThreadFileWriter _multiThreadFileWriter;
        private readonly ILogger<FileWatcher> _logger;

        public FileWatcher(IOptions<AppConfig> appConfig, IMultiThreadFileWriter multiThreadFileWriter,
            ILogger<FileWatcher> logger)
        {
            _multiThreadFileWriter = multiThreadFileWriter;
            _logger = logger;
            var appConfig1 = appConfig.Value;
            _watcher = new FileSystemWatcher(appConfig1.FullPathFolder);
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested) return Task.CompletedTask;

            _watcher.Created += (o, e) => Task.Run(() => OnCreated(o, e), stoppingToken);
            _watcher.Changed += (o, e) => Task.Run(() => OnChanged(o, e), stoppingToken);
            _watcher.Deleted += (o, e) => Task.Run(() => OnDeleted(o, e), stoppingToken);
            _watcher.EnableRaisingEvents = true;
            return Task.CompletedTask;
        }

        private async Task OnCreated(object sender, FileSystemEventArgs e)
        {
#if DEBUG
            _logger.LogInformation($"File Created {e.FullPath}. Executable thread: {Thread.CurrentThread.ManagedThreadId}");
#endif
            _logger.LogInformation($"Start file processing {e.Name}");
            var fileTypeEnum = GetFileTypeEnum(e.FullPath);
            IFileOperationSpecification fileCreatedProcessor = new FileCreatedProcessor(fileTypeEnum);
            var text = await fileCreatedProcessor.Handle(e.FullPath);
            _multiThreadFileWriter.WriteLine(text);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
#if DEBUG
            _logger.LogInformation($"File Changed. Executable thread: {Thread.CurrentThread.ManagedThreadId}");
#endif
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
#if DEBUG
            _logger.LogInformation($"File Deleted. Executable thread: {Thread.CurrentThread.ManagedThreadId}");
#endif
        }

        private FileTypeEnum GetFileTypeEnum(string path)
        {
            var fileInfo = new FileInfo(path);
            return !Enum.TryParse(fileInfo.Extension.Replace(".", string.Empty), true, out FileTypeEnum fileTypeEnum)
                ? FileTypeEnum.NotSpecific
                : fileTypeEnum;
        }

        public void Dispose()
        {
            _watcher?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}