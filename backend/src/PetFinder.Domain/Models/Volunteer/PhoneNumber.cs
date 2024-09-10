using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record PhoneNumber
{
    private PhoneNumber()
    {
    }

    public string Value { get; private set; } = default!;

    public static Result<PhoneNumber, Error> Create(string value)
    {
        var validationResult = Validate(
            value: value);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new PhoneNumber()
        {
            Value = value
        };
    }

    private static Result<bool, Error> Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidationRegex.IsMatch(value))
            return Errors.General.ValueIsInvalid();

        return true;
    }

    private static readonly string ValidationRegexPattern = @"(^\+\d{1,3}\d{10}$|^$)";

    private static readonly Regex ValidationRegex = new Regex(
        pattern: ValidationRegexPattern,
        options: RegexOptions.Singleline | RegexOptions.Compiled);
}