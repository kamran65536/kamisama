# ApplicationRoleRepository

<a id="applicationrolerepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationRoleRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationRoleRepository.cs#L7)

Namespace: `KamiSama.Modules.Identity.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `ApplicationRoleRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class ApplicationRoleRepository(KamiSamaIdentityDbContext context) : DbRepository<ApplicationRole, KamiSamaIdentityDbContext>(context), IApplicationRoleRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationRoleRepository.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationRoleRepository(KamiSamaIdentityDbContext context) : DbRepository<ApplicationRole, KamiSamaIdentityDbContext>(context), IApplicationRoleRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `KamiSamaIdentityDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByIdAsync](method-findbyidasync-10.md) | Runs the `FindByIdAsync` operation on `ApplicationRoleRepository`. Use it when your code needs this specific behavior from the package. |
| [ListAsync](method-listasync-13.md) | Runs the `ListAsync` operation on `ApplicationRoleRepository`. Use it when your code needs this specific behavior from the package. |

