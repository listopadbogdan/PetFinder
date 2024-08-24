using PetFinder.Domain.Abstract;

namespace PetFinder.Domain.Pet;

public class Pet : Entity<PetId>
{
    private Pet(PetId id) : base(id) { }
    public string Name { get; private set; } = default!;
    public string AnimalType { get; private set; } = default!;
    public string GeneralDescription { get; private set; } = default!;
    public string Breed { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string HealthInformation { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string OwnerPhoneNumber { get; private set; } = default!;
    public DateOnly BirthDate { get; private set; }
    public bool IsCastrated { get; private set; }
    public bool IsVaccinated { get; private set; }
    public HelpStatusPet HelpStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<PetPhoto.PetPhoto> Photos { get; private set; } = new();
}