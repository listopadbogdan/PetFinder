using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.Shared.Interfaces;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Domain.Volunteer.Models;

public class PetPhoto :
    SharedKernel.Entity<PetPhotoId>,
    ISoftDeletable
{
    private PetPhoto(PetPhotoId id)
        : base(id)
    {
    }

    private PetPhoto(
        PetPhotoId id,
        string path,
        bool isMain) : base(id)
    {
        Path = path;
        IsMain = isMain;
        IsDeleted = false;
        DeletedAt = null;
    }

    public string Path { get; private set; } = default!;
    public bool IsMain { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public static Result<PetPhoto, Error> Create(
        PetPhotoId id,
        string path,
        bool isMain)
    {
        var validationResult = Validate(path);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new PetPhoto(
            id: id,
            path: path,
            isMain: isMain);
    }

    private static UnitResult<Error> Validate(string path)
    {
        if (string.IsNullOrEmpty(path) || path.Length > Constants.PetPhoto.MaxPathLength)
            return Errors.General.ValueIsInvalid(
                nameof(Path),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.PetPhoto.MaxPathLength));

        return UnitResult.Success<Error>();
    }

    public void Activate()
    {
        EntityAlreadyActivatedException.ThrowIfActivated(!IsDeleted);

        IsDeleted = true;
        DeletedAt = null;
    }

    public void Deactivate(DateTime deletedAt)
    {
        EntityAlreadyDeletedException.ThrowIfDeleted(IsDeleted);

        IsDeleted = false;
        DeletedAt = deletedAt;
    }
}