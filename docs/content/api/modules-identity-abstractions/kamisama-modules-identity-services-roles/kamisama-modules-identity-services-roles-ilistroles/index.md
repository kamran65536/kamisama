# IListRoles

<a id="ilistroles"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L4)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Lists roles through the standard paged feature contract. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListRoles : IListFeature<RoleDto, RoleSearchModel>;
```

## Example

```csharp
PagedResult<RoleDto> roles = await listRoles.ListAsync(RoleSearchModel.All, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

