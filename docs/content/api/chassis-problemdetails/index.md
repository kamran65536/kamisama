# KamiSama.Chassis.ProblemDetails

[Back to package index](../index.md)

Version: `10.0.10`

## Description

ASP.NET Core ProblemDetails integration for converting KamiSama HTTP exceptions into standardized API error responses. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Chassis.ProblemDetails --version 10.0.10
```

## Namespaces

- [KamiSama.Chassis.ProblemDetails](kamisama-chassis-problemdetails/index.md) (5 types)

## Types

- [KamiSama.Chassis.ProblemDetails.IProblemDetailsDataProvider](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-iproblemdetailsdataprovider/index.md) - The interface provides information for problem details. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-kamisamaproblemdetailsoptions/index.md) - Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior.
- [KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsProvider](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-kamisamaproblemdetailsprovider/index.md) - Converts `HttpExceptionBase` to `ProblemDetails`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.ProblemDetailsExceptionFilter](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-problemdetailsexceptionfilter/index.md) - Filter for mapping exceptions to problem details. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.ProblemDetails.ServiceCollectionExtension](kamisama-chassis-problemdetails/kamisama-chassis-problemdetails-servicecollectionextension/index.md) - Service Collection Extension for adding exception handing to AspNetCore apps. Use it with the surrounding package APIs when composing application code.
