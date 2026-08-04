# IApplicationUserRepository

<a id="iapplicationuserrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs#L5)

Namespace: `KamiSama.Modules.Identity.Repositories.Abstractions`

Kind: `Interface`

## Description

Repository implementation or contract for `IApplicationUserRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, UserSearchModel>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByEmailAsync](method-findbyemailasync-8.md) | Runs the `FindByEmailAsync` operation on `IApplicationUserRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-7.md) | Runs the `FindByIdAsync` operation on `IApplicationUserRepository`. Use it when your code needs this specific behavior from the package. |

