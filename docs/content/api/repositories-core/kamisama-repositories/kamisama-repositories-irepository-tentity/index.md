# IRepository<TEntity>

<a id="irepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L10)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Repository implementation or contract for `IRepository<TEntity>`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
public interface IRepository<TEntity> : IDisposable
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-16.md) | Adds a new item in the repository. Use it with the surrounding package APIs when composing application code. |
| [Delete](method-delete-26.md) | Deletes an item from repository. Use it with the surrounding package APIs when composing application code. |
| [Find](method-find-32.md) | Finds an single item in the repository. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-21.md) | Update method, does nothing. Use it with the surrounding package APIs when composing application code. |

