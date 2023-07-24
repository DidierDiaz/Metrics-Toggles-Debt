using System.Text.Json.Serialization;

namespace MetricsTogglesDebt.API.Helper
{
    public class SpecialCharactersResultJson
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("chars")]
        public List<string>? Chars { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
