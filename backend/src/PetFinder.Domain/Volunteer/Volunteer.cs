using PetFinder.Domain.Abstract;
using PetFinder.Domain.Pet;

namespace PetFinder.Domain.Volunteer;

public class Volunteer : Entity<VolunteerId>
{
    private Volunteer(VolunteerId id) 
        : base(id) { }
    public string FirstName { get; private set; } = default!;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public List<SocialNetworks> SocialNetworks { get; private set; } = new();
    public List<AssistanceDetails> AssistanceDetails { get; private set; } = new();
    public List<Pet.Pet> Pets { get; private set; } = new();

    public int PetsFoundHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.FoundHome);
    public int PetsLookingForHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.LookingForHome);
    public int PetsOnTreatmentCount =>
        throw new NotImplementedException(); // Pets.Count(p => p.HealthInformation.Contains("На лечении"));
}