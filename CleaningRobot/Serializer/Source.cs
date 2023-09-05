using CleaningRobot.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Represents the target object into which JSON input is deserialized.
    /// </summary>
    [JsonObject(ItemRequired = Required.Always)]
    internal class Source
    {
        /// <summary>
        /// The map as a matrix of m by n in.
        /// </summary>
        [System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
        public SpaceType[][] Map { get; set; } = Array.Empty<SpaceType[]>();


        /// <summary>
        /// Starting position of the robot.
        /// </summary>
        public RobotPosition Start { get; set; } = new();


        /// <summary>
        /// Commands for the robot to execute.
        /// </summary>
        public IList<CommandType> Commands { get; set; } = new List<CommandType>();


        /// <summary>
        /// Battery level of the robot.
        /// </summary>
        public int Battery { get; set; }
    }
}