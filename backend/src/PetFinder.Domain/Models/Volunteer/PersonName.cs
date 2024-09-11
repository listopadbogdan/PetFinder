using System.Runtime.InteropServices.JavaScript;
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

    public static Result<PersonName, Error> Create(string firstName, string? middleName, string lastName)
    {
        var validationResult = Validate(
            firstName: firstName,
            middleName: middleName,
            lastName: lastName);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new PersonName()
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName
        };
    }

    private static UnitResult<Error> Validate(string firstName, string? middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > Constants.PersonName.MaxFirstNameLength)
            return Errors.General.ValueIsInvalid(
                valueName: nameof(FirstName),
                description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxFirstNameLength));

        if (middleName?.Length > Constants.PersonName.MaxMiddleNameLength)
            return Errors.General.ValueIsInvalid(
                    valueName: nameof(LastName),
                    description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxLastNameLength));

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > Constants.PersonName.MaxLastNameLength)
            return Errors.General.ValueIsInvalid(
                valueName: nameof(MiddleName),
                description: StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PersonName.MaxMiddleNameLength));

        return UnitResult.Success<Error>();
    }
}