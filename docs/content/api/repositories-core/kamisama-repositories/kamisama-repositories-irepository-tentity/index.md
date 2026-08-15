# IRepository<TEntity>

<a id="irepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L10)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Defines synchronous add, update, delete, and first-match lookup operations. Implementations determine persistence, transaction, duplicate, and missing-entity behavior.

## Declaration

```csharp
public interface IRepository<TEntity> : IDisposable
```

## Example

```csharp
using KamiSama.Repositories;

public sealed class UserService(IRepository<User> users)
{
    public User? FindByEmail(string email) => users.Find(user => user.Email == email);
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-16.md) | Adds an entity according to the implementation's persistence and duplicate rules. |
| [Delete](method-delete-26.md) | Deletes an entity according to the implementation's matching and persistence rules. |
| [Find](method-find-32.md) | Returns the first entity matching the predicate, or `null` when none matches. |
| [Update](method-update-21.md) | Updates an entity according to the implementation's matching and persistence rules; the contract does not require replacement or merging. |

