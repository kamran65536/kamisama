# IProblemDetailsDataProvider

<a id="iproblemdetailsdataprovider"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L9)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Interface`

## Description

The interface provides information for problem details. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IProblemDetailsDataProvider
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertExceptionToProblemDetails](method-convertexceptiontoproblemdetails-23.md) | Converts Exception to ProblemDetails. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [LocalizeArguments](property-localizearguments-18.md) | try to localize arguments or not. Use it with the surrounding package APIs when composing application code. |
| [Localizer](property-localizer-14.md) | String Localizer to be used. Use it with the surrounding package APIs when composing application code. |

