using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Volunteer : Entity<VolunteerId>
{
    private readonly List<AssistanceDetails> _assistanceDetails = new();
    private readonly List<Pet> _pets = new();
    private readonly List<SocialNetwork> _socialNetworks = new();

    private Volunteer(VolunteerId id)
        : base(id)
    {
    }

    public PersonName PersonName { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<AssistanceDetails> AssistanceDetails => _assistanceDetails;
    public IReadOnlyList<Pet> Pets => _pets;

    public int PetsFoundHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.FoundHome);
    public int PetsLookingForHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.LookingForHome);
    public int PetsOnTreatmentCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.OnTreatment);
}