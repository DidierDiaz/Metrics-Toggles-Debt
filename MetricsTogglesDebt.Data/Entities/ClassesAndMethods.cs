using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricsTogglesDebt.Data.Entities
{
    public class ClassesAndMethods
    {
        [Key]
        public int Id { get; set; }

        public string? Path { get; set; }
        public string? Method { get; set; }
        public bool Found { get; set; }

        [Column(TypeName = "jsonb")]
        public List<string>? FoundPaths { get; set; }
    }
}
