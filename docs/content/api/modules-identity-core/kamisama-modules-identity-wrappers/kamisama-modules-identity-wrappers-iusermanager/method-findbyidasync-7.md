# FindByIdAsync

[Back to IUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L7)

Type: `KamiSama.Modules.Identity.Wrappers.IUserManager`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `string` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | Returns a `Task<ApplicationUser?>` value. |

## Example

No concise standalone example is available yet.

