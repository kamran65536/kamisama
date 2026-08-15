# ConfigureServices

[Back to LocalizationModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L23)

Type: `KamiSama.Modules.Localization.LocalizationModule`

Kind: `Method`

## Description

Scans this assembly for attributed feature services, binds `LocalizationOptions`, supplies a fallback array only when configuration produces , and registers localization resources. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void ConfigureServices(IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The service collection configured before the application is built. |

## Example

No concise standalone example is available yet.

