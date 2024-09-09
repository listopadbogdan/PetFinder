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

    public static Result<AssistanceDetails> Create(string title, string description)
    {
        var validationResult = Validate(
            name: title,
            description: description);

        if (validationResult.IsFailure)
            return Result.Failure<AssistanceDetails>(validationResult.Error);

        return Result.Success(new AssistanceDetails()
        {
            Description = description,
            Title = title
        });
    }

    private static Result Validate(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.AssistanceDetail.MaxNameLength)
            return NameValidationFailureResult;

        if (string.IsNullOrWhiteSpace(description) ||
            description.Length > Constants.AssistanceDetail.MaxDescriptionLength)
            return DescriptionValidationFailureResult;

        return Results.Success;
    }

    private static readonly Result NameValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Title),
            valueMaxLimit: Constants.AssistanceDetail.MaxNameLength));

    private static readonly Result DescriptionValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Description),
            valueMaxLimit: Constants.AssistanceDetail.MaxDescriptionLength));
}