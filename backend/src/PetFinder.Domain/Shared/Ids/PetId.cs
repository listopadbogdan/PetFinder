namespace PetFinder.Domain.Shared.Ids;

public record PetId
{
    public Guid Value { get; }

    private PetId(Guid value)
    {
        Value = value;
    }

    public static PetId New() => new(Guid.NewGuid());

    public static PetId Create(Guid value) => new(value);
}