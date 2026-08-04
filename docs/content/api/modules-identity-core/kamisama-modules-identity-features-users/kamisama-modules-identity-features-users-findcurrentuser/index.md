# FindCurrentUser

<a id="findcurrentuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/FindCurrentUser.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/FindCurrentUser.cs#L7)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `FindCurrentUser` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class FindCurrentUser(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	IHttpContextAccessor httpContextAccessor) : IFindCurrentUser
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/FindCurrentUser.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class FindCurrentUser(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	IHttpContextAccessor httpContextAccessor) : IFindCurrentUser
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |
| `sessionManager` | `IApplicationSessionManager` | `-` | The `sessionManager` value passed to this member. |
| `httpContextAccessor` | `IHttpContextAccessor` | `-` | The `httpContextAccessor` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentUserAsync](method-getcurrentuserasync-19.md) | Runs the `GetCurrentUserAsync` operation on `FindCurrentUser`. Use it when your code needs this specific behavior from the package. |

