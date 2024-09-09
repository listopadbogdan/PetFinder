using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;

namespace PetFinder.Application.Features;

public class CreateVolunteerHandler
{
    private readonly IVolunteerRepository _volunteerRepository;

    public CreateVolunteerHandler(IVolunteerRepository volunteerRepository) 
        => _volunteerRepository = volunteerRepository;

    public async Task<Result<Guid, string>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;
        
        if ((await _volunteerRepository.GetByEmail(emailResult.Value, cancellationToken)).IsFailure)
            return $"Email {emailResult.Value} is exists";
        
        var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
        if (phoneNumberResult.IsFailure)
            return phoneNumberResult.Error;

        if ((await _volunteerRepository.GetByPhoneNumber(phoneNumberResult.Value, cancellationToken)).IsFailure)
            return  $"PhoneNumber {phoneNumberResult.Value} is exists";

        var personNameResult = PersonName.Create(
            firstName: request.PersonNameDto.FirstName,
            middleName: request.PersonNameDto.MiddleName,
            lastName: request.PersonNameDto.LastName);

        if (personNameResult.IsFailure)
            return personNameResult.Error;

        IEnumerable<Result<SocialNetwork>> socialNetworks = request.SocialNetworkDtos
            .Select(dto => SocialNetwork.Create(title: dto.Title, url: dto.Url));

        Result<SocialNetwork>? failedSn = socialNetworks.FirstOrDefault(sn => sn.IsFailure);
        if (failedSn is not null)
            return failedSn.Value.Error;

        IEnumerable<Result<AssistanceDetails>> assistanceDetails = request.AssistanceDetailsDtos
            .Select(dto => AssistanceDetails.Create(title: dto.Title, description: dto.Description));

        Result<AssistanceDetails>? failedAs = assistanceDetails.FirstOrDefault(ad => ad.IsFailure);
        if (failedAs is not null)
            return failedAs.Value.Error;

        var volunteerId = VolunteerId.New();

        var volunteer = PetFinder.Domain.Models.Volunteer.Create(
            id: volunteerId,
            personName: personNameResult.Value,
            phoneNumber: phoneNumberResult.Value,
            socialNetworks: socialNetworks.UnwrapFromResultToValue(),
            assistanceDetails: assistanceDetails.UnwrapFromResultToValue(),
            email: request.Email,
            experienceYears: request.ExperienceYears,
            description: request.Description);
        
        if (volunteer.IsFailure)
            return volunteer.Error;

        return volunteer.Value.Id.Value;
    }
}

public static class ResultExtensions
{
    public static IEnumerable<T> UnwrapFromResultToValue<T>(this IEnumerable<Result<T>> collections)
        => collections.Select(c => c.Value);
}