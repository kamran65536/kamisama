# IApplicationUserRepository

<a id="iapplicationuserrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs#L9)

Namespace: `KamiSama.Modules.Identity.Repositories.Abstractions`

Kind: `Interface`

## Description

Defines Core user persistence, paging, and lookup. The current implementation saves immediately and does not honor every `UserSearchModel` field.

## Declaration

```csharp
public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, UserSearchModel>
```

## Example

```csharp
ApplicationUser? user = await repository.FindByIdAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByEmailAsync](method-findbyemailasync-20.md) | Finds a user by email through the configured Identity user manager. Use it with the surrounding package APIs when composing application code. |
| [FindByIdAsync](method-findbyidasync-15.md) | Finds a user by identifier. Use it with the surrounding package APIs when composing application code. |

