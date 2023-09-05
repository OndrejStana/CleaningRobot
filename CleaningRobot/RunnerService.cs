using CleaningRobot.Commands;
using CleaningRobot.Serializer;
using CleaningRobot.Enums;
using CleaningRobot.Robot;
using Microsoft.Extensions.Logging;

namespace CleaningRobot
{
    /// <summary>
    /// Represents a service responsible for running the main program.
    /// </summary>
    internal class RunnerService : IRunnerService
    {
        private const string RUNNING_EXCEPTION = "Running of program failed'.";

        private readonly ISerializationService serializationService;
        private readonly IDeserializationService deserializationService;
        private readonly IRobotService robotService;
        private readonly ILogger<RunnerService> logger;
        private readonly ICommandService commandService;


        /// <summary>
        /// Initializes a new instance of the <see cref="RunnerService"/> class.
        /// </summary>
        public RunnerService(
            ILogger<RunnerService> logger,
            ISerializationService serializationService,
            IDeserializationService deserializationService,
            IRobotService robotService,
            ICommandService commandService)
        {
            this.logger = logger;
            this.serializationService = serializationService;
            this.deserializationService = deserializationService;
            this.robotService = robotService;
            this.commandService = commandService;
        }


        /// <inheritdoc />
        public void Run()
        {
            try
            {
                var source = deserializationService.Deserialize();
                robotService.Initialize(source);
                foreach (var command in source.Commands)
                {
                    var result = commandService.TryCommand(command);
                    if (result == CommandState.CannotExecute)
                    {
                        result = commandService.TryBackOffStrategy();
                    }
                    if (result != CommandState.Success)
                    {
                        break;
                    }
                }
                serializationService.Serialize();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, RUNNING_EXCEPTION);
            }
        }
    }
}