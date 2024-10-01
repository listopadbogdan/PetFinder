namespace PetFinder.Domain.SharedKernel;

public abstract class Entity<T>(T id)
{
    public T Id { get; } = id;

    public override int GetHashCode() => HashCode.Combine(GetType().GetHashCode(), Id);
    public override bool Equals(object? obj) => obj is Entity<T> entity && entity.Id!.Equals(Id);
}