# ConvertExceptionToProblemDetails

[Back to IProblemDetailsDataProvider](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L25)

Type: `KamiSama.Chassis.ProblemDetails.IProblemDetailsDataProvider`

Kind: `Method`

## Description

Converts an exception into the problem details payload returned to the client. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
ProblemDetails ConvertExceptionToProblemDetails(Exception exception);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `exception` | `Exception` | `-` | The exception raised while MVC processes the request. |

## Returns

| Type | Description |
| --- | --- |
| `ProblemDetails` | A problem details instance describing the failure. |

## Example

No concise standalone example is available yet.

