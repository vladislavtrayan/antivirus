using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class AntivirusContext : DbContext
    {
        public DbSet<Virus> Viruses { get; set; }
        public DbSet<Signature> Signatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Signature>()
                .HasMany(v => v.Viruses)
                .WithOne()
                .HasForeignKey(v => v.SignatureId);
        }
        
        public AntivirusContext(DbContextOptions<AntivirusContext> options)
            : base(options)
        {
        }
    }
}