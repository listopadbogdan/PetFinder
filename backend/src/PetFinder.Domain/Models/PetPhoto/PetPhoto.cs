using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class PetPhoto : Entity<PetPhotoId>
{
    private PetPhoto(PetPhotoId id) 
        : base(id) { }
    public string Path { get; private set; } = default!;
    public bool IsMain { get; private set; }
}