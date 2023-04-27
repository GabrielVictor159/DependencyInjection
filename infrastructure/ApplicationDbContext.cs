using Microsoft.EntityFrameworkCore;
using DependencyInjection.Model;

public class ApplicationDbContext : DbContext
{
    public DbSet<Resultado> Results => Set<Resultado>();
    public DbSet<Operation> Operations => Set<Operation>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=db; Port=5432; Database=postgres; Uid=postgres; Pwd=postgres;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operation>()
            .HasKey(e => e.Id);
        // Foi o jeito que funcionou kkkkkk
        modelBuilder.Entity<Resultado>()
           .HasKey(e => e.Id);
        modelBuilder.Entity<Resultado>()
            .HasOne(e => e.operation)
            .WithOne(e => e.resultado)
            .HasForeignKey<Resultado>(e => e.OperationId);
    }




}
