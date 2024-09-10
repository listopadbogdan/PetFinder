using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record PersonName
{
    private PersonName()
    {
    }

    public string FirstName { get; private set; } = default!;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = default!;

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

    private static Result<bool, Error> Validate(string firstName, string? middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > Constants.PersonName.MaxFirstNameLength)
            return FirstNameValidationFailureResult;

        if (middleName?.Length > Constants.PersonName.MaxMiddleNameLength)
            return MiddleNameValidationFailureResult;

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > Constants.PersonName.MaxLastNameLength)
            return LastNameValidationFailureResult;

        return true;
    }

    private static readonly Result<bool, Error> FirstNameValidationFailureResult = 
        Errors.General.ValueIsInvalid(
            valueName: nameof(FirstName),
            description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxFirstNameLength));

    private static readonly Result<bool, Error> LastNameValidationFailureResult = 
        Errors.General.ValueIsInvalid(
            valueName: nameof(LastName),
            description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxLastNameLength));

    private static readonly Result<bool, Error> MiddleNameValidationFailureResult =  
        Errors.General.ValueIsInvalid(
            valueName: nameof(MiddleName),
            description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxMiddleNameLength));
}