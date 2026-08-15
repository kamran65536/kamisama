# ApplyConfigurationToAsync

[Back to KamiSamaIdentityWebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:111](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L111)

Type: `KamiSama.Modules.Identity.KamiSamaIdentityWebModule`

Kind: `Method`

## Description

Creates a startup scope and runs migration and seed stages selected by the named initialization options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built web application. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation of startup initialization. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes when startup database initialization finishes. |

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new KamiSamaIdentityWebModule(
    webBuilder.Configuration.GetSection("Identity"),
    webBuilder.Configuration.GetSection("Identity:Database"),
    registerIdentity: true,
    useJwtAuth: true,
    configureDbContext: database => database.AddPostgresqlIdentityDbContext()));
```

