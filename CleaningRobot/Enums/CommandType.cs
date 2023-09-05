using System.Runtime.Serialization;

namespace CleaningRobot.Enums
{
    /// <summary>
    /// Represents the list of commands that the robot can execute.
    /// </summary>
    internal enum CommandType
    {
        /// <summary>
        /// Instructs the robot to turn 90 degrees to the left.
        /// </summary>
        [EnumMember(Value = "TL")]
        TurnLeft,


        /// <summary>
        /// Instructs the robot to turn 90 degrees to the right.
        /// </summary>
        [EnumMember(Value = "TR")]
        TurnRight,


        /// <summary>
        /// Instructs the robot to advance one cell forward into the next cell.
        /// </summary>
        [EnumMember(Value = "A")]
        Advance,


        /// <summary>
        /// Instructs the robot to move back one cell without changing direction.
        /// </summary>
        [EnumMember(Value = "B")]
        Back,


        /// <summary>
        /// Instructs the robot to clean the current cell.
        /// </summary>
        [EnumMember(Value = "C")]
        Clean
    }
}