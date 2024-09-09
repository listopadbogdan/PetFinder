using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure;

namespace PetFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController
{
    public VolunteerController(ApplicationDbContext context )
    {
        
    }
    [HttpGet]
    public IActionResult Get()
    {
        
    } 
}