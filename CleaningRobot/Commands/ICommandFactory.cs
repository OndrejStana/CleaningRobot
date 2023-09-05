using CleaningRobot.Enums;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Factory for creating robot commands.
    /// </summary>
    internal interface ICommandFactory
    {
        /// <summary>
        /// Creates a new robot command.
        /// <param name="commandType">An type of command to be created.</param>
        /// <returns>An implementation of the <see cref="ICommand"/> interface.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When the specified command is not supported.</exception>
        /// </summary>
        ICommand CreateCommand(CommandType commandType);
    }
}