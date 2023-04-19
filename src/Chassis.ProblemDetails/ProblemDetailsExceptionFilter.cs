using KamiSama.Chassis.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.Exceptions;

using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Filter for mapping exceptions to problem details 
/// </summary>
[ExcludeFromCodeCoverage]
public class ProblemDetailsExceptionFilter : IExceptionFilter
{
	private readonly IProblemDetailsDataProvider problemDetailsDataProvider;
	
	/// <inheritdoc />
	public ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider)
	{
		this.problemDetailsDataProvider = problemDetailsDataProvider;
	}
	/// <inheritdoc />
	public void OnException(ExceptionContext context)
	{
		ProblemDetails problemDetails = problemDetailsDataProvider.ConvertExceptionToProblemDetails(context);
		context.Result = new ObjectResult(problemDetails);
		context.ExceptionHandled = true;
	}
}
