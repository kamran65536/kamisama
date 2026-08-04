# ApplicationSessionCookieEvents

<a id="applicationsessioncookieevents"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionCookieEvents.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionCookieEvents.cs#L6)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ApplicationSessionCookieEvents` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ApplicationSessionCookieEvents(
	IApplicationSessionManager sessionManager) : CookieAuthenticationEvents
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionCookieEvents.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationSessionCookieEvents(
	IApplicationSessionManager sessionManager) : CookieAuthenticationEvents
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sessionManager` | `IApplicationSessionManager` | `-` | The `sessionManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidatePrincipal](method-validateprincipal-10.md) | Runs the `ValidatePrincipal` operation on `ApplicationSessionCookieEvents`. Use it when your code needs this specific behavior from the package. |

