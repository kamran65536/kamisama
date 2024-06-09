namespace KamiSama.Chassis.ProblemDetails;

using KamiSama.Chassis.HttpExceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

/// <summary>
/// Converts <see cref="HttpExceptionBase" /> to <see cref="ProblemDetails"/>
/// </summary>
[ExcludeFromCodeCoverage]
public class KamiSamaProblemDetailsProvider(IStringLocalizer<KamiSamaProblemDetailsProvider> localizer) : IProblemDetailsDataProvider
{
	/// <inheritdoc/>
	public ProblemDetails ConvertExceptionToProblemDetails(ExceptionContext context)
	{
		if (context.Exception is not HttpExceptionBase exception)
			exception = new InvalidOperationHttpException(context.Exception.Message);

		var args = new object[exception.ExceptionLocalizationArguments.Length];

		for (int i = 0; i < args.Length; i++)
			args[i] = exception.ExceptionLocalizationArguments[i] ?? "";

		var localizedString = localizer.GetString(exception.ExceptionLocalizationKey, args);

		string title = localizedString.ResourceNotFound ? context.Exception.Message : localizedString;

		return new ProblemDetails
		{
			Title = title,
			Status = exception.StatusCode,
		};
	}
}
