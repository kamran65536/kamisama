# ConfigureRequestLocalization

[Back to RequestLocalizationModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RequestLocalizationModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RequestLocalizationModule.cs#L32)

Type: `KamiSama.Modules.RequestLocalizationModule`

Kind: `Method`

## Description

Invokes the required constructor callback for request-localization options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureRequestLocalization(RequestLocalizationOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `RequestLocalizationOptions` | `-` | The request-localization options configured before build. |

## Example

No concise standalone example is available yet.

