using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;

// Dependency Injection and Settings: https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/
// DragonFruit: https://www.hanselman.com/blog/DragonFruitAndSystemCommandLineIsANewWayToThinkAboutNETConsoleApps.aspx
// DragonFruit Nuget: (Alpha Release) https://www.nuget.org/packages/System.CommandLine.DragonFruit
// DragonFruit Overview: https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview

namespace BoilerplateConsole
{
    public class Program
    {
        public static int Main(bool verbose,
            string flavor = "chocolate",
            int count = 1)
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

            Console.WriteLine(verbose);
            Console.WriteLine(flavor);
            Console.WriteLine(count);

            var appHost = serviceProvider.GetService<IAppHost>();
            appHost.Run();

            return 0;
        }
    }
}
