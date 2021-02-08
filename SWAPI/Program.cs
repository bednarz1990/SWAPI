using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SWAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>().Build();
        }

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables();
        }
    }
}