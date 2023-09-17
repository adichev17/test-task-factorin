using FileFolderWatcher;
using FileFolderWatcher.Interfaces;
using FileFolderWatcher.Models.Configuration;
using FileFolderWatcher.Services;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IFileWatcher, FileWatcher>();
        services.AddSingleton<IMultiThreadFileWriter, MultiThreadFileWriter>();
        services.AddOptions<AppConfig>().Bind(configuration.GetSection(AppConfig.Section));
    })
    .Build();

host.Run();
