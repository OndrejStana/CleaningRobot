using CleaningRobot.Serializer;
using CleaningRobot.Enums;

namespace CleaningRobot.Robot
{
    /// <summary>
    /// Represents current robot state.
    /// </summary>
    internal interface IRobotState
    {
        /// <summary>
        /// Position X.
        /// </summary>
        int X { get; set; }


        /// <summary>
        /// Position Y.
        /// </summary>
        public int Y { get; set; }


        /// <summary>
        /// The direction in which the robot is facing.
        /// </summary>
        public Direction Facing { get; set; }


        /// <summary>
        /// Battery level of the robot.
        /// </summary>
        public int Battery { get; set; }


        /// <summary>
        /// Collection of visited cells.
        /// </summary>
        public IList<Location> Visited { get; set; }


        /// <summary>
        /// Collection of cleaned cells.
        /// </summary>
        public IList<Location> Cleaned { get; set; }


        /// <summary>
        /// The map as a matrix of m by n in.
        /// </summary>
        public SpaceType[][] Map { get; set; }
    }
}