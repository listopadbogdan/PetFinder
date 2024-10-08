namespace PetFinder.Domain.Shared.Ids;

public record VolunteerId
{
    public Guid Value { get; }

    private VolunteerId(Guid value)
    {
        Value = value;
    }

    public static VolunteerId New() => new(Guid.NewGuid());

    public static VolunteerId Create(Guid value) => new(value);
}