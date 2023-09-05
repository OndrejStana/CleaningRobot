using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable turn right robot command.
    /// </summary>
    internal class TurnRightCommand : ICommand
    {
        private const int BATTERY_COST = 1;

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="TurnRightCommand"/> class.
        /// </summary>
        public TurnRightCommand(IRobotService robotService)
        {
            this.robotService = robotService;
        }


        /// <inheritdoc />
        public CommandState Execute()
        {
            if (robotService.TryDrainBattery(BATTERY_COST) == CommandState.OutOfBattery)
            {
                return CommandState.OutOfBattery;
            }

            robotService.TurnRight();
            return CommandState.Success;
        }
    }
}