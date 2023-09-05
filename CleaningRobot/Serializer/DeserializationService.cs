using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CleaningRobot.Serializer
{
    /// <summary>
    /// Service responsible for deserialization.
    /// </summary>
    internal class DeserializationService : IDeserializationService
    {
        private const string LOADING_FILE = "Loading file '{0}'.";
        private const string FILE_NOT_FOUND = "File '{0}' not found";
        private const string JSON_VALIDATION_ERROR_OBJECT_IS_NULL = "Empty input. Could not parse to source object.";

        private readonly ILogger<DeserializationService> logger;
        private readonly string? sourceFile;
        private Source? source;


        /// <summary>
        /// Initializes a new instance of the <see cref="DeserializationService"/> class.
        /// </summary>
        public DeserializationService(
            IConfiguration configuration,
            ILogger<DeserializationService> logger)
        {
            sourceFile = configuration["sourceFile"];
            this.logger = logger;
        }


        /// <inheritdoc />
        public Source Deserialize()
        {
            if (source == null)
            {
                logger.LogInformation(LOADING_FILE, sourceFile);
                if (!File.Exists(sourceFile))
                {
                    throw new FileNotFoundException(string.Format(FILE_NOT_FOUND, sourceFile));
                }

                var jsonString = File.ReadAllText(sourceFile);
                var deserializeObject = JsonConvert.DeserializeObject<Source>(jsonString);
                Validate(deserializeObject);
                source = deserializeObject!;
            }

            return source;
        }


        private void Validate(Source? deserializeObject)
        {
            if (deserializeObject == null)
            {
                throw new JsonException(JSON_VALIDATION_ERROR_OBJECT_IS_NULL);
            }
        }
    }
}