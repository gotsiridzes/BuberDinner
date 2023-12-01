using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class ErrorsController : ControllerBase
{
    public async Task<ActionResult> Error()
    {
        await Task.CompletedTask;
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IError serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        return Problem(title: message, statusCode: statusCode);
    }
}
