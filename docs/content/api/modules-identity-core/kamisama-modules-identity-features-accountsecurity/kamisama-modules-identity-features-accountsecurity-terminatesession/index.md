# TerminateSession

<a id="terminatesession"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/TerminateSession.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/TerminateSession.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `TerminateSession` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class TerminateSession(IApplicationSessionRepository sessionRepository) : ITerminateSession
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/TerminateSession.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class TerminateSession(IApplicationSessionRepository sessionRepository) : ITerminateSession
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sessionRepository` | `IApplicationSessionRepository` | `-` | The `sessionRepository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [TerminateAsync](method-terminateasync-6.md) | Runs the `TerminateAsync` operation on `TerminateSession`. Use it when your code needs this specific behavior from the package. |

