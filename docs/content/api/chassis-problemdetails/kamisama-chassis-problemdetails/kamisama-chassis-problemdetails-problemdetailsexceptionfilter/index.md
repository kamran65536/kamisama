# ProblemDetailsExceptionFilter

<a id="problemdetailsexceptionfilter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L12)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Handles MVC exceptions by converting them to problem details through the configured provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
```

## Remarks

The filter marks every exception as handled. The current implementation assigns an `ObjectResult` but does not explicitly copy the problem details status to `ObjectResult.StatusCode`.

## Example

```csharp
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options.UseDefaultProblemDetailsProvider());
// MVC resolves and invokes ProblemDetailsExceptionFilter globally.
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L12)

Handles MVC exceptions by converting them to problem details through the configured provider. Use it with the surrounding package APIs when composing application code.

```csharp
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `problemDetailsDataProvider` | `IProblemDetailsDataProvider` | `-` | The scoped provider used to build response payloads. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnException](method-onexception-19.md) | Converts the current exception, assigns the result, and marks the exception as handled. Use it with the surrounding package APIs when composing application code. |

