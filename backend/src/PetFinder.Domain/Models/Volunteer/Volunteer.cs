using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private Volunteer(VolunteerId id)
        : base(id)
    {
    }

    public PersonName PersonName { get; private set; } = default!;

    public int ExperienceYears { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public List<SocialNetworks> SocialNetworks { get; private set; } = new();
    public List<AssistanceDetails> AssistanceDetails { get; private set; } = new();
    public List<Pet> Pets { get; private set; } = new();

    public int PetsFoundHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.FoundHome);
    public int PetsLookingForHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.LookingForHome);

    public int PetsOnTreatmentCount =>
        throw new NotImplementedException(); // Pets.Count(p => p.HealthInformation.Contains("На лечении"));
}