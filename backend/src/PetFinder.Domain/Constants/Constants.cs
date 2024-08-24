namespace PetFinder.Domain.Constants;

public static class Constants
{
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
}