# KamiSamaIdentityDbContext

<a id="kamisamaidentitydbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L5)

Namespace: `KamiSama.Modules.Identity.Repositories.Database`

Kind: `Class`

## Description

Provides the `KamiSamaIdentityDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class KamiSamaIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
```

## Constructors

### KamiSamaIdentityDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L9)

Initializes a new `KamiSamaIdentityDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected KamiSamaIdentityDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The `options` value passed to this member. |

### KamiSamaIdentityDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L12)

Initializes a new `KamiSamaIdentityDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public KamiSamaIdentityDbContext(DbContextOptions<KamiSamaIdentityDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<KamiSamaIdentityDbContext>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnModelCreating](method-onmodelcreating-16.md) | Runs the `OnModelCreating` operation on `KamiSamaIdentityDbContext`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [ApplicationSessions](property-applicationsessions-7.md) | Exposes the `ApplicationSessions` value on `KamiSamaIdentityDbContext`. Read or set it as part of configuring or using the type. |

