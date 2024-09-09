using CSharpFunctionalExtensions;

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
        List<SocialNetwork> socialNetworks,
        List<AssistanceDetails> assistanceDetails,
        string email,
        int experienceYears,
        string description) : base(id)
    {
        PersonName = personName;
        PhoneNumber = phoneNumber;
        ExperienceYears = experienceYears;
        Description = description;
        
        _socialNetworks = socialNetworks;
        _assistanceDetails = assistanceDetails;
        _socialNetworks = [];
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

    public static Result<Volunteer> Create(
        VolunteerId id,
        PersonName personName,
        PhoneNumber phoneNumber,
        IEnumerable<SocialNetwork>? socialNetworks,
        IEnumerable<AssistanceDetails>? assistanceDetails,
        string email,
        int experienceYears,
        string description)
    {
        var volunteer = new Volunteer(
            id: id,
            personName: personName,
            phoneNumber: phoneNumber,
            socialNetworks: socialNetworks?.ToList() ?? [],
            assistanceDetails: assistanceDetails?.ToList() ?? [],
            email: email,
            experienceYears: experienceYears,
            description: description
        );
        return Result.Success(volunteer);
    }
}