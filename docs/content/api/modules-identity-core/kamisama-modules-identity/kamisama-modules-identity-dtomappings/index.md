# DtoMappings

<a id="dtomappings"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/DtoMappings.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/DtoMappings.cs#L8)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

Maps Identity users and roles to abstraction DTOs. User mapping requires roles to be loaded separately and calculates enabled state from lockout fields.

## Declaration

```csharp
public static partial class DtoMappings
```

## Example

```csharp
UserDto userDto = user.ToDto([KnownRoles.User]);
RoleDto roleDto = role.ToDto();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ToDto](method-todto-15.md) | Maps a user and caller-supplied role names to a `UserDto`. Use it with the surrounding package APIs when composing application code. |
| [ToDto](method-todto-21.md) | Maps an Identity role to a `RoleDto`. Use it with the surrounding package APIs when composing application code. |

