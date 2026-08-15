# KamiSama.Chassis.ProblemDetails

[Back to KamiSama.Chassis.ProblemDetails](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [IProblemDetailsDataProvider](kamisama-chassis-problemdetails-iproblemdetailsdataprovider/index.md) | Interface | Converts exceptions into ASP.NET Core problem details for the MVC exception filter. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L10) |
| [KamiSamaProblemDetailsOptions](kamisama-chassis-problemdetails-kamisamaproblemdetailsoptions/index.md) | Class | Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L11) |
| [KamiSamaProblemDetailsProvider](kamisama-chassis-problemdetails-kamisamaproblemdetailsprovider/index.md) | Class | Converts KamiSama HTTP exceptions into ASP.NET Core problem details payloads. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs#L14) |
| [ProblemDetailsExceptionFilter](kamisama-chassis-problemdetails-problemdetailsexceptionfilter/index.md) | Class | Handles MVC exceptions by converting them to problem details through the configured provider. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L12) |
| [ServiceCollectionExtension](kamisama-chassis-problemdetails-servicecollectionextension/index.md) | Class | Registers the KamiSama ProblemDetails provider and global MVC exception filter. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ServiceCollectionExtension.cs#L11) |
