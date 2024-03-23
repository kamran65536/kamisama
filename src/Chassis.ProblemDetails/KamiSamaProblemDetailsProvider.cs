namespace KamiSama.Chassis.ProblemDetails;

using KamiSama.Chassis.HttpExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
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
		if (context.Exception is HttpExceptionBase exception)
			return new ProblemDetails
			{
				Title = exception.Message,
				Status = exception.StatusCode,
			};
		else if (context.Exception is InvalidOperationException)
			return new ProblemDetails
			{
				Title = context.Exception.Message,
				Detail = "Invalid Operation Exception",
				Status = StatusCodes.Status500InternalServerError,
			};
		else
			return new ProblemDetails
			{
				Title = context.Exception.Message,
				Detail = context.Exception.StackTrace,
				Status = StatusCodes.Status500InternalServerError,
			};
	}
}
