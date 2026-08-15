# AddRequestLocalization

[Back to RequestLocalizationExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RequestLocalizationModule.cs:46](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RequestLocalizationModule.cs#L46)

Type: `KamiSama.Modules.RequestLocalizationExtension`

Kind: `Method`

## Description

Queues request-localization services and middleware using an options callback. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, Action<RequestLocalizationOptions> configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<RequestLocalizationOptions>` | `-` | The required request-localization options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
using System.Globalization;
using Microsoft.AspNetCore.Localization;

ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddRequestLocalization(new RequestCulture("en-US"), new CultureInfo("en-US"));
```

