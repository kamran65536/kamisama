# IListActiveSessions

<a id="ilistactivesessions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L4)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Lists active sessions for a user; implementations define authorization and current-session detection. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListActiveSessions
```

## Example

```csharp
IReadOnlyList<ActiveSessionDto> sessions = await listActiveSessions.ListAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-10.md) | Returns active sessions for the specified user. Use it with the surrounding package APIs when composing application code. |

