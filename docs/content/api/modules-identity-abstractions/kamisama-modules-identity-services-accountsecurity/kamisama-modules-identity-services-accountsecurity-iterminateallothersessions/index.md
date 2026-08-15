# ITerminateAllOtherSessions

<a id="iterminateallothersessions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L14)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Revokes every active session for a user except the implementation-defined current session. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ITerminateAllOtherSessions
```

## Example

```csharp
await terminateAllOtherSessions.TerminateAllOtherAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [TerminateAllOtherAsync](method-terminateallotherasync-20.md) | Terminates all other sessions for the specified user. Use it with the surrounding package APIs when composing application code. |

