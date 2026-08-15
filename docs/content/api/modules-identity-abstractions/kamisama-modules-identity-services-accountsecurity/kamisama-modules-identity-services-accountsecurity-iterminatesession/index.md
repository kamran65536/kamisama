# ITerminateSession

<a id="iterminatesession"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L24)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Revokes one session belonging to a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ITerminateSession
```

## Example

```csharp
await terminateSession.TerminateAsync(userId, sessionId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [TerminateAsync](method-terminateasync-31.md) | Terminates the selected session. Use it with the surrounding package APIs when composing application code. |

