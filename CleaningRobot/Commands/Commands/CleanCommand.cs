using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable clean robot command.
    /// </summary>
    internal class CleanCommand : ICommand
    {
        private const int BATTERY_COST = 5;

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="CleanCommand"/> class.
        /// </summary>
        public CleanCommand(IRobotService robotService)
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

            robotService.Clean();
            return CommandState.Success;
        }
    }
}