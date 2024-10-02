using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;
using PetFinder.Application.Providers;
using PetFinder.Infrastructure.Providers;
using PetFinder.Infrastructure.Repositories;

namespace PetFinder.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddDbContext<ApplicationDbContext>();

        services.AddScoped<IVolunteerRepository, VolunteerRepository>();
        
        return services;
    }
}