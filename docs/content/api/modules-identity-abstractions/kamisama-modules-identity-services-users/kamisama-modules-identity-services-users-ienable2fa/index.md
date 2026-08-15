# IEnable2fa

<a id="ienable2fa"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L27)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Enables two-factor authentication after validating an authenticator code. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IEnable2fa
```

## Example

```csharp
await enable2fa.EnableAsync(new Enable2faRequest(userId, authenticatorCode), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [EnableAsync](method-enableasync-33.md) | Enables two-factor authentication using the supplied setup verification. Use it with the surrounding package APIs when composing application code. |

