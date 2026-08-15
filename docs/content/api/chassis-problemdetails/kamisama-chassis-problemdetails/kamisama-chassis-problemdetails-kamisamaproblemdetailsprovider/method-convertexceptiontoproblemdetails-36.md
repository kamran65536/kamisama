# ConvertExceptionToProblemDetails

[Back to KamiSamaProblemDetailsProvider](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs#L36)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsProvider`

Kind: `Method`

## Description

Converts an exception to a problem details title and status. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ProblemDetails ConvertExceptionToProblemDetails(Exception exception);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `exception` | `Exception` | `-` | The exception to convert. Non-HTTP exceptions are wrapped as internal-operation failures. |

## Returns

| Type | Description |
| --- | --- |
| `ProblemDetails` | A problem details payload containing the resolved title and HTTP status value. |

## Example

No concise standalone example is available yet.

