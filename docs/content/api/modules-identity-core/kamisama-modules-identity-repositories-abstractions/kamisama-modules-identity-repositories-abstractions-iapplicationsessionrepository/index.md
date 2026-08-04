# IApplicationSessionRepository

<a id="iapplicationsessionrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs#L3)

Namespace: `KamiSama.Modules.Identity.Repositories.Abstractions`

Kind: `Interface`

## Description

Repository implementation or contract for `IApplicationSessionRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal interface IApplicationSessionRepository
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-5.md) | Runs the `AddAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [FindActiveBySessionKeyAsync](method-findactivebysessionkeyasync-6.md) | Runs the `FindActiveBySessionKeyAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [ListActiveByUserIdAsync](method-listactivebyuseridasync-7.md) | Runs the `ListActiveByUserIdAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeAllExceptAsync](method-revokeallexceptasync-9.md) | Runs the `RevokeAllExceptAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeAsync](method-revokeasync-8.md) | Runs the `RevokeAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [RevokeBySessionKeyAsync](method-revokebysessionkeyasync-10.md) | Runs the `RevokeBySessionKeyAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |
| [TouchAsync](method-touchasync-11.md) | Runs the `TouchAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package. |

