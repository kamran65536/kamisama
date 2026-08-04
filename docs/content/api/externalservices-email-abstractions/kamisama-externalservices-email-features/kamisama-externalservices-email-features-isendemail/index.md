# ISendEmail

<a id="isendemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs#L3)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Interface`

## Description

Defines the contract for `ISendEmail` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface ISendEmail
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendEmailAsync](method-sendemailasync-5.md) | Runs the `SendEmailAsync` operation on `ISendEmail`. Use it when your code needs this specific behavior from the package. |

