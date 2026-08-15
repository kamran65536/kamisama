# OnException

[Back to ProblemDetailsExceptionFilter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L19)

Type: `KamiSama.Chassis.ProblemDetails.ProblemDetailsExceptionFilter`

Kind: `Method`

## Description

Converts the current exception, assigns the result, and marks the exception as handled. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void OnException(ExceptionContext context);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `ExceptionContext` | `-` | The MVC exception context to update. |

## Example

No concise standalone example is available yet.

