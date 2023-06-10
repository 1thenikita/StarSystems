using Microsoft.EntityFrameworkCore;
using StarSystems.Server.Entities;

namespace StarSystems.Server;

public class DBContext : DbContext
{
    public DbSet<SpaceObjectEntity> SpaceObjects => Set<SpaceObjectEntity>();
    public DbSet<StarSystemEntity> StarSystems => Set<StarSystemEntity>();

    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StarSystemEntity>().HasMany(x => x.SpaceObjects)
            .WithOne(x => x.StarSystem)
            .HasForeignKey(x => x.StarSystemID);

        modelBuilder.Entity<StarSystemEntity>()
            .HasOne(x => x.CenterOfMasses)
            .WithOne()
            .HasForeignKey<StarSystemEntity>(x => x.CenterOfMassesID)
            .OnDelete(DeleteBehavior.SetNull);

        base.OnModelCreating(modelBuilder);
    }
}