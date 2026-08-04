# VerifyUserTokenAsync

[Back to WrappedUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs:87](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs#L87)

Type: `KamiSama.Modules.Identity.Wrappers.WrappedUserManager`

Kind: `Method`

## Description

Runs the `VerifyUserTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `tokenProvider` | `string` | `-` | The `tokenProvider` value passed to this member. |
| `purpose` | `string` | `-` | The `purpose` value passed to this member. |
| `token` | `string` | `-` | The `token` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

