using PetFinder.Infrastructure;

namespace PetFinder.API.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.ConfigureServices();
    }

    private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDbContext>();
        
        return builder;
    }
}