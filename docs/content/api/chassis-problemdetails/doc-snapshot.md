---
last-checked-utc: 2026-08-14T23:07:51Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Chassis.ProblemDetails.ServiceCollectionExtension
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

ASP.NET Core ProblemDetails integration for converting KamiSama HTTP exceptions into standardized API error responses.

## How to use

```shell
dotnet add package KamiSama.Chassis.ProblemDetails --version 10.0.0
```

Call `AddExceptionFilterForProblemDetails` after `AddControllers`. The default setup registers scoped provider and filter services, enables resource localization, and installs the filter globally. A custom `IProblemDetailsDataProvider` factory must configure its own localizer and argument-localization behavior.

The filter handles every MVC exception. Non-HTTP exceptions become status 500 payloads whose title exposes the original exception message. The current filter does not explicitly set `ObjectResult.StatusCode`, and the default provider does not copy `HttpExceptionBase.ExtendedProperties` into the payload; these runtime limitations remain unchanged.

## Example decisions

`IProblemDetailsDataProvider`, `KamiSamaProblemDetailsOptions`, `KamiSamaProblemDetailsProvider`, and `ProblemDetailsExceptionFilter` have full-name-matched class examples. Static `ServiceCollectionExtension` is exempt because the package How-to and filter example demonstrate its only registration method.
