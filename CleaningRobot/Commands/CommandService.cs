using CleaningRobot.Enums;
using Microsoft.Extensions.Logging;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a service to run robot commands.
    /// </summary>
    internal class CommandService : ICommandService
    {
        private const string EXECUTING_COMMAND = "Executing command of type: {0}.";
        private const string EXECUTING_BACK_OFF_SEQUENCE = "Executing back off sequece: {0}.";

        private readonly ICommandFactory commandFactory;
        private readonly ILogger<CommandService> logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandService"/> class.
        /// </summary>
        public CommandService(
            ICommandFactory commandFactory,
            ILogger<CommandService> logger)
        {
            this.commandFactory = commandFactory;
            this.logger = logger;
        }


        /// <inheritdoc />
        public CommandState TryCommand(CommandType command)
        {
            logger.LogInformation(EXECUTING_COMMAND, command);
            return commandFactory.CreateCommand(command).Execute();
        }


        /// <inheritdoc />
        public CommandState TryBackOffStrategy()
        {
            foreach (var backOffSequence in GetBackOffSequences())
            {
                var result = TryBackOffSequence(backOffSequence);
                if (result != CommandState.CannotExecute)
                {
                    return result;
                }
            }

            return CommandState.Stuck;
        }


        private CommandState TryBackOffSequence(BackOffSequence backOffSequence)
        {
            logger.LogInformation(EXECUTING_BACK_OFF_SEQUENCE, backOffSequence.Name);
            foreach (var commandType in backOffSequence.Commands)
            {
                var command = commandFactory.CreateCommand(commandType);
                var result = command.Execute();
                if (result != CommandState.Success)
                {
                    return result;
                }
            }

            return CommandState.Success;
        }


        private IEnumerable<BackOffSequence> GetBackOffSequences()
        {
            yield return new BackOffSequence
            {
                Name = "BackOffSequence1",
                Commands = new List<CommandType> { CommandType.TurnRight, CommandType.Advance, CommandType.TurnLeft }
            };
            yield return new BackOffSequence
            {
                Name = "BackOffSequence2",
                Commands = new List<CommandType> { CommandType.TurnRight, CommandType.Advance, CommandType.TurnRight }
            };
            yield return new BackOffSequence
            {
                Name = "BackOffSequence3",
                Commands = new List<CommandType> { CommandType.TurnRight, CommandType.Advance, CommandType.TurnRight }
            };
            yield return new BackOffSequence
            {
                Name = "BackOffSequence4",
                Commands = new List<CommandType>
                    { CommandType.TurnRight, CommandType.Back, CommandType.TurnRight, CommandType.Advance }
            };
            yield return new BackOffSequence
            {
                Name = "BackOffSequence5",
                Commands = new List<CommandType> { CommandType.TurnLeft, CommandType.TurnLeft, CommandType.Advance }
            };
        }
    }
}