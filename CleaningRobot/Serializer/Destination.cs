using Newtonsoft.Json;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Represents the target object onto which JSON output is serialized.
    /// </summary>
    internal class Destination
    {
        /// <summary>
        /// Collection of visited cells.
        /// </summary>
        [JsonProperty(PropertyName = "visited")]
        public IEnumerable<Location> Visited { get; set; } = Enumerable.Empty<Location>();


        /// <summary>
        /// Collection of cleaned cells.
        /// </summary>
        [JsonProperty(PropertyName = "cleaned")]
        public IEnumerable<Location> Cleaned { get; set; } = Enumerable.Empty<Location>();


        /// <summary>
        /// Final robot position.
        /// </summary>
        [JsonProperty(PropertyName = "final")]
        public RobotPosition? Final { get; set; }


        /// <summary>
        /// Battery level of the robot.
        /// </summary>
        [JsonProperty(PropertyName = "battery")]
        public int Battery { get; set; }
    }
}