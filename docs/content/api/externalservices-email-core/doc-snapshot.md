---
last-checked-utc: 2026-08-14T22:38:25Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Provider-selecting email registration for ASP.NET Core applications, including default-provider options and a built-in mock provider. Use it to route `ISendEmail` calls to keyed transport implementations.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Core --version 10.0.0
```

Add the core module with the configuration section containing the `email` provider key. The default `mock` implementation logs method entry and performs no delivery; add a transport package and select its registered key for real delivery. A missing keyed provider causes `CannotFindExternalServiceException`.

## Example decisions

All three public classes have class-level examples. The `ConfigureServices` and `ApplyConfigurationToAsync` lifecycle members are explained by their summaries and class-level module example; separate standalone examples are unnecessary.
