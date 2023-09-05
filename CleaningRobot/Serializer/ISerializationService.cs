namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Service responsible for serialization.
    /// </summary>
    internal interface ISerializationService
    {
        /// <summary>
        /// Serializes robot state onto output json file, selected in second program parameter.
        /// </summary>
        void Serialize();
    }
}