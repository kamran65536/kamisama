# ResetAccessFailedCountAsync

[Back to WrappedUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs:80](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs#L80)

Type: `KamiSama.Modules.Identity.Wrappers.WrappedUserManager`

Kind: `Method`

## Description

Runs the `ResetAccessFailedCountAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IdentityResult>` | Returns a `Task<IdentityResult>` value. |

## Example

No concise standalone example is available yet.

