namespace CleaningRobot.Enums
{
    /// <summary>
    /// Represents the result of executed robot command.
    /// </summary>
    internal enum CommandState
    {
        /// <summary>
        /// Command executed successfully.
        /// </summary>
        Success,


        /// <summary>
        /// Robot is out of battery.
        /// </summary>
        OutOfBattery,


        /// <summary>
        /// Command cannot be executed.
        /// </summary>
        CannotExecute,


        /// <summary>
        /// Robot is stuck.
        /// </summary>
        Stuck
    }
}