# IExistsRoleByName

<a id="iexistsrolebyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Features.cs#L18)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Interface`

## Description

Checks whether a role exists for a name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IExistsRoleByName : IExistsByNameFeature;
```

## Example

```csharp
bool exists = await existsRoleByName.ExistsByNameAsync("Operator", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

