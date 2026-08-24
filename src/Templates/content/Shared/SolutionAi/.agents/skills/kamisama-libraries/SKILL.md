---
name: kamisama-libraries
description: Use when generating or reviewing code that integrates with KamiSama extension, repository, chassis, module, dependency-injection, serialization, logging, IranSystem, or testing APIs.
---

# KamiSama Libraries

1. Read the reference matching the target area.
2. Reuse the documented public API before adding a helper or ad hoc abstraction.
3. Prefer async repository and feature APIs and preserve cancellation tokens.
4. Verify package versions and exact APIs against the installed packages or source before implementation.

References:

- `references/core-and-serialization.md`
- `references/repositories.md`
- `references/chassis-and-features.md`
- `references/web-modules.md`
- `references/misc.md`

Important caveats: `ResponseCachingModule.ApplyConfigurationToAsync` currently throws `NotImplementedException`; use `SwaggerModule` rather than the internal placeholder `OpenApiModule`; current `GoneException` and `NotSupportedHttpException` status codes are 401 and 500 respectively.
