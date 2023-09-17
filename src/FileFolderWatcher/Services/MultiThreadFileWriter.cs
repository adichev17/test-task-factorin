using System.Collections.Concurrent;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Models.Configuration;
using Microsoft.Extensions.Options;

namespace FileFolderWatcher.Services
{
    public class MultiThreadFileWriter : IMultiThreadFileWriter
    {
        private readonly AppConfig _appConfig;
        private static readonly ConcurrentQueue<string> TextQueue = new();
        private readonly CancellationTokenSource _source = new();
        private readonly CancellationToken _token;

        public MultiThreadFileWriter(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value;
            _token = _source.Token;
            // run the task to monitor the queue
            Task.Run(WriteToFile, _token);
        }

        public void WriteLine(string line)
        {
            TextQueue.Enqueue(line);
        }

        private async Task WriteToFile()
        {
            while (true)
            {
                if (_token.IsCancellationRequested)
                {
                    return;
                }

                await using var w = File.AppendText(_appConfig.OutputFilePathResult);
                while (TextQueue.TryDequeue(out string textLine))
                {
                    await w.WriteLineAsync(textLine);
                }

                await w.FlushAsync();
            }
        }
    }
}
