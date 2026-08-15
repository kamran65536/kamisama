# KamiSamaIdentityDbContext

<a id="kamisamaidentitydbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L9)

Namespace: `KamiSama.Modules.Identity.Repositories.Database`

Kind: `Class`

## Description

Identity EF Core context for users, roles, claims, tokens, and revocable sessions. Core can migrate it during the extended builder's post-build startup phase.

## Declaration

```csharp
public class KamiSamaIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
```

## Example

```csharp
services.AddMultiProviderDbContext<KamiSamaIdentityDbContext>(configuration.GetSection("Identity:Database"))
    .AddPostgresqlIdentityDbContext();
```

## Constructors

### KamiSamaIdentityDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L16)

Initializes a context for a derived provider-specific context. Use it with the surrounding package APIs when composing application code.

```csharp
protected KamiSamaIdentityDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The non-generic options supplied by the concrete provider context. |

### KamiSamaIdentityDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L21)

Initializes the directly configured base context. Use it with the surrounding package APIs when composing application code.

```csharp
public KamiSamaIdentityDbContext(DbContextOptions<KamiSamaIdentityDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<KamiSamaIdentityDbContext>` | `-` | The options for this context type. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnModelCreating](method-onmodelcreating-27.md) | Configures the unique session-key index, user relationship, cascade deletion, and assembly configurations. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [ApplicationSessions](property-applicationsessions-12.md) | Gets or sets the session entity set. Use it with the surrounding package APIs when composing application code. |

