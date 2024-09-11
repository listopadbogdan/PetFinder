using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record AssistanceDetails
{
    private AssistanceDetails()
    {
    }

    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static Result<AssistanceDetails, Error> Create(string title, string description)
    {
        var validationResult = Validate(
            title: title,
            description: description);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new AssistanceDetails()
        {
            Description = description,
            Title = title
        };
    }

    private static UnitResult<Error> Validate(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.AssistanceDetail.MaxTitleLength)
            return Errors.General.ValueIsInvalid(
                nameof(Title),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.AssistanceDetail.MaxTitleLength));

        if (string.IsNullOrWhiteSpace(description) ||
            description.Length > Constants.AssistanceDetail.MaxDescriptionLength)
            return Errors.General.ValueIsInvalid(
                nameof(Title),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.AssistanceDetail.MaxDescriptionLength));

        return UnitResult.Success<Error>();
    }
}