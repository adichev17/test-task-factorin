namespace FileFolderWatcher.Models.Configuration
{
    /// <summary>
    /// model config to "appsettings.json"
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// section name
        /// </summary>
        public const string Section = "AppConfig";
        /// <summary>
        /// Full path to the tracking folder
        /// </summary>
        public string FullPathFolder { get; set; }
        /// <summary>
        /// Full path to the output result
        /// </summary>
        public string OutputFilePathResult { get; set; }
    }
}
