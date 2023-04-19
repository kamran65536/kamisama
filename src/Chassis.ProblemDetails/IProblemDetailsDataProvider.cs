namespace KamiSama.Chassis.ProblemDetails;

using Microsoft.AspNetCore.Mvc.Filters;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// The interface provides information for problem details
/// </summary>
public interface IProblemDetailsDataProvider
{
	/// <summary>
	/// Converts Exception to ProblemDetails
	/// </summary>
	/// <param name="context"></param>
	/// <returns></returns>
	ProblemDetails ConvertExceptionToProblemDetails(ExceptionContext context);
}
