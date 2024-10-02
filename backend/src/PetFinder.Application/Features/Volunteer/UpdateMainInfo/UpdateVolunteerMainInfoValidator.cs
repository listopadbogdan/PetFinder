using FluentValidation;

namespace PetFinder.Application.Features.UpdateMainInfo;

public class UpdateVolunteerMainInfoValidator
    : AbstractValidator<UpdateVolunteerMainInfoRequest>
{
    public UpdateVolunteerMainInfoValidator()
    {
        RuleFor(r => r.Dto)
            .SetValidator(_ => new UpdateVolunteerMainInfoDtoValidator());
    }
}