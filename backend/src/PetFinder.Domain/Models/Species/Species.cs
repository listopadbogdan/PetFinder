using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = default!;

    private Species(SpeciesId id)
        : base(id)
    {
    }

    private Species(
        SpeciesId id,
        string title,
        IEnumerable<Breed>? breeds) : base(id) 
    {
        Title = title;
        _breeds = breeds?.ToList() ?? [];
    }

    public string Title { get; private set; } = default!;
    public IReadOnlyList<Breed> Breeds => _breeds;

    public static Result<Species, Error> Create(
        SpeciesId id,
        string title,
        IEnumerable<Breed>? breeds)
    {
        var validationResult = Validate(title: title);
        
        if (validationResult.IsFailure)
            return validationResult.Error;
        
        return new Species(
            id: id,
            title: title,
            breeds: breeds);
    }

    private static UnitResult<Error> Validate(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.Species.MaxTitleLength)
            return Errors.General.ValueIsInvalid(
                nameof(Title),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.Species.MaxTitleLength));
        
        return UnitResult.Success<Error>();
    }
}