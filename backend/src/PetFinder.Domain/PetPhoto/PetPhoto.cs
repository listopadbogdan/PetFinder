using PetFinder.Domain.Abstract;

namespace PetFinder.Domain.PetPhoto;

public class PetPhoto : Entity<PetPhotoId>
{
    private PetPhoto(PetPhotoId id) 
        : base(id) { }
    public string Path { get; private set; } = default!;
    public bool IsMain { get; private set; }
}