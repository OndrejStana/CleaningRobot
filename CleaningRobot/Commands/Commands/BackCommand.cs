using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable back robot command.
    /// </summary>
    internal class BackCommand : ICommand
    {
        private const int BATTERY_COST = 3;

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="BackCommand"/> class.
        /// </summary>
        public BackCommand(IRobotService robotService)
        {
            this.robotService = robotService;
        }


        /// <inheritdoc />
        public CommandState Execute()
        {
            return robotService.TryDrainBattery(BATTERY_COST) == CommandState.OutOfBattery 
                ? CommandState.OutOfBattery 
                : robotService.TryGoBack();
        }
    }
}