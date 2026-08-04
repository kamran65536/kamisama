# UseProblemDetailsProvider

[Back to KamiSamaProblemDetailsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L44)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions`

Kind: `Method`

## Description

Uses customer provider as Problem Details Provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public KamiSamaProblemDetailsOptions UseProblemDetailsProvider(Func<IServiceProvider, IProblemDetailsDataProvider> providerFunc);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `providerFunc` | `Func<IServiceProvider, IProblemDetailsDataProvider>` | `-` | The `providerFunc` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `KamiSamaProblemDetailsOptions` | Returns a `KamiSamaProblemDetailsOptions` value. |

## Example

No concise standalone example is available yet.

