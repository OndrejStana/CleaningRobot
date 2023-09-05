using CleaningRobot.Commands;
using CleaningRobot.Serializer;
using CleaningRobot.Robot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CleaningRobot
{
    public class Program
    {
        private const string INVALID_ARGUMENTS = "The number {0} of arguments is invalid.";

        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddLogging(configure => configure.AddConsole())
                        .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
                    services.AddSingleton<IConfiguration>(configuration);
                    services.AddSingleton<IRobotState, RobotState>();
                    services.AddTransient<IDeserializationService, DeserializationService>();
                    services.AddTransient<IRobotService, RobotService>();
                    services.AddTransient<ICommandFactory, CommandFactory>();
                    services.AddTransient<ICommandService, CommandService>();
                    services.AddTransient<ISerializationService, SerializationService>();
                    services.AddTransient<IRunnerService, RunnerService>();
                })
                .Build();

            if (args.Length != 2)
            {
                var logger = host.Services.GetService<ILogger<Program>>();
                logger!.LogError(INVALID_ARGUMENTS, args.Length);
                return;
            }

            configuration["sourceFile"] = args[0];
            configuration["destinationFile"] = args[1];

            var runnerService = ActivatorUtilities.CreateInstance<RunnerService>(host.Services);
            runnerService.Run();
        }
    }
}