using MetricsTogglesDebt.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsTogglesDebt.Data
{
    public class MetricsTogglesDebtDbContext : DbContext
    {
        public MetricsTogglesDebtDbContext(DbContextOptions<MetricsTogglesDebtDbContext> options) : base(options) { }

        public DbSet<ClassesAndMethods> ClassesAndMethods { get; set; }
        public DbSet<LinesOfCode> LinesOfCode { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
