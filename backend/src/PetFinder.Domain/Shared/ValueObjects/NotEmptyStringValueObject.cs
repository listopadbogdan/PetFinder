using CSharpFunctionalExtensions;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Domain.Shared.ValueObjects;

public abstract record  NotEmptyStringValueObject
{
    private NotEmptyStringValueObject()
    {
    }

    private protected NotEmptyStringValueObject(string value)
    {
        Value = value;
    }

    public string Value { get; } = default!;

    protected static Result<TNotEmptyStringImpl, Error> Create<TNotEmptyStringImpl>(
        Func<string, TNotEmptyStringImpl> createFunc,
        string value,
        int maxLength)
    {
        var validationResult = Validate(value, maxLength);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return createFunc(value);
    }

    protected static UnitResult<Error> Validate(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value) || value.Length > maxLength)
            return Errors.General.ValueIsInvalid(
                nameof(value),
                StringHelper.GetValueEmptyOrMoreThanNeedString(maxLength));

        return UnitResult.Success<Error>();
    }
}