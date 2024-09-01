using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record Address
{
    private Address()
    {
    }

    public string Country { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string Street { get; private set; } = default!;
    public string House { get; private set; } = default!;
    public string? Description { get; private set; }

    public static Result<Address> Create(string country, string city, string street, string house,
        string? description)
    {
        var validationResult = Validate(
            country: country,
            city: city,
            street: street,
            house: house,
            description: description);

        if (validationResult.IsFailure)
            return Result.Failure<Address>(validationResult.Error);

        return Result.Success(new Address()
        {
            Country = country,
            City = city,
            Street = street,
            House = house,
            Description = description
        });
    }

    private static Result Validate(string country, string city, string street, string house,
        string? description)
    {
        if (string.IsNullOrWhiteSpace(country) || country.Length > Constants.Address.MaxCountryLength)
            return CountryValidationFailureResult;

        if (string.IsNullOrWhiteSpace(city) || city.Length > Constants.Address.MaxCityLength)
            return CityValidationFailureResult;

        if (string.IsNullOrWhiteSpace(street) || street.Length > Constants.Address.MaxStreetLength)
            return StreetValidationFailureResult;

        if (string.IsNullOrWhiteSpace(house) || house.Length > Constants.Address.MaxStreetLength)
            return HouseValidationFailureResult;

        if (description?.Length > Constants.Address.MaxDescriptionLength)
            return DescriptionValidationFailureResult;

        return Constants.ValueObject.SuccessValidationResult;
    }

    private static readonly Result DescriptionValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Description),
            valueMaxLimit: Constants.Address.MaxDescriptionLength));

    private static readonly Result HouseValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(House),
            valueMaxLimit: Constants.Address.MaxHouseLength));

    private static readonly Result CityValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(City),
            valueMaxLimit: Constants.Address.MaxCityLength));

    private static readonly Result StreetValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Street),
            valueMaxLimit: Constants.Address.MaxStreetLength));

    private static readonly Result CountryValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Country),
            valueMaxLimit: Constants.Address.MaxCountryLength));
}