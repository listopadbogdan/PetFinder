using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.Shared.Interfaces;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Enums;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Domain.Volunteer.Models;

public class Pet : 
    SharedKernel.Entity<PetId>,
    ISoftDeletable
{
    private readonly List<PetPhoto> _photos = default!;

    private Pet(PetId id) : base(id)
    {
    }

    private Pet(
        PetId id,
        SpeciesBreedObject speciesBreedObject,
        string name,
        string animalType,
        string generalDescription,
        string color,
        string healthInformation,
        Address address,
        double weight,
        double height,
        string ownerPhoneNumber,
        DateOnly birthDate,
        bool isCastrated,
        bool isVaccinated,
        HelpStatusPet helpStatusPet,
        DateTime createdAt,
        IEnumerable<PetPhoto>? photos) : base(id)
    {
        SpeciesBreedObject = speciesBreedObject;
        Name = name;
        AnimalType = animalType;
        GeneralDescription = generalDescription;
        Color = color;
        HealthInformation = healthInformation;
        Address = address;
        Weight = weight;
        Height = height;
        OwnerPhoneNumber = ownerPhoneNumber;
        BirthDate = birthDate;
        IsCastrated = isCastrated;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatusPet;
        CreatedAt = createdAt;
        _photos = photos?.ToList() ?? [];
        DeletedAt = null;
        IsDeleted = false;  
    }

    public SpeciesBreedObject SpeciesBreedObject { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string AnimalType { get; private set; } = default!;
    public string GeneralDescription { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string HealthInformation { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string OwnerPhoneNumber { get; private set; } = default!;
    public DateOnly BirthDate { get; private set; }
    public bool IsCastrated { get; private set; }
    public bool IsVaccinated { get; private set; }

    public HelpStatusPet HelpStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyList<PetPhoto> Photos => _photos;
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public static Result<Pet, Error> Create(
        PetId id,
        SpeciesBreedObject speciesBreedObject,
        string name,
        string animalType,
        string generalDescription,
        string color,
        string healthInformation,
        Address address,
        double weight,
        double height,
        string ownerPhoneNumber,
        DateOnly birthDate,
        bool isCastrated,
        bool isVaccinated,
        HelpStatusPet helpStatusPet,
        DateTime createdAt,
        IEnumerable<PetPhoto>? photos)
    {
        var validationResult = Validate(
            name: name,
            animalType: animalType,
            generalDescription: generalDescription,
            color: color,
            healthInformation: healthInformation,
            weight: weight,
            height: height,
            ownerPhoneNumber: ownerPhoneNumber,
            birthDate: birthDate);
        
        if (validationResult.IsFailure)
            return validationResult.Error;

        return new Pet(
            id: id,
            speciesBreedObject: speciesBreedObject,
            name: name, 
            animalType: animalType,
            generalDescription: generalDescription,
            color: color,
            healthInformation: healthInformation,
            address: address,
            weight: weight,
            height: height,
            ownerPhoneNumber: ownerPhoneNumber,
            birthDate: birthDate,
            isCastrated: isCastrated,
            isVaccinated: isVaccinated,
            helpStatusPet: helpStatusPet,
            createdAt: createdAt,
            photos: photos);
    }

    private static UnitResult<Error> Validate(
        string name,
        string animalType,
        string generalDescription, 
        string color,
        string healthInformation,
        string ownerPhoneNumber, 
        double weight,
        double height,
        DateOnly birthDate)
    {
        if (string.IsNullOrEmpty(name) || name.Length > Constants.Pet.MaxNameLength)
            return Errors.General.ValueIsInvalid(
                nameof(Name),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxNameLength));
        
        if (string.IsNullOrEmpty(animalType) || animalType.Length > Constants.Pet.MaxAnimalTypeLength)
            return Errors.General.ValueIsInvalid(
                nameof(AnimalType),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxAnimalTypeLength));

        if (string.IsNullOrWhiteSpace(generalDescription)
            || generalDescription.Length > Constants.Pet.MaxGeneralDescriptionLength)
            return Errors.General.ValueIsInvalid(
                nameof(GeneralDescription),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxGeneralDescriptionLength));
        
        if (string.IsNullOrWhiteSpace(color)
            || color.Length > Constants.Pet.MaxColorLength)
            return Errors.General.ValueIsInvalid(
                nameof(Color),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxColorLength));
        
        if (string.IsNullOrWhiteSpace(healthInformation)
            || color.Length > Constants.Pet.MaxHealthInformationLength)
            return Errors.General.ValueIsInvalid(
                nameof(HealthInformation),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxHealthInformationLength));
        
        if (string.IsNullOrWhiteSpace(ownerPhoneNumber)
            || ownerPhoneNumber.Length > Constants.Pet.MaxOwnerPhoneNumberLength)
            return Errors.General.ValueIsInvalid(
                nameof(OwnerPhoneNumber),
                StringHelper.GetValueMoreThanNeedString(Constants.Pet.MaxOwnerPhoneNumberLength));

        if (weight < Constants.Pet.MinWeightValue)
            return Errors.General.ValueIsInvalid(
                nameof(Weight),
                StringHelper.GetValueLessThanNeedString(Constants.Pet.MinWeightValue));
        
        if (height < Constants.Pet.MinHeightValue)
            return Errors.General.ValueIsInvalid(
                nameof(Height),
                StringHelper.GetValueLessThanNeedString(Constants.Pet.MinHeightValue));

        if (birthDate >= DateOnly.FromDateTime(DateTime.Now))
            return Errors.General.ValueIsInvalid(
                nameof(BirthDate),
                StringHelper.GetValueLessThanNeedString("now"));
        
        return UnitResult.Success<Error>();
    }

    public void Activate()
    {
        EntityAlreadyActivatedException.ThrowIfActivated(!IsDeleted);

        IsDeleted = false;
        DeletedAt = null;
        
        _photos.ForEach(p => p.Activate());
    }

    public void Deactivate(DateTime deletedAt)
    {
        EntityAlreadyDeletedException.ThrowIfDeleted(IsDeleted);

        IsDeleted = true;
        DeletedAt = deletedAt;
        
        _photos.ForEach(p => p.Deactivate(deletedAt));
    }
}