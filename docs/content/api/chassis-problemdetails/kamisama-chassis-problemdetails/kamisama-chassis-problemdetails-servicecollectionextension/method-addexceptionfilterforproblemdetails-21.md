# AddExceptionFilterForProblemDetails

[Back to ServiceCollectionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/ServiceCollectionExtension.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ServiceCollectionExtension.cs#L21)

Type: `KamiSama.Chassis.ProblemDetails.ServiceCollectionExtension`

Kind: `Method`

## Description

Adds the scoped conversion services and configures MVC to resolve the exception filter globally. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMvcBuilder AddExceptionFilterForProblemDetails(this IMvcBuilder builder, Action<KamiSamaProblemDetailsOptions>? config = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMvcBuilder` | `-` | The MVC builder whose services and filter collection are configured. |
| `config` | `Action<KamiSamaProblemDetailsOptions>?` | `null` | An optional callback that replaces the provider or changes localization settings. |

## Returns

| Type | Description |
| --- | --- |
| `IMvcBuilder` | The MVC builder so registration can continue fluently. |

## Remarks

The default setup uses the package resources and handles all exceptions, including exceptions that are not `HttpExceptionBase` instances.

## Example

No concise standalone example is available yet.

