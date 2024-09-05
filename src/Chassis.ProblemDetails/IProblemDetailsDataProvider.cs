namespace KamiSama.Chassis.ProblemDetails;

using Microsoft.Extensions.Localization;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// The interface provides information for problem details
/// </summary>
public interface IProblemDetailsDataProvider
{
	/// <summary>
	/// String Localizer to be used
	/// </summary>
	IStringLocalizer? Localizer { get; set; }
	/// <summary>
	/// try to localize arguments or not
	/// </summary>
	bool LocalizeArguments { get; set; }
	/// <summary>
	/// Converts Exception to ProblemDetails
	/// </summary>
	/// <param name="context"></param>
	/// <returns></returns>
	ProblemDetails ConvertExceptionToProblemDetails(ExceptionContext context);
}
