# ToDto

[Back to DtoMappings](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/DtoMappings.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/DtoMappings.cs#L21)

Type: `KamiSama.Modules.Identity.DtoMappings`

Kind: `Method`

## Description

Maps an Identity role to a `RoleDto`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static RoleDto ToDto(this ApplicationRole role);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `role (extension receiver)` | `ApplicationRole` | `-` | The Identity role to map. |

## Returns

| Type | Description |
| --- | --- |
| `RoleDto` | The role DTO. |

## Example

```csharp
RoleDto dto = role.ToDto();
```

