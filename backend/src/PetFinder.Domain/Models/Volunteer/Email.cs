using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record Email
{
    private Email()
    {
    }

    public string Value { get; private set; } = default!;

    public static Result<Email> Create(string value)
    {
        var validationResult = Validate(
            value: value);

        if (validationResult.IsFailure)
            return Result.Failure<Email>(validationResult.Error);

        return Result.Success(new Email()
        {
            Value = value,
        });
    }

    private static Result Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidationRegex.IsMatch(value))
            return Results.ValueIsNotMatchRegexPatternValidationFailureResult(nameof(value), ValidationRegexPattern);

        return Results.Success;
    }

    private static readonly string ValidationRegexPattern = @"^[\w-\.]{1,40}@([\w-]+\.)+[\w-]{2,4}$";

    private static readonly Regex ValidationRegex = new Regex(
        pattern: ValidationRegexPattern,
        options: RegexOptions.Singleline | RegexOptions.Compiled);
}