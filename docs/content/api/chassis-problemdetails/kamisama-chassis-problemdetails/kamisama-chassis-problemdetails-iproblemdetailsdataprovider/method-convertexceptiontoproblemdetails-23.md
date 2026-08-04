# ConvertExceptionToProblemDetails

[Back to IProblemDetailsDataProvider](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L23)

Type: `KamiSama.Chassis.ProblemDetails.IProblemDetailsDataProvider`

Kind: `Method`

## Description

Converts Exception to ProblemDetails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
ProblemDetails ConvertExceptionToProblemDetails(Exception exception);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `exception` | `Exception` | `-` | The `exception` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ProblemDetails` | Returns a `ProblemDetails` value. |

## Example

No concise standalone example is available yet.

