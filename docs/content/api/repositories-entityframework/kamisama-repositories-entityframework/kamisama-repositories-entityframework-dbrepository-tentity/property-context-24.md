# Context

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L24)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

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

