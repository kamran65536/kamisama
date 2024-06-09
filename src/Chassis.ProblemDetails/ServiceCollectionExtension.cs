using KamiSama.Chassis.ProblemDetails.Properties;
using Microsoft.Extensions.DependencyInjection;
using System;
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
    /// <returns></returns>
    public static IMvcBuilder AddExceptionFilterForProblemDetails(this IMvcBuilder builder, Action<KamiSamaProblemDetailsOptions>? config = null)
    {
        var options = new KamiSamaProblemDetailsOptions()
            .UseDefaultProblemDetailsProvider()
            .UseResourceLocalizer<Resources>();

        config?.Invoke(options);

        builder.Services.AddTransient<KamiSamaProblemDetailsOptions>(sp => options);
        builder.Services.AddScoped<KamiSamaProblemDetailsProvider>();
        builder.Services.AddScoped<IProblemDetailsDataProvider>(options.ProblemDetailsDataProviderFunc!);
        builder.Services.AddScoped<ProblemDetailsExceptionFilter>();

        return builder.AddMvcOptions(opt => opt.Filters.AddService<ProblemDetailsExceptionFilter>());
    }
}
