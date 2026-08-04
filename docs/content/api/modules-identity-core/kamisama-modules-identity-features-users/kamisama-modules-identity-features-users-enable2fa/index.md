# Enable2fa

<a id="enable2fa"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/IEnable2fa.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/IEnable2fa.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `Enable2fa` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class Enable2fa(
	ILogger<Enable2fa> logger,
	IUserManager userManager) : IEnable2fa
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/IEnable2fa.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class Enable2fa(
	ILogger<Enable2fa> logger,
	IUserManager userManager) : IEnable2fa
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `logger` | `ILogger<Enable2fa>` | `-` | The `logger` value passed to this member. |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [EnableAsync](method-enableasync-8.md) | Runs the `EnableAsync` operation on `Enable2fa`. Use it when your code needs this specific behavior from the package. |

