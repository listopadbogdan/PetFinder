using CSharpFunctionalExtensions;
using FluentValidation;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Application.Extensions;

internal static class ValidatorExtensions
{
    public static IRuleBuilderOptionsConditions<T, TElement> MustBeValueObject<T, TElement>(
        this IRuleBuilder<T, TElement> ruleBuilder,
        Func<TElement, UnitResult<Error>> factoryMethod)
    {
        return ruleBuilder.Custom((value, context) =>
        {
            var result = factoryMethod(value);

            if (result.IsFailure)
                context.AddFailure(result.Error.Serialize());
        });
    }

    public static IRuleBuilderOptions<T, TElement> WithError<T, TElement>(
        this IRuleBuilderOptions<T, TElement> ruleBuilder, 
        Error error)
        => ruleBuilder.WithMessage(error.Serialize());
}