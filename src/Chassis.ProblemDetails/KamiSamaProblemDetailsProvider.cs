namespace KamiSama.Chassis.ProblemDetails;
using KamiSama.Chassis.HttpExceptions;
using KamiSama.Chassis.ProblemDetails.Properties;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Converts KamiSama HTTP exceptions into ASP.NET Core problem details payloads.
/// </summary>
/// <remarks>Non-HTTP exceptions are represented as status 500 using their message. The current conversion does not copy <see cref="HttpExceptionBase.ExtendedProperties"/> to the payload.</remarks>
[ExcludeFromCodeCoverage]
public class KamiSamaProblemDetailsProvider : IProblemDetailsDataProvider
{
	/// <summary>Gets or sets the optional localizer used for the title and its arguments.</summary>
	public IStringLocalizer? Localizer { get; set; }
	/// <summary>Gets or sets whether each localization argument is localized before title formatting.</summary>
	public bool LocalizeArguments { get; set; }

	private object? SafeLocalize(object? obj, params object[] args)
	{
		var str = obj + "";
		var localized = Localizer!.GetString(str, args);

		if (localized.ResourceNotFound)
			return obj;
		else
			return localized.Value;
	}

	/// <summary>Converts an exception to a problem details title and status.</summary>
	/// <param name="exception">The exception to convert. Non-HTTP exceptions are wrapped as internal-operation failures.</param>
	/// <returns>A problem details payload containing the resolved title and HTTP status value.</returns>
	public ProblemDetails ConvertExceptionToProblemDetails(Exception exception)
	{
		if (exception is not HttpExceptionBase httpException)
			httpException = new InvalidOperationHttpException(exception.Message);

		if (Localizer == null)
			return new ProblemDetails
			{
				Title = httpException.Message,
				Status = httpException.StatusCode,
			};

		var args = new object[httpException.ExceptionLocalizationArguments.Length];

		for (int i = 0; i < args.Length; i++)
		{
			if (this.LocalizeArguments)
				args[i] = SafeLocalize(httpException.ExceptionLocalizationArguments[i]) ?? "";
			else
				args[i] = httpException.ExceptionLocalizationArguments[i] + "";
		}
		
		return new ProblemDetails
		{
			Title = SafeLocalize(httpException.ExceptionLocalizationKey, args) + "",
			Status = httpException.StatusCode,
		};
	}
}
