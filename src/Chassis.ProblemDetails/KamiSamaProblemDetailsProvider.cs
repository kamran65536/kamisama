namespace KamiSama.Chassis.ProblemDetails;
using KamiSama.Chassis.HttpExceptions;
using KamiSama.Chassis.ProblemDetails.Properties;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Converts <see cref="HttpExceptionBase" /> to <see cref="ProblemDetails"/>
/// </summary>
[ExcludeFromCodeCoverage]
public class KamiSamaProblemDetailsProvider : IProblemDetailsDataProvider
{
	/// <inheritdoc	/>
	public IStringLocalizer? Localizer { get; set; }
	/// <inheritdoc />
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

	/// <inheritdoc/>
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
