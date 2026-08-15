# IFindRoleById

<a id="ifindrolebyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L12)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Finds a role by its `Guid` identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindRoleById : IFindByIdFeature<RoleDto, Guid>;
```

## Example

```csharp
RoleDto role = await findRoleById.FindByIdAsync(roleId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

