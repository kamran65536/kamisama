using KamiSama.Chassis.ProblemDetails.Properties;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.ProblemDetails;

/// <summary>
/// Registers the KamiSama ProblemDetails provider and global MVC exception filter.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Adds the scoped conversion services and configures MVC to resolve the exception filter globally.
    /// </summary>
    /// <param name="builder">The MVC builder whose services and filter collection are configured.</param>
    /// <param name="config">An optional callback that replaces the provider or changes localization settings.</param>
    /// <returns>The MVC builder so registration can continue fluently.</returns>
    /// <remarks>The default setup uses the package resources and handles all exceptions, including exceptions that are not <c>HttpExceptionBase</c> instances.</remarks>
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
