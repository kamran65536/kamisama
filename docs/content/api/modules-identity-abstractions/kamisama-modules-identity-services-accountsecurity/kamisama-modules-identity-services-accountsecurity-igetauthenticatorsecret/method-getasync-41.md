# GetAsync

[Back to IGetAuthenticatorSecret](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L41)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.IGetAuthenticatorSecret`

Kind: `Method`

## Description

Returns the user&apos;s authenticator secret. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<string> GetAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The target user identifier. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<string>` | The authenticator secret. |

## Example

```csharp
string secret = await getAuthenticatorSecret.GetAsync(userId, cancellationToken);
```

