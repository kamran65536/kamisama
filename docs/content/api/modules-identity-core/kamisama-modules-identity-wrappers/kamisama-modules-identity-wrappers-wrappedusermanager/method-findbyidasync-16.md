# FindByIdAsync

[Back to WrappedUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs#L16)

Type: `KamiSama.Modules.Identity.Wrappers.WrappedUserManager`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<ApplicationUser?> FindByIdAsync(string id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `string` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | Returns a `Task<ApplicationUser?>` value. |

## Example

No concise standalone example is available yet.

