using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record AssistanceDetails
{
    private AssistanceDetails()
    {
    }

    public string Name { get; private init; } = default!;
    public string Description { get; private init; } = default!;

    public Result<AssistanceDetails> Create(string name, string description)
    {
        var validationResult = Validate(
            name: name,
            description: description);

        if (validationResult.IsFailure)
            return Result.Failure<AssistanceDetails>(validationResult.Error);

        return Result.Success(new AssistanceDetails()
        {
            Description = description,
            Name = name
        });
    }

    private Result Validate(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.AssistanceDetail.MaxNameLength)
            return NameValidationFailureResult;

        if (string.IsNullOrWhiteSpace(description) ||
            description.Length > Constants.AssistanceDetail.MaxDescriptionLength)
            return DescriptionValidationFailureResult;

        return Constants.ValueObject.SuccessValidationResult;
    }

    private static readonly Result NameValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Name),
            valueMaxLimit: Constants.AssistanceDetail.MaxNameLength));

    private static readonly Result DescriptionValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Description),
            valueMaxLimit: Constants.AssistanceDetail.MaxDescriptionLength));
}