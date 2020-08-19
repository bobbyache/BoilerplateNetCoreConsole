using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

// Dependency Injection and Settings: https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/
// CommandLineParser: https://github.com/commandlineparser/commandline?WT.mc_id=-blog-scottha

namespace BoilerplateConsole
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                   });

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
