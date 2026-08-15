---
last-checked-utc: 2026-08-14T22:31:50Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

HTTP-oriented exceptions for external-service discovery failures, timeouts, and invalid provider responses.
Use them at integration boundaries to expose consistent localization keys, arguments, and 500 or 504 status codes.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Exceptions --version 10.0.0
```

Throw `CannotFindExternalServiceException` when a configured integration cannot be resolved, `ExternalServiceTimedOutException` when a provider exceeds its timeout, and `InvalidResponseForExternalServiceException` when a provider response cannot be used. KamiSama problem-details handling can then expose each exception's localization key, arguments, and HTTP status code consistently.

## Example decisions

All three public exception classes have class-level examples; no exemptions are required.
