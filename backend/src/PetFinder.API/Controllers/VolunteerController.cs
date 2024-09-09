using Microsoft.AspNetCore.Mvc;
using PetFinder.Application.Features;
using PetFinder.Infrastructure;

namespace PetFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest createVolunteerRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(createVolunteerRequest, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : Ok(result.Value);
    }
}