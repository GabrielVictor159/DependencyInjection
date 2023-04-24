using Microsoft.EntityFrameworkCore;
using DependencyInjection.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Resultado> Results { get; set; }


}