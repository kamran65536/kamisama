# ValidateAsync

[Back to ValidateAuthenticatorCode](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ValidateAuthenticatorCode.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ValidateAuthenticatorCode.cs#L6)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ValidateAuthenticatorCode`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `ValidateAuthenticatorCode`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task ValidateAsync(ValidateAuthenticatorCodeRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ValidateAuthenticatorCodeRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

