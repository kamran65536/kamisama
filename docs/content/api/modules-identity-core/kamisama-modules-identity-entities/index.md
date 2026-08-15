# KamiSama.Modules.Identity.Entities

[Back to KamiSama.Modules.Identity.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ApplicationRole](kamisama-modules-identity-entities-applicationrole/index.md) | Class | ASP.NET Core Identity role with a `Guid` key. Use it with the Core Identity store and role feature implementations. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L4) |
| [ApplicationSession](kamisama-modules-identity-entities-applicationsession/index.md) | Class | Persistent revocable authentication session. Validation updates and saves `LastConnection`, producing database writes on authenticated traffic. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationSession.cs#L9) |
| [ApplicationUser](kamisama-modules-identity-entities-applicationuser/index.md) | Class | ASP.NET Core Identity user with a `Guid` key and application-session navigation. Inherited Identity state stores credentials, confirmation, and lockout data. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L7) |
