# IAsyncRepository<_EntityType>

<a id="iasyncrepository-entitytype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L7)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Adds asynchronous mutation and lookup methods to `IRepository<TEntity>`. Implementations determine whether work is truly asynchronous and how cancellation, failures, and persistence are handled.

## Declaration

```csharp
public interface IAsyncRepository<_EntityType> : IRepository<_EntityType>
```

## Example

```csharp
using KamiSama.Repositories;

public sealed class UserService(IAsyncRepository<User> users)
{
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => users.FindAsync(user => user.Email == email, cancellationToken);
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-15.md) | Asynchronously adds an entity according to the implementation's persistence, duplicate, cancellation, and failure rules. |
| [DeleteAsync](method-deleteasync-29.md) | Asynchronously deletes an entity according to the implementation's matching, persistence, cancellation, and failure rules. |
| [FindAsync](method-findasync-36.md) | Asynchronously returns the first entity matching the predicate, or `null` when none matches. |
| [UpdateAsync](method-updateasync-22.md) | Asynchronously updates an entity according to the implementation's matching, persistence, cancellation, and failure rules. |

