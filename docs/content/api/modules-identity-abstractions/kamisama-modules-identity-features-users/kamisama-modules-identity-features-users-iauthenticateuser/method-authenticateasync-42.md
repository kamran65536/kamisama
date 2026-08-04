# AuthenticateAsync

[Back to IAuthenticateUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L42)

Type: `KamiSama.Modules.Identity.Features.Users.IAuthenticateUser`

Kind: `Method`

## Description

Runs the `AuthenticateAsync` operation on `IAuthenticateUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<UserDto> AuthenticateAsync(AuthenticateUserRequest request, CancellationToken cancellationToken);
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

