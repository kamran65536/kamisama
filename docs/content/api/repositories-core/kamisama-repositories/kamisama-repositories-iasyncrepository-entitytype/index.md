# IAsyncRepository<_EntityType>

<a id="iasyncrepository-entitytype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L7)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

IAsyncRepository is the same as IRepository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IAsyncRepository<_EntityType> : IRepository<_EntityType>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-15.md) | Adds an item into the repository. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-29.md) | Deletes an item from repository. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-36.md) | Finds an item in the repository. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-22.md) | Updates an item in the repository. Use it with the surrounding package APIs when composing application code. |

