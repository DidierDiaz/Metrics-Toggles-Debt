using System.Text.Json.Serialization;

namespace MetricsTogglesDebt.API.Helper
{
    public class ReportResultsJson
    {
        [JsonPropertyName("file")]
        public string? File { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonPropertyName("comment")]
        public int? Comment { get; set; }

        [JsonPropertyName("blank")]
        public int? Blank { get; set; }
    }
}
