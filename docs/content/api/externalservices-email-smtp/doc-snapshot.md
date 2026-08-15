---
last-checked-utc: 2026-08-14T22:38:25Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

SMTP transport registration and configuration for KamiSama email services. The current implementation contains a known inverted validation defect that rejects complete SMTP settings before sending.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Smtp --version 10.0.0
```

Add the SMTP module with the configuration section containing its connection, credential, TLS, and sender settings.

**Known runtime defect:** the internal SMTP sender throws `InvalidOperationHttpException` when `SmtpOptions.IsValid()` returns `true`. Complete settings are rejected before any SMTP send is attempted, while incomplete settings continue and fail later. Successful sending is not claimed; the runtime condition must be corrected in a future code change before relying on this provider.

## Example decisions

Both public classes have class-level configuration or registration examples, with no exemptions. The examples intentionally do not claim or demonstrate successful sending while the inverted validation defect exists.
