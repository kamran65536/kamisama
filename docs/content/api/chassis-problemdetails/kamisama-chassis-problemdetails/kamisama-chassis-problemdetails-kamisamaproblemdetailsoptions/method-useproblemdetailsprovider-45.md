# UseProblemDetailsProvider

[Back to KamiSamaProblemDetailsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L45)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions`

Kind: `Method`

## Description

Selects a custom provider factory for exception conversion. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public KamiSamaProblemDetailsOptions UseProblemDetailsProvider(Func<IServiceProvider, IProblemDetailsDataProvider> providerFunc);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `providerFunc` | `Func<IServiceProvider, IProblemDetailsDataProvider>` | `-` | The factory invoked by dependency injection to create a scoped provider. |

## Returns

| Type | Description |
| --- | --- |
| `KamiSamaProblemDetailsOptions` | This options instance for fluent configuration. |

## Remarks

Custom providers receive no automatic localization configuration; the factory must initialize any required provider properties.

## Example

No concise standalone example is available yet.

