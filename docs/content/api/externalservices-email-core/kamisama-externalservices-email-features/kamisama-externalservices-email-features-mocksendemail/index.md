# MockSendEmail

<a id="mocksendemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/Features/MockSendEmail.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/Features/MockSendEmail.cs#L7)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Class`

## Description

Provides the `MockSendEmail` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class MockSendEmail(ILogger<MockSendEmail> logger) : ISendEmail
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/Features/MockSendEmail.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class MockSendEmail(ILogger<MockSendEmail> logger) : ISendEmail
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `logger` | `ILogger<MockSendEmail>` | `-` | The `logger` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendEmailAsync](method-sendemailasync-10.md) | Runs the `SendEmailAsync` operation on `MockSendEmail`. Use it when your code needs this specific behavior from the package. |

