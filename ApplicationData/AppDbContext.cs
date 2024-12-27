using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Csv01Profile> Csv01Profiles { get; set; }
    // public DbSet<Vcf01Profile> Vcf01Profiles { get; set; }
    public DbSet<Vcf02Profile> Vcf02Profiles { get; set; }
}
