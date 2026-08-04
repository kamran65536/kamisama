# KamiSamaProblemDetailsOptions

<a id="kamisamaproblemdetailsoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L11)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior.

## Declaration

```csharp
public class KamiSamaProblemDetailsOptions
```

## Example

```csharp
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options
        .UseDefaultProblemDetailsProvider()
        .UseResourceLocalizer<ErrorMessages>());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [UseDefaultProblemDetailsProvider](method-usedefaultproblemdetailsprovider-29.md) | Uses `KamiSamaProblemDetailsProvider` as default Problem Details Provider. Use it with the surrounding package APIs when composing application code. |
| [UseProblemDetailsProvider](method-useproblemdetailsprovider-44.md) | Uses customer provider as Problem Details Provider. Use it with the surrounding package APIs when composing application code. |
| [UseResourceLocalizer<ResourceType>](method-useresourcelocalizer-resourcetype-64.md) | Uses Resource String Localizer. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-24.md) | Localize argument parameters or not. Use it with the surrounding package APIs when composing application code. |
| [ProblemDetailsDataProviderFunc](property-problemdetailsdataproviderfunc-16.md) | Problem details provider factory function. Use it with the surrounding package APIs when composing application code. |
| [StringLocalizerFunc](property-stringlocalizerfunc-20.md) | Exposes the `StringLocalizerFunc` value on `KamiSamaProblemDetailsOptions`. Read or set it as part of configuring or using the type. |

