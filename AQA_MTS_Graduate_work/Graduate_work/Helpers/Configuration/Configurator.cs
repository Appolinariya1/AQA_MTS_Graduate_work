using System.Reflection;
using Graduate_work.Models;
using Microsoft.Extensions.Configuration;

namespace Graduate_work.Helpers.Configuration

{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        public static AppSettings AppSettings
        {
            get
            {
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");

                appSettings.URL = child["URL"];
                appSettings.API_URL = child["API_URL"];
                appSettings.Token = child["Token"];

                return appSettings;
            }
        }

        public static List<User?> Users
        {
            get
            {
                List<User?> users = new List<User?>();
                var child = Configuration.GetSection("Users");
                foreach (var section in child.GetChildren())
                {
                    var user = new User.Builder()
                        .SetEmail(section["Email"])
                        .SetPassword(section["Password"])
                        .Build();

                    users.Add(user);
                }

                return users;
            }
        }

        public static string? BrowserType => Configuration[nameof(BrowserType)];
        public static double WaitsTimeout => Double.Parse(Configuration[nameof(WaitsTimeout)]);
    }
}