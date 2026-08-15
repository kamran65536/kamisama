namespace KamiSama.Chassis.ProblemDetails;

using Microsoft.Extensions.Localization;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Converts exceptions into ASP.NET Core problem details for the MVC exception filter.
/// </summary>
/// <remarks>Implementations control the response payload. The filter treats every converted exception as handled.</remarks>
public interface IProblemDetailsDataProvider
{
	/// <summary>
	/// Gets or sets the optional localizer used to resolve exception keys and arguments.
	/// </summary>
	IStringLocalizer? Localizer { get; set; }
	/// <summary>
	/// Gets or sets whether localization arguments are localized before formatting the title.
	/// </summary>
	bool LocalizeArguments { get; set; }
	/// <summary>
	/// Converts an exception into the problem details payload returned to the client.
	/// </summary>
	/// <param name="exception">The exception raised while MVC processes the request.</param>
	/// <returns>A problem details instance describing the failure.</returns>
	ProblemDetails ConvertExceptionToProblemDetails(Exception exception);
}
