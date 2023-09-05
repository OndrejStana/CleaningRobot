using CleaningRobot.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Position of the robot.
    /// </summary>
    [JsonObject(ItemRequired = Required.Always)]
    internal class RobotPosition
    {
        /// <summary>
        /// Position X.
        /// </summary>
        public int X { get; set; }


        /// <summary>
        /// Position Y.
        /// </summary>
        public int Y { get; set; }


        /// <summary>
        /// The direction in which the robot is facing.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "facing")]
        public Direction Facing { get; set; }
    }
}