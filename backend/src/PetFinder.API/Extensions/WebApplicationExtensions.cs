using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure;

namespace PetFinder.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task ConfigureAsync(this WebApplication app)
    {
        await app.ConfigureEnvironmentAsync();

        app.UseHttpLogging();
        app.MapControllers();
        app.UseHttpsRedirection();
    }

    private static async Task ConfigureEnvironmentAsync(this WebApplication app)
    {
        if (app.Environment.IsDevelopment()) 
            await app.ConfigureDevelopment();
    }

    private static async Task ConfigureDevelopment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            throw new InvalidOperationException("Environment is not development");

        app.UseSwagger();
        app.UseSwaggerUI();

        await app.ApplyMigrations();
    }
 
    private static async Task ApplyMigrations(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}