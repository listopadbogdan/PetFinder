using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;

namespace PetFinder.Application.Features;

public interface IVolunteerRepository
{
    Task<VolunteerId> Add(Volunteer volunteer,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetById(VolunteerId volunteerId,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetByEmail(Email email,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber,
        CancellationToken cancellationToken);
}