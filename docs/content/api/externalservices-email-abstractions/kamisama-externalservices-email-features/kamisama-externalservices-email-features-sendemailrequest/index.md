# SendEmailRequest

<a id="sendemailrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs#L3)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Record`

## Description

Provides the `SendEmailRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `RecipientAddress` | `string` | `-` | The `RecipientAddress` value passed to this member. |
| `Subject` | `string` | `-` | The `Subject` value passed to this member. |
| `Body` | `string` | `-` | The `Body` value passed to this member. |
| `IsHtml` | `bool` | `-` | The `IsHtml` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

