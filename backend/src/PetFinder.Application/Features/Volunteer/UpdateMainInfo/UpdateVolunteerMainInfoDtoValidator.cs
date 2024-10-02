using FluentValidation;
using PetFinder.Application.Extensions;
using PetFinder.Domain.Volunteer.Models;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Application.Features.UpdateMainInfo;

public class UpdateVolunteerMainInfoDtoValidator : AbstractValidator<UpdateVolunteerMainInfoDto>
{
    public UpdateVolunteerMainInfoDtoValidator()
    {
        RuleFor(dto => dto.PersonNameDto).MustBeValueObject(
            personNameDto => PersonName.Validate(
                firstName: personNameDto.FirstName,
                middleName: personNameDto.MiddleName,
                lastName: personNameDto.LastName));

        RuleFor(dto => dto.PhoneNumber).MustBeValueObject(PhoneNumber.Validate);

        RuleFor(dto => dto.Email).MustBeValueObject(Email.Validate);

        RuleFor(dto => dto.VolunteerDescription).MustBeValueObject(VolunteerDescription.Validate);

        RuleFor(dto => dto.ExperienceYears).MustBeValueObject(Volunteer.ValidateExperienceYears);
    }
}