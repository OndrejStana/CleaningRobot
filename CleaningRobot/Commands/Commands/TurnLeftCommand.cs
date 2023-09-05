using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable turn left robot command.
    /// </summary>
    internal class TurnLeftCommand : ICommand
    {
        private const int BATTERY_COST = 1;

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="TurnLeftCommand"/> class.
        /// </summary>
        public TurnLeftCommand(IRobotService robotService)
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

            robotService.TurnLeft();
            return CommandState.Success;
        }
    }
}