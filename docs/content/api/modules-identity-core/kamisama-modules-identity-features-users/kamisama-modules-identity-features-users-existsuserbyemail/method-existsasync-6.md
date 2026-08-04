# ExistsAsync

[Back to ExistsUserByEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ExistsUserByEmail.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ExistsUserByEmail.cs#L6)

Type: `KamiSama.Modules.Identity.Features.Users.ExistsUserByEmail`

Kind: `Method`

## Description

Runs the `ExistsAsync` operation on `ExistsUserByEmail`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The `email` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

