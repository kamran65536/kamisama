---
last-checked-utc: 2026-08-14T22:31:50Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.ExternalServices.Email.Features.SendEmailRequest
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Provider-neutral contract and request model for sending email through KamiSama external-service implementations.
Reference it from callers and providers that need to exchange recipient, subject, body, and HTML-format data without depending on SMTP or another transport.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Abstractions --version 10.0.0
```

Inject `ISendEmail` into application code and pass a `SendEmailRequest` containing the recipient, subject, body, and content format. Set `IsHtml` only when the body contains HTML; provider packages implement the transport-specific delivery behavior.

## Example decisions

`ISendEmail` has a class-level calling example. `SendEmailRequest` is a simple data record and does not require a class-level example.
