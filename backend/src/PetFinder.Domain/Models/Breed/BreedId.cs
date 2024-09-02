namespace PetFinder.Domain.Models;

public class BreedId
{
    public Guid Value { get; }

    private BreedId(Guid id)
    {
        Value = id;
    }

    public static BreedId New() => new(Guid.NewGuid());

    public static BreedId Create(Guid value) => new(value);
}