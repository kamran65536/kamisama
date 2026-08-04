# ListActiveSessions

<a id="listactivesessions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ListActiveSessions.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ListActiveSessions.cs#L6)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ListActiveSessions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ListActiveSessions(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IListActiveSessions
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ListActiveSessions.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ListActiveSessions(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IListActiveSessions
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sessionRepository` | `IApplicationSessionRepository` | `-` | The `sessionRepository` value passed to this member. |
| `httpContextAccessor` | `IHttpContextAccessor` | `-` | The `httpContextAccessor` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-11.md) | Runs the `ListAsync` operation on `ListActiveSessions`. Use it when your code needs this specific behavior from the package. |

