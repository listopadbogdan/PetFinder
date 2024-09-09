using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;

namespace PetFinder.Application.Features;

public interface IVolunteerRepository
{
    Task<VolunteerId> Add(PetFinder.Domain.Models.Volunteer volunteer,
        CancellationToken cancellationToken);
    Task<Result<PetFinder.Domain.Models.Volunteer>> GetById(VolunteerId volunteerId,
        CancellationToken cancellationToken);
    Task<Result<PetFinder.Domain.Models.Volunteer>> GetByEmail(Email email, 
        CancellationToken cancellationToken);
    Task<Result<PetFinder.Domain.Models.Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber,
        CancellationToken cancellationToken);
}