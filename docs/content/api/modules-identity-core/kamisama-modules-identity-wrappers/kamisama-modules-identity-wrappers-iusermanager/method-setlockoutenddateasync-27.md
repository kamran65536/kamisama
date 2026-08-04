# SetLockoutEndDateAsync

[Back to IUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L27)

Type: `KamiSama.Modules.Identity.Wrappers.IUserManager`

Kind: `Method`

## Description

Runs the `SetLockoutEndDateAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `lockoutEnd` | `DateTimeOffset?` | `-` | The `lockoutEnd` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IdentityResult>` | Returns a `Task<IdentityResult>` value. |

## Example

No concise standalone example is available yet.

