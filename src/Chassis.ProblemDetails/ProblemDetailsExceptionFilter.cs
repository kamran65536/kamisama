using KamiSama.Chassis.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.Exceptions;

using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

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
		ProblemDetails problemDetails = problemDetailsDataProvider.ConvertExceptionToProblemDetails(context);
		context.Result = new ObjectResult(problemDetails);
		context.ExceptionHandled = true;
	}
}
