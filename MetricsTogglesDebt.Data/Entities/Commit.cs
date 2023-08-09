using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MetricsTogglesDebt.Data.Entities
{
    [Table("Commits")]
    public class Commit
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("sha1")]
        public string? Sha1 { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("parents")]
        public List<string>? Parents { get; set; }

        [JsonPropertyName("tree")]
        public string? Tree { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("author")]
        public Author? Author { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("committer")]
        public Committer? Committer { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("GPG")]
        public GPG? GPG { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("refs")]
        public List<string>? Refs { get; set; }

        [Column(TypeName = "jsonb")]
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
    }

    public class Author
    {
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }

    public class Committer
    {
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }

    public class GPG
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }
    }

    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
