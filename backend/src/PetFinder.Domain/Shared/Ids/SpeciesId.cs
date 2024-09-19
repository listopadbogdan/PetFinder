namespace PetFinder.Domain.Shared.Ids;

public record SpeciesId
{
    public Guid Value { get; }

    private SpeciesId(Guid id)
    {
        Value = id;
    }

    public static SpeciesId New() => new(Guid.NewGuid());

    public static SpeciesId Create(Guid value) => new(value);
}