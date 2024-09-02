using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Breed : Entity<BreedId>
{
    private Breed(BreedId id)
        : base(id)
    {
    }

    public string Description { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public Species Species { get; private set; } = default!;
}