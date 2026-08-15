# OnModelCreating

[Back to LocationsDbContext](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Database/LocationsDbContext.cs#L37)

Type: `KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext`

Kind: `Method`

## Description

Applies the base model and configures each city to have one province, each province to have many cities, and province deletion as restricted rather than cascading.

## Declaration

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `modelBuilder` | `ModelBuilder` | `-` | The builder for the Locations EF Core model. |

## Example

No concise standalone example is available yet.

