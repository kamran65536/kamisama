# LocationsDbContext

<a id="locationsdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L5)

Namespace: `KamiSama.Modules.Locations.Repositories.Database`

Kind: `Class`

## Description

Provides the `LocationsDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public abstract class LocationsDbContext : DbContext
```

## Constructors

### LocationsDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L10)

Initializes a new `LocationsDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected LocationsDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The `options` value passed to this member. |

### LocationsDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L13)

Initializes a new `LocationsDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public LocationsDbContext(DbContextOptions<LocationsDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<LocationsDbContext>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnModelCreating](method-onmodelcreating-17.md) | Runs the `OnModelCreating` operation on `LocationsDbContext`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [Cities](property-cities-8.md) | Exposes the `Cities` value on `LocationsDbContext`. Read or set it as part of configuring or using the type. |
| [Provinces](property-provinces-7.md) | Exposes the `Provinces` value on `LocationsDbContext`. Read or set it as part of configuring or using the type. |

