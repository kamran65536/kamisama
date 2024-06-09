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
    public static IMvcBuilder AddExceptionFilterForProblemDetails(this IMvcBuilder builder, Func<IServiceProvider, IProblemDetailsDataProvider>? problemDetailsProviderFunc  = null)
    {
        if (problemDetailsProviderFunc != null)
            builder.Services.AddScoped<IProblemDetailsDataProvider>(problemDetailsProviderFunc);
        else
            builder.Services.AddScoped<IProblemDetailsDataProvider, KamiSamaProblemDetailsProvider>(); 
        
        return builder.AddMvcOptions(opt => opt.Filters.AddService<ProblemDetailsExceptionFilter>());
    }
}
