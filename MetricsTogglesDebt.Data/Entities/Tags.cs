using System.ComponentModel.DataAnnotations;

namespace MetricsTogglesDebt.Data.Entities
{
    public class Tags
    {
        [Key]
        public int Id { get; set; }

        public string? Tag { get; set; }
        public string? SHA1 { get; set; }
        public string? Type { get; set; }
        public int Size { get; set; }
    }
}
