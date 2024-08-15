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
	public ProblemDetails ConvertExceptionToProblemDetails(ExceptionContext context)
	{
		if (context.Exception is not HttpExceptionBase exception)
			exception = new InvalidOperationHttpException(context.Exception.Message);

		if (Localizer == null)
			return new ProblemDetails
			{
				Title = exception.Message,
				Status = exception.StatusCode,
			};

		var args = new object[exception.ExceptionLocalizationArguments.Length];

		for (int i = 0; i < args.Length; i++)
		{
			if (this.LocalizeArguments)
				args[i] = SafeLocalize(exception.ExceptionLocalizationArguments[i]) ?? "";
			else
				args[i] = exception.ExceptionLocalizationArguments[i] + "";
		}
		
		return new ProblemDetails
		{
			Title = SafeLocalize(exception.ExceptionLocalizationKey, args) + "",
			Status = exception.StatusCode,
		};
	}
}
