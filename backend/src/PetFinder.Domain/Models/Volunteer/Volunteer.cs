using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<AssistanceDetails> _assistanceDetails = default!;
    private readonly List<Pet> _pets = default!;
    private readonly List<SocialNetwork> _socialNetworks = default!;

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
        string description,
        List<SocialNetwork>? socialNetworks,
        List<AssistanceDetails>? assistanceDetails,
        List<Pet>? pets) : base(id)
    {
        PersonName = personName;
        PhoneNumber = phoneNumber;
        ExperienceYears = experienceYears;
        Description = description;
        Email = email;
        _socialNetworks = socialNetworks ?? [];
        _pets = pets ?? [];
        _assistanceDetails = assistanceDetails ?? [];
    }

    public PersonName PersonName { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public string Description { get; private set; } = default!;

    public Email Email { get; private set; } = default!;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<AssistanceDetails> AssistanceDetails => _assistanceDetails;
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
        string description,
        IEnumerable<SocialNetwork>? socialNetworks = default,
        IEnumerable<AssistanceDetails>? assistanceDetails = null,
        IEnumerable<Pet>? pets = null)
    {
        return new Volunteer(
            id: id,
            personName: personName,
            phoneNumber: phoneNumber,
            email: email,
            experienceYears: experienceYears,
            description: description,
            socialNetworks: socialNetworks?.ToList(),
            assistanceDetails: assistanceDetails?.ToList(),
            pets: pets?.ToList()
        );
    }
}