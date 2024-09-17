using FluentValidation.Results;
using PetFinder.Domain.Shared;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Application.Extensions;

public static class ValidationExtensions
{
    public static ErrorList ToList(this IEnumerable<ValidationFailure> validationFailures)
    {
        var errors = validationFailures.Select(
            ve =>
            {
                var error = Error.Deserialize(ve.ErrorMessage);
                return Error.Validation(error.Code, error.Message, ve.PropertyName);
            });


        return new ErrorList(errors);
    }
}