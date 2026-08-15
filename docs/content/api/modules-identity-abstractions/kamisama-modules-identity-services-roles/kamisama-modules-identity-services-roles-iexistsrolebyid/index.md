# IExistsRoleById

<a id="iexistsrolebyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L16)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Checks whether a role exists for a `Guid` identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IExistsRoleById : IExistsByIdFeature<Guid>;
```

## Example

```csharp
bool exists = await existsRoleById.ExistsByIdAsync(roleId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

