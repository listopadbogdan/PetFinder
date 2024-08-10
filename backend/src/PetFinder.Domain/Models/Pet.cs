using PetFinder.Domain.Enums;

namespace PetFinder.Domain.Models;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public AnimalType AnimalType { get; set; }
    public string GeneralDescription { get; set; } = default!;
    public string Breed { get; set; } = default!;
    public string Color { get; set; } = default!;
    public string HealthInformation { get; set; } = default!;
    public string Address { get; set; } = default!;
    public double Weight { get; set; }
    public double Height { get; set; }
    public string OwnerPhoneNumber { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    public bool IsCastrated { get; set; }
    public bool IsVaccinated { get; set; }
    public HelpStatusPet HelpStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public AssistanceDetails AssistanceDetails { get; set; } = default!;
}