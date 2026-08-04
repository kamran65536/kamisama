# GetAsync

[Back to GetAuthenticatorSecret](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/GetAuthenticatorSecret.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/GetAuthenticatorSecret.cs#L6)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.GetAuthenticatorSecret`

Kind: `Method`

## Description

Runs the `GetAsync` operation on `GetAuthenticatorSecret`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<string> GetAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<string>` | Returns a `Task<string>` value. |

## Example

No concise standalone example is available yet.

