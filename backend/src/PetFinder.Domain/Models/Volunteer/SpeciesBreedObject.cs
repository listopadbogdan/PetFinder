using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record SpeciesBreedObject
{
    private SpeciesBreedObject()
    {
    }

    public SpeciesId SpeciesId { get; private set; } = default!;
    public BreedId BreedId { get; private set; } = default!;

    public static Result<SpeciesBreedObject> Create(SpeciesId speciesId, BreedId breedId)
        => Result.Success(new SpeciesBreedObject()
        {
            SpeciesId = speciesId,
            BreedId = breedId
        });
}