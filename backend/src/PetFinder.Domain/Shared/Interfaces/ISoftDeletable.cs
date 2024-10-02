namespace PetFinder.Domain.Shared.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; }  
    DateTime? DeletedAt { get; }
    void Activate();
    void Deactivate(DateTime deletedAt);
}