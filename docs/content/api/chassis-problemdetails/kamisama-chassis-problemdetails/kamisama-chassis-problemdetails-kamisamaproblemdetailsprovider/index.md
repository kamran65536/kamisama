# KamiSamaProblemDetailsProvider

<a id="kamisamaproblemdetailsprovider"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs#L13)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Converts `HttpExceptionBase` to `ProblemDetails`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class KamiSamaProblemDetailsProvider : IProblemDetailsDataProvider
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertExceptionToProblemDetails](method-convertexceptiontoproblemdetails-33.md) | Runs the `ConvertExceptionToProblemDetails` operation on `KamiSamaProblemDetailsProvider`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-19.md) | Exposes the `LocalizeArguments` value on `KamiSamaProblemDetailsProvider`. Read or set it as part of configuring or using the type. |
| [Localizer](property-localizer-17.md) | Exposes the `Localizer` value on `KamiSamaProblemDetailsProvider`. Read or set it as part of configuring or using the type. |

