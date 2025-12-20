using backend.Models;
using Microsoft.EntityFrameworkCore;
namespace backend;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Models.FichaT20> FichaT20 { get; set; }
    public DbSet<Models.PericiaT20> PericiaT20 { get; set; }
    public DbSet<Models.HabilidadeT20> HabilidadeT20 { get; set; }
    public DbSet<Models.EquipamentoT20> EquipamentoT20 { get; set; }
    public DbSet<Models.ModT20> ModT20 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the one-to-many relationship between mdl_FichaT20 and mdl_HabilidadeT20
        modelBuilder.Entity<Models.FichaT20>()
            .HasMany(e => e.Habilidades)
            .WithOne(e => e.Ficha)
            .HasForeignKey(e => e.FichaId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        
        modelBuilder.Entity<FichaT20>()
            .HasMany(f => f.Equipamentos)
            .WithOne(e => e.FichaT20)
            .HasForeignKey(e => e.FichaT20Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FichaT20>()
            .HasMany(f => f.Pericias)
            .WithOne(p => p.FichaT20)
            .HasForeignKey(p => p.FichaT20Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HabilidadeT20>()
            .HasMany(h => h.Mods)
            .WithOne(m => m.Habilidade)
            .HasForeignKey(m => m.HabilidadeId);

        modelBuilder.Entity<EquipamentoT20>()
            .HasMany(e => e.Mods)
            .WithOne(m => m.Equipamento)
            .HasForeignKey(m => m.EquipamentoId);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<TimeStampEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = now;
                    entry.Property(x => x.CreatedAt).IsModified = false; 
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}