using Microsoft.Extensions.Configuration;

namespace CapitolisTestAutomationUI.Support
{
    public static class AppSettingsReader
    {
        private static IConfigurationRoot? _config;

        static AppSettingsReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            _config = builder.Build();
        }

        public static string GetConfigValue(string key) => _config[key] ?? throw new ArgumentNullException(nameof(key) + " not found in config!");
    }
}
