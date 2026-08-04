# ProblemDetailsExceptionFilter

<a id="problemdetailsexceptionfilter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L11)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Filter for mapping exceptions to problem details. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L11)

Filter for mapping exceptions to problem details. Use it with the surrounding package APIs when composing application code.

```csharp
public class ProblemDetailsExceptionFilter(IProblemDetailsDataProvider problemDetailsDataProvider) : IExceptionFilter
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `problemDetailsDataProvider` | `IProblemDetailsDataProvider` | `-` | The `problemDetailsDataProvider` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnException](method-onexception-17.md) | Runs the `OnException` operation on `ProblemDetailsExceptionFilter`. Use it when your code needs this specific behavior from the package. |

