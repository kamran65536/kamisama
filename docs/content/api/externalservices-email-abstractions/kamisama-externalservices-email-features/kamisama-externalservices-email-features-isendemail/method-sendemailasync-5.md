# SendEmailAsync

[Back to ISendEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs#L5)

Type: `KamiSama.ExternalServices.Email.Features.ISendEmail`

Kind: `Method`

## Description

Runs the `SendEmailAsync` operation on `ISendEmail`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `SendEmailRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

