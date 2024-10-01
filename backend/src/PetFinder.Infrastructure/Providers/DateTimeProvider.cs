using PetFinder.Application.Providers;

namespace PetFinder.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}