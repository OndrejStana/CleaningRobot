using System.Runtime.Serialization;

namespace CleaningRobot.Enums
{
    /// <summary>
    /// Represents the direction in which the robot is facing.
    /// </summary>
    internal enum Direction
    {
        /// <summary>
        /// North direction.
        /// </summary>
        [EnumMember(Value = "N")]
        North,


        /// <summary>
        /// East direction.
        /// </summary>
        [EnumMember(Value = "E")]
        East,


        /// <summary>
        /// South direction.
        /// </summary>
        [EnumMember(Value = "S")]
        South,


        /// <summary>
        /// West direction.
        /// </summary>
        [EnumMember(Value = "W")]
        West
    }
}