using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<CsvProfile> CsvProfiles { get; set; }
    public DbSet<VcfProfile> VcfProfiles { get; set; }

}
