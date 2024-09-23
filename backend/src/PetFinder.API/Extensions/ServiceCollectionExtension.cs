using Microsoft.CodeAnalysis.Options;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace PetFinder.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureLogging(this IServiceCollection services, 
        IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Seq(configuration.GetConnectionString("Seq")
                         ?? throw new InvalidOperationException("No connection string for Seq"))
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .CreateLogger();
        
        services.AddSerilog();
        
        return services;
    }
}