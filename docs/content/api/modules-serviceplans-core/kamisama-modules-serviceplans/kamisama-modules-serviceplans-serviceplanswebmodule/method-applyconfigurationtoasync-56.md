# ApplyConfigurationToAsync

[Back to ServicePlansWebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs:56](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L56)

Type: `KamiSama.Modules.ServicePlans.ServicePlansWebModule`

Kind: `Method`

## Description

Resolves a custom or migration-only database initializer and executes the enabled initialization stages after build. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application whose scoped services are used for initialization. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel initialization. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the configured database initialization. |

## Example

No concise standalone example is available yet.

