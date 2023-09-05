using CleaningRobot.Enums;

namespace CleaningRobot.Commands
{
    /// <summary>
    /// Robot back off sequence.
    /// </summary>
    internal class BackOffSequence
    {
        /// <summary>
        /// Name of back off sequence.
        /// </summary>
        public string Name { get; set; } = string.Empty;


        /// <summary>
        /// List of robot commands in back off sequence.
        /// </summary>
        public List<CommandType> Commands { get; set; } = new();
    }
}