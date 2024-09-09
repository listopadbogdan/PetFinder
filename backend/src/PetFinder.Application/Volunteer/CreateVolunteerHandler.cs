using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;

namespace PetFinder.Application;

public class CreateVolunteerHandler(IVolunteerRepository volunteerRepository)
{
    private readonly IVolunteerRepository _volunteerRepository = volunteerRepository;

    public async Task<Result<VolunteerId>> Handle(
        CreateVolunteerRequest createVolunteerRequest,
        CancellationToken cancellationToken = default)
    {
        
        
    }
    
    
}

public record CreateVolunteerRequest(
    PersonNameDto PersonNameDto, 
    IEnumerable<SocialNetworkDto> SocialNetworkDtos,
    IEnumerable<AssistanceDetailsDto> AssistanceDetailsDtos,
    int ExperienceYears,
    string Description,
    string Email);