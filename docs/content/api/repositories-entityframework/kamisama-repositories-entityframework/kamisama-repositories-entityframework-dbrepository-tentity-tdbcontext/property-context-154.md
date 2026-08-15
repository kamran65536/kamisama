# Context

[Back to DbRepository<TEntity, TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:154](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L154)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>`

Kind: `Property`

## Description

Gets the borrowed context as &lt;typeparamref name=&quot;TDbContext&quot;/&gt; for derived repositories. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected new TDbContext Context => (TDbContext)base.Context;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | The context supplied to the constructor. |

## Example

No concise standalone example is available yet.

