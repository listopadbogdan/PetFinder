using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;
using PetFinder.Infrastructure.Repositories;

namespace PetFinder.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        
        services.AddScoped<IVolunteerRepository, VolunteerRepository>();

        return services;
    }
}