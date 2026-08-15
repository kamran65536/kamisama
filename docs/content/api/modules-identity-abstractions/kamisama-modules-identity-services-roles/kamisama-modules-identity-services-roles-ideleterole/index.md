# IDeleteRole

<a id="ideleterole"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L10)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Deletes the role identified by a `Guid`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDeleteRole : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteRole.DeleteAsync(roleId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

