# KamiSama.Modules.ServicePlans

[Back to KamiSama.Modules.ServicePlans.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-modules-serviceplans-extendedwebapplicationbuilderextensions/index.md) | Class | Adds ServicePlans registration and post-build initialization to an extended builder. A matching provider callback is required in normal setup, and `BuildAsync` cannot provision the module schema from current provider packages. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L70) |
| [ServicePlansOptions](kamisama-modules-serviceplans-serviceplansoptions/index.md) | Class | Represents the currently empty object bound from the ServicePlans `options` section. Database and initialization settings use separate repository option types. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansOptions.cs#L7) |
| [ServicePlansWebModule](kamisama-modules-serviceplans-serviceplanswebmodule/index.md) | Class | Registers ServicePlans options, assignable scoped features and repositories, keyed provider setup, and named post-build initialization. It maps no transport or security layer, and current providers contain no ServicePlans migrations. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L23) |
