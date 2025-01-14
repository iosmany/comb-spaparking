
namespace COMB.SpaParking.Persistence;

using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain;
using COMB.SpaParking.Domain.Entities;
using COMB.SpaParking.Domain.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public sealed class DatabaseContext : IdentityDbContext<IdentityUser>, IDatabaseService
{
    public DbSet<ParkingArea> ParkingAreas { get; set; }
    public DbSet<ParkingPermit> ParkingPermits { get; set; }
    public DbSet<ParkingAreaType> ParkingAreaTypes { get; set; }

    DbContextOptionsBuilder SetEngine(DbContextOptionsBuilder optionsBuilder)
    {
        if (Configuration.Properties.SqlEngine == Configuration.SqlEngine.SqlServer)
            return optionsBuilder.UseSqlServer(Configuration.Properties.ConnectionString);
        else if (Configuration.Properties.SqlEngine == Configuration.SqlEngine.InMemory)
            return optionsBuilder.UseInMemoryDatabase("COMBParkingDb");

        return optionsBuilder;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        SetEngine(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies(); 

#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.RenameIdentityTables();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ParkingsPermitsByAreaView>()
            .HasNoKey()
            .ToView("v_ParkingPermits_by_Area");

        modelBuilder.Entity<ParkingAreasView>()
            .HasNoKey()
            .ToView("v_ParkingAreas");

    }

    void SetAudit()
    {
        foreach (var entity in this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
        {
            if (entity is IAudit audit)
                audit.MarkCreated();

            if (entity.Entity is ParkingArea parkingArea)
                parkingArea.MarkCreated();
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAudit();
        return await base.SaveChangesAsync(cancellationToken);
    }
}

static class RenameAspNetEntities
{
    public static void RenameIdentityTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUser>(entity =>entity.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(entity =>entity.ToTable("Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>entity.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>entity.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>entity.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>entity.ToTable("RoleClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>entity.ToTable("UserTokens"));
    }
}
