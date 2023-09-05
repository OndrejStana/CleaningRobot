using CleaningRobot.Enums;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a service to run robot commands.
    /// </summary>
    internal interface ICommandService
    {
        /// <summary>
        /// Tries a single robot command.
        /// <param name="command">An type of command to be tried.</param>
        /// <returns>A result state of tried command.
        /// <see cref="CommandState.Success"/> when command is executed successfully.
        /// <see cref="CommandState.OutOfBattery"/> when robot does not have enough battery.
        /// <see cref="CommandState.CannotExecute"/> when command cannot be executed.</returns>
        /// </summary>
        CommandState TryCommand(CommandType command);


        /// <summary>
        /// Tries back off strategy.
        /// <returns>A result state of tried back off strategy.
        /// <see cref="CommandState.Success"/> when command is executed successfully.
        /// <see cref="CommandState.OutOfBattery"/> when robot does not have enough battery.
        /// <see cref="CommandState.Stuck"/> when robot is stuck.</returns>
        /// </summary>
        CommandState TryBackOffStrategy();
    }
}