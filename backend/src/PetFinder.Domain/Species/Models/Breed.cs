using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Domain.Species.Models;

public class Breed : SharedKernel.Entity<BreedId>
{
    private Breed(BreedId id)
        : base(id)
    {
    }

    private Breed(
        BreedId id,
        string title,
        string description, 
        Species species) : base(id)
    {
        Title = title;
        Description = description;
        Species = species;
    }

    public string Description { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public Species Species { get; private set; } = default!;

    public static Result<Breed, Error> Create(
        BreedId id,
        string title,
        string description,
        Species species)
    {
        var validationResult = Validate(
            title: title,
            description: description);
        
        if (validationResult.IsFailure)
            return validationResult.Error;
        
        return new Breed(
            id: id,
            title: title,
            description: description,
            species: species);
    }

    private static UnitResult<Error> Validate(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.Breed.MaxTitleLength)
            return Errors.General.ValueIsInvalid(
                nameof(Title),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.Breed.MaxTitleLength));
        
        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.Breed.MaxDescriptionLength)
            return Errors.General.ValueIsInvalid(
                nameof(Description),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.Breed.MaxDescriptionLength));

        return UnitResult.Success<Error>();
    }
}