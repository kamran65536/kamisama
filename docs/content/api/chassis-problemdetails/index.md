# KamiSama.Chassis.ProblemDetails

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core ProblemDetails integration for converting KamiSama HTTP exceptions into standardized API error responses. Use it with the surrounding package APIs when composing application code.

## How to use

```shell
dotnet add package KamiSama.Chassis.ProblemDetails --version 10.0.0
```

Register the MVC filter after adding controllers. The default provider converts `HttpExceptionBase` metadata and uses the package resource localizer:

```csharp
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options
        .UseDefaultProblemDetailsProvider()
        .UseResourceLocalizer<ErrorMessages>());
```

The filter handles every MVC exception. Non-HTTP exceptions become status 500 payloads whose title uses the original exception message. The current filter does not explicitly assign `ObjectResult.StatusCode`, and the default provider does not copy `ExtendedProperties`; account for those runtime limitations or supply a custom `IProblemDetailsDataProvider`. Custom provider factories must configure their own localization behavior.

## Namespaces

- [KamiSama.Chassis.ProblemDetails](kamisama-chassis-problemdetails/index.md) (5 types)

## Types

- [KamiSama.Chassis.ProblemDetails.IProblemDetailsDataProvider](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-iproblemdetailsdataprovider/index.md) - Converts exceptions into ASP.NET Core problem details for the MVC exception filter. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-kamisamaproblemdetailsoptions/index.md) - Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior.
- [KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsProvider](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-kamisamaproblemdetailsprovider/index.md) - Converts KamiSama HTTP exceptions into ASP.NET Core problem details payloads. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.ProblemDetailsExceptionFilter](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-problemdetailsexceptionfilter/index.md) - Handles MVC exceptions by converting them to problem details through the configured provider. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.ServiceCollectionExtension](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-servicecollectionextension/index.md) - Registers the KamiSama ProblemDetails provider and global MVC exception filter. Use it with the surrounding package APIs when composing application code.
