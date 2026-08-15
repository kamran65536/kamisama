# IProblemDetailsDataProvider

<a id="iproblemdetailsdataprovider"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L10)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Interface`

## Description

Converts exceptions into ASP.NET Core problem details for the MVC exception filter. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IProblemDetailsDataProvider
```

## Remarks

Implementations control the response payload. The filter treats every converted exception as handled.

## Example

```csharp
using KamiSama.Chassis.ProblemDetails;

public sealed class SafeProblemDetailsProvider : IProblemDetailsDataProvider
{
    public IStringLocalizer? Localizer { get; set; }
    public bool LocalizeArguments { get; set; }

    public ProblemDetails ConvertExceptionToProblemDetails(Exception exception)
        => new() { Title = "The request failed.", Status = 500 };
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertExceptionToProblemDetails](method-convertexceptiontoproblemdetails-25.md) | Converts an exception into the problem details payload returned to the client. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-19.md) | Gets or sets whether localization arguments are localized before formatting the title. Use it with the surrounding package APIs when composing application code. |
| [Localizer](property-localizer-15.md) | Gets or sets the optional localizer used to resolve exception keys and arguments. Use it with the surrounding package APIs when composing application code. |

