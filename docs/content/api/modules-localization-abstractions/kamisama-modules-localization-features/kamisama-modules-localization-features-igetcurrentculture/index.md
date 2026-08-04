# IGetCurrentCulture

<a id="igetcurrentculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L7)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Interface`

## Description

Defines the contract for `IGetCurrentCulture` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IGetCurrentCulture
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentCultureAsync](method-getcurrentcultureasync-9.md) | Runs the `GetCurrentCultureAsync` operation on `IGetCurrentCulture`. Use it when your code needs this specific behavior from the package. |

