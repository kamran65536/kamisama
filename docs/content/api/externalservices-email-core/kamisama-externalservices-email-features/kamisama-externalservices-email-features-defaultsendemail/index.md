# DefaultSendEmail

<a id="defaultsendemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/Features/DefaultSendEmail.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/Features/DefaultSendEmail.cs#L9)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Class`

## Description

Provides the `DefaultSendEmail` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class DefaultSendEmail(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<EmailDefaultsOptions> options) : ISendEmail
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/Features/DefaultSendEmail.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class DefaultSendEmail(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<EmailDefaultsOptions> options) : ISendEmail
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `loggerFactory` | `ILoggerFactory` | `-` | The `loggerFactory` value passed to this member. |
| `serviceProvider` | `IServiceProvider` | `-` | The `serviceProvider` value passed to this member. |
| `options` | `IOptions<EmailDefaultsOptions>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendEmailAsync](method-sendemailasync-12.md) | Runs the `SendEmailAsync` operation on `DefaultSendEmail`. Use it when your code needs this specific behavior from the package. |

