using System.Runtime.Serialization;

namespace CleaningRobot.Enums
{
    /// <summary>
    /// Represents type of cell in map.
    /// </summary>
    internal enum SpaceType
    {
        /// <summary>
        /// A cleanable cell of 1 by 1 that can be occupied and cleaned (S).
        /// </summary>
        [EnumMember(Value = "S")]
        Cleanable,


        /// <summary>
        /// A column of 1 by 1 which can’t be occupied or cleaned (C).
        /// </summary>
        [EnumMember(Value = "C")]
        Uncleanable,


        /// <summary>
        /// A wall represented by an empty cell (null) or by being outside the matrix.
        /// </summary>
        [EnumMember(Value = "null")]
        Wall
    }
}