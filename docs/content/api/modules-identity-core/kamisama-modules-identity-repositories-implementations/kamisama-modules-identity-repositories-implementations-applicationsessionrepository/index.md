# ApplicationSessionRepository

<a id="applicationsessionrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationSessionRepository.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationSessionRepository.cs#L6)

Namespace: `KamiSama.Modules.Identity.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `ApplicationSessionRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class ApplicationSessionRepository(KamiSamaIdentityDbContext context) : IApplicationSessionRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationSessionRepository.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ApplicationSessionRepository(KamiSamaIdentityDbContext context) : IApplicationSessionRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `KamiSamaIdentityDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-9.md) | Runs the `AddAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [FindActiveBySessionKeyAsync](method-findactivebysessionkeyasync-15.md) | Runs the `FindActiveBySessionKeyAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [ListActiveByUserIdAsync](method-listactivebyuseridasync-19.md) | Runs the `ListActiveByUserIdAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeAllExceptAsync](method-revokeallexceptasync-35.md) | Runs the `RevokeAllExceptAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeAsync](method-revokeasync-25.md) | Runs the `RevokeAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeBySessionKeyAsync](method-revokebysessionkeyasync-52.md) | Runs the `RevokeBySessionKeyAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [TouchAsync](method-touchasync-60.md) | Runs the `TouchAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |

