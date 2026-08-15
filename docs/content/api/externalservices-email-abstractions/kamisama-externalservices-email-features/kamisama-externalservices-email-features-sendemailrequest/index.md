# SendEmailRequest

<a id="sendemailrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs#L11)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Record`

## Description

Contains the provider-neutral data required to send one email message. Use it with `ISendEmail.SendEmailAsync` regardless of the underlying email transport.

## Declaration

```csharp
public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs#L11)

Contains the provider-neutral data required to send one email message. Use it with `ISendEmail.SendEmailAsync` regardless of the underlying email transport.

```csharp
public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `RecipientAddress` | `string` | `-` | The destination email address. |
| `Subject` | `string` | `-` | The email subject line. |
| `Body` | `string` | `-` | The plain-text or HTML message body. |
| `IsHtml` | `bool` | `-` | Whether &lt;paramref name=&quot;Body&quot;/&gt; contains HTML content. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

