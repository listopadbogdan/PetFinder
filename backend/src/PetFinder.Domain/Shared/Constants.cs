// ReSharper disable InconsistentNaming

using CSharpFunctionalExtensions;

namespace PetFinder.Domain.Shared;

public static class Constants
{
    public static class PetPhoto
    {
        public const int MaxPathLength = 256;
        public const string TableName = "pet_photos";
    }

    public static class Volunteer
    {
        public const int MaxFirstNameLength = 32;
        public const int MaxMiddleNameLength = 32;
        public const int MaxLastNameLength = 32;
        public const int MaxPhoneNumberLength = 16;
        public const int MaxDescriptionLength = 256;
        public const string TableName = "volunteers";
    }

    public static class Pet
    {
        public const int MaxNameLength = 128;
        public const int MaxAnimalTypeLength = 64;
        public const int MaxGeneralDescriptionLength = 256;
        public const int MaxBreedLength = 32;
        public const int MaxColorLength = 32;
        public const int MaxHealthInformationLength = 256;
        public const int MaxAddressLength = 256;
        public const int MaxOwnerPhoneNumberLength = 16;
        public const string TableName = "pets";
    }

    public static class Address
    {
        public const int MaxCountryLength = 64;
        public const int MaxCityLength = 64;
        public const int MaxStreetLength = 64;
        public const int MaxHouseLength = 16;
        public const int MaxDescriptionLength = 64;
    }

    public static class SocialNetwork
    {
        public const int MaxUrlLength = 256;
        public const int MaxNameLength = 32;
    }

    public static class AssistanceDetail
    {
        public const int MaxNameLength = 64;
        public const int MaxDescriptionLength = 128;
    }

    public static class PersonName
    {
        public const int MaxFirstNameLength = 64;
        public const int MaxMiddleNameLength = 64;
        public const int MaxLastNameLength = 64;
    }


    public static class ValueObject
    {
        public static readonly Result SuccessValidationResult = Result.Success();
    }
}