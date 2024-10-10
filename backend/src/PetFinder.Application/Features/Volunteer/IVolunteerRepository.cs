using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Models;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Application.Features;

public interface IVolunteerRepository
{
    VolunteerId Add(Volunteer volunteer,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetById(VolunteerId volunteerId,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetByEmail(Email email,
        CancellationToken cancellationToken);

    Task<Result<Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber,
        CancellationToken cancellationToken);

    public Task<bool> CheckPhoneNumberForExists(PhoneNumber phoneNumber,
        CancellationToken cancellationToken = default);
    
    public Task<bool> CheckEmailForExists(Email email,
        CancellationToken cancellationToken = default);

    void Delete(Volunteer volunteer);
    void Save(Volunteer volunteer);
}
