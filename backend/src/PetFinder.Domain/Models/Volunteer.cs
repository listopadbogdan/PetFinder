using PetFinder.Domain.Enums;

namespace PetFinder.Domain.Models;

public class Volunteer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = default!;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = default!;
    public int ExperienceYears { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public List<SocialNetworks> SocialNetworks { get; private set; } = new();
    public List<AssistanceDetails> AssistanceDetails { get; private set; } = new();
    public List<Pet> Pets { get; private set; } = new();
    
    public int PetsFoundHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.FoundHome);
    public int PetsLookingForHomeCount => Pets.Count(p => p.HelpStatus == HelpStatusPet.LookingForHome);
    public int PetsOnTreatmentCount => throw new NotImplementedException(); // Pets.Count(p => p.HealthInformation.Contains("На лечении"));


}