using Microsoft.AspNetCore.Mvc;
using PetFinder.Domain.Shared;

namespace PetFinder.API.Extensions;

public static class ResponseExtensions
{
    public static IActionResult ToResponse(this Error error)
    {
        var statusCode = error.ErrorType switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError,
        };

        return new ObjectResult(error) { StatusCode = statusCode };
    }
}