# Context

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L28)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Property`

## Description

Gets the borrowed context used for queries and persistence. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected DbContext Context { get; } = context;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | The context supplied to the constructor. |

## Example

No concise standalone example is available yet.

