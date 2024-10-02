namespace PetFinder.Domain.Shared.Exceptions;

public class EntityAlreadyDeletedException() 
    : InvalidOperationException("Entity has already been deactivated.")
{
    public static void ThrowIfDeleted(bool isDeleted)
    {
        if (isDeleted)
            throw new EntityAlreadyDeletedException();
    }
}