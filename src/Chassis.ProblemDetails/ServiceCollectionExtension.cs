using KamiSama.Chassis.Exceptions;
using KamiSama.Chassis.ProblemDetails;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Service Collection Extension for adding exception handing to AspNetCore apps
/// </summary>
[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
	/// <summary>
	/// Adds Exception Filter for problem details
	/// </summary>
	/// <param name="builder"></param>
	/// <param name="problemDetailsProvider"></param>
	/// <returns></returns>
	public static IMvcBuilder AddExceptionFilterForProblemDetails(this IMvcBuilder builder, IProblemDetailsDataProvider? problemDetailsProvider = null)
	{
		var filter = new ProblemDetailsExceptionFilter(problemDetailsProvider ?? new KamiSamaProblemDetailsProvider());

		return builder.AddMvcOptions(opt => opt.Filters.Add(filter));
	}
}
