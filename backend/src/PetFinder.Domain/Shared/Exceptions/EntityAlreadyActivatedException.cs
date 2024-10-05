namespace PetFinder.Domain.Shared.Exceptions;

public class EntityAlreadyActivatedException() 
    : InvalidOperationException("Entity has already been activated.")
{
    public static void ThrowIfActivated(bool isActivated)
    {
        if (isActivated)
            throw new EntityAlreadyActivatedException();
    }
}