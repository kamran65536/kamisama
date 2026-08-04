# ToDto

[Back to DtoMappings](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/DtoMappings.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/DtoMappings.cs#L9)

Type: `KamiSama.Modules.Identity.DtoMappings`

Kind: `Method`

## Description

Runs the `ToDto` operation on `DtoMappings`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static UserDto ToDto(this ApplicationUser user, string[] roles);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user (extension receiver)` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `roles` | `string[]` | `-` | The `roles` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `UserDto` | Returns a `UserDto` value. |

## Example

No concise standalone example is available yet.

