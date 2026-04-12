using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DemoNUnitProject.Utils
{
    public class ConfigReader
    {
        private static IConfiguration configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
      .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string GetBrowser()
        {
            return configuration["browser"];
        }

        public static string GetBaseUrl()
        {
            return configuration["baseUrl"];
        }

        public static int GetTimeout()
        {
            return int.Parse(configuration["timeout"]);
        }
    }
}