# IGetAuthenticatorSecret

<a id="igetauthenticatorsecret"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L35)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Reads or creates the authenticator secret associated with a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IGetAuthenticatorSecret
```

## Example

```csharp
string secret = await getAuthenticatorSecret.GetAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetAsync](method-getasync-41.md) | Returns the user&apos;s authenticator secret. Use it with the surrounding package APIs when composing application code. |

