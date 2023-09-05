using CleaningRobot.Robot;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Service responsible for serialization.
    /// </summary>
    internal class SerializationService : ISerializationService
    {
        private readonly IRobotService robotService;
        private readonly string destinationFile;


        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationService"/> class.
        /// </summary>
        public SerializationService(
            IConfiguration configuration,
            IRobotService robotService)
        {
            destinationFile = configuration["destinationFile"]!;
            this.robotService = robotService;
        }


        public void Serialize()
        {
            using (var file = File.CreateText(destinationFile))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, robotService.GetCurrentPosition());
            }
        }
    }
}