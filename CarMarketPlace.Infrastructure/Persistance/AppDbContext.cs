using System.Net.NetworkInformation;
using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarMarketPlace.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<City> Citys { get; set; }
    public DbSet<Dealer> Dealers { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
