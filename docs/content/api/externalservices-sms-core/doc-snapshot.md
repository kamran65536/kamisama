---
last-checked-utc: 2026-08-14T22:45:41Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Provider-selecting SMS registration for ASP.NET Core applications, including default-provider options and a scoped mock provider. Use it to route unkeyed `ISendSms` calls to scoped keyed providers.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the required root-version command for repository documentation; when installing from NuGet, replace it with a version that is actually available.

```shell
dotnet add package KamiSama.ExternalServices.Sms.Core --version 10.0.0
```

Add `AddSmsCoreServicesModule` with a section containing the `sms` key, then call the extended builder's `Build` or `BuildAsync`; adding a module alone does not run `ConfigureServices`. Exact provider keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`.

The core module registers a scoped unkeyed `ISendSms` dispatcher and a scoped keyed `mock` provider. Application services normally inject unkeyed `ISendSms`; the dispatcher resolves the selected scoped keyed provider. The mock only logs method entry and performs no delivery.

**Runtime caveats:** an unknown key actually causes `GetRequiredKeyedService` to throw `InvalidOperationException`; the source's later `CannotFindExternalServiceException` path is unreachable. The dispatcher returns the provider task without awaiting it, so it wraps only non-HTTP exceptions thrown synchronously during provider invocation. Exceptions that fault the returned task are not logged or wrapped, and cancellation behavior is provider-specific.

## Example decisions

All three public classes have full-name-matched class-level registration or configuration examples. Direct-call examples for the `ConfigureServices` and `ApplyConfigurationToAsync` lifecycle members are explicitly unnecessary because the module example demonstrates the supported `Build`/`BuildAsync` lifecycle.
