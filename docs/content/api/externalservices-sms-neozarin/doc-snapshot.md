---
last-checked-utc: 2026-08-14T22:45:41Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Scoped NeoZarin HTTP SMS provider registration and configuration for KamiSama SMS services. It requires KamiSama RestSharp and `AddHttpClient`, and the current sender contains a known inverted validation defect.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the required root-version command for repository documentation; when installing from NuGet, replace it with a version that is actually available.

```shell
dotnet add package KamiSama.ExternalServices.Sms.NeoZarin --version 10.0.0
```

Call `AddHttpClient` and `AddKamiSamaRestSharp` before adding the SMS modules. Select the exact `neo-zarin` key in the core `sms` setting, add both `AddSmsCoreServicesModule` and `AddNeoZarinSmsModule`, then call the extended builder's `Build` or `BuildAsync`. The core package provides the scoped unkeyed dispatcher; this package registers a scoped keyed `ISendSms` provider.

Bind `base-url`, `username`, `password`, `sms-api-path`, `sms-sender-number`, and `sms-api-key`. Store the username, password, and SMS API key in protected configuration, never source control. The built-in base URL is plain HTTP; configure an HTTPS provider URL when available.

**Known runtime defect:** `NeoSendSms` throws `InvalidOperationHttpException` when `NeoZarinSmsOptions.IsValidForSms()` returns `true`. Complete settings are rejected before an HTTP request, while incomplete settings proceed toward request construction. Successful delivery is not claimed until the inverted condition is fixed. If request execution is reached, the cancellation token is forwarded to RestSharp.

## Example decisions

Both public classes have full-name-matched class-level examples. The examples include required HTTP registrations, protected secret loading, and module build requirements without claiming successful delivery.
