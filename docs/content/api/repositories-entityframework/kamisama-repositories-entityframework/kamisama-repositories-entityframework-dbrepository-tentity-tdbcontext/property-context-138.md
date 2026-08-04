# Context

[Back to DbRepository<TEntity, TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:138](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L138)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>`

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

