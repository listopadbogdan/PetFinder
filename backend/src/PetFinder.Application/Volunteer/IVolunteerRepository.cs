using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;

namespace PetFinder.Application;

public interface IVolunteerRepository
{
    Task<VolunteerId> Add(Volunteer volunteer, CancellationToken cancellationToken);
    Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken);
}