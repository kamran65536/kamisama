# ConfigureServices

[Back to ControllersModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ControllersModule.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L12)

Type: `KamiSama.Modules.ControllersModule`

Kind: `Method`

## Description

Calls `AddControllers` and passes the resulting builder to `ConfigureMvcBuilder`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void ConfigureServices(IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The service collection configured before build. |

## Example

No concise standalone example is available yet.

