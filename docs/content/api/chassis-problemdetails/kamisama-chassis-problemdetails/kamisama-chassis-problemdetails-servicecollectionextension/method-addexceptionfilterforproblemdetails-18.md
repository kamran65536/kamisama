# AddExceptionFilterForProblemDetails

[Back to ServiceCollectionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/ServiceCollectionExtension.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ServiceCollectionExtension.cs#L18)

Type: `KamiSama.Chassis.ProblemDetails.ServiceCollectionExtension`

Kind: `Method`

## Description

Adds Exception Filter for problem details. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMvcBuilder AddExceptionFilterForProblemDetails(this IMvcBuilder builder, Action<KamiSamaProblemDetailsOptions>? config = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMvcBuilder` | `-` | The `builder` value passed to this member. |
| `config` | `Action<KamiSamaProblemDetailsOptions>?` | `null` | The `config` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IMvcBuilder` | Returns a `IMvcBuilder` value. |

## Example

No concise standalone example is available yet.

