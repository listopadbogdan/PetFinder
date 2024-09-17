using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Enums;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Domain.Volunteer.Models;

public class Volunteer : SharedKernel.Entity<VolunteerId>
{
    private readonly List<AssistanceDetails> _assistanceDetails = default!;
    private readonly List<Pet> _pets = [];
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
        VolunteerDescription description,
        IEnumerable<SocialNetwork>? socialNetworks,
        IEnumerable<AssistanceDetails>? assistanceDetails) : base(id)
    {
        PersonName = personName;
        PhoneNumber = phoneNumber;
        ExperienceYears = experienceYears;
        Description = description;
        Email = email;
        _socialNetworks = socialNetworks?.ToList() ?? [];
        _assistanceDetails = assistanceDetails?.ToList() ?? [];
    }

    public PersonName PersonName { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public VolunteerDescription Description { get; private set; } = default!;
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
        VolunteerDescription description,
        IEnumerable<SocialNetwork>? socialNetworks = default,
        IEnumerable<AssistanceDetails>? assistanceDetails = null)
    {
        return new Volunteer(
            id,
            personName,
            phoneNumber,
            email,
            experienceYears,
            description,
            socialNetworks?.ToList(),
            assistanceDetails?.ToList()
        );
    }
}