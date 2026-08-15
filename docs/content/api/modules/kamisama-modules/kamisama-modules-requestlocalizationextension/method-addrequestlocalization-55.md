# AddRequestLocalization

[Back to RequestLocalizationExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RequestLocalizationModule.cs:55](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RequestLocalizationModule.cs#L55)

Type: `KamiSama.Modules.RequestLocalizationExtension`

Kind: `Method`

## Description

Queues request localization with one default request culture and the same supported culture array for formatting and UI resources. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, RequestCulture defaultCulture, params CultureInfo[] supportedCultures);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `defaultCulture` | `RequestCulture` | `-` | The default formatting and UI culture. |
| `supportedCultures` | `CultureInfo[]` | `-` | The supported formatting and UI cultures; the array is assigned directly to both options. |

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

