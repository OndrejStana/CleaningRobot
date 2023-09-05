using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Factory for creating robot commands.
    /// </summary>
    internal class CommandFactory : ICommandFactory
    {
        private const string INVALID_COMMAND_TYPE = "Invalid command type.";

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        public CommandFactory(IRobotService robotService)
        {
            this.robotService = robotService;
        }


        /// <inheritdoc/>
        public ICommand CreateCommand(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.TurnLeft => new TurnLeftCommand(robotService),
                CommandType.TurnRight => new TurnRightCommand(robotService),
                CommandType.Advance => new AdvanceCommand(robotService),
                CommandType.Back => new BackCommand(robotService),
                CommandType.Clean => new CleanCommand(robotService),
                _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, INVALID_COMMAND_TYPE)
            };
        }
    }
}