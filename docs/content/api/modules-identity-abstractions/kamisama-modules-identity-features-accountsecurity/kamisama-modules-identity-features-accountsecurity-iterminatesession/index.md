# ITerminateSession

<a id="iterminatesession"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L13)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Interface`

## Description

Defines the contract for `ITerminateSession` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface ITerminateSession
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [TerminateAsync](method-terminateasync-15.md) | Runs the `TerminateAsync` operation on `ITerminateSession`. Use it when your code needs this specific behavior from the package. |

