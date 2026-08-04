# ConvertToDto

[Back to ListUsers](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs#L32)

Type: `KamiSama.Modules.Identity.Features.Users.ListUsers`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `ListUsers`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<UserDto> ConvertToDto(ApplicationUser entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `ApplicationUser` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

