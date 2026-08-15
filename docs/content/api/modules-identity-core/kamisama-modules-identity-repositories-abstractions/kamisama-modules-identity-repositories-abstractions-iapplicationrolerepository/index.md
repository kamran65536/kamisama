# IApplicationRoleRepository

<a id="iapplicationrolerepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L10)

Namespace: `KamiSama.Modules.Identity.Repositories.Abstractions`

Kind: `Interface`

## Description

Combines Core role mutation, paging, and identifier/name lookup contracts. Concrete repository behavior determines normalization and save boundaries.

## Declaration

```csharp
public interface IApplicationRoleRepository :
	IGenericRepository<ApplicationRole, RoleSearchModel>,
	ILookupByIdRepository<ApplicationRole, Guid>,
	ILookupByNameRepository<ApplicationRole>
```

## Example

```csharp
ApplicationRole? role = await repository.FindByNameAsync("Operator", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

