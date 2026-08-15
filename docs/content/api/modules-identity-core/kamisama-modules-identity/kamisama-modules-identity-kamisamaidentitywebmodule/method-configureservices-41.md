# ConfigureServices

[Back to KamiSamaIdentityWebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L41)

Type: `KamiSama.Modules.Identity.KamiSamaIdentityWebModule`

Kind: `Method`

## Description

Registers named database and initialization options, Identity when selected, authentication, scanned features, and the base multi-provider DbContext. The provider callback must call an installed provider extension or context resolution will fail later.

## Declaration

```csharp
public override void ConfigureServices(IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The application service collection. |

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new KamiSamaIdentityWebModule(
    webBuilder.Configuration.GetSection("Identity"),
    webBuilder.Configuration.GetSection("Identity:Database"),
    registerIdentity: true,
    useJwtAuth: true,
    configureDbContext: database => database.AddPostgresqlIdentityDbContext()));
```

