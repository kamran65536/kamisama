# OnModelCreating

[Back to KamiSamaIdentityDbContext](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Database/KamiSamaIdentityDbContext.cs#L27)

Type: `KamiSama.Modules.Identity.Repositories.Database.KamiSamaIdentityDbContext`

Kind: `Method`

## Description

Configures the unique session-key index, user relationship, cascade deletion, and assembly configurations. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `modelBuilder` | `ModelBuilder` | `-` | The model builder supplied by Entity Framework Core. |

## Example

No concise standalone example is available yet.

