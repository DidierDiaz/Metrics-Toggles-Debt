using System.Text.Json.Serialization;

namespace MetricsTogglesDebt.API.Helper
{
    public class MethodsResultsJson
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("found")]
        public bool Found { get; set; }

        [JsonPropertyName("foundPaths")]
        public List<string>? FoundPaths { get; set; }
    }
}
