# IUpdateRole

<a id="iupdaterole"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L8)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Updates the role identified by a `Guid`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IUpdateRole : IUpdateFeature<UpdateRoleRequest, Guid>;
```

## Example

```csharp
await updateRole.UpdateAsync(roleId, new UpdateRoleRequest("Reviewer"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

