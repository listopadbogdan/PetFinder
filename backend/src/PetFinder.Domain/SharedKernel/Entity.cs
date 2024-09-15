namespace PetFinder.Domain.SharedKernel;

public abstract class Entity<T>(T id)
{
    public T Id { get; } = id;
}