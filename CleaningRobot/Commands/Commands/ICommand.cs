using CleaningRobot.Enums;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Represents a executable robot command.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes a robot command.
        /// </summary>
        public CommandState Execute();
    }
}