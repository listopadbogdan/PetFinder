using PetFinder.Application;
using PetFinder.Infrastructure;

namespace PetFinder.API.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.ConfigureServices();

        return builder;
    }

    private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddInfrastructure()
            .AddApplication();

        return builder;
    }
}