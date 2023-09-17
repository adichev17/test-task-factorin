using FileFolderWatcher.Interfaces;

namespace FileFolderWatcher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileWatcher _fileWatcher;

        public Worker(ILogger<Worker> logger, IFileWatcher fileWatcher)
        {
            _logger = logger;
            _fileWatcher = fileWatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _fileWatcher.StartAsync(stoppingToken);
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            while (!stoppingToken.IsCancellationRequested)
            {
#if DEBUG
                await Task.Delay(2000, stoppingToken);
#else
                //await Task.Delay(1000, stoppingToken);
#endif
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _fileWatcher?.Dispose();
            await Task.CompletedTask;
        }
    }
}