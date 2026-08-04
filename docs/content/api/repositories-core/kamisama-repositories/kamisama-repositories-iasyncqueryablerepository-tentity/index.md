# IAsyncQueryableRepository<TEntity>

<a id="iasyncqueryablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IAsyncQueryableRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncQueryableRepository.cs#L9)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

IAsyncQueryable Repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository<TEntity>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Where](method-where-16.md) | the same as Where, just to indicate async behavior. Use it with the surrounding package APIs when composing application code. |

