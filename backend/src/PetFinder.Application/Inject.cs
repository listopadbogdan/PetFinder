using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;

namespace PetFinder.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateVolunteerHandler>();
        
        return services;
    }
}