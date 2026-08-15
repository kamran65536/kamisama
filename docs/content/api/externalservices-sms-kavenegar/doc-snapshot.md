---
last-checked-utc: 2026-08-14T22:45:41Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Scoped Kavenegar SMS provider registration and configuration for KamiSama SMS services. The current sender contains a known inverted validation defect that rejects a configured API key before sending.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the required root-version command for repository documentation; when installing from NuGet, replace it with a version that is actually available.

```shell
dotnet add package KamiSama.ExternalServices.Sms.Kavenegar --version 10.0.0
```

Select the exact `kavenegar` key in the core `sms` setting. Add both `AddSmsCoreServicesModule` and `AddKavenegarSmsServiceModule`, then call the extended builder's `Build` or `BuildAsync` so module service registration runs. The core package provides the scoped unkeyed dispatcher; this package registers a scoped keyed `ISendSms` provider.

Bind `sender-phone-number` and `api-key` from the Kavenegar section. Keep the API key in a secret store or protected configuration and out of source, examples, logs, and errors.

**Known runtime defect:** `KavenegarSendSms` throws `InvalidOperationHttpException` when `KavenegarSmsOptions.IsValid()` returns `true`. A configured API key is rejected before any send, while a missing key proceeds into provider construction. Successful delivery is not claimed until the inverted condition is fixed. The Kavenegar SDK send is synchronous, `SendSmsAsync` returns `Task.CompletedTask`, and the cancellation token is ignored, so cancellation cannot stop an in-progress send.

## Example decisions

Both public classes have full-name-matched class-level examples. The examples show protected secret loading and module build requirements without claiming successful delivery.
