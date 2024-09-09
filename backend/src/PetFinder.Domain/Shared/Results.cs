using CSharpFunctionalExtensions;

namespace PetFinder.Domain.Shared;

public static class Results
{
    public static Result ValueIsNotMatchRegexPatternValidationFailureResult(string name, string pattern)
        => Result.Failure($"{name} is is not match pattern {pattern}");

    public static readonly Result Success = Result.Success();
}