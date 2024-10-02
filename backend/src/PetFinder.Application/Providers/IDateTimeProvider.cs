namespace PetFinder.Application.Providers;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
}