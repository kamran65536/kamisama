# ApplicationSessionManager

<a id="applicationsessionmanager"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionManager.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionManager.cs#L6)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ApplicationSessionManager` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ApplicationSessionManager(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IApplicationSessionManager
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionManager.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationSessionManager(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IApplicationSessionManager
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
| [CreateAsync](method-createasync-11.md) | Runs the `CreateAsync` operation on `ApplicationSessionManager`. Use it when your code needs this specific behavior from the package. |
| [ValidateAsync](method-validateasync-30.md) | Runs the `ValidateAsync` operation on `ApplicationSessionManager`. Use it when your code needs this specific behavior from the package. |

