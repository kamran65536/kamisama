---
last-checked-utc: 2026-08-14T22:38:25Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.ExternalServices.Sms.Features.SendSmsRequest
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Provider-neutral SMS sending contracts and request data. This package contains abstractions only and does not send messages or register an SMS provider.

## How to use

Version `10.0.0` is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.

```shell
dotnet add package KamiSama.ExternalServices.Sms.Abstractions --version 10.0.0
```

Inject an `ISendSms` implementation supplied by a provider package and pass a `SendSmsRequest` to `SendSmsAsync`. This package only defines the contract and request data; it does not select a provider, register one, or perform delivery.

## Example decisions

`ISendSms` and `SendSmsAsync` have calling examples. `SendSmsRequest` is a simple data record and is exempt from a separate class-level example.
