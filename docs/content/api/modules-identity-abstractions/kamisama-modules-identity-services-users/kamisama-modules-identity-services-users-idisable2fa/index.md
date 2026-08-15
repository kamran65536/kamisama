# IDisable2fa

<a id="idisable2fa"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L18)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Disables two-factor authentication for a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDisable2fa
```

## Example

```csharp
await disable2fa.DisableAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DisableAsync](method-disableasync-24.md) | Disables two-factor authentication for the specified user. Use it with the surrounding package APIs when composing application code. |

