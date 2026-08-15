using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.ProblemDetails;
/// <summary>
/// Handles MVC exceptions by converting them to problem details through the configured provider.
/// </summary>
/// <param name="problemDetailsDataProvider">The scoped provider used to build response payloads.</param>
/// <remarks>The filter marks every exception as handled. The current implementation assigns an <see cref="ObjectResult"/> but does not explicitly copy the problem details status to <see cref="ObjectResult.StatusCode"/>.</remarks>
[ExcludeFromCodeCoverage]
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
{
    private readonly IProblemDetailsDataProvider problemDetailsDataProvider = problemDetailsDataProvider;

    /// <summary>Converts the current exception, assigns the result, and marks the exception as handled.</summary>
    /// <param name="context">The MVC exception context to update.</param>
    public void OnException(ExceptionContext context)
    {
        var problemDetails = problemDetailsDataProvider.ConvertExceptionToProblemDetails(context.Exception);
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
