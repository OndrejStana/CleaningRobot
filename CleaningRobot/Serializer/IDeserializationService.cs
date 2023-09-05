using Newtonsoft.Json;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Service responsible for deserialization.
    /// </summary>
    internal interface IDeserializationService
    {
        /// <summary>
        /// Deserialize input json file, selected in first program parameter.
        /// <returns>A deserialized source object.</returns>
        /// <exception cref="JsonSerializationException">When the json file cannot be deserialized.</exception>
        /// <exception cref="FileNotFoundException">When the set input file is not found.</exception>
        /// <exception cref="JsonException">When the json file is null.</exception>
        /// </summary>
        Source Deserialize();
    }
}