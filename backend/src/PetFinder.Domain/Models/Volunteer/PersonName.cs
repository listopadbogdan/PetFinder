using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record PersonName
{
    private PersonName()
    {
    }

    public string FirstName { get; private init; } = default!;
    public string? MiddleName { get; private init; }
    public string LastName { get; private init; } = default!;

    public static Result<PersonName> Create(string firstName, string? middleName, string lastName)
    {
        var validationResult = Validate(
            firstName: firstName,
            middleName: middleName,
            lastName: lastName);

        if (validationResult.IsFailure)
            return Result.Failure<PersonName>(validationResult.Error);

        return Result.Success(new PersonName()
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName
        });
    }

    private static Result Validate(string firstName, string? middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > Constants.PersonName.MaxFirstNameLength)
            return FirstNameValidationFailureResult;

        if (middleName?.Length > Constants.PersonName.MaxMiddleNameLength)
            return MiddleNameValidationFailureResult;

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > Constants.PersonName.MaxLastNameLength)
            return LastNameValidationFailureResult;

        return Constants.ValueObject.SuccessValidationResult;
    }

    private static readonly Result FirstNameValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(FirstName),
            valueMaxLimit: Constants.PersonName.MaxFirstNameLength));

    private static readonly Result LastNameValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(LastName),
            valueMaxLimit: Constants.PersonName.MaxLastNameLength));

    private static readonly Result MiddleNameValidationFailureResult = Result.Failure(
        StringHelper.GetValueMoreThanNeedString(
            valueName: nameof(FirstName),
            valueMaxLimit: Constants.PersonName.MaxMiddleNameLength));
}