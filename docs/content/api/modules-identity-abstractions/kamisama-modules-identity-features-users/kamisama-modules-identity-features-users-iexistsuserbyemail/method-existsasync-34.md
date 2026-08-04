# ExistsAsync

[Back to IExistsUserByEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L34)

Type: `KamiSama.Modules.Identity.Features.Users.IExistsUserByEmail`

Kind: `Method`

## Description

Runs the `ExistsAsync` operation on `IExistsUserByEmail`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
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

