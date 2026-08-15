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
| [UseDefaultProblemDetailsProvider](method-usedefaultproblemdetailsprovider-29.md) | Selects `KamiSamaProblemDetailsProvider` and applies this instance&apos;s localization settings when it is resolved. Use it with the surrounding package APIs when composing application code. |
| [UseProblemDetailsProvider](method-useproblemdetailsprovider-45.md) | Selects a custom provider factory for exception conversion. Use it with the surrounding package APIs when composing application code. |
| [UseResourceLocalizer<ResourceType>](method-useresourcelocalizer-resourcetype-55.md) | Configures a resource-based string localizer for the default provider. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-24.md) | Gets or sets whether the default provider localizes message arguments before formatting the title. Use it with the surrounding package APIs when composing application code. |
| [ProblemDetailsDataProviderFunc](property-problemdetailsdataproviderfunc-16.md) | Gets or sets the dependency-injection factory that creates the scoped conversion provider. Use it with the surrounding package APIs when composing application code. |
| [StringLocalizerFunc](property-stringlocalizerfunc-20.md) | Gets or sets the factory that resolves the optional string localizer. Use it with the surrounding package APIs when composing application code. |

