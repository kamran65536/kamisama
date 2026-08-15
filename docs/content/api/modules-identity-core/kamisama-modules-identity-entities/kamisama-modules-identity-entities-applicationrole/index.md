# ApplicationRole

<a id="applicationrole"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L4)

Namespace: `KamiSama.Modules.Identity.Entities`

Kind: `Class`

## Description

ASP.NET Core Identity role with a `Guid` key. Use it with the Core Identity store and role feature implementations.

## Declaration

```csharp
public class ApplicationRole : IdentityRole<Guid>
```

## Example

```csharp
var role = new ApplicationRole(KnownRoles.Operator)
{
    Id = Guid.NewGuid()
};
```

## Constructors

### ApplicationRole

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L7)

Initializes an empty role for Identity and Entity Framework Core materialization. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationRole();
```

## Parameters

This member does not declare parameters.

### ApplicationRole

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L10)

Initializes a role with the supplied name. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationRole(string roleName) : base(roleName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `roleName` | `string` | `-` | The initial role name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

