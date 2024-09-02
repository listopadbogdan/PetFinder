using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Species : Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = new();

    private Species(SpeciesId id)
        : base(id)
    {
    }

    public string Title { get; private set; } = default!;
    public IReadOnlyList<Breed> Breeds => _breeds;
}