using Jashter.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jashter.Services
{
    public class JsonConvertService : IJsonConvertService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly ILogger<JsonConvertService> _logger;
        public JsonConvertService(ILogger<JsonConvertService> logger)
        {
            _jsonSerializerSettings = new JsonSerializerSettings();
            _jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            _logger = logger;

        }
        public T Deserialize<T>(string content)
        {
            T? item = JsonConvert.DeserializeObject<T>(content);
            if (item is null)
            {
                _logger.LogError("Cannot desirialize object.");
                _logger.LogError($"Content: {content}");
                throw new ArgumentException("Please check your json value.");
            }
            return item;
        }

        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item, _jsonSerializerSettings);
        }
    }
}
