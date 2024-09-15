namespace PetFinder.Domain.Shared.Ids;

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