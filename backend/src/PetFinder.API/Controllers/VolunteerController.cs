using Microsoft.AspNetCore.Mvc;
using PetFinder.API.Extensions;
using PetFinder.Application.Features;

namespace PetFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest createVolunteerRequest,
        [FromServices] ILogger<VolunteerController> logger,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(createVolunteerRequest, cancellationToken);

        return result.IsFailure
            ? result.Error.ToResponse()
            : Ok(result.Value);
    }
}