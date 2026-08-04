# ExistsByNameAsync

[Back to ExistsUserByName](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ExistsUserByName.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ExistsUserByName.cs#L6)

Type: `KamiSama.Modules.Identity.Features.Users.ExistsUserByName`

Kind: `Method`

## Description

Runs the `ExistsByNameAsync` operation on `ExistsUserByName`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<bool> ExistsByNameAsync(string username, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `username` | `string` | `-` | The `username` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

