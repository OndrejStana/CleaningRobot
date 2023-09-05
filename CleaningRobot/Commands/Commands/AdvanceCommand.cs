using CleaningRobot.Enums;
using CleaningRobot.Robot;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable advance robot command.
    /// </summary>
    internal class AdvanceCommand : ICommand
    {
        private const int BATTERY_COST = 2;

        private readonly IRobotService robotService;


        /// <summary>
        /// Initializes a new instance of the <see cref="AdvanceCommand"/> class.
        /// </summary>
        public AdvanceCommand(IRobotService robotService)
        {
            this.robotService = robotService;
        }


        /// <inheritdoc />
        public CommandState Execute()
        {
            return robotService.TryDrainBattery(BATTERY_COST) == CommandState.OutOfBattery 
                ? CommandState.OutOfBattery 
                : robotService.TryAdvance();
        }
    }
}