# ExistsAsync

[Back to IExistsUserByEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:71](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L71)

Type: `KamiSama.Modules.Identity.Services.Users.IExistsUserByEmail`

Kind: `Method`

## Description

Returns whether a user has the supplied email address. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The email address to look up. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when a matching user exists; otherwise . |

## Example

```csharp
bool exists = await existsUserByEmail.ExistsAsync("ada@example.com", cancellationToken);
```

