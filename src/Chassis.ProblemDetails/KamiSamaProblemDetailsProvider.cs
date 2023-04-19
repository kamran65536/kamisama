namespace KamiSama.Chassis.ProblemDetails;

using KamiSama.Chassis.HttpExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Converts <see cref="HttpExceptionBase" /> to <see cref="ProblemDetails"/>
/// </summary>
[ExcludeFromCodeCoverage]
public class KamiSamaProblemDetailsProvider : IProblemDetailsDataProvider
{
	/// <inheritdoc/>
	public ProblemDetails ConvertExceptionToProblemDetails(ExceptionContext context)
	{
		return context.Exception is not HttpExceptionBase exception
			? new ProblemDetails
			{
				Title = context.Exception.Message,
				Detail = context.Exception.StackTrace,
				Status = StatusCodes.Status500InternalServerError,
			}
			: new ProblemDetails
			{
				Title = exception.Message,
				Status = exception.StatusCode,
			};
	}
}
