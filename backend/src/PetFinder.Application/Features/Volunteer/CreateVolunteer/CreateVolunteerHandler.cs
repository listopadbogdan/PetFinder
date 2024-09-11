using CSharpFunctionalExtensions;
using PetFinder.Domain.Models;
using PetFinder.Domain.Shared;

namespace PetFinder.Application.Features;

public class CreateVolunteerHandler(IVolunteerRepository volunteerRepository)
{
    public async Task<Result<Guid, Error>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        if ((await volunteerRepository.GetByEmail(emailResult.Value, cancellationToken)).IsSuccess)
            return Errors.General.RecordWithValueIsNotUnique(nameof(Volunteer), nameof(Email), emailResult.Value);

        var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
        if (phoneNumberResult.IsFailure)
            return phoneNumberResult.Error;

        if ((await volunteerRepository.GetByPhoneNumber(phoneNumberResult.Value, cancellationToken)).IsSuccess)
            return Errors.General.RecordWithValueIsNotUnique(nameof(Volunteer), nameof(PhoneNumber),
                phoneNumberResult.Value);

        var personNameResult = PersonName.Create(
            firstName: request.PersonNameDto.FirstName,
            middleName: request.PersonNameDto.MiddleName,
            lastName: request.PersonNameDto.LastName);
        if (personNameResult.IsFailure)
            return personNameResult.Error;

        IEnumerable<Result<SocialNetwork, Error>> socialNetworks = request.SocialNetworkDtos
            .Select(dto => SocialNetwork.Create(title: dto.Title, url: dto.Url)).ToList();

        if (socialNetworks.Count(sn => sn.IsFailure) > 0)
        {
            var sn =  socialNetworks.First(sn => sn.IsFailure);
            return sn.Error;
        }

        IEnumerable<Result<AssistanceDetails, Error>> assistanceDetails = request.AssistanceDetailsDtos
            .Select(dto => AssistanceDetails.Create(title: dto.Title, description: dto.Description)).ToList();

        if (assistanceDetails.Count(ad => ad.IsFailure) > 0)
        {
            var ad = assistanceDetails.First(ad => ad.IsFailure);
            return ad.Error;
        };

        var volunteerId = VolunteerId.New();

        var createVolunteerResult = Volunteer.Create(
            id: volunteerId,
            personName: personNameResult.Value,
            phoneNumber: phoneNumberResult.Value,
            email: emailResult.Value,
            socialNetworks: socialNetworks.UnwrapFromResultToValue(),
            assistanceDetails: assistanceDetails.UnwrapFromResultToValue(),
            experienceYears: request.ExperienceYears,
            description: request.Description);

        if (createVolunteerResult.IsFailure)
            return createVolunteerResult.Error;

        await volunteerRepository.Add(createVolunteerResult.Value, cancellationToken);
        return volunteerId.Value;
    }
}

public static class ResultExtensions
{
    public static IEnumerable<T> UnwrapFromResultToValue<T>(this IEnumerable<Result<T>> collections)
        => collections.Select(c => c.Value);

    public static IEnumerable<T> UnwrapFromResultToValue<T, TE>(this IEnumerable<Result<T, TE>> collections)
        => collections.Select(c => c.Value);
}