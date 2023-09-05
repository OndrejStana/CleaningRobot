using CleaningRobot.Serializer;
using CleaningRobot.Enums;

namespace CleaningRobot.Robot
{
    /// <summary>
    /// Represents current robot state.
    /// </summary>
    internal class RobotState : IRobotState
    {
        /// <inheritdoc />
        public int X { get; set; }


        /// <inheritdoc />
        public int Y { get; set; }


        /// <inheritdoc />
        public Direction Facing { get; set; }


        /// <inheritdoc />
        public int Battery { get; set; }


        /// <inheritdoc />
        public IList<Location> Visited { get; set; } = new List<Location>();


        /// <inheritdoc />
        public IList<Location> Cleaned { get; set; } = new List<Location>();


        /// <inheritdoc />
        public SpaceType[][] Map { get; set; } = Array.Empty<SpaceType[]>();
    }
}