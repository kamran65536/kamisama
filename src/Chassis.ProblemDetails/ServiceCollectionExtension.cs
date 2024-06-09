using KamiSama.Chassis.ProblemDetails.Properties;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.ProblemDetails;

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
        problemDetailsProvider ??= new KamiSamaProblemDetailsProvider();

        return builder.AddMvcOptions(opt => opt.Filters.AddService<ProblemDetailsExceptionFilter>());
    }
}
