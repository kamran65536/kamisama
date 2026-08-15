# ProblemDetailsDataProviderFunc

[Back to KamiSamaProblemDetailsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L16)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions`

Kind: `Property`

## Description

Gets or sets the dependency-injection factory that creates the scoped conversion provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public Func<IServiceProvider, IProblemDetailsDataProvider>? ProblemDetailsDataProviderFunc { get; set; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `Func<IServiceProvider, IProblemDetailsDataProvider>?` value. |

## Example

No concise standalone example is available yet.

