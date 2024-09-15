using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record SpeciesBreedObject
{
    private SpeciesBreedObject()
    {
    }

    private SpeciesBreedObject(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;  
    }

    public SpeciesId SpeciesId { get; } = default!;
    public BreedId BreedId { get; } = default!;

    public static Result<SpeciesBreedObject, Error> Create(SpeciesId speciesId, BreedId breedId)
        => new SpeciesBreedObject(
            speciesId: speciesId,
            breedId: breedId);
}