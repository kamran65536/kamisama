# AddNeoZarinSmsModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs#L41)

Type: `KamiSama.ExternalServices.Sms.NeoZarin.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Adds the NeoZarin SMS module; register `HttpClient` and KamiSama RestSharp first, then call `Build` or `BuildAsync` so this module registers its services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddNeoZarinSmsModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection neoZarinSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder receiving the module. |
| `neoZarinSection` | `IConfigurationSection` | `-` | The configuration section containing NeoZarin endpoint, credential, sender, and API settings. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder so core SMS and application modules can be chained. |

## Example

No concise standalone example is available yet.

