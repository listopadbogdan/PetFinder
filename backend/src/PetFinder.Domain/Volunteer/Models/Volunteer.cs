using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.Shared.ValueObjects;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Enums;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Domain.Volunteer.Models;

public class Volunteer : SharedKernel.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = default!;

    private Volunteer(VolunteerId id)
        : base(id)
    {
    }

    private Volunteer(
        VolunteerId id,
        PersonName personName,
        PhoneNumber phoneNumber,
        Email email,
        int experienceYears,
        VolunteerDescription description,
        ValueObjectList<SocialNetwork> socialNetworks,
        ValueObjectList<AssistanceDetails> assistanceDetails) : base(id)
    {
        PersonName = personName;
        PhoneNumber = phoneNumber;
        ExperienceYears = experienceYears;
        Description = description;
        Email = email;
        SocialNetworks = socialNetworks;
        AssistanceDetails = assistanceDetails;
        _pets = [];
    }

    public PersonName PersonName { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public VolunteerDescription Description { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public ValueObjectList<SocialNetwork> SocialNetworks { get; private set; } = default!;
    public ValueObjectList<AssistanceDetails> AssistanceDetails { get; private set; } = default!;
    public IReadOnlyList<Pet> Pets => _pets;

    public int PetsFoundHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.FoundHome);
    public int PetsLookingForHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.LookingForHome);
    public int PetsOnTreatmentCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.OnTreatment);

    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        PersonName personName,
        PhoneNumber phoneNumber,
        Email email,
        int experienceYears,
        VolunteerDescription description,
        ValueObjectList<SocialNetwork> socialNetworks,
        ValueObjectList<AssistanceDetails> assistanceDetails)
    {
        return new Volunteer(
            id: id,
            personName: personName,
            phoneNumber: phoneNumber,
            email: email,
            experienceYears: experienceYears,
            description: description,
            socialNetworks: socialNetworks,
            assistanceDetails: assistanceDetails
        );
    }
}