# ApplicationSignInManager

<a id="applicationsigninmanager"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSignInManager.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSignInManager.cs#L9)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ApplicationSignInManager` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ApplicationSignInManager(
	UserManager<ApplicationUser> userManager,
	IHttpContextAccessor contextAccessor,
	IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
	IOptions<IdentityOptions> optionsAccessor,
	ILogger<SignInManager<ApplicationUser>> logger,
	IAuthenticationSchemeProvider schemes,
	IUserConfirmation<ApplicationUser> confirmation,
	IApplicationSessionManager sessionManager)
	: SignInManager<ApplicationUser>(
		userManager,
		contextAccessor,
		claimsFactory,
		optionsAccessor,
		logger,
		schemes,
		confirmation)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSignInManager.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationSignInManager(
	UserManager<ApplicationUser> userManager,
	IHttpContextAccessor contextAccessor,
	IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
	IOptions<IdentityOptions> optionsAccessor,
	ILogger<SignInManager<ApplicationUser>> logger,
	IAuthenticationSchemeProvider schemes,
	IUserConfirmation<ApplicationUser> confirmation,
	IApplicationSessionManager sessionManager)
	: SignInManager<ApplicationUser>(
		userManager,
		contextAccessor,
		claimsFactory,
		optionsAccessor,
		logger,
		schemes,
		confirmation)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `UserManager<ApplicationUser>` | `-` | The `userManager` value passed to this member. |
| `contextAccessor` | `IHttpContextAccessor` | `-` | The `contextAccessor` value passed to this member. |
| `claimsFactory` | `IUserClaimsPrincipalFactory<ApplicationUser>` | `-` | The `claimsFactory` value passed to this member. |
| `optionsAccessor` | `IOptions<IdentityOptions>` | `-` | The `optionsAccessor` value passed to this member. |
| `logger` | `ILogger<SignInManager<ApplicationUser>>` | `-` | The `logger` value passed to this member. |
| `schemes` | `IAuthenticationSchemeProvider` | `-` | The `schemes` value passed to this member. |
| `confirmation` | `IUserConfirmation<ApplicationUser>` | `-` | The `confirmation` value passed to this member. |
| `sessionManager` | `IApplicationSessionManager` | `-` | The `sessionManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SignInWithClaimsAsync](method-signinwithclaimsasync-27.md) | Runs the `SignInWithClaimsAsync` operation on `ApplicationSignInManager`. Use it when your code needs this specific behavior from the package. |

