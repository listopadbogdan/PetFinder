namespace PetFinder.Domain.Shared.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; }  
    DateTime? DeletedAt { get; }
    void Activate();
    void Deactivate(DateTime deletedAt);
}

public class EntityAlreadyDeletedException() 
    : InvalidOperationException("Entity has already been deactivated.")
{
    public static void ThrowIfDeleted(bool isDeleted)
    {
        if (isDeleted)
            throw new EntityAlreadyDeletedException();
    }
}

public class EntityAlreadyActivatedException() 
    : InvalidOperationException("Entity has already been activated.")
{
    public static void ThrowIfActivated(bool isActivated)
    {
        if (isActivated)
            throw new EntityAlreadyActivatedException();
    }
}