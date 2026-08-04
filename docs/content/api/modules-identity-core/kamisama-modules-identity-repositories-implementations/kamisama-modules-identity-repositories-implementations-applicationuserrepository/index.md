# ApplicationUserRepository

<a id="applicationuserrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs#L8)

Namespace: `KamiSama.Modules.Identity.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `ApplicationUserRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class ApplicationUserRepository(IUserManager userManager, KamiSamaIdentityDbContext context) :
	GenericRepository<ApplicationUser, UserSearchModel, KamiSamaIdentityDbContext>(context),
	IApplicationUserRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationUserRepository(IUserManager userManager, KamiSamaIdentityDbContext context) :
	GenericRepository<ApplicationUser, UserSearchModel, KamiSamaIdentityDbContext>(context),
	IApplicationUserRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |
| `context` | `KamiSamaIdentityDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-13.md) | Runs the `ApplySearchModel` operation on `ApplicationUserRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByEmailAsync](method-findbyemailasync-36.md) | Runs the `FindByEmailAsync` operation on `ApplicationUserRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-33.md) | Runs the `FindByIdAsync` operation on `ApplicationUserRepository`. Use it when your code needs this specific behavior from the package. |

