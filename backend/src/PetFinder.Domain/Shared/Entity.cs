namespace PetFinder.Domain.Shared;

public abstract class Entity<T>(T id)
{
    public T Id { get; } = id;
}