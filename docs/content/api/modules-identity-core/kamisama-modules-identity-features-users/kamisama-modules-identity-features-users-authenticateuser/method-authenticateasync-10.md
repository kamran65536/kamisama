# AuthenticateAsync

[Back to AuthenticateUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/AuthenticateUser.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AuthenticateUser.cs#L10)

Type: `KamiSama.Modules.Identity.Features.Users.AuthenticateUser`

Kind: `Method`

## Description

Runs the `AuthenticateAsync` operation on `AuthenticateUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<UserDto> AuthenticateAsync(AuthenticateUserRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AuthenticateUserRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

