# KamiSama.Modules.Identity

[Back to KamiSama.Modules.Identity.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [DtoMappings](kamisama-modules-identity-dtomappings/index.md) | Class | Maps Identity users and roles to abstraction DTOs. User mapping requires roles to be loaded separately and calculates enabled state from lockout fields. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/DtoMappings.cs#L8) |
| [ExtendedWebApplicationBuilderExtensions](kamisama-modules-identity-extendedwebapplicationbuilderextensions/index.md) | Class | Adds the Identity Core web module to an extended builder. Its provider callback must register one installed Identity database provider before startup context resolution. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L125) |
| [KamiSamaIdentityWebModule](kamisama-modules-identity-kamisamaidentitywebmodule/index.md) | Class | Registers Identity, authentication, scanned feature implementations, and a multi-provider DbContext, then performs configured database initialization after build. A concrete provider callback and correctly ordered authentication middleware are required in practice. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L26) |
