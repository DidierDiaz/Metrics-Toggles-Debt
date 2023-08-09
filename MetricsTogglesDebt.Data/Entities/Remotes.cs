using System.ComponentModel.DataAnnotations;

namespace MetricsTogglesDebt.Data.Entities
{
    public class Remotes
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SHA1 { get; set; }

        public string? Type { get; set; }

        public int Size { get; set; }
    }
}
