using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

// Dependency Injection and Settings: https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/

namespace BoilerplateConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            // .AddEnvironmentVariables("JRTech_");

            var config = builder.Build();
            var author = config.GetSection("author").Get<Person>();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppHost, AppHost>()
                .AddSingleton<IServiceA, ServiceA>()
            .BuildServiceProvider();

            var appHost = serviceProvider.GetService<IAppHost>();
            appHost.Run();
        }
    }
}
