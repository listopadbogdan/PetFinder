using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Infrastructure.Dto;

public class AssistanceDetailsDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public  AssistanceDetails ToValueObjecct() 
        => AssistanceDetails.Create(title:Title, description:Description).Value;
}