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

		string title;
		var args = new object[exception.ExceptionLocalizationArguments.Length];

		for (int i = 0; i < args.Length; i++)
			args[i] = exception.ExceptionLocalizationArguments[i] ?? "";
		var localizedString = Localizer.GetString(exception.ExceptionLocalizationKey, args);

		if (localizedString.ResourceNotFound)
			title = HttpExceptionBase.TryFormatString(exception.ExceptionLocalizationKey ?? "", exception.ExceptionLocalizationArguments);
		else
			title = localizedString;

		return new ProblemDetails
		{
			Title = title,
			Status = exception.StatusCode,
		};
	}
}
