using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.ProblemDetails;
/// <summary>
/// Filter for mapping exceptions to problem details 
/// </summary>
/// <inheritdoc />
[ExcludeFromCodeCoverage]
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
{
    private readonly IProblemDetailsDataProvider problemDetailsDataProvider = problemDetailsDataProvider;

    /// <inheritdoc />
    public void OnException(ExceptionContext context)
    {
        var problemDetails = problemDetailsDataProvider.ConvertExceptionToProblemDetails(context.Exception);
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
