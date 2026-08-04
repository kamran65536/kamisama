# ApplicationSessionJwtBearerEvents

<a id="applicationsessionjwtbearerevents"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionJwtBearerEvents.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionJwtBearerEvents.cs#L5)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ApplicationSessionJwtBearerEvents` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ApplicationSessionJwtBearerEvents(
	IApplicationSessionManager sessionManager) : JwtBearerEvents
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionJwtBearerEvents.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationSessionJwtBearerEvents(
	IApplicationSessionManager sessionManager) : JwtBearerEvents
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sessionManager` | `IApplicationSessionManager` | `-` | The `sessionManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [TokenValidated](method-tokenvalidated-9.md) | Runs the `TokenValidated` operation on `ApplicationSessionJwtBearerEvents`. Use it when your code needs this specific behavior from the package. |

