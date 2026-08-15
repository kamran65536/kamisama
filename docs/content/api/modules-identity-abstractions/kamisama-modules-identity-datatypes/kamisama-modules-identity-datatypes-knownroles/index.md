# KnownRoles

<a id="knownroles"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/DataTypes/KnownRoles.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/DataTypes/KnownRoles.cs#L8)

Namespace: `KamiSama.Modules.Identity.DataTypes`

Kind: `Class`

## Description

Defines the canonical `SuperAdmin`, `Operator`, and `User` role-name strings. These constants neither seed roles nor grant authorization.

## Declaration

```csharp
public static class KnownRoles
```

## Example

```csharp
using KamiSama.Modules.Identity.DataTypes;

services.AddAuthorization(options =>
    options.AddPolicy("Operators", policy => policy.RequireRole(KnownRoles.SuperAdmin, KnownRoles.Operator)));
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Fields

| Member | Description |
| --- | --- |
| [Operator](field-operator-12.md) | Identifies an operational staff role with application-defined permissions. Use it with the surrounding package APIs when composing application code. |
| [SuperAdmin](field-superadmin-10.md) | Identifies the unrestricted administrative role. Use it with the surrounding package APIs when composing application code. |
| [User](field-user-14.md) | Identifies the standard application-user role. Use it with the surrounding package APIs when composing application code. |

