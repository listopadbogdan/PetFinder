using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFinder.Application;
using PetFinder.Domain.Models;

namespace PetFinder.Infrastructure.Repositories;

public class VolunteerRepository(ApplicationDbContext dbContext) : IVolunteerRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<VolunteerId> Add(Volunteer volunteer, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(volunteer);

        await _dbContext.AddAsync(volunteer, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(volunteerId);

        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Pets)
            .ThenInclude(p => p.Photos)
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken: cancellationToken);

        if (volunteer is null)
            return Result.Failure<Volunteer>("Not not found");

        return Result.Success(volunteer);
    }
}