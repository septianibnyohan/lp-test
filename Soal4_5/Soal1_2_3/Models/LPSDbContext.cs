using Microsoft.EntityFrameworkCore;

namespace Soal1_2_3.Models
{
    public class LPSDbContext : DbContext
    {
        public LPSDbContext(DbContextOptions<LPSDbContext> options) : base(options)
        {
        }

        public DbSet<MasterJenisBuku> MasterJenisBukus { get; set; }
        public DbSet<Buku> Buku { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Buku>()
                .HasOne(b => b.MasterJenisBuku)
                .WithMany()
                .HasForeignKey(b => b.JenisBukuId);
        }
    }
}
