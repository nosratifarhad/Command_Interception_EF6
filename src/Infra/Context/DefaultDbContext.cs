using CommandInterceptionWebApplication.Domain.Entitys;
using CommandInterceptionWebApplication.Infra.Interceptors;
using CommandInterceptionWebApplication.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CommandInterceptionWebApplication.Infra.Context;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
    : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductEFConfiguration());
    }

    public DbSet<Product> Products { get; set; }

}
