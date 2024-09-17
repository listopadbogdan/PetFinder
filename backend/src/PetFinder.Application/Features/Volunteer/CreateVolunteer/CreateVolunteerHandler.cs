using CSharpFunctionalExtensions;
using FluentValidation;
using PetFinder.Application.Extensions;
using PetFinder.Domain.Shared;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Models;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Application.Features;

public class CreateVolunteerHandler(
    IVolunteerRepository volunteerRepository,
    IValidator<CreateVolunteerRequest> validator)
{
    public async Task<Result<Guid, ErrorList>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.Errors.ToList();

        var email = Email.Create(request.Email).Value;

        if ((await volunteerRepository.GetByEmail(email, cancellationToken)).IsSuccess)
            return Errors.General.RecordWithValueIsNotUnique(
                nameof(Volunteer), nameof(Email), email.Value).ToErrorList();

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

        if ((await volunteerRepository.GetByPhoneNumber(phoneNumber, cancellationToken)).IsSuccess)
            return Errors.General.RecordWithValueIsNotUnique(
                nameof(Constants.Volunteer), nameof(PhoneNumber), phoneNumber.Value).ToErrorList();

        var personName = PersonName.Create(
            request.PersonNameDto.FirstName,
            request.PersonNameDto.MiddleName,
            request.PersonNameDto.LastName).Value;

        var description = VolunteerDescription.Create(request.Description).Value;

        IEnumerable<SocialNetwork> socialNetworks = request.SocialNetworkDtos
            .Select(dto => SocialNetwork.Create(dto.Title, dto.Url).Value).ToList();

        IEnumerable<AssistanceDetails> assistanceDetails = request.AssistanceDetailsDtos
            .Select(dto => AssistanceDetails.Create(dto.Title, dto.Description).Value).ToList();

        var volunteerId = VolunteerId.New();

        var createVolunteerResult = Volunteer.Create(
            volunteerId,
            personName,
            phoneNumber,
            email,
            socialNetworks: socialNetworks,
            assistanceDetails: assistanceDetails,
            experienceYears: request.ExperienceYears,
            description: description);

        if (createVolunteerResult.IsFailure)
            return createVolunteerResult.Error.ToErrorList();

        await volunteerRepository.Add(createVolunteerResult.Value, cancellationToken);

        return volunteerId.Value;
    }
}