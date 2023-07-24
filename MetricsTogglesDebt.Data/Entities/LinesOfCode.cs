using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricsTogglesDebt.Data.Entities
{
    public class LinesOfCode
    {
        [Key]
        public int Id { get; set; }

        public string? File { get; set; }
        public string? Lines { get; set; }
        public string? Language { get; set; }
        public string? Comments { get; set; }
        public string? Blank { get; set; }

        [Column(TypeName = "jsonb")]
        public List<string>? SpecialCharacters { get; set; }
    }
}
