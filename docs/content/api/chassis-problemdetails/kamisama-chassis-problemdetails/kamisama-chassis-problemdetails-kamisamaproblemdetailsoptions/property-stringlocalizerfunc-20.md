# StringLocalizerFunc

[Back to KamiSamaProblemDetailsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L20)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions`

Kind: `Property`

## Description

Gets or sets the factory that resolves the optional string localizer. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public Func<IServiceProvider, IStringLocalizer?>? StringLocalizerFunc { get; set; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `Func<IServiceProvider, IStringLocalizer?>?` value. |

## Example

No concise standalone example is available yet.

