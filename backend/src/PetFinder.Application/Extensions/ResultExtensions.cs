using CSharpFunctionalExtensions;

namespace PetFinder.Application.Extensions;

internal static class ResultExtensions
{
    public static IEnumerable<T> UnwrapFromResultToValue<T>(this IEnumerable<Result<T>> collections)
    {
        return collections.Select(c => c.Value);
    }

    public static IEnumerable<T> UnwrapFromResultToValue<T, TE>(this IEnumerable<Result<T, TE>> collections)
    {
        return collections.Select(c => c.Value);
    }
}