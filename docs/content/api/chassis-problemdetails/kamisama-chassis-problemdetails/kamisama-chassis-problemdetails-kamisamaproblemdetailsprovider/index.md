# KamiSamaProblemDetailsProvider

<a id="kamisamaproblemdetailsprovider"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs#L14)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Converts KamiSama HTTP exceptions into ASP.NET Core problem details payloads. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class KamiSamaProblemDetailsProvider : IProblemDetailsDataProvider
```

## Remarks

Non-HTTP exceptions are represented as status 500 using their message. The current conversion does not copy `HttpExceptionBase.ExtendedProperties` to the payload.

## Example

```csharp
using KamiSama.Chassis.ProblemDetails;

var provider = new KamiSamaProblemDetailsProvider
{
    Localizer = errorLocalizer,
    LocalizeArguments = true
};

ProblemDetails details = provider.ConvertExceptionToProblemDetails(exception);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertExceptionToProblemDetails](method-convertexceptiontoproblemdetails-36.md) | Converts an exception to a problem details title and status. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-20.md) | Gets or sets whether each localization argument is localized before title formatting. Use it with the surrounding package APIs when composing application code. |
| [Localizer](property-localizer-18.md) | Gets or sets the optional localizer used for the title and its arguments. Use it with the surrounding package APIs when composing application code. |

