# LocationsDbContext

<a id="locationsdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L9)

Namespace: `KamiSama.Modules.Locations.Repositories.Database`

Kind: `Class`

## Description

Provider-neutral EF Core context consumed by Locations repositories. It exposes tracked province and city sets and configures restricted city-to-province deletion; a concrete provider context must be registered for runtime resolution.

## Declaration

```csharp
public abstract class LocationsDbContext : DbContext
```

## Remarks

Install and register a concrete Locations provider context; application services consume this abstract context through keyed multi-provider resolution.

## Example

```csharp
using IServiceScope scope = app.Services.CreateScope();
LocationsDbContext context = scope.ServiceProvider.GetRequiredService<LocationsDbContext>();
List<Province> provinces = await context.Provinces.AsNoTracking().ToListAsync(cancellationToken);
```

## Constructors

### LocationsDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L22)

Initializes a provider-specific derived context with non-generic EF Core options. Use it with the surrounding package APIs when composing application code.

```csharp
protected LocationsDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The options configured by the concrete provider registration. |

### LocationsDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L29)

Initializes the base Locations context with options typed for direct base-context construction. Use it with the surrounding package APIs when composing application code.

```csharp
public LocationsDbContext(DbContextOptions<LocationsDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<LocationsDbContext>` | `-` | The EF Core options for this base context. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [OnModelCreating](method-onmodelcreating-37.md) | Applies the base model and configures each city to have one province, each province to have many cities, and province deletion as restricted rather than cascading. |

### Properties

| Member | Description |
| --- | --- |
| [Cities](property-cities-16.md) | Gets or sets the tracked city entity set used by Core repositories. |
| [Provinces](property-provinces-13.md) | Gets or sets the tracked province entity set used by Core repositories. |

