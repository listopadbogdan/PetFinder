namespace PetFinder.Domain.Models;

public class PetPhotoId
{
    public Guid Value { get; }

    private PetPhotoId(Guid value)
    {
        Value = value;
    }

    public static PetPhotoId New() => new(Guid.NewGuid());

    public static PetPhotoId Create(Guid value) => new(value);
}