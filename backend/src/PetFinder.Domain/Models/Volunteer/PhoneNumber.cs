using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record PhoneNumber
{
    private PhoneNumber()
    {
    }

    public string Value { get; private init; } = default!;

    public Result<PhoneNumber> Create(string value)
    {
        var validationResult = Validate(
            value: value);

        if (validationResult.IsFailure)
            return Result.Failure<PhoneNumber>(validationResult.Error);

        return Result.Success(new PhoneNumber()
        {
            Value = value
        });
    }

    private static Result Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidationRegex.IsMatch(value))
            return ValueValidationFailureResult;

        return Constants.ValueObject.SuccessValidationResult;
    }

    private static readonly string ValidationRegexPattern = @"(^\+\d{1,3}\d{10}$|^$)";

    private static readonly Regex ValidationRegex = new Regex(
        pattern: ValidationRegexPattern,
        options: RegexOptions.Singleline | RegexOptions.Compiled);

    private static readonly Result ValueValidationFailureResult = Result.Failure(
        $"{nameof(Value)} is is not match pattern {ValidationRegexPattern}");
}