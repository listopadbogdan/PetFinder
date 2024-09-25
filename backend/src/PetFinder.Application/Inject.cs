using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;
using PetFinder.Application.Features.Shared;

namespace PetFinder.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        // services.AddScoped<CreateVolunteerHandler>();
        services.LoadHandlersFromAssembly();

        return services;
    }
}