using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PetFinder.Application.Providers;
using PetFinder.Domain.Shared.Interfaces;

namespace PetFinder.Infrastructure.Interceptors;

public class SoftDeleteInterceptor(IDateTimeProvider dateTimeProvider)
    : SaveChangesInterceptor
{


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
            DeactivateSoftDeletables(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
            DeactivateSoftDeletables(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    private void DeactivateSoftDeletables(DbContext context)
    {
        var e2 = context.ChangeTracker.Entries().ToList();
        
        var entries = context.ChangeTracker
            .Entries<ISoftDeletable>()
            .Where(e => e.State == EntityState.Deleted);

        var now = dateTimeProvider.Now;
        foreach (var softDeletable in entries)
        {
            softDeletable.State = EntityState.Modified;
            softDeletable.Entity.Deactivate(now);
        }
    }
}