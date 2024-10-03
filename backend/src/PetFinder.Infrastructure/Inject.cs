using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;
using PetFinder.Application.Providers;
using PetFinder.Infrastructure.Extensions;
using PetFinder.Infrastructure.Providers;
using PetFinder.Infrastructure.Repositories;

namespace PetFinder.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IFileProvider, MinioProvider>();

        services.ConfigureMinio(configuration);
        
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IVolunteerRepository, VolunteerRepository>();
        
        return services;
    }
}