namespace PetFinder.Domain.Abstract;

public abstract class Entity<T>(T id) 
{
    public T Id { get;  } = id;
}