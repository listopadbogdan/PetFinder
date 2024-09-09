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
        [FromBody] CreateVolunteerRequest createVolunteerRequest)
    {
        var result = await handler.Handle(createVolunteerRequest);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}