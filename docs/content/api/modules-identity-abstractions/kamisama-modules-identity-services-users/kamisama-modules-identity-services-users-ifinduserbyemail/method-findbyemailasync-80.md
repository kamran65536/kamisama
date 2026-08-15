# FindByEmailAsync

[Back to IFindUserByEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:80](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L80)

Type: `KamiSama.Modules.Identity.Services.Users.IFindUserByEmail`

Kind: `Method`

## Description

Returns the user with the supplied email address. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<UserDto> FindByEmailAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The email address to look up. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | The matching user. |

## Example

```csharp
UserDto user = await findUserByEmail.FindByEmailAsync("ada@example.com", cancellationToken);
```

