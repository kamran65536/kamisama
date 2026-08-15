# ToDto

[Back to DtoMappings](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/DtoMappings.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/DtoMappings.cs#L15)

Type: `KamiSama.Modules.Identity.DtoMappings`

Kind: `Method`

## Description

Maps a user and caller-supplied role names to a `UserDto`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static UserDto ToDto(this ApplicationUser user, string[] roles);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user (extension receiver)` | `ApplicationUser` | `-` | The Identity user to map. |
| `roles` | `string[]` | `-` | The role names already loaded for the user. |

## Returns

| Type | Description |
| --- | --- |
| `UserDto` | A user DTO whose enabled flag follows the module&apos;s lockout calculation. |

## Example

```csharp
UserDto dto = user.ToDto([KnownRoles.User]);
```

