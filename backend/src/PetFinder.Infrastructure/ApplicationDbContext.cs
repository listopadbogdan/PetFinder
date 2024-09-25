using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetFinder.Domain.Species.Models;
using PetFinder.Domain.Volunteer.Models;

namespace PetFinder.Infrastructure;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration = null!;

    private ApplicationDbContext() { }
    
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Volunteer> Volunteers => Set<Volunteer>();
    public DbSet<Species> Species => Set<Species>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ApplicationDbContext")
                                 ?? throw new InvalidOperationException("No connection string for ApplicationDbContext"))
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    private static ILoggerFactory CreateLoggerFactory()
        => LoggerFactory.Create(builder => builder.AddConsole());
}