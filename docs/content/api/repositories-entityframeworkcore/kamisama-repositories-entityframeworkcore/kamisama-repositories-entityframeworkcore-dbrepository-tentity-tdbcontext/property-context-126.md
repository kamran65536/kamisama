# Context

[Back to DbRepository<TEntity, TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:126](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L126)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>`

Kind: `Property`

## Description

Exposes the `Context` value on `DbRepository<TEntity, TDbContext>`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
protected new TDbContext Context => (TDbContext)base.Context;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `TDbContext` value. |

## Example

No concise standalone example is available yet.

